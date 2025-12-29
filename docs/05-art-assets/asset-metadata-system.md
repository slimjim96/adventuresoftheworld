# Environmental Asset Metadata System

## Overview

Every environmental decoration asset needs metadata so the procedural generation system knows **how** and **when** to spawn it.

---

## Asset Data Structure

### **DecorationData ScriptableObject**

Each environmental asset has a ScriptableObject with:

```csharp
[CreateAssetMenu(fileName = "Decoration", menuName = "Environment/Decoration")]
public class DecorationData : ScriptableObject
{
    [Header("Visual")]
    public GameObject prefab;           // The actual sprite prefab
    public Sprite sprite;               // The sprite asset

    [Header("Classification")]
    public EnvironmentTheme theme;      // Forest, Mountain, Desert, etc.
    public ParallaxLayer layer;         // Far, Mid, Near background
    public DecorationCategory category; // Tree, Rock, Cloud, etc.

    [Header("Spawning Rules")]
    public Vector2 sizeRange;           // Min/max scale variation
    public float spawnWeight = 1f;      // Probability weight
    public float minSpacing = 5f;       // Min distance between spawns
    public bool canFlipHorizontal = true; // Mirror for variety

    [Header("Visual Variety")]
    public Color[] colorVariations;     // Tint variations
    public float minAlpha = 0.8f;       // Transparency range
    public float maxAlpha = 1f;
}
```

---

## Asset Categories

### **By Environment Theme**

```csharp
public enum EnvironmentTheme
{
    Forest,
    Mountain,
    Desert,
    Underwater,
    Ocean,
    Universal  // Works in any environment
}
```

### **By Parallax Layer**

```csharp
public enum ParallaxLayer
{
    FarBackground,   // Slowest scroll (0.2x), largest elements
    MidBackground,   // Medium scroll (0.5x), medium elements
    NearBackground,  // Fast scroll (0.8x), small elements
    Foreground       // Same as camera (1.0x), grass/details
}
```

### **By Decoration Type**

```csharp
public enum DecorationCategory
{
    // Vegetation
    Tree,
    Bush,
    Grass,
    Flower,

    // Terrain
    Rock,
    Boulder,
    Hill,

    // Sky
    Cloud,
    Bird,

    // Water (Underwater/Ocean)
    Seaweed,
    Coral,
    Fish,
    Wave,

    // Structures
    Ruins,
    Building,
    Wreckage,

    // Effects
    Particle,
    Ambient
}
```

---

## Spawning Rules by Layer

### **Far Background (0.2x scroll speed)**

**Characteristics:**
- Large scale (3-10 units)
- Low detail (silhouettes okay)
- Wide spacing (20-50 units apart)
- Low spawn frequency

**Assets Needed:**
- **Forest**: Distant tree lines, hills
- **Mountain**: Far peaks, large rock formations
- **Desert**: Sand dunes, distant ruins
- **Underwater**: Coral reefs in distance, shipwrecks
- **Ocean**: Islands, large boats

**Metadata Example:**
```
Theme: Forest
Layer: FarBackground
Category: Hill
Size Range: (5, 10)
Spawn Weight: 0.3
Min Spacing: 40
```

---

### **Mid Background (0.5x scroll speed)**

**Characteristics:**
- Medium scale (2-5 units)
- Moderate detail
- Medium spacing (10-20 units)
- Main visual layer

**Assets Needed:**
- **Forest**: Trees, large bushes, logs
- **Mountain**: Boulders, rock outcrops
- **Desert**: Cacti, rock formations, pillars
- **Underwater**: Large seaweed, coral clusters
- **Ocean**: Waves, boats, debris

**Metadata Example:**
```
Theme: Forest
Layer: MidBackground
Category: Tree
Size Range: (2, 4)
Spawn Weight: 1.0
Min Spacing: 8
Can Flip: true
Color Variations: [Green1, Green2, Green3]
```

---

### **Near Background (0.8x scroll speed)**

**Characteristics:**
- Small scale (0.5-2 units)
- High detail
- Close spacing (5-10 units)
- Frequent spawning

**Assets Needed:**
- **Forest**: Bushes, flowers, small rocks, grass clumps
- **Mountain**: Small rocks, snow patches, ice
- **Desert**: Small cacti, tumbleweed, sand details
- **Underwater**: Small plants, bubbles, tiny fish
- **Ocean**: Small waves, foam, floating objects

