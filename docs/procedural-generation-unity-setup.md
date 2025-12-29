# Procedural Generation Unity Setup - Adventures of the World

**Week 5 Implementation Guide** - Building the pattern chunk system for dynamic level generation.

---

## Prerequisites

- Week 3-4 complete (core mechanics, HUD, coins, obstacles working)
- Test level created and validated
- Understanding of ScriptableObjects
- Prefabs created: Platform, Coin, Spike

---

## Part 1: ScriptableObject Foundation

### Step 1: Create ChunkData ScriptableObject

Create `Assets/Scripts/ProceduralGeneration/ChunkData.cs`:

```csharp
using UnityEngine;

namespace AdventuresOfTheWorld.ProceduralGeneration
{
    /// <summary>
    /// Defines a reusable pattern chunk for procedural level generation.
    /// Contains platforms, obstacles, and collectibles in a fixed pattern.
    /// </summary>
    [CreateAssetMenu(fileName = "Chunk_New", menuName = "Level Generation/Chunk Data")]
    public class ChunkData : ScriptableObject
    {
        [Header("Chunk Info")]
        public string chunkName;
        [TextArea(2, 4)]
        public string description;
        public EnvironmentTheme theme = EnvironmentTheme.Any;

        [Header("Difficulty")]
        [Range(1, 10)]
        public int difficultyRating = 1;
        public ChunkDifficulty difficulty = ChunkDifficulty.Easy;

        [Header("Dimensions")]
        public float chunkLength = 10f; // Width in world units
        public float chunkHeight = 8f;  // Height in world units

        [Header("Spawn Rules")]
        public float spawnWeight = 1f; // Higher = more likely to spawn
        public int minLevelNumber = 1;
        public int maxLevelNumber = 99;

        [Header("Chunk Elements")]
        public ChunkElement[] platforms;
        public ChunkElement[] obstacles;
        public ChunkElement[] coins;

        [Header("Preview")]
        public Sprite previewImage; // Optional thumbnail for editor
    }

    [System.Serializable]
    public class ChunkElement
    {
        public GameObject prefab;
        public Vector3 localPosition;  // Position relative to chunk origin
        public Vector3 localScale = Vector3.one;
        public float localRotation = 0f; // Z-axis rotation
        public bool randomFlip = false;  // Randomly flip horizontally
    }

    public enum ChunkDifficulty
    {
        Tutorial,  // No hazards, wide platforms
        Easy,      // Simple gaps, few hazards
        Medium,    // Medium gaps, some hazards
        Hard,      // Large gaps, many hazards
        Expert     // Precision jumps, dense hazards
    }

    public enum EnvironmentTheme
    {
        Any,       // Can appear in any environment
        Forest,
        Mountain,
        Desert,
        Underwater,
        Ocean
    }
}
```

### Step 2: Create Chunk Library ScriptableObject

Create `Assets/Scripts/ProceduralGeneration/ChunkLibrary.cs`:

```csharp
using UnityEngine;
using System.Collections.Generic;

namespace AdventuresOfTheWorld.ProceduralGeneration
{
    /// <summary>
    /// Container for all chunk patterns, organized by difficulty and theme.
    /// Used by LevelGenerator to select appropriate chunks.
    /// </summary>
    [CreateAssetMenu(fileName = "ChunkLibrary", menuName = "Level Generation/Chunk Library")]
    public class ChunkLibrary : ScriptableObject
    {
        [Header("All Chunks")]
        public List<ChunkData> allChunks = new List<ChunkData>();

        [Header("Start Chunks")]
        public List<ChunkData> startChunks = new List<ChunkData>();

        [Header("End Chunks")]
        public List<ChunkData> endChunks = new List<ChunkData>();

        /// <summary>
        /// Get chunks matching difficulty level
        /// </summary>
        public List<ChunkData> GetChunksByDifficulty(ChunkDifficulty difficulty)
        {
            return allChunks.FindAll(c => c.difficulty == difficulty);
        }

        /// <summary>
        /// Get chunks matching theme
        /// </summary>
        public List<ChunkData> GetChunksByTheme(EnvironmentTheme theme)
        {
            return allChunks.FindAll(c => c.theme == theme || c.theme == EnvironmentTheme.Any);
        }

        /// <summary>
        /// Get chunks matching both difficulty and theme
        /// </summary>
        public List<ChunkData> GetChunks(ChunkDifficulty difficulty, EnvironmentTheme theme)
        {
            return allChunks.FindAll(c =>
                c.difficulty == difficulty &&
                (c.theme == theme || c.theme == EnvironmentTheme.Any)
            );
        }

        /// <summary>
        /// Get random weighted chunk from list
        /// </summary>
        public ChunkData GetRandomChunk(List<ChunkData> chunks, System.Random rng)
        {
            if (chunks == null || chunks.Count == 0)
                return null;

            // Calculate total weight
            float totalWeight = 0f;
            foreach (var chunk in chunks)
            {
                totalWeight += chunk.spawnWeight;
            }

            // Pick random value
            float randomValue = (float)rng.NextDouble() * totalWeight;

            // Find chunk
            float cumulative = 0f;
            foreach (var chunk in chunks)
            {
                cumulative += chunk.spawnWeight;
                if (randomValue <= cumulative)
                {
                    return chunk;
                }
            }

            return chunks[chunks.Count - 1]; // Fallback
        }
    }
}
```

