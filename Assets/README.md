# Assets Folder Structure

**Purpose:** Organized hierarchy for Ludo.ai generated assets and Unity prefabs.

---

## 📁 Folder Hierarchy

```
Assets/
├── Characters/
│   ├── Sprites/          # Raw character PNGs from Ludo.ai
│   │   ├── cat.png
│   │   ├── dog.png
│   │   └── ... (13 animals)
│   └── Prefabs/           # Unity prefabs with animations/scripts
│       ├── Cat.prefab
│       └── ...
│
├── Cart/
│   ├── Sprites/           # Cart PNG from Ludo.ai
│   │   └── cart.png
│   └── Prefabs/           # Cart prefab with wheel animation
│       └── Cart.prefab
│
├── Environments/
│   ├── CrossTheme/        # Reusable assets across multiple themes
│   │   ├── Boulders/      # 4 boulder variations
│   │   ├── Cliffs/        # 3 cliff variations
│   │   ├── Clouds/        # 4 cloud variations
│   │   └── Rocks/         # 3 generic rock variations
│   │
│   ├── Forest/
│   │   ├── Far/           # Distant elements (mountains, giant trees, etc.)
│   │   ├── Mid/           # Trees, structures, large objects
│   │   └── Near/          # Bushes, small rocks, flowers, grass
│   │
│   ├── Mountain/
│   │   ├── Far/
│   │   ├── Mid/
│   │   └── Near/
│   │
│   ├── Desert/
│   │   ├── Far/
│   │   ├── Mid/
│   │   └── Near/
│   │
│   ├── Underwater/
│   │   ├── Far/
│   │   ├── Mid/
│   │   └── Near/
│   │
│   ├── Ocean/
│   │   ├── Far/
│   │   ├── Mid/
│   │   └── Near/
│   │
│   └── Prefabs/           # Environment object prefabs with parallax settings
│       ├── Forest/
│       ├── Mountain/
│       └── ...
│
├── Platforms/
│   ├── Patterns/          # Tileable surface textures
│   │   ├── Forest/        # 5 forest patterns (mossy stone, wood+vines, etc.)
│   │   ├── Mountain/      # 5 mountain patterns
│   │   ├── Desert/        # 5 desert patterns
│   │   ├── Underwater/    # 5 underwater patterns
│   │   └── Ocean/         # 5 ocean patterns
│   │
│   ├── Curved/            # Vector-style curved platform shapes
│   │   ├── Forest/        # 5 curved platforms (arch, log bridge, etc.)
│   │   ├── Mountain/      # 5 curved platforms
│   │   ├── Desert/        # 5 curved platforms
│   │   ├── Underwater/    # 5 curved platforms
│   │   └── Ocean/         # 5 curved platforms
│   │
│   └── Prefabs/           # Platform prefabs with colliders
│       ├── Straight/      # Standard platforms using patterns
│       └── Curved/        # Curved platform prefabs
│
└── UI/
    ├── Icons/
    │   ├── Characters/    # 13 animal select icons + cart icon
    │   └── Misc/          # Coin, heart, star icons
    │
    ├── Buttons/           # Button sprites (9-slice ready)
    ├── Panels/            # Panel/frame sprites (9-slice ready)
    │
    ├── Borders/           # Platform border patterns (tileable)
    │   ├── Forest/        # 3 forest border variations
    │   ├── Mountain/
    │   ├── Desert/
    │   ├── Underwater/
    │   └── Ocean/
    │
    ├── Screens/           # Welcome/title screen backgrounds
    │   ├── desktop_welcome.png
    │   └── mobile_welcome.png
    │
    └── Prefabs/           # UI prefabs for Unity Canvas
```

---

## 🎮 Prefab Structure

### Character Prefab Hierarchy
```
Cat (Prefab)
├── Sprite Renderer (cat.png)
├── Animator Controller
└── Character Script
```

### Cart + Character Composite
```
PlayerCart (Prefab)
├── Cart
│   ├── Sprite Renderer (cart.png)
│   └── Wheel Animator
├── CharacterMount (empty transform for positioning)
│   └── [Character prefab instantiated here]
└── Cart Controller Script
```

