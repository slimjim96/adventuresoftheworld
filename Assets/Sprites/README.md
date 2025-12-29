# Sprites

This directory contains all 2D sprite assets for the game.

## Folder Structure

### Characters/
- `Lion/` - Lion character sprites
- `Bunny/` - Bunny character sprites
- `Duck/` - Duck character sprites
- `Mouse/` - Mouse character sprites
- `Cart/` - Cart vehicle sprites and variations

### Environments/
Environment-specific sprites organized by world:
- `Forest/` - Trees, logs, grass, foliage
- `Mountain/` - Rocks, snow, cliffs
- `Desert/` - Sand, cacti, ruins
- `Underwater/` - Water, coral, plants, bubbles
- `Ocean/` - Waves, boats, islands

### Obstacles/
- Static and dynamic obstacle sprites
- Hazards (spikes, pits, etc.)
- Platform variations

### UI/
- Buttons and menu elements
- Icons (hearts, coins, stars)
- HUD elements
- Font textures (if using bitmap fonts)

### Collectibles/
- Coin sprites and animations
- Extra life pickups
- Power-up sprites

## Asset Guidelines

### Format
- **Source**: SVG vector graphics (preferred)
- **Export**: PNG sprites (if SVG runtime is slow)
- **Resolution**: Design at 2x or 4x for high-DPI displays

### Naming Convention
- Use lowercase with underscores: `character_lion_idle.png`
- Include state/variation in name: `coin_gold_01.png`
- Animation frames: `enemy_walk_01.png`, `enemy_walk_02.png`, etc.

### Import Settings (Unity)
- **Sprite Mode**: Single or Multiple (for sprite sheets)
- **Pixels Per Unit**: 100 (standard 2D)
- **Filter Mode**: Point (for pixel art) or Bilinear (for smooth art)
- **Compression**: Use compression on mobile builds
- **Max Size**: Optimize based on sprite size (512, 1024, 2048)

### Sprite Sheets
- Combine related sprites into atlases for performance
- Use Unity's Sprite Packer or Sprite Atlas
- Keep atlas size under 2048x2048 for compatibility

## Art Style Reference

- **Theme**: Cartoon, whimsical, family-friendly
- **Colors**: Vibrant and saturated
- **Line Art**: Clean, smooth outlines
- **Shading**: Minimal, cel-shaded style preferred

## Placeholder Assets

During early development, use simple colored shapes:
- Cart: Rectangle with wheels
- Characters: Simple animal shapes
- Obstacles: Basic geometric shapes
- Coins: Yellow circles with '$' or star icon

Replace with final art as development progresses.