---

## Part 2: Level Generator Core

### Step 1: Create LevelGenerator Script

Create `Assets/Scripts/ProceduralGeneration/LevelGenerator.cs`:

```csharp
using UnityEngine;
using System.Collections.Generic;

namespace AdventuresOfTheWorld.ProceduralGeneration
{
    /// <summary>
    /// Generates procedural levels using pattern chunks from ChunkLibrary.
    /// Supports seeded generation for reproducible levels.
    /// </summary>
    public class LevelGenerator : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private ChunkLibrary chunkLibrary;
        [SerializeField] private Transform levelContainer;

        [Header("Level Settings")]
        [SerializeField] private int targetChunkCount = 10;
        [SerializeField] private EnvironmentTheme levelTheme = EnvironmentTheme.Forest;
        [SerializeField] private bool useRandomSeed = true;
        [SerializeField] private int manualSeed = 12345;

        [Header("Difficulty Progression")]
        [SerializeField] private bool progressDifficulty = true;
        [SerializeField] private AnimationCurve difficultyCurve;

        private System.Random _rng;
        private int _currentSeed;
        private float _currentXPosition = 0f;
        private List<GameObject> _spawnedChunks = new List<GameObject>();

        private void Start()
        {
            if (levelContainer == null)
            {
                GameObject container = new GameObject("GeneratedLevel");
                levelContainer = container.transform;
            }

            // Initialize difficulty curve if not set
            if (difficultyCurve == null || difficultyCurve.keys.Length == 0)
            {
                difficultyCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
            }
        }

        /// <summary>
        /// Generate a new procedural level
        /// </summary>
        public void GenerateLevel()
        {
            ClearLevel();

            // Initialize random number generator with seed
            _currentSeed = useRandomSeed ? Random.Range(0, 1000000) : manualSeed;
            _rng = new System.Random(_currentSeed);

            Debug.Log($"Generating level with seed: {_currentSeed}");

            _currentXPosition = 0f;

            // Spawn start chunk
            SpawnStartChunk();

            // Spawn main chunks
            for (int i = 0; i < targetChunkCount; i++)
            {
                float progress = (float)i / targetChunkCount;
                ChunkDifficulty difficulty = GetDifficultyAtProgress(progress);
                SpawnChunk(difficulty);
            }

            // Spawn end chunk (finish line)
            SpawnEndChunk();

            Debug.Log($"Level generated: {_spawnedChunks.Count} chunks, length: {_currentXPosition} units");
        }

        private void SpawnStartChunk()
        {
            if (chunkLibrary.startChunks.Count == 0)
            {
                Debug.LogWarning("No start chunks defined! Skipping start chunk.");
                return;
            }

            ChunkData startChunk = chunkLibrary.GetRandomChunk(chunkLibrary.startChunks, _rng);
            SpawnChunkAtPosition(startChunk);
        }

        private void SpawnChunk(ChunkDifficulty difficulty)
        {
            List<ChunkData> availableChunks = chunkLibrary.GetChunks(difficulty, levelTheme);

            if (availableChunks.Count == 0)
            {
                Debug.LogWarning($"No chunks found for difficulty: {difficulty}, theme: {levelTheme}");
                return;
            }

            ChunkData selectedChunk = chunkLibrary.GetRandomChunk(availableChunks, _rng);
            SpawnChunkAtPosition(selectedChunk);
        }

        private void SpawnEndChunk()
        {
            if (chunkLibrary.endChunks.Count == 0)
            {
                Debug.LogWarning("No end chunks defined! Skipping end chunk.");
                return;
            }

            ChunkData endChunk = chunkLibrary.GetRandomChunk(chunkLibrary.endChunks, _rng);
            SpawnChunkAtPosition(endChunk);
        }

        private void SpawnChunkAtPosition(ChunkData chunkData)
        {
            GameObject chunkContainer = new GameObject($"Chunk_{chunkData.chunkName}");
            chunkContainer.transform.SetParent(levelContainer);
            chunkContainer.transform.position = new Vector3(_currentXPosition, 0f, 0f);

            // Spawn platforms
            SpawnElements(chunkData.platforms, chunkContainer.transform);

            // Spawn obstacles
            SpawnElements(chunkData.obstacles, chunkContainer.transform);

            // Spawn coins
            SpawnElements(chunkData.coins, chunkContainer.transform);

            _spawnedChunks.Add(chunkContainer);
            _currentXPosition += chunkData.chunkLength;
        }

        private void SpawnElements(ChunkElement[] elements, Transform parent)
        {
            if (elements == null || elements.Length == 0)
                return;

            foreach (var element in elements)
            {
                if (element.prefab == null)
                    continue;

                Vector3 worldPos = parent.position + element.localPosition;
                Quaternion rotation = Quaternion.Euler(0f, 0f, element.localRotation);

                GameObject spawnedObject = Instantiate(element.prefab, worldPos, rotation, parent);
                spawnedObject.transform.localScale = element.localScale;

                // Random flip if enabled
                if (element.randomFlip && _rng.Next(0, 2) == 0)
                {
                    Vector3 scale = spawnedObject.transform.localScale;
                    scale.x *= -1;
                    spawnedObject.transform.localScale = scale;
                }
            }
        }

        private ChunkDifficulty GetDifficultyAtProgress(float progress)
        {
            if (!progressDifficulty)
                return ChunkDifficulty.Easy;

            float difficultyValue = difficultyCurve.Evaluate(progress);

            if (difficultyValue < 0.2f) return ChunkDifficulty.Easy;
            if (difficultyValue < 0.4f) return ChunkDifficulty.Medium;
            if (difficultyValue < 0.7f) return ChunkDifficulty.Hard;
            return ChunkDifficulty.Expert;
        }

        private void ClearLevel()
        {
            foreach (var chunk in _spawnedChunks)
            {
                if (chunk != null)
                    Destroy(chunk);
            }

            _spawnedChunks.Clear();
            _currentXPosition = 0f;
        }

        public int GetCurrentSeed() => _currentSeed;
    }
}
```

