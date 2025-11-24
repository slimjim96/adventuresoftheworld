# Procedural Level Generation System

## Overview

Adventures of the World uses a **hybrid level design approach**:
- **Static Levels**: Hand-crafted tutorial and key story levels (Levels 1-5)
- **Dynamic Levels**: Procedurally generated levels using pattern chunks (Levels 6+)

This system ensures both consistent teaching moments and infinite replayability.

---

## Design Philosophy

### Goals
1. **Variation**: Each playthrough feels fresh and different
2. **Playability**: Generated levels are always beatable
3. **Fairness**: Difficulty increases gradually, not randomly
4. **Performance**: Fast generation with object pooling
5. **Consistency**: Seeded generation allows replaying same levels

### Core Principles
- ✅ Pattern chunks over pure algorithms (safer, faster)
- ✅ Gradual difficulty scaling (not sudden spikes)
- ✅ Defined finish line (not endless)
- ✅ Seeded randomization (reproducible levels)
- ✅ Camera-based spawning (efficient memory usage)

---

## Level Types

### Static Levels (1-5)
**Purpose**: Tutorial and introduction
- Level 1: Basic jumping (Forest)
- Level 2: Gaps and timing (Forest)
- Level 3: Obstacles introduced (Forest)
- Level 4-5: Combining mechanics (Mountain)

**Characteristics:**
- Hand-placed platforms and obstacles
- Carefully designed difficulty curve
- Teach specific mechanics
- Same every playthrough

### Dynamic Levels (6-15)
**Purpose**: Replayability and variety
- Generated from pattern chunks
- Seeded randomization
- Difficulty scales with level number
- Same seed = same level layout

**Characteristics:**
- 500-1000 meter length (varies by level)
- Finish line at end
- Procedurally placed platforms, obstacles, coins
- Dynamic background decorations

---

## Pattern Chunk System

### What is a Pattern Chunk?

A **pattern chunk** is a pre-designed segment of platforms and obstacles that is:
- **Safe**: Guaranteed to be beatable
- **Tested**: Manually verified in Unity
- **Modular**: Can connect to other chunks seamlessly
- **Varied**: Different difficulty levels

**Think of them as "Lego blocks" that snap together to make a level.**

---

### Chunk Categories

#### 1. **Easy Chunks** (Tutorial, Early Game)
- Short gaps (1-2 units)
- Long platforms (5-8 units)
- Few obstacles
- Many coins
- **Use in**: Levels 1-5, first 200m of dynamic levels

**Examples:**
- Flat run (no gaps, just running)
- Single small gap
- Low barrier to jump over
- Gentle coin trail

#### 2. **Medium Chunks** (Mid-Game)
- Medium gaps (2-3 units)
- Medium platforms (3-5 units)
- Moderate obstacles
- Strategic coin placement
- **Use in**: Levels 6-10, 200-500m sections

**Examples:**
- Two gaps in sequence
- Platform with spike hazard
- Moving platform
- Risk/reward coin placement (above hazards)

#### 3. **Hard Chunks** (Late Game)
- Large gaps (3-4 units)
- Short platforms (2-4 units)
- Dense obstacles
- Challenging coin placement
- **Use in**: Levels 11-15, 500m+ sections

**Examples:**
- Multiple consecutive jumps
- Narrow platforms with hazards
- Moving obstacles
- Precision timing required

#### 4. **Decoration Chunks** (All Levels)
- Background elements only
- Trees, rocks, clouds, bushes
- Environment-specific
- No collision
- **Use in**: Parallax layers

---

### Chunk Structure

Each chunk is a **prefab** containing:

```
ChunkPrefab
├── Platforms (child objects)
│   ├── Platform1 (BoxCollider2D)
│   ├── Platform2
│   └── Platform3
├── Obstacles (child objects)
│   ├── Spike1
│   └── Barrier1
├── Collectibles (child objects)
│   ├── Coin1
│   ├── Coin2
│   └── Coin3
└── ChunkData (script)
    ├── Length: 10 units
    ├── Difficulty: Medium
    ├── Entry Height: 0
    └── Exit Height: 0
```

**Key Properties:**
- **Length**: How far the chunk extends (X-axis)
- **Difficulty**: Easy/Medium/Hard rating
- **Entry/Exit Height**: Y-position for connecting chunks
- **Theme**: Which environment it belongs to

---

## Level Generation Algorithm

### Overview

```
1. Initialize level with seed
2. Determine total length (based on level number)
3. Select starting chunk (always easy)
4. Loop until length reached:
   a. Choose next chunk (based on difficulty curve)
   b. Position chunk at end of previous chunk
   c. Spawn chunk and activate
5. Place finish line at end
6. Activate background decoration spawning
```

### Detailed Flow

#### Step 1: Level Initialization
```csharp
LevelSeed = GetSeedForLevel(levelNumber);
Random.InitState(LevelSeed);

TotalLength = GetLevelLength(levelNumber);
CurrentDistance = 0;
```