**Metadata Example:**
```
Theme: Desert
Layer: NearBackground
Category: Bush (small cactus)
Size Range: (0.5, 1.2)
Spawn Weight: 1.5
Min Spacing: 3
Can Flip: true
```

---

### **Foreground (1.0x scroll speed)**

**Characteristics:**
- Very small (0.2-1 unit)
- Decorative details
- Parallax same as ground
- Optional layer

**Assets Needed:**
- Grass blades
- Small flowers
- Pebbles
- Sparkles/particles

---

## Asset Naming Convention

### **File Naming Format:**

```
[Theme]_[Layer]_[Category]_[Variant]_[Size].png

Examples:
Forest_Mid_Tree_Oak_Large.png
Forest_Mid_Tree_Oak_Small.png
Forest_Mid_Tree_Pine_Medium.png
Mountain_Far_Peak_Snowy_01.png
Desert_Near_Cactus_Small_01.png
Ocean_Mid_Wave_Crest_01.png
```

### **Prefab Naming:**

```
Deco_[Theme]_[Category]_[Variant]

Examples:
Deco_Forest_Tree_Oak
Deco_Mountain_Rock_Large
Deco_Desert_Cactus_01
```

---

## Required Asset Counts Per Environment

### **Minimum Viable (Per Theme):**

**Far Background:** 2-3 large elements
**Mid Background:** 5-7 medium elements
**Near Background:** 3-5 small elements

**Total per environment: 10-15 unique assets**
**Across 5 environments: 50-75 total environmental assets**

### **Recommended (Per Theme):**

**Far Background:** 3-5 large elements
**Mid Background:** 8-12 medium elements
**Near Background:** 5-8 small elements

**Total per environment: 16-25 unique assets**
**Across 5 environments: 80-125 total environmental assets**

---

## Variety Strategies (Credit-Efficient)

### **1. Generate Base Asset, Create Variations**

**Generate once in Ludo.ai:**
- Forest_Mid_Tree_01

**Create variations in Unity/Photoshop:**
- Flip horizontally (mirror)
- Tint with different greens
- Scale up/down
- Adjust alpha (transparency)

**Result:** 1 credit → 4-5 variations

### **2. Modular Elements**

**Generate separate parts:**
- Tree trunk (generic)
- Tree foliage (variations)

**Combine in Unity:**
- Mix and match trunks + foliage
- More variety from fewer assets

### **3. Procedural Color Variation**

**In DecorationData:**
```csharp
colorVariations = [
    #228B22 (Forest Green),
    #006400 (Dark Green),
    #32CD32 (Lime Green)
];
```

**Spawner applies random tint:**
- 1 asset → 3 color variants

---

## Ludo.ai Prompt Strategy

### **Generate in Sets (Batch Consistency)**

**Bad Approach:**
- Generate tree 1 today
- Generate tree 2 next week
- Different styles, inconsistent ❌

**Good Approach:**
- Generate all Forest Mid-Background trees in one session ✅
- Same prompt, same seed influences
- Consistent style across variations

### **Master Prompt Template for Decorations:**

```
[OBJECT TYPE] for 2D game environment, flat vector art style,
simple clean design, [ENVIRONMENT] theme, [COLOR PALETTE],
thick black outlines, NO depth, NO 3D, completely flat,
side view for parallax scrolling, transparent background,
cartoon style matching mobile game aesthetic, [SIZE] element,
suitable for [LAYER] background layer, family-friendly design
```

### **Example - Forest Tree (Mid Background):**

```
Oak tree for 2D game environment, flat vector art style,
simple clean design, forest theme, vibrant green leaves with brown trunk,
thick black outlines, NO depth, NO 3D, completely flat,
side view for parallax scrolling, transparent background,
cartoon style matching mobile game aesthetic, medium-sized element,
suitable for mid-background layer, family-friendly design
```

### **Variables to Adjust:**

| Variable | Options |
|----------|---------|
| **Object Type** | oak tree, cactus, rock formation, wave |
| **Environment** | forest, mountain, desert, underwater, ocean |
| **Color Palette** | vibrant green, sandy yellow, ocean blue, etc. |
| **Size** | small, medium, large |
| **Layer** | far-background, mid-background, near-background |