---

## Part 3: Creating Your First Chunks in Unity

### Step 1: Create ChunkLibrary Asset

1. **In Project window**, navigate to `Assets/Data/`
2. **Right-click** → **Create** → **Level Generation** → **Chunk Library**
3. Rename to `MainChunkLibrary`

### Step 2: Create Your First ChunkData Asset

1. **In Project window**, create folder `Assets/Data/Chunks/`
2. **Right-click in Chunks folder** → **Create** → **Level Generation** → **Chunk Data**
3. Rename to `Chunk_EasyGap_01`

### Step 3: Configure Easy Gap Chunk

Select `Chunk_EasyGap_01` and configure:

**Chunk Info:**
- Chunk Name: "Easy Gap"
- Description: "Simple 2-unit gap with 3 coins"
- Theme: Any

**Difficulty:**
- Difficulty Rating: 2
- Difficulty: Easy

**Dimensions:**
- Chunk Length: 10
- Chunk Height: 8

**Spawn Rules:**
- Spawn Weight: 1
- Min Level Number: 1
- Max Level Number: 5

**Platforms (Array Size: 2):**
1. Element 0:
   - Prefab: Drag `Platform` prefab
   - Local Position: (0, 0, 0)
   - Local Scale: (3, 1, 1)

2. Element 1:
   - Prefab: Drag `Platform` prefab
   - Local Position: (5, 0, 0)
   - Local Scale: (5, 1, 1)