### Environment Object Prefab
```
ForestTree_Oak (Prefab)
├── Sprite Renderer (forest_mid_oak.png)
├── Parallax Layer Component (speed: 0.5)
└── Sort Order: Mid Layer
```

### Platform Prefab (Straight)
```
Platform_Forest_Stone (Prefab)
├── Visual
│   ├── Left Cap (sprite)
│   ├── Middle (tiled pattern sprite)
│   └── Right Cap (sprite)
├── Box Collider 2D
└── Platform Effector 2D (optional, for one-way)
```

### Platform Prefab (Curved)
```
Platform_Forest_Arch (Prefab)
├── Sprite Renderer (curved platform sprite)
├── Polygon Collider 2D (fitted to curve)
└── Platform Script
```

---

## 📐 Platform "Shelf" Design

For platforms where part represents background (shelf effect):

```
┌─────────────────────────────────────┐
│  Background portion (decorative)    │  ← Visual only, no collision
├─────────────────────────────────────┤
│  Walkable surface (shelf top)       │  ← Collider here
└─────────────────────────────────────┘
```

**Implementation:**
```
ShelfPlatform (Prefab)
├── Background (Sprite Renderer, no collider)
│   └── Decorative back portion of platform
├── Surface (Sprite Renderer + Collider)
│   └── Walkable top edge
└── Platform Controller
```

---

## 🏷️ Naming Conventions

### Sprites (from Ludo.ai)
```
[theme]_[layer]_[object].png

Examples:
forest_far_mountain_range.png
forest_mid_oak_tree.png
forest_near_bush_leafy.png
mountain_mid_snow_drift.png
crosstheme_boulder_large.png
```

### Patterns
```
pattern_[theme]_[material].png

Examples:
pattern_forest_mossy_stone.png
pattern_desert_sandstone.png
```

### Curved Platforms
```
curved_[theme]_[shape].png

Examples:
curved_forest_stone_arch.png
curved_mountain_ice_slide.png
```

### Prefabs
```
[Category]_[Theme]_[Name].prefab

Examples:
Env_Forest_OakTree.prefab
Platform_Mountain_IceSlide.prefab
Char_Cat.prefab
```

---

## 🔢 Parallax Layer Settings

| Layer | Parallax Speed | Sorting Layer | Use For |
|-------|---------------|---------------|---------|
| Far | 0.2x | Background-Far | Mountains, sky elements, distant silhouettes |
| Mid | 0.5x | Background-Mid | Trees, structures, large objects |
| Near | 0.8x | Background-Near | Bushes, rocks, foreground details |
| Platform | 1.0x | Gameplay | All platforms (moves with camera) |
| Character | 1.0x | Player | Cart and characters |
| UI | Fixed | UI | All interface elements |

---

## 📥 Import Workflow

### 1. Import Sprites from Ludo.ai
1. Download PNG from Ludo.ai
2. Rename following naming convention
3. Place in appropriate folder based on theme/layer
4. In Unity, set:
   - Texture Type: Sprite (2D and UI)
   - Sprite Mode: Single
   - Filter Mode: Bilinear
   - Compression: None (for quality) or Low Quality (for size)

### 2. For Tileable Patterns
1. Place in `Platforms/Patterns/[Theme]/`
2. In Unity, set:
   - Wrap Mode: Repeat
   - Mesh Type: Full Rect

### 3. Create Prefabs
1. Drag sprite to scene
2. Add necessary components (colliders, scripts)
3. Drag from Hierarchy to appropriate Prefabs folder
4. Delete scene instance

---

## 🔗 Related Documentation

- `/ludo/background-assets-prompts.md` - Environment asset prompts
- `/ludo/platform-patterns-prompts.md` - Platform pattern prompts
- `/ludo/ui-assets-guide.md` - UI element prompts
- `/ludo/ludo-ai-project-brief.md` - Master style guide

---

**Created:** 2026-01-20
**For:** Adventures of the World - Unity 2022.3 LTS
