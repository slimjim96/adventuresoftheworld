# Parallax Background Setup - Adventures of the World

**Week 5-6 Implementation Guide** - Creating layered parallax backgrounds with dynamic decoration spawning.

---

## Prerequisites

- Week 3-4 complete (core mechanics)
- Procedural generation system implemented
- Understanding of sorting layers and camera depth
- Basic understanding of parallax scrolling concept

---

## What is Parallax Scrolling?

**Parallax scrolling** creates depth illusion by moving background layers at different speeds:
- **Far background** (mountains, sky): Moves slowest (0.2x camera speed)
- **Mid background** (trees, clouds): Moves medium (0.5x camera speed)
- **Near background** (bushes, rocks): Moves fastest (0.8x camera speed)

---

## Part 1: Sorting Layer Setup

### Step 1: Create Sorting Layers

1. **Edit** → **Project Settings** → **Tags and Layers**
2. Expand **Sorting Layers**
3. Click **+** to add new layers in this order:

```
0. Default
1. Background_Far      (Layer ID: 1)
2. Background_Mid      (Layer ID: 2)
3. Background_Near     (Layer ID: 3)
4. Ground              (Layer ID: 4)
5. Obstacles           (Layer ID: 5)
6. Player              (Layer ID: 6)
7. Collectibles        (Layer ID: 7)
8. UI                  (Layer ID: 8)
```

**Why this order?**
- Lower numbers render first (behind)
- Higher numbers render last (in front)
- Background_Far renders behind everything
- UI renders in front of everything

---

## Part 2: Parallax Layer Controller

### Step 1: Create ParallaxLayer Script

Create `Assets/Scripts/Environment/ParallaxLayer.cs`:

```csharp
using UnityEngine;

namespace AdventuresOfTheWorld.Environment
{
    /// <summary>
    /// Controls parallax scrolling for a single background layer.
    /// Moves layer at a fraction of the camera's speed to create depth effect.
    /// </summary>
    public class ParallaxLayer : MonoBehaviour
    {
        [Header("Parallax Settings")]
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private float parallaxMultiplier = 0.5f;
        [Tooltip("0 = static, 1 = moves with camera, 0.5 = half camera speed")]

        [Header("Vertical Parallax (Optional)")]
        [SerializeField] private bool enableVerticalParallax = false;
        [SerializeField] private float verticalMultiplier = 0.3f;

        [Header("Auto-Repeat (Infinite Scroll)")]
        [SerializeField] private bool enableAutoRepeat = false;
        [SerializeField] private float repeatWidth = 20f;

        private Vector3 _lastCameraPosition;
        private Vector3 _startPosition;

        private void Start()
        {
            // Auto-find camera if not assigned
            if (cameraTransform == null)
            {
                Camera mainCamera = Camera.main;
                if (mainCamera != null)
                {
                    cameraTransform = mainCamera.transform;
                }
                else
                {
                    Debug.LogError("ParallaxLayer: No camera assigned and Camera.main not found!");
                }
            }

            _lastCameraPosition = cameraTransform.position;
            _startPosition = transform.position;
        }

        private void LateUpdate()
        {
            if (cameraTransform == null)
                return;

            // Calculate camera movement since last frame
            Vector3 deltaMovement = cameraTransform.position - _lastCameraPosition;

            // Apply parallax effect
            float parallaxX = deltaMovement.x * parallaxMultiplier;
            float parallaxY = enableVerticalParallax ? deltaMovement.y * verticalMultiplier : 0f;

            transform.position += new Vector3(parallaxX, parallaxY, 0f);

            // Auto-repeat for infinite scrolling
            if (enableAutoRepeat)
            {
                float distanceFromStart = transform.position.x - _startPosition.x;
                if (Mathf.Abs(distanceFromStart) >= repeatWidth)
                {
                    transform.position = new Vector3(
                        _startPosition.x,
                        transform.position.y,
                        transform.position.z
                    );
                }
            }

            _lastCameraPosition = cameraTransform.position;
        }
    }
}
```

---

## Part 3: Background Layer Setup in Unity

### Step 1: Create Background Container

1. **In Hierarchy**, right-click → **Create Empty**
2. Rename to `BackgroundLayers`
3. **Position**: (0, 0, 0)
4. This will hold all background layers