---

## Asset Import Settings (Unity)

### **For Environmental Sprites:**

**Texture Settings:**
- **Texture Type**: Sprite (2D and UI)
- **Sprite Mode**: Single
- **Pixels Per Unit**: 100
- **Mesh Type**: Full Rect
- **Max Size**: 1024 or 2048 (based on layer)

**Far Background:**
- Max Size: 2048 (can be large)
- Compression: None or Low

**Mid Background:**
- Max Size: 1024
- Compression: Medium

**Near Background:**
- Max Size: 512
- Compression: Medium-High

---

## ScriptableObject Setup Workflow

### **1. Generate Asset in Ludo.ai**
- Export as PNG, transparent background
- Resolution: 1024x1024 or higher

### **2. Import to Unity**
- Drag to: `Assets/Sprites/Environments/[Theme]/[Layer]/`
- Apply import settings

### **3. Create ScriptableObject**
- Right-click in Project: `Create → Environment → Decoration`
- Name: `Deco_Forest_Tree_Oak`

### **4. Configure Metadata**
```
Prefab: (create from sprite)
Theme: Forest
Layer: MidBackground
Category: Tree
Size Range: (2, 4)
Spawn Weight: 1.0
Min Spacing: 8
Can Flip: true
Color Variations: [#228B22, #006400, #32CD32]
```

### **5. Add to Spawner Library**
- Add to `BackgroundSpawner` decoration pool
- Ready for procedural use!

---

## Testing Checklist

**Before accepting a generated asset:**

- [ ] **Style matches** existing assets in same theme
- [ ] **Facing correct direction** (side view for scrolling)
- [ ] **Appropriate detail level** for layer (far = simple, near = detailed)
- [ ] **Transparent background** (no white box)
- [ ] **Correct resolution** (1024x1024 minimum)
- [ ] **Clean edges** (no artifacts or blur)
- [ ] **Can be flipped** without looking wrong
- [ ] **Scales well** (test at min/max size range)
- [ ] **Imports correctly** to Unity
- [ ] **Works in procedural spawner** (test in play mode)

---

## Asset Priority Order (Credit Optimization)

### **Phase 1: Core Spawning Test (Week 5)**
Generate 1-2 assets per layer for ONE environment:
- 1 far background element
- 2 mid background elements
- 1 near background element

**Purpose:** Test prompts, verify spawning system works

**Cost:** ~4-8 credits (with iterations)

### **Phase 2: Single Environment Complete (Week 6)**
Complete Forest environment:
- 3 far background
- 6 mid background
- 4 near background

**Purpose:** Prove the full system works end-to-end

**Cost:** ~13 assets = ~26-39 credits (with 2-3 iterations each)

### **Phase 3: Remaining Environments (Weeks 7-8)**
Replicate for Mountain, Desert, Underwater, Ocean:
- 4 environments × 13 assets = 52 assets

**Purpose:** Full environmental variety

**Cost:** ~104-156 credits

### **Phase 4: Characters (Weeks 9-10)**
Generate 4 core characters (simple, static):
- Lion, Bunny, Duck, Mouse

**Cost:** ~8-16 credits

### **Total Estimated Credits: 150-220 credits** (with iterations and variations)

---

## Prompt Iteration Log Template

**Track what works/doesn't work:**

```markdown
## Asset: Forest Tree (Oak)
**Target:** Mid-background tree for forest theme

### Attempt 1
**Prompt:** "oak tree flat 2d game art transparent background"
**Result:** ❌ Too realistic, has depth/shading
**Issue:** Not flat enough, prompt too vague

### Attempt 2
**Prompt:** "oak tree for 2D game, flat vector art, NO depth, thick outlines..."
**Result:** ⚠️ Better but inconsistent with other assets
**Issue:** Slightly different style than previous trees

### Attempt 3
**Prompt:** [Same as Attempt 2 + added "side view for parallax scrolling"]
**Result:** ✅ Perfect! Consistent, flat, correct angle
**Credits Used:** 3 total
**Keeper:** Yes - saved as Deco_Forest_Tree_Oak

**Final Prompt for Reuse:**
[Copy exact working prompt here]
```

---

*Last Updated: 2025-11-23*
*Focus: Procedural generation asset needs*