**Coins (Array Size: 3):**
1. Element 0:
   - Prefab: Drag `Coin` prefab
   - Local Position: (3, 2, 0)

2. Element 1:
   - Prefab: Drag `Coin` prefab
   - Local Position: (3.5, 2.5, 0)

3. Element 2:
   - Prefab: Drag `Coin` prefab
   - Local Position: (4, 2, 0)

### Step 4: Create More Chunk Variations

**Chunk Templates to Create (Target: 30-50 total):**

**Start Chunks (5 chunks):**
- `Chunk_Start_Safe` - Flat safe platform, no hazards
- `Chunk_Start_Coins` - Flat with coin trail
- `Chunk_Start_Jump` - Gentle jump to warm up

**Easy Chunks (10 chunks):**
- `Chunk_EasyGap_01` - Simple 2-unit gap
- `Chunk_EasyGap_02` - 2-unit gap, different coin pattern
- `Chunk_EasyCoins_01` - Platform with coin cluster
- `Chunk_EasyStep_01` - Small step up
- etc.

**Medium Chunks (10 chunks):**
- `Chunk_MediumGap_01` - 3-unit gap
- `Chunk_MediumSpike_01` - Platform with single spike
- `Chunk_MediumJump_01` - Higher jump required
- etc.

**Hard Chunks (8 chunks):**
- `Chunk_HardGap_01` - 3.5-unit gap
- `Chunk_HardSpikes_01` - Multiple spikes in sequence
- `Chunk_HardPrecision_01` - Narrow landing
- etc.

**End Chunks (3 chunks):**
- `Chunk_End_FinishPlatform` - Wide safe platform with finish line
- `Chunk_End_CoinBonus` - Finish with bonus coins
- `Chunk_End_Victory` - Final jump to finish

---

## Part 4: Unity Editor Setup

### Step 1: Create LevelGenerator GameObject

1. **In Hierarchy**, right-click → **Create Empty**
2. Rename to `LevelGenerator`
3. **Add Component** → `LevelGenerator` script

### Step 2: Configure LevelGenerator

Select `LevelGenerator` and configure:

**References:**
- Chunk Library: Drag `MainChunkLibrary` asset
- Level Container: Leave empty (auto-creates)

**Level Settings:**
- Target Chunk Count: 10
- Level Theme: Forest
- Use Random Seed: Checked
- Manual Seed: 12345 (used when unchecked)

**Difficulty Progression:**
- Progress Difficulty: Checked
- Difficulty Curve: (Default ease-in-out created automatically)

### Step 3: Populate Chunk Library

1. **Select MainChunkLibrary** asset
2. Configure arrays:
   - **All Chunks**: Drag ALL chunk assets here
   - **Start Chunks**: Drag only start chunks
   - **End Chunks**: Drag only end chunks

---

## Part 5: Testing Procedural Generation

### Test 1: Manual Generation (Editor Button)

Create editor script: `Assets/Editor/LevelGeneratorEditor.cs`:

```csharp
#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using AdventuresOfTheWorld.ProceduralGeneration;

[CustomEditor(typeof(LevelGenerator))]
public class LevelGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelGenerator generator = (LevelGenerator)target;

        GUILayout.Space(10);

        if (GUILayout.Button("Generate Level", GUILayout.Height(30)))
        {
            generator.GenerateLevel();
        }

        if (GUILayout.Button("Clear Level", GUILayout.Height(30)))
        {
            // Clear will happen automatically when generating
            Debug.Log("Use Generate Level to create a new level (auto-clears old one)");
        }
    }
}
#endif
```

**Usage:**
1. Select `LevelGenerator` in Hierarchy
2. Click **"Generate Level"** button in Inspector
3. Level spawns in Scene view
4. Click multiple times to see different random variations

### Test 2: Seeded Generation