### Step 2: Create Far Background Layer

1. **Right-click BackgroundLayers** → **Create Empty**
2. Rename to `Layer_Far`
3. **Position**: (0, 0, 10) ← Z position keeps it behind everything
4. **Add Component** → `ParallaxLayer`
5. Configure:
   - Camera Transform: Drag Main Camera
   - Parallax Multiplier: **0.2**
   - Enable Auto Repeat: Unchecked (for now)

### Step 3: Create Mid Background Layer

1. **Right-click BackgroundLayers** → **Create Empty**
2. Rename to `Layer_Mid`
3. **Position**: (0, 0, 5)
4. **Add Component** → `ParallaxLayer`
5. Configure:
   - Parallax Multiplier: **0.5**

### Step 4: Create Near Background Layer

1. **Right-click BackgroundLayers** → **Create Empty**
2. Rename to `Layer_Near`
3. **Position**: (0, 0, 1)
4. **Add Component** → `ParallaxLayer`
5. Configure:
   - Parallax Multiplier: **0.8**

---

## Part 4: Adding Placeholder Background Elements

### Step 1: Create Sky Gradient (Far Layer)

1. **Right-click Layer_Far** → **2D Object** → **Sprites** → **Square**
2. Rename to `Sky`
3. Configure:
   - **Transform**:
     - Position: (0, 3, 0)
     - Scale: (50, 15, 1) ← Very wide
   - **Sprite Renderer**:
     - Color: Sky Blue (#87CEEB)
     - Sorting Layer: **Background_Far**
     - Order in Layer: 0

**For gradient effect:**
- Add multiple overlapping squares with different blue shades
- Or use a Material with gradient shader (advanced)

### Step 2: Create Far Mountains (Far Layer)

1. **Right-click Layer_Far** → **2D Object** → **Sprites** → **Triangle**
2. Rename to `Mountain_Far_01`
3. Configure:
   - **Position**: (5, -2, 0)
   - **Scale**: (8, 6, 1)
   - **Sprite Renderer**:
     - Color: Dark Blue-Gray (#4A5A6A)
     - Sorting Layer: **Background_Far**
     - Order in Layer: 1
4. **Duplicate** 5-10 times with varying positions and scales
5. **Parent all** to `Layer_Far`

### Step 3: Create Mid Trees (Mid Layer)

1. **Right-click Layer_Mid** → **2D Object** → **Sprites** → **Triangle** (for now)
2. Rename to `Tree_Mid_01`
3. Configure:
   - **Position**: (3, -1, 0)
   - **Scale**: (2, 4, 1)
   - **Sprite Renderer**:
     - Color: Dark Green (#228B22)
     - Sorting Layer: **Background_Mid**
     - Order in Layer: 0
4. **Duplicate** several times
5. Vary positions: X spacing 5-10 units apart

### Step 4: Create Near Bushes (Near Layer)

1. **Right-click Layer_Near** → **2D Object** → **Sprites** → **Circle**
2. Rename to `Bush_Near_01`
3. Configure:
   - **Position**: (2, -0.5, 0)
   - **Scale**: (1.5, 1.2, 1)
   - **Sprite Renderer**:
     - Color: Bright Green (#32CD32)
     - Sorting Layer: **Background_Near**
     - Order in Layer: 0
4. **Duplicate** and scatter along level

---

## Part 5: Testing Parallax Effect

### Test 1: Visual Parallax Check

1. **Play** the scene
2. Observe as cart moves forward:
   - ✅ Far mountains move SLOWLY
   - ✅ Mid trees move MEDIUM speed
   - ✅ Near bushes move FAST
   - ✅ Creates depth illusion

### Test 2: Adjust Multipliers

Experiment with different values:
- Far: 0.1 - 0.3 (very slow)
- Mid: 0.4 - 0.6 (medium)
- Near: 0.7 - 0.9 (almost camera speed)

**Too subtle?** Increase multiplier differences
**Too exaggerated?** Reduce multiplier differences

---

## Part 6: Dynamic Decoration Spawning

### Step 1: Create DecorationData ScriptableObject

*(This was already designed in `asset-metadata-system.md`)*

Create `Assets/Scripts/Environment/DecorationData.cs`:

```csharp
using UnityEngine;

namespace AdventuresOfTheWorld.Environment
{
    /// <summary>
    /// Defines metadata for environmental decoration assets.
    /// Used by BackgroundSpawner for procedural decoration placement.
    /// </summary>
    [CreateAssetMenu(fileName = "Decoration_New", menuName = "Environment/Decoration")]
    public class DecorationData : ScriptableObject
    {
        [Header("Visual")]
        public GameObject prefab;
        public Sprite sprite;

        [Header("Classification")]
        public EnvironmentTheme theme = EnvironmentTheme.Forest;
        public ParallaxLayer layer = ParallaxLayer.Mid;
        public DecorationCategory category = DecorationCategory.Tree;

        [Header("Spawning Rules")]
        public Vector2 sizeRange = new Vector2(1f, 3f);
        [Range(0f, 10f)]
        public float spawnWeight = 1f;
        public float minSpacing = 5f;
        public bool canFlipHorizontal = true;
        public bool canRandomRotate = false;

        [Header("Visual Variety")]
        public Color[] colorVariations;
        [Range(0f, 1f)]
        public float minAlpha = 0.8f;
        [Range(0f, 1f)]
        public float maxAlpha = 1f;

        [Header("Animation (Optional)")]
        public bool enableSwaying = false;
        public float swaySpeed = 1f;
        public float swayAmount = 0.1f;
    }

    public enum EnvironmentTheme
    {
        Forest,
        Mountain,
        Desert,
        Underwater,
        Ocean
    }

    public enum ParallaxLayer
    {
        Far,
        Mid,
        Near
    }

    public enum DecorationCategory
    {
        // Far Layer
        Mountain,
        Cloud,
        Sun,
        Moon,

        // Mid Layer
        Tree,
        Hill,
        Building,

        // Near Layer
        Bush,
        Rock,
        Grass,
        Flower,
        Crystal
    }
}
```

### Step 2: Create BackgroundSpawner Script

Create `Assets/Scripts/Environment/BackgroundSpawner.cs`:

```csharp
using UnityEngine;
using System.Collections.Generic;

namespace AdventuresOfTheWorld.Environment
{
    /// <summary>
    /// Spawns environmental decorations along parallax background layers.
    /// Works with LevelGenerator to populate backgrounds procedurally.
    /// </summary>
    public class BackgroundSpawner : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform farLayerContainer;
        [SerializeField] private Transform midLayerContainer;
        [SerializeField] private Transform nearLayerContainer;

        [Header("Decoration Sets")]
        [SerializeField] private List<DecorationData> farDecorations;
        [SerializeField] private List<DecorationData> midDecorations;
        [SerializeField] private List<DecorationData> nearDecorations;

        [Header("Spawn Settings")]
        [SerializeField] private float levelLength = 100f;
        [SerializeField] private EnvironmentTheme currentTheme = EnvironmentTheme.Forest;
        [SerializeField] private bool useRandomSeed = true;
        [SerializeField] private int manualSeed = 12345;

        [Header("Density")]
        [SerializeField] private int farDecorationCount = 5;
        [SerializeField] private int midDecorationCount = 15;
        [SerializeField] private int nearDecorationCount = 25;

        private System.Random _rng;

        public void SpawnDecorations()
        {
            // Initialize RNG
            int seed = useRandomSeed ? Random.Range(0, 1000000) : manualSeed;
            _rng = new System.Random(seed);

            // Clear existing decorations
            ClearDecorations();

            // Spawn on each layer
            SpawnLayer(farDecorations, farLayerContainer, farDecorationCount, "Background_Far");
            SpawnLayer(midDecorations, midLayerContainer, midDecorationCount, "Background_Mid");
            SpawnLayer(nearDecorations, nearLayerContainer, nearDecorationCount, "Background_Near");

            Debug.Log($"Background decorations spawned for theme: {currentTheme}");
        }

        private void SpawnLayer(List<DecorationData> decorations, Transform container, int count, string sortingLayer)
        {
            if (decorations == null || decorations.Count == 0)
            {
                Debug.LogWarning($"No decorations defined for {sortingLayer}");
                return;
            }

            // Filter by theme
            List<DecorationData> themeDecorations = decorations.FindAll(d => d.theme == currentTheme);
            if (themeDecorations.Count == 0)
            {
                Debug.LogWarning($"No decorations for theme {currentTheme} on {sortingLayer}");
                return;
            }

            float lastXPosition = 0f;

            for (int i = 0; i < count; i++)
            {
                // Select random decoration
                DecorationData decoration = GetWeightedRandomDecoration(themeDecorations);
                if (decoration == null || decoration.prefab == null)
                    continue;

                // Calculate position
                float xPos = lastXPosition + decoration.minSpacing + (float)_rng.NextDouble() * 5f;
                float yPos = GetRandomYPosition(decoration);

                // Clamp to level bounds
                if (xPos > levelLength)
                    break;

                // Spawn decoration
                Vector3 position = new Vector3(xPos, yPos, 0f);
                GameObject spawned = Instantiate(decoration.prefab, position, Quaternion.identity, container);
                spawned.name = $"{decoration.category}_{i}";

                // Apply variations
                ApplyVisualVariations(spawned, decoration);

                // Set sorting layer
                SpriteRenderer sr = spawned.GetComponent<SpriteRenderer>();
                if (sr != null)
                {
                    sr.sortingLayerName = sortingLayer;
                }

                lastXPosition = xPos;
            }
        }

        private DecorationData GetWeightedRandomDecoration(List<DecorationData> decorations)
        {
            float totalWeight = 0f;
            foreach (var dec in decorations)
            {
                totalWeight += dec.spawnWeight;
            }

            float random = (float)_rng.NextDouble() * totalWeight;
            float cumulative = 0f;

            foreach (var dec in decorations)
            {
                cumulative += dec.spawnWeight;
                if (random <= cumulative)
                    return dec;
            }

            return decorations[decorations.Count - 1];
        }

        private float GetRandomYPosition(DecorationData decoration)
        {
            // Different Y ranges for different layers
            switch (decoration.layer)
            {
                case ParallaxLayer.Far:
                    return (float)_rng.NextDouble() * 4f - 2f; // -2 to 2

                case ParallaxLayer.Mid:
                    return (float)_rng.NextDouble() * 3f - 1f; // -1 to 2

                case ParallaxLayer.Near:
                    return (float)_rng.NextDouble() * 2f - 0.5f; // -0.5 to 1.5

                default:
                    return 0f;
            }
        }

        private void ApplyVisualVariations(GameObject obj, DecorationData decoration)
        {
            // Random scale
            float randomScale = Random.Range(decoration.sizeRange.x, decoration.sizeRange.y);
            obj.transform.localScale *= randomScale;

            // Random flip
            if (decoration.canFlipHorizontal && _rng.Next(0, 2) == 0)
            {
                Vector3 scale = obj.transform.localScale;
                scale.x *= -1;
                obj.transform.localScale = scale;
            }

            // Random color variation
            SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
            if (sr != null && decoration.colorVariations != null && decoration.colorVariations.Length > 0)
            {
                Color randomColor = decoration.colorVariations[_rng.Next(0, decoration.colorVariations.Length)];
                float randomAlpha = Mathf.Lerp(decoration.minAlpha, decoration.maxAlpha, (float)_rng.NextDouble());
                randomColor.a = randomAlpha;
                sr.color = randomColor;
            }
        }

        private void ClearDecorations()
        {
            ClearContainer(farLayerContainer);
            ClearContainer(midLayerContainer);
            ClearContainer(nearLayerContainer);
        }

        private void ClearContainer(Transform container)
        {
            if (container == null)
                return;

            while (container.childCount > 0)
            {
                DestroyImmediate(container.GetChild(0).gameObject);
            }
        }
    }
}
```

---

## Part 7: Unity Setup for Dynamic Spawning

### Step 1: Add BackgroundSpawner Component

1. **Select BackgroundLayers** GameObject
2. **Add Component** → `BackgroundSpawner`

### Step 2: Assign Layer Containers

- Far Layer Container: Drag `Layer_Far`
- Mid Layer Container: Drag `Layer_Mid`
- Near Layer Container: Drag `Layer_Near`

### Step 3: Create Placeholder DecorationData Assets

1. Create folder: `Assets/Data/Decorations/Forest/`
2. **Right-click** → **Create** → **Environment** → **Decoration**
3. Create test decorations:
   - `Deco_Forest_Tree_Mid_01`
   - `Deco_Forest_Bush_Near_01`
   - `Deco_Forest_Mountain_Far_01`

### Step 4: Populate Decoration Lists

Select `BackgroundLayers` → `BackgroundSpawner` component:
- **Far Decorations**: Drag far decoration assets
- **Mid Decorations**: Drag mid decoration assets
- **Near Decorations**: Drag near decoration assets

### Step 5: Configure Spawn Settings

- Level Length: 100 (match your procedural level length)
- Current Theme: Forest
- Use Random Seed: Checked
- Far Decoration Count: 5
- Mid Decoration Count: 15
- Near Decoration Count: 25

---

## Part 8: Editor Tool for Background Spawning

Create `Assets/Editor/BackgroundSpawnerEditor.cs`:

```csharp
#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using AdventuresOfTheWorld.Environment;

[CustomEditor(typeof(BackgroundSpawner))]
public class BackgroundSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        BackgroundSpawner spawner = (BackgroundSpawner)target;

        GUILayout.Space(10);

        if (GUILayout.Button("Spawn Decorations", GUILayout.Height(30)))
        {
            spawner.SpawnDecorations();
        }
    }
}
#endif
```

**Usage:**
- Select `BackgroundLayers`
- Click **"Spawn Decorations"** button
- Background elements populate across all layers

---

## Part 9: Integration with Procedural Generation

### Option 1: Spawn After Level Generation

In `LevelGenerator.cs`, add:

```csharp
[Header("Background")]
[SerializeField] private BackgroundSpawner backgroundSpawner;

public void GenerateLevel()
{
    // ... existing chunk generation code ...

    // Spawn background decorations after level
    if (backgroundSpawner != null)
    {
        backgroundSpawner.SpawnDecorations();
    }
}
```

### Option 2: Synchronized Seeding

Use same seed for both level and background:

```csharp
// In LevelGenerator
backgroundSpawner.manualSeed = _currentSeed;
backgroundSpawner.useRandomSeed = false;
backgroundSpawner.SpawnDecorations();
```

---

## Part 10: Troubleshooting

### Parallax not working?

- Check camera reference is assigned
- Verify ParallaxLayer script on each layer
- Ensure LateUpdate is running (check in Profiler)

### Background elements not spawning?

- Check DecorationData assets assigned to spawner
- Verify prefabs assigned in DecorationData
- Check theme matches (Forest decorations won't spawn in Desert theme)

### Background too cluttered?

- Reduce decoration counts
- Increase minSpacing in DecorationData
- Adjust spawn weights (lower = less frequent)

### Z-fighting (flickering)?

- Ensure each layer has different Z position
- Far: Z = 10, Mid: Z = 5, Near: Z = 1

---

## Part 11: Next Steps (Week 6+)

1. ✅ Parallax system working
2. ⏭️ Replace placeholder decorations with Ludo.ai-generated assets
3. ⏭️ Create 65+ DecorationData assets (see `ludo-ai-environmental-prompts.md`)
4. ⏭️ Add swaying animation to trees/grass
5. ⏭️ Implement infinite scrolling for endless backgrounds

---

## Summary Checklist

- [ ] Sorting layers created (Background_Far/Mid/Near)
- [ ] ParallaxLayer script created
- [ ] Three background layers set up with parallax
- [ ] Placeholder background elements added
- [ ] Parallax effect tested and working
- [ ] DecorationData ScriptableObject created
- [ ] BackgroundSpawner script created
- [ ] BackgroundSpawner configured in scene
- [ ] Test decorations spawning on all layers
- [ ] Integration with LevelGenerator tested

---

**Your parallax background system is ready!** 🌳

Now you have depth, atmosphere, and dynamic decoration spawning. In Week 6, you'll replace these placeholders with beautiful Ludo.ai-generated environmental art.

---

*Last Updated: 2025-11-23*
*Phase: Week 5-6 - Parallax Backgrounds*
*Status: ROUGH DRAFT - Test and refine as you implement*