**Level Length by Number:**
- Levels 1-5: 300-500m (static, hand-designed)
- Levels 6-8: 500m
- Levels 9-11: 700m
- Levels 12-14: 1000m
- Level 15: 1200m (finale)

#### Step 2: Difficulty Curve Calculation
```csharp
// Determine what % through the level we are
float progressPercent = CurrentDistance / TotalLength;

// Map to difficulty tier
if (progressPercent < 0.3f)
    difficulty = "Easy";
else if (progressPercent < 0.7f)
    difficulty = "Medium";
else
    difficulty = "Hard";
```

#### Step 3: Chunk Selection
```csharp
List<ChunkData> availableChunks = GetChunksForDifficulty(difficulty);

// Filter by theme
availableChunks = FilterByTheme(availableChunks, currentTheme);

// Filter by connection (exit/entry heights match)
availableChunks = FilterByHeight(availableChunks, lastChunkExitHeight);

// Random selection from filtered list
ChunkData selectedChunk = availableChunks[Random.Range(0, availableChunks.Count)];
```

#### Step 4: Chunk Spawning
```csharp
Vector3 spawnPosition = new Vector3(CurrentDistance, lastChunkExitHeight, 0);
GameObject chunk = Instantiate(selectedChunk.Prefab, spawnPosition, Quaternion.identity);

CurrentDistance += selectedChunk.Length;
lastChunkExitHeight = selectedChunk.ExitHeight;
```

#### Step 5: Finish Line Placement
```csharp
Vector3 finishPosition = new Vector3(TotalLength, 0, 0);
GameObject finishLine = Instantiate(FinishLinePrefab, finishPosition, Quaternion.identity);
```

---

## Seeded Generation

### How Seeding Works

**Seed Formula:**
```csharp
int seed = levelNumber * 1000 + worldNumber * 100 + playerID;
```

**Example:**
- Level 7, World 2, Player 1: `7000 + 200 + 1 = 7201`
- Same level always uses same seed = same layout

**Benefits:**
- Players can replay levels with same layout
- Share level seeds with friends
- Speedrunning becomes viable
- Bug reproduction easier

**Randomness Sources:**
- Chunk selection order
- Coin placement within chunks
- Background decoration timing
- Obstacle variations

**Non-Random Elements:**
- Difficulty curve (always same)
- Total length (always same)
- Chunk connection rules (always valid)

---

## Difficulty Scaling

### Scaling Parameters

All difficulty factors increase gradually:

| Distance | Speed | Gap Size | Platform Length | Obstacle Density |
|----------|-------|----------|-----------------|------------------|
| 0-200m   | 5 u/s | 1-2 units | 5-8 units      | Low (10%)       |
| 200-400m | 6 u/s | 2-3 units | 4-6 units      | Medium (25%)    |
| 400-600m | 7 u/s | 2.5-3.5 units | 3-5 units   | High (40%)      |
| 600m+    | 8 u/s | 3-4 units | 2-4 units      | Very High (60%) |

### Cart Speed Increase
```csharp
float baseSpeed = 5f;
float speedMultiplier = 1f + (distance / 500f) * 0.2f;
float currentSpeed = baseSpeed * speedMultiplier;
cartController.SetSpeed(currentSpeed);
```

**Example:**
- 0m: 5.0 units/second
- 250m: 6.0 units/second
- 500m: 7.0 units/second
- 750m: 8.0 units/second

### Chunk Selection Weighting

As player progresses, chunk difficulty shifts:

**Early Game (0-30% of level):**
- Easy: 70% chance
- Medium: 25% chance
- Hard: 5% chance

**Mid Game (30-70% of level):**
- Easy: 20% chance
- Medium: 60% chance
- Hard: 20% chance

**Late Game (70-100% of level):**
- Easy: 10% chance
- Medium: 30% chance
- Hard: 60% chance

---

## Background Decoration System

### Dynamic Spawning

Background objects spawn based on **camera position**:

```csharp
if (cameraX + spawnDistance > lastDecorationX + decorationSpacing)
{
    SpawnDecoration();
    lastDecorationX = cameraX + spawnDistance;
}
```

**Parameters:**
- `spawnDistance`: 30 units ahead of camera
- `decorationSpacing`: 5-15 units (random)
- Destroy when 20 units behind camera

### Parallax Layers

**3 Layers of background:**

1. **Far Background** (slowest)
   - Mountains, distant objects
   - Scroll speed: 0.2x camera speed
   - Large, infrequent objects

2. **Mid Background**
   - Trees, large rocks, buildings
   - Scroll speed: 0.5x camera speed
   - Medium-sized objects

3. **Near Background**
   - Bushes, small rocks, foreground grass
   - Scroll speed: 0.8x camera speed
   - Small, frequent objects

### Environment-Specific Decorations

**Forest:**
- Far: Hills, distant trees
- Mid: Large trees, logs
- Near: Bushes, flowers, mushrooms

**Mountain:**
- Far: Snow peaks, clouds
- Mid: Rock formations, boulders
- Near: Small rocks, snow patches

**Desert:**
- Far: Sand dunes, ruins
- Mid: Cacti, rocks, tumbleweeds
- Near: Small cacti, sand details

