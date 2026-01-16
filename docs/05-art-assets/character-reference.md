# Character Reference Guide - Adventures of the World

## Playable Characters

The game features **13 adorable animal characters** that players can select to ride in their cart through various adventures.

---

## Character Roster

### 1. **Cat** 🐱
- **Personality**: Curious, agile, independent
- **Color Palette**: Orange tabby, gray, or calico
- **Visual Notes**: Pointy ears, whiskers, expressive eyes

### 2. **Dog** 🐶
- **Personality**: Loyal, energetic, friendly
- **Color Palette**: Brown, golden, or spotted
- **Visual Notes**: Floppy ears, wagging tail, happy expression

### 3. **Elephant** 🐘
- **Personality**: Wise, gentle, strong
- **Color Palette**: Gray with pink accents
- **Visual Notes**: Long trunk, large ears, small tail

### 4. **Bear** 🐻
- **Personality**: Brave, cuddly, protective
- **Color Palette**: Brown or honey-colored
- **Visual Notes**: Round ears, sturdy build, gentle face

### 5. **Unicorn** 🦄
- **Personality**: Magical, graceful, whimsical
- **Color Palette**: White/pastel with rainbow mane
- **Visual Notes**: Horn on forehead, flowing mane, sparkles

### 6. **Fish** 🐟
- **Personality**: Cheerful, bubbly, adventurous
- **Color Palette**: Bright orange, blue, or tropical colors
- **Visual Notes**: Fins, scales, big eyes, bubble trail

### 7. **Fox** 🦊
- **Personality**: Clever, quick, mischievous
- **Color Palette**: Orange-red with white accents
- **Visual Notes**: Pointed ears, bushy tail, sharp features

### 8. **Duck** 🦆
- **Personality**: Fun-loving, cheerful, optimistic
- **Color Palette**: Yellow or white with orange beak
- **Visual Notes**: Webbed feet, sailor hat (optional), wings

### 9. **Lion** 🦁
- **Personality**: Brave, bold, leader
- **Color Palette**: Golden with orange mane
- **Visual Notes**: Majestic mane, confident expression, strong

### 10. **Bunny** 🐰
- **Personality**: Energetic, quick, adorable
- **Color Palette**: White, brown, or gray
- **Visual Notes**: Long ears, fluffy tail, pink nose

### 11. **Mouse** 🐭
- **Personality**: Clever, curious, scrappy
- **Color Palette**: Gray or brown
- **Visual Notes**: Big round ears, small size, long tail

### 12. **Snowman** ⛄
- **Personality**: Jolly, cool, friendly
- **Color Palette**: White with colorful scarf and hat
- **Visual Notes**: Three snowball body, carrot nose, stick arms

### 13. **Dragon** 🐉
- **Personality**: Fierce but friendly, powerful, magical
- **Color Palette**: Green, purple, or blue with scales
- **Visual Notes**: Wings, spikes, tail, small horns, friendly face

---

## Design Specifications

### Art Style
- **Style**: Hand-Painted 2.5D (Rayman Legends inspired)
- **Complexity**: Gradient shading, painterly textures, soft highlights
- **Appeal**: Family-friendly, whimsical, magical atmosphere
- **Target**: All ages (8+)
- **Ludo.ai Settings**: Hand-Painted + 2.5D + Platformer perspective

### Consistency Requirements
- All characters should be **same size** (head-to-body ratio)
- **Same level of detail** across all characters
- **Unified gradient shading style** with soft lighting
- **Consistent painterly texture** quality
- **Vibrant colors** with atmospheric depth

### Technical Requirements
- **Format**: PNG with transparency (NOT SVG)
- **Size**: 512-2048 pixels height recommended
- **Background**: Transparent (critical)
- **Orientation**: Facing right (direction of cart movement)
- **Expression**: Happy, friendly, adventurous
- **Pose**: Sitting upright in "riding pose" (as if in cart)

### Character Positioning (Cart+Animal Architecture)
- **IMPORTANT**: Cart and animals are **SEPARATE assets**
- Characters **do NOT sit inside the cart** - they are positioned **behind it** in Unity
- Animals rendered in "riding pose" (sitting upright, ready to ride)
- One cart asset is reused for all 13 characters
- Character switching only changes the animal sprite (not the cart)
- Z-position: Cart at 0, Animal at -0.1 (renders animal in front of cart visually)

**See `ludo-ai-complete-asset-guide-2.5D.md` for detailed prompts and Unity setup.**

---

## Character States (Future)

For future development, each character may have:
- **Idle**: Default sitting in cart
- **Jump**: Excited expression during jump
- **Hit**: Surprised/hurt expression when damaged
- **Victory**: Celebrating at level end

**Version 1.0**: Single idle sprite per character

---

## Unlock Progression

### Starting Character
- **Cat** 🐱 (default, FREE - always available)

### Early Unlocks (500-750 coins)
- Mouse 🐭 - 500 coins
- Dog 🐶 - 500 coins
- Duck 🦆 - 600 coins
- Bunny 🐰 - 700 coins
- Elephant 🐘 - 750 coins

### Mid-Tier Unlocks (800-1000 coins)
- Fish 🐟 - 800 coins
- Fox 🦊 - 900 coins
- Bear 🐻 - 1000 coins
- Snowman ⛄ - 1000 coins

### Premium Unlocks (1200-2000 coins)
- Unicorn 🦄 - 1200 coins
- Lion 🦁 - 1500 coins
- Dragon 🐉 - 2000 coins (most expensive)

**Prices match `ludo-ai-complete-asset-guide-2.5D.md` - see that guide for generation prompts.**

---

## Usage Notes

- Characters are **cosmetic only** (no gameplay differences in v1.0)
- Players choose character in Character Select screen
- Selected character persists across levels
- Character appears in cart during gameplay
- Different character = different player personality expression

---

## Asset Naming Convention

When creating sprites, use this naming format:
```
character_[name]_idle.png
```

Examples:
- `character_cat_idle.png`
- `character_dragon_idle.png`
- `character_unicorn_idle.png`

---

## Color Palette Reference

### Primary Colors (Vibrant, Saturated)
- **Cat**: #FF9500 (Orange)
- **Dog**: #8B4513 (Brown)
- **Elephant**: #A9A9A9 (Gray)
- **Bear**: #D2691E (Brown/Honey)
- **Unicorn**: #FFFFFF (White) + #FF69B4 (Pink/Rainbow)
- **Fish**: #FFA500 (Orange) or #00BFFF (Blue)
- **Fox**: #FF4500 (Orange-Red)
- **Duck**: #FFD700 (Yellow)
- **Lion**: #FFA500 (Gold/Orange)
- **Bunny**: #FFFFFF (White) or #D2B48C (Tan)
- **Mouse**: #808080 (Gray)
- **Snowman**: #FFFFFF (White)
- **Dragon**: #32CD32 (Green) or #9370DB (Purple)

---

## Implementation Checklist

- [ ] Generate character sprites (13 total)
- [ ] Import to `Assets/Sprites/Characters/`
- [ ] Create character ScriptableObjects
- [ ] Update Character Selection UI
- [ ] Update shop with unlock prices
- [ ] Test all characters display correctly in cart

---

*Last Updated: 2025-11-23*
*Total Characters: 13*