1. **Uncheck** "Use Random Seed"
2. Set **Manual Seed** to `12345`
3. Click **"Generate Level"**
4. Note the level pattern
5. Click again - should generate IDENTICAL level
6. Change seed to `54321` - generates different level

### Test 3: Difficulty Progression

1. **Check** "Progress Difficulty"
2. Click **Generate Level**
3. Observe chunks get harder toward the end
4. Adjust **Difficulty Curve** to change progression rate

---

## Part 6: Chunk Design Best Practices

### Design Guidelines

**Chunk Length:**
- Keep consistent (8-12 units recommended)
- Allows smooth transitions between chunks

**Element Positioning:**
- Use local positions relative to chunk origin (0, 0, 0)
- Chunk origin is left edge, ground level

**Platform Rules:**
- Always provide a landing platform
- Gaps should be jumpable (max 4 units at Easy difficulty)
- Overlap platforms slightly at chunk boundaries to prevent gaps

**Coin Placement:**
- Guide player's jump arc
- Reward risky play (high coins = higher risk)
- 3-7 coins per chunk recommended

**Obstacle Spacing:**
- Minimum 3 units between hazards
- Give player time to react
- Increase density for harder chunks

### Chunk Boundary Handling

**Problem:** Gaps or overlaps at chunk boundaries

**Solution:** Design chunks with standard entry/exit points:
- Entry (X: 0): Platform should extend from X: -0.5 to X: 2
- Exit (X: chunk length): Platform should extend to X: length + 0.5

**Example for 10-unit chunk:**
```
Entry platform:  X: -0.5 to X: 2    (2.5 units)
Exit platform:   X: 8 to X: 10.5    (2.5 units)
Middle content:  X: 2 to X: 8       (6 units)
```

---

## Part 7: Advanced Features (Optional)

### Feature 1: Chunk Variants

Create variations of same chunk:
- `Chunk_Gap_01a`, `Chunk_Gap_01b`, `Chunk_Gap_01c`
- Same difficulty, different coin patterns
- Increases variety without creating entirely new chunks

### Feature 2: Themed Chunk Sets

Organize chunks by environment:
- Forest chunks: Tree obstacles, green platforms
- Desert chunks: Cactus obstacles, sand-colored platforms
- Use `theme` field to filter during generation

### Feature 3: Dynamic Difficulty Adjustment

Modify `GetDifficultyAtProgress()` to:
- Track player death count
- Reduce difficulty if player struggling
- Increase difficulty if player doing well

---

## Part 8: Troubleshooting

### Chunks not spawning?

- Check ChunkLibrary has chunks assigned
- Verify chunk difficulty matches requested difficulty
- Check chunk theme matches level theme (or is set to "Any")

### Chunks overlapping?

- Verify chunk length matches actual chunk width
- Check platform positions don't extend beyond chunk length

### No variety in chunks?

- Create more chunk assets (target: 30-50)
- Adjust spawn weights for better distribution
- Ensure multiple chunks at each difficulty level

### Chunks don't connect smoothly?

- Design chunks with standard entry/exit platforms
- Use slight overlaps (0.5 units) at boundaries
- Test chunk transitions in isolation first

---

## Part 9: Next Steps

Once chunk system works:

1. ✅ Create 30-50 chunk variations
2. ⏭️ Add parallax background spawning (see `parallax-setup-guide.md`)
3. ⏭️ Integrate with level progression system
4. ⏭️ Replace placeholder graphics with Ludo.ai assets (Week 6)

---

## Summary Checklist

- [ ] ChunkData ScriptableObject created
- [ ] ChunkLibrary ScriptableObject created
- [ ] LevelGenerator script implemented
- [ ] At least 5 test chunks created
- [ ] ChunkLibrary populated with chunks
- [ ] LevelGenerator configured in scene
- [ ] Test generation working (random seed)
- [ ] Seeded generation working (reproducible)
- [ ] Difficulty progression tested
- [ ] Chunk boundaries connect smoothly

---

**Your procedural generation foundation is ready!** 🎮

*Last Updated: 2025-11-23*
*Phase: Week 5 - Procedural Generation*
*Status: ROUGH DRAFT - Test and refine as you implement*