**Underwater:**
- Far: Coral reefs, shipwrecks
- Mid: Seaweed, large fish
- Near: Small fish, bubbles, plants

**Ocean:**
- Far: Islands, boats
- Mid: Waves, seagulls
- Near: Floating debris, small waves

---

## Chunk Library

### How Many Chunks Needed?

**Minimum Viable:**
- Easy: 10 chunks
- Medium: 10 chunks
- Hard: 10 chunks
- **Total: 30 chunks**

**Recommended:**
- Easy: 15 chunks
- Medium: 20 chunks
- Hard: 15 chunks
- **Total: 50 chunks**

**With this library:**
- 30 chunks = 27,000 possible combinations for 3-chunk sequences
- 50 chunks = 125,000 possible combinations
- Enough variety for hundreds of unique levels

### Chunk Naming Convention

```
Chunk_[Difficulty]_[Type]_[Number]

Examples:
- Chunk_Easy_FlatRun_01
- Chunk_Medium_TwoGaps_03
- Chunk_Hard_MovingPlatform_02
```

---

## Object Pooling

For performance, use object pooling:

### Pooled Objects
- Platform chunks
- Coins
- Obstacles
- Background decorations
- Particle effects

### Pool Sizes
- Chunks: 5-10 active at once
- Coins: 50-100
- Decorations: 20-30 per layer
- Obstacles: 20-30

### Lifecycle
1. Spawn ahead of camera
2. Active in camera view
3. Deactivate behind camera
4. Return to pool
5. Reuse for new spawn

---

## Implementation Plan (Month 2)

### Week 5: Foundation
- [ ] Create ChunkData ScriptableObject
- [ ] Build ChunkSpawner manager
- [ ] Implement seeded random generation
- [ ] Test with 3 basic chunks

### Week 6: Chunk Library
- [ ] Design and build 10 easy chunks
- [ ] Design and build 10 medium chunks
- [ ] Design and build 10 hard chunks
- [ ] Test all chunks individually

### Week 7: Generation Logic
- [ ] Implement difficulty curve algorithm
- [ ] Create chunk selection system
- [ ] Build level length calculation
- [ ] Add finish line spawning

### Week 8: Polish & Background
- [ ] Background decoration spawning
- [ ] Parallax scrolling system
- [ ] Object pooling implementation
- [ ] Performance optimization

---

## Technical Architecture

### Scripts Required

```
Scripts/Level/
├── ProceduralLevelGenerator.cs
├── ChunkData.cs (ScriptableObject)
├── ChunkSpawner.cs
├── DifficultyScaler.cs
├── BackgroundSpawner.cs
├── DecorationPooler.cs
└── LevelSeedManager.cs
```

### Data Structures

**ChunkData.cs:**
```csharp
[CreateAssetMenu(fileName = "Chunk", menuName = "Level/Chunk")]
public class ChunkData : ScriptableObject
{
    public GameObject prefab;
    public float length;
    public DifficultyLevel difficulty;
    public EnvironmentTheme theme;
    public float entryHeight;
    public float exitHeight;
}
```

**ProceduralLevelGenerator.cs:**
```csharp
public class ProceduralLevelGenerator : MonoBehaviour
{
    public int levelNumber;
    public EnvironmentTheme theme;
    public List<ChunkData> chunkLibrary;

    private int seed;
    private float totalLength;
    private float currentDistance;

    public void GenerateLevel();
    private ChunkData SelectNextChunk();
    private void SpawnChunk(ChunkData chunk);
    private void SpawnFinishLine();
}
```

---

## Testing & Validation

### Chunk Testing Checklist

For each chunk:
- [ ] Is it beatable at min/max cart speeds?
- [ ] Do entry/exit heights make sense?
- [ ] Are gaps within jump distance?
- [ ] Are coins collectible without dying?
- [ ] Does it connect smoothly to other chunks?

### Level Testing

- [ ] Generate 10 levels with same seed (should be identical)
- [ ] Generate 10 levels with different seeds (should vary)
- [ ] Complete full level without touching controls (should be possible for easy sections)
- [ ] Verify finish line appears at correct distance
- [ ] Check performance (60 FPS maintained)

---

## Future Enhancements (Post-Launch)

### Potential Additions

- **Daily Challenge**: Shared seed for all players
- **Custom Seeds**: Players enter seed codes
- **Level Editor**: Create and share custom chunks
- **Special Events**: Holiday-themed chunks
- **Difficulty Modifiers**: Hard mode, speed run mode
- **Chunk Workshop**: Community-created chunks

---

## Summary

**Key Features:**
✅ Pattern chunk-based generation (safe, fast)
✅ Seeded randomization (reproducible)
✅ Gradual difficulty scaling (all parameters)
✅ Defined finish line (level-based length)
✅ Dynamic background decorations
✅ Object pooling (performance)

**Month 2 Priority**: Foundation for replayability

---

*Last Updated: 2025-11-23*
*Implementation Target: Month 2 (Weeks 5-8)*
