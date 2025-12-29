# Placeholder Assets Guide

This guide explains how to create simple placeholder assets in Unity to start prototyping immediately, before final art is created.

---

## Why Use Placeholders?

During early development (Month 1), you don't need polished art. Placeholders allow you to:
- ✅ Test gameplay mechanics immediately
- ✅ Focus on code and game feel
- ✅ Iterate quickly without art dependencies
- ✅ Establish proper scale and proportions
- ✅ Replace easily with final art later

**Rule of thumb:** Use simple colored shapes for prototyping, replace in Month 3 (polish phase).

---

## Creating Placeholder Sprites in Unity

### Method 1: Built-in Sprites (Fastest)

Unity has built-in sprite shapes you can use immediately.

**Available shapes:**
- Square
- Circle
- Triangle
- Hexagon
- Capsule

**How to use:**
1. **Right-click in Hierarchy → 2D Object → Sprites → [Shape]**
2. Rename the object
3. Adjust **Scale** in Transform
4. Change **Color** in Sprite Renderer

---

## Placeholder Art Specifications

### Player Cart

**Type**: Square sprite (representing cart body)

| Property | Value |
|----------|-------|
| **Shape** | Square |
| **Color** | Brown (#8B4513) or Orange (#FF8C00) |
| **Scale** | (1, 0.5, 1) - Rectangular cart shape |
| **Sorting Layer** | Default |
| **Order in Layer** | 10 (above ground) |

**Optional - Add wheels:**
1. Create 2 child Circle sprites
2. Color: Dark Gray (#3 33333)
3. Scale: (0.2, 0.2, 1)
4. Position: Left (-0.3, -0.3, 0) and Right (0.3, -0.3, 0)

---

### Animal Characters

Since characters ride IN the cart, keep them simple for now.

**Type**: Circle or simple shape

| Animal | Shape | Color | Scale |
|--------|-------|-------|-------|
| **Lion** | Circle | Orange (#FF9500) | (0.4, 0.4, 1) |
| **Bunny** | Circle | White (#FFFFFF) | (0.3, 0.4, 1) |
| **Duck** | Circle | Yellow (#FFD700) | (0.35, 0.35, 1) |
| **Mouse** | Circle | Gray (#A9A9A9) | (0.25, 0.25, 1) |

**Position**: As child of PlayerCart, offset slightly above cart (0, 0.3, 0)

---

### Ground & Platforms

**Type**: Square sprite (stretched)

| Property | Value |
|----------|-------|
| **Shape** | Square |
| **Color** | Green (#228B22) for grass<br>Brown (#8B4513) for dirt<br>Gray (#808080) for stone |
| **Scale** | (length, 1, 1) - e.g., (10, 1, 1) for 10-unit platform |
| **Sorting Layer** | Default |
| **Order in Layer** | 0 (background) |

**Variations by environment:**
- Forest: Green
- Mountain: Gray
- Desert: Sandy Yellow (#F4A460)
- Underwater: Blue (#4682B4)
- Ocean: Dark Blue (#1E90FF)

---

### Obstacles

#### Simple Barrier (Jump Over)

| Property | Value |
|----------|-------|
| **Shape** | Square |
| **Color** | Brown (#654321) or Red (#CD5C5C) |
| **Scale** | (0.5, 1.5, 1) - Tall narrow box |

#### Hazard (Deadly - Spikes)

| Property | Value |
|----------|-------|
| **Shape** | Triangle (pointed up) |
| **Color** | Red (#FF0000) or Dark Gray (#2F4F4F) |
| **Scale** | (0.5, 0.8, 1) |
| **Tip**: Rotate to point upward |

#### Gap (Missing Platform)

Simply leave empty space between ground platforms (1-3 units wide).

---

### Collectibles

#### Coin

| Property | Value |
|----------|-------|
| **Shape** | Circle |
| **Color** | Gold (#FFD700) or Yellow (#FFFF00) |
| **Scale** | (0.3, 0.3, 1) - Small |
| **Order in Layer** | 5 (above ground, below player) |

**Optional animation:**
- Add simple rotation script or Animator
- Rotate Y-axis for "spinning coin" effect

#### Extra Life (Heart)

| Property | Value |
|----------|-------|
| **Shape** | Circle (or two circles for heart shape) |
| **Color** | Red (#FF1744) or Pink (#FF69B4) |
| **Scale** | (0.4, 0.4, 1) |

---

### Background Elements

Keep backgrounds VERY simple initially.

#### Sky Background

Use **Main Camera → Background** color:
- Forest: Light Blue (#87CEEB)
- Mountain: Pale Blue (#B0C4DE)
- Desert: Orange Sunset (#FFE4B5)
- Underwater: Dark Blue (#20B2AA)
- Ocean: Sky Blue (#00BFFF)

#### Distant Background Elements (Optional)

- **Shape**: Large squares or circles
- **Color**: Muted (low saturation)
- **Position**: Far behind player (Z = 5)
- **Sorting Layer**: Background (-10)

Examples:
- Mountains: Gray triangles in background
- Trees: Green circles (forest)
- Clouds: White circles

---

## Creating Prefabs from Placeholders

Once you create a good placeholder, turn it into a prefab for reuse.

### Example: Coin Prefab

1. Create coin (Circle sprite, yellow, scale 0.3)
2. Add **CircleCollider2D**:
   - Is Trigger: ✅
3. Drag from Hierarchy to **Assets/Prefabs/Collectibles/**
4. Name it **"Coin.prefab"**
5. Delete original from scene
6. Now drag prefab into scene whenever you need a coin

**Prefab benefits:**
- Consistent sizing
- Easy to update (change prefab, all instances update)
- Can be spawned via script

---

## Quick Placeholder Creation Workflow

### For a new obstacle:

1. **Right-click Hierarchy → 2D Object → Sprites → Square**
2. Rename: "Obstacle_Barrier"
3. Set Color: Brown
4. Scale: (0.5, 1.5, 1)
5. Tag: "Obstacle"
6. Layer: "Obstacles"
7. Add **BoxCollider2D**
8. Drag to **Prefabs/Obstacles** folder
9. ✅ Done!

### For a collectible:

1. **Right-click Hierarchy → 2D Object → Sprites → Circle**
2. Rename: "Coin"
3. Set Color: Gold
4. Scale: (0.3, 0.3, 1)
5. Tag: "Coin"
6. Layer: "Collectibles"
7. Add **CircleCollider2D** (Is Trigger: ✅)
8. Add coin collection script (later)
9. Drag to **Prefabs/Collectibles** folder
10. ✅ Done!

---

## Placeholder UI Elements

### HUD Icons

**Lives (Hearts):**
- Small red circles (0.15 scale)
- Arranged horizontally in UI

**Coin Icon:**
- Small yellow circle (0.2 scale)
- Next to coin counter text

**Buttons:**
- Use Unity **UI → Button** (already has sprite)
- Change colors in **Button → Colors** section

### Text

Use **TextMeshPro** for ALL text:
- **UI → Text - TextMeshPro**
- Default font is fine for placeholder
- Clear, readable size (24-48pt)

---

## Asset Organization

Store placeholder assets separately for easy replacement later.

### Folder Structure

```
Assets/Sprites/
├── _Placeholders/          ← All temp art here
│   ├── Cart_Placeholder.png
│   ├── Coin_Placeholder.png
│   └── ...
├── Characters/             ← Final art (empty for now)
├── Environments/
└── ...
```

**Why separate?**
- Easy to find and delete placeholders later
- Won't accidentally use in final build
- Clear what needs to be replaced

---

## Placeholder Color Palette

Use this simple palette for consistency:

| Element | Color Name | Hex Code |
|---------|------------|----------|
| **Player Cart** | Brown | #8B4513 |
| **Ground (Forest)** | Green | #228B22 |
| **Ground (Mountain)** | Gray | #808080 |
| **Ground (Desert)** | Sandy | #F4A460 |
| **Hazard** | Red | #FF0000 |
| **Coin** | Gold | #FFD700 |
| **Extra Life** | Pink | #FF69B4 |
| **Sky** | Sky Blue | #87CEEB |
| **Obstacle** | Dark Brown | #654321 |

---

## Tips for Good Placeholders

### Do's ✅
- Keep it SIMPLE (basic shapes)
- Use BRIGHT colors (easy to see)
- Maintain CONSISTENT scale (1 unit ≈ 1 meter)
- Make PREFABS for reusable objects
- Use CLEAR naming (Placeholder_Cart, Temp_Coin)

### Don'ts ❌
- Don't spend too much time on placeholder art
- Don't use inconsistent sizes
- Don't use similar colors for different object types
- Don't forget to add colliders
- Don't use placeholders in final release

---

## When to Replace Placeholders

| Phase | What to Use |
|-------|-------------|
| **Month 1 (Weeks 1-4)** | 100% Placeholders - Focus on mechanics |
| **Month 2 (Weeks 5-8)** | Mix - Start adding real art for main elements |
| **Month 3 (Weeks 9-12)** | Final Art - Replace all placeholders |

**Priority for art replacement:**
1. Player cart & characters (most visible)
2. Collectibles (coins, hearts)
3. Environment backgrounds
4. Obstacles
5. UI elements

---

## Testing Placeholder Scale

Good placeholder art should feel right even though it's simple.

### Scale Test Checklist

- [ ] Player cart feels appropriately sized
- [ ] Can clearly see all objects on screen
- [ ] Jump height looks proportional to obstacles
- [ ] Coins are easy to spot
- [ ] Obstacles feel threatening but fair

**Common fixes:**
- Cart too small? Increase scale to (1.2, 0.6, 1)
- Can't see coins? Make them bigger or brighter
- Obstacles blend in? Use contrasting colors

---

## Replacing Placeholders with Final Art

When you get final art:

1. **Import sprite** to appropriate folder (not _Placeholders)
2. **Update prefab**:
   - Select prefab in Project
   - Drag new sprite to Sprite Renderer
3. **All instances update automatically** ✅

**Alternative (if sprite size differs):**
1. Create NEW prefab with final art
2. Use Find & Replace tool or manually swap
3. Delete old placeholder prefab

---

## Sample Placeholder Scene Hierarchy

```
Gameplay Scene
├── PlayerCart (Orange square + wheels)
├── Ground (Green long rectangle)
├── Platform1 (Green rectangle)
├── Platform2 (Green rectangle)
├── Gap (empty space)
├── Obstacle_Barrier (Brown tall rectangle)
├── Obstacle_Spike (Red triangle)
├── Coin (Yellow circle) x 10
├── ExtraLife (Red circle)
└── FinishLine (Invisible trigger)
```

Simple, functional, ready to test gameplay!

---

## Resources

### Free Placeholder Asset Packs (Optional)

If you want slightly nicer placeholders:

- **Kenney.nl** - Simple 2D assets (free)
  - https://kenney.nl/assets/platformer-art-deluxe
- **OpenGameArt.org** - Community assets
  - https://opengameart.org/

But honestly, **Unity's built-in shapes are perfect** for early prototyping.

---

## Summary

**For Month 1 development:**
- Use **Unity built-in sprites** (squares, circles, triangles)
- **Color code** by function (gold = coin, red = hazard)
- Keep it **simple and fast**
- Focus on **gameplay feel**, not visuals
- Make **prefabs** for everything
- **Replace in Month 3** with final art

**Remember:** Minecraft looked like blocks and became one of the best games ever. Gameplay > Graphics in early development! 🎮

---

*Last Updated: 2025-11-22*
