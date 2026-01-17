# Adventures of the World - Ludo.ai Asset Generation Brief

**Last Updated:** 2026-01-17
**Purpose:** Single-source reference for consistent asset generation in Ludo.ai

---

## 🎮 Project Identity

**Game Title:** Adventures of the World
**Genre:** 2D Auto-Scrolling Platformer (Action, Casual)
**Art Style:** Hand-Painted 2.5D (Rayman Legends inspired)
**Platform:** Mobile primary, Desktop secondary
**Target Audience:** Family-friendly, casual gamers (all ages)
**Country:** United States

---

## ⚙️ CRITICAL GLOBAL SETTINGS

**Use these settings for ALL asset generation in Ludo.ai:**

```
Art Style: Hand-Painted
Perspective: 2.5D
Genre: Platformer
```

**IMPORTANT:** Never change these base settings across assets to maintain consistency.

---

## 🎨 Universal Art Direction Standards

### Lighting System (NON-NEGOTIABLE)

**Global Light Source:** Upper-Left (Northwest, 45° from top-left)

**Why upper-left?**
- Rayman Legends inspiration (traditional hand-painted style)
- Creates natural rim lighting as cart moves left→right
- More whimsical and artistic than corporate upper-right
- Consistent shadow direction across all assets

**Shadow Specifications:**
- **Direction:** Lower-right (45° down-right)
- **Softness:** Soft edges, painterly (NOT harsh)
- **Intensity:** Subtle, whimsical (not dramatic)
- **Color:** Warm dark browns/purples (not pure black)

**Add to EVERY prompt:**
```
soft directional lighting from upper-left, gentle shadows to lower-right,
painterly highlights on top-left surfaces, warm rim lighting
```

**Negative prompts (lighting):**
```
bottom lighting, flat lighting, no shadows, harsh shadows,
multiple light sources, rim lighting from right, top-down lighting
```

### Visual Style Requirements

**Always include:**
- Vibrant, saturated colors with gradient shading
- Painterly textures (brushstroke feel)
- Soft, organic shapes (whimsical, not geometric)
- Magical/fantasy atmosphere
- Transparent PNG background
- Side view profile (pure 2D side-on view)
- Isolated element only (no ground, no base, no context)

**Always exclude (negative prompts):**
- Flat colors, solid fills
- 3D render, isometric view
- Thick cartoon outlines, vector style
- Harsh edges, geometric shapes
- Ground, base, floor, shadow below
- Realistic photographic style

---

## 🌍 World Theme Specifications

### 1. Forest (Levels 1-3) - "Enchanted Grove"

**Color Palette:**
- Primary: Vibrant green `#6ABF4B`
- Secondary: Dark forest green `#2D5016`
- Accent: Rich brown `#5C4033`
- Sky: Soft blue `#87CEEB`

**Atmosphere:** Morning dappled sunlight, magical woodland, beginner-friendly warmth

**Lighting Notes:** Softer shadows (canopy filtering), warm green tones in highlights

**Decoration Types:**
- Far: Mountains (dark blue-green), fluffy clouds (white)
- Mid: Oak/pine/birch trees, rolling hills, large mushrooms
- Near: Bushes, rocks with moss, wildflowers, grass tufts

---

### 2. Mountain (Levels 4-6) - "Alpine Heights"

**Color Palette:**
- Primary: Blue-gray stone `#4A5A6A`
- Secondary: Light gray `#BFBFBF`
- Accent: Purple-gray `#B8B8D1`
- Highlight: Snow white `#F0F8FF`

**Atmosphere:** Crisp alpine air, dramatic peaks, rugged challenge

**Lighting Notes:** Stronger contrast (clear mountain light), cool blue tones in shadows

**Decoration Types:**
- Far: Jagged peaks (snow-capped), wispy clouds, distant ranges
- Mid: Rocky outcrops, hardy pine trees, cliff faces, snow drifts
- Near: Boulders, small rocks, hardy shrubs, mountain grass, magical crystals

---

### 3. Desert (Levels 7-9) - "Golden Sands"

**Color Palette:**
- Primary: Warm orange `#FF8C42`
- Secondary: Orange-brown `#D2691E`
- Accent: Pale yellow `#FFE4B5`
- Vegetation: Sage green `#9CAF88`

**Atmosphere:** Golden hour warmth, heat shimmer, sun-baked adventure

**Lighting Notes:** Warm golden highlights, soft but visible shadows, sunset/sunrise tones

**Decoration Types:**
- Far: Sand dunes (rolling curves), distant dunes, stylized sun
- Mid: Saguaro cacti, barrel cacti, rock formations, dead trees, sand dunes
- Near: Rocks, small succulents, cartoon skulls, tumbleweeds, dry grass

---

### 4. Underwater (Levels 10-12) - "Mystic Depths"

**Color Palette:**
- Primary: Aqua blue `#00CED1`
- Secondary: Deep blue `#003D5C`
- Accent: Purple `#9370DB`
- Coral: Pink `#FF6F91`

**Atmosphere:** Magical underwater world, diffused light, mysterious wonder

**Lighting Notes:** Very soft shadows (water scatter), aqua/blue tones in highlights, ethereal glow

**Decoration Types:**
- Far: Coral reef silhouettes, underwater rocks, tall kelp strands
- Mid: Brain coral, branch coral, seaweed kelp, underwater rocks, anemones
- Near: Seashells, small plants, rocks with algae, bubble clusters, crystals

---

### 5. Ocean/Beach (Levels 13-15) - "Tropical Paradise"

**Color Palette:**
- Primary: Ocean blue `#0077BE`
- Secondary: Sandy tan `#C2B280`
- Accent: Tropical green `#00A86B`
- Highlight: Coral orange `#FF7F50`

**Atmosphere:** Tropical paradise, sunset/sunrise light, breezy finale

**Lighting Notes:** Warm sunset tones in highlights, cool blue shadows, beach-y feel

**Decoration Types:**
- Far: Distant islands, tropical clouds, ocean waves
- Mid: Palm trees, beach rocks, wooden boats, pier sections
- Near: Large seashells, starfish, beach rocks, tropical plants, friendly crabs

---

## 🐾 Character Design Standards

### Universal Character Requirements

**All 13 animals must follow these rules:**

**Pose:** Sitting upright in "riding pose" (as if sitting in cart)
**Direction:** Facing right (cart movement direction)
**Expression:** Happy, friendly, adventurous
**View:** Pure side profile (2D, not 3/4 view)
**Size:** Consistent proportions (scalable in Unity)
**Context:** NO cart visible, NO ground, isolated character only

**Character Prompt Template:**
```
[ANIMAL] character for 2D platformer game, Rayman Legends inspired,
sitting upright in riding pose, side view profile,
[COLOR DESCRIPTION], vibrant hand-painted illustration,
gradient shading, friendly expression, whimsical fantasy style,
painterly texture,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on face and left side, subtle rim lighting,
transparent background PNG, isolated character,
no cart, no vehicle, no ground, full body visible

NEGATIVE: flat colors, 3D render, isometric, cartoon outlines,
standing pose, cart visible, ground, harsh shadows, bottom lighting,
flat lighting, multiple light sources
```

### The 13 Playable Characters

| # | Animal | Primary Color | Personality | Unlock Cost |
|---|--------|---------------|-------------|-------------|
| 1 | Cat | Orange tabby, white belly | Curious, agile | FREE (default) |
| 2 | Dog | Brown, cream chest | Loyal, energetic | 500 coins |
| 3 | Elephant | Gray, pink ears | Gentle, strong | 750 coins |
| 4 | Bear | Brown, tan muzzle | Strong, cuddly | 1000 coins |
| 5 | Unicorn | White, rainbow mane | Magical, graceful | 1200 coins |
| 6 | Fish | Orange, blue fins | Bubbly, optimistic | 800 coins |
| 7 | Fox | Orange-red, white chest | Clever, quick | 900 coins |
| 8 | Duck | Yellow, orange beak | Cheerful, quirky | 600 coins |
| 9 | Lion | Golden, red mane | Brave, regal | 1500 coins |
| 10 | Bunny | White, pink ears | Energetic, cheerful | 700 coins |
| 11 | Mouse | Gray, pink features | Brave, clever | 500 coins |
| 12 | Snowman | White, carrot nose | Cool, friendly | 1000 coins |
| 13 | Dragon | Purple, green wings | Powerful, friendly | 2000 coins |

---

## 🛒 The Cart (1 Reusable Asset)

**Description:** Wooden mine cart with wheels, side profile, empty (no character inside)

**Purpose:** All 13 characters sit in this same cart (composited in Unity)

**Key Features:**
- Rich brown wood with gradient shading
- Visible wheels (for rotation animation)
- Magical fantasy feel
- Rayman Legends style
- Side view profile only

**Cart Prompt:**
```
Wooden mine cart for 2D platformer game, Rayman Legends style,
vibrant hand-painted illustration, side view profile,
rich brown wood with gradient shading, magical fantasy feel,
sturdy wheels visible, painterly texture,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on top-left wooden planks, rim lighting,
transparent background PNG, isolated cart element,
no character inside, no ground, no rails,
whimsical adventure aesthetic

NEGATIVE: flat colors, 3D render, isometric, cartoon outlines,
character visible, ground, rails, harsh shadows, bottom lighting,
flat lighting, multiple light sources
```

---

## 🌳 Environmental Decoration System

### Asset Organization

**Total Environmental Assets:** 65 (13 per theme × 5 themes)

**Layer Distribution per Theme:**
- **Far Layer (0.2x parallax speed):** 3 assets - Mountains, clouds, distant elements
- **Mid Layer (0.5x parallax speed):** 5 assets - Trees, hills, structures
- **Near Layer (0.8x parallax speed):** 5 assets - Bushes, rocks, grass, flowers

### Environmental Asset Prompt Template

```
[OBJECT NAME] for [THEME] platformer [LAYER - far/midground/foreground],
Rayman Legends style, vibrant hand-painted illustration,
[THEME COLOR PALETTE], gradient shading,
painterly texture, [SPECIFIC DETAILS],
soft directional lighting from upper-left, gentle shadows to lower-right,
[LAYER-SPECIFIC LIGHTING NOTES],
transparent background PNG, isolated element,
no ground, no base, side view

NEGATIVE: flat colors, 3D render, isometric, cartoon outlines,
ground, base, harsh shadows, bottom lighting, flat lighting,
multiple light sources
```

### Lighting by Asset Type

| Asset Type | Lighting Notes |
|-----------|----------------|
| **Cart** | Highlight top-left planks, soft shadow under right edge |
| **Animals** | Face/front illuminated, rim light on right ear/back |
| **Trees/Bushes** | Left foliage brighter, right side darker gradient |
| **Rocks** | Top-left surface lit, lower-right in soft shadow |
| **Mountains** | Left slope illuminated, right slope darker |
| **Clouds** | Bright puffy tops on left, gray undersides on right |

---

## ✅ Quality Control Checklist

**Before approving ANY asset, verify:**

- [ ] Transparent PNG background (no white/colored background)
- [ ] No ground/base/floor visible below element
- [ ] Pure side view (not isometric, not 3/4 view, not angled)
- [ ] Hand-painted style with gradient shading (not flat vector)
- [ ] Upper-left lighting applied (highlights on left, shadows on right)
- [ ] Consistent with Rayman Legends aesthetic (whimsical, magical)
- [ ] Appropriate theme color palette used
- [ ] Isolated element only (no extra objects or context)
- [ ] No harsh cartoon outlines or thick vector edges
- [ ] Painterly texture visible (brushstroke feel)

---

## 📊 Asset Generation Workflow

### Phase 1: Cart (Week 6 - Day 1)
1. Generate main cart (1 asset)
2. Test in Unity with placeholder animal
3. Verify wheel animation approach

### Phase 2: Core Animals (Week 6 - Days 2-3)
1. Generate Cat, Dog, Lion, Bunny (4 animals)
2. Test in Unity positioned in cart
3. Verify scale and positioning
4. Adjust prompt if needed before batch generation

### Phase 3: Remaining Animals (Week 7)
1. Batch generate remaining 9 animals
2. Test each in Unity
3. Ensure consistency across all 13 characters

### Phase 4: Forest Environment (Week 7)
1. Generate all 13 Forest assets
2. Test in Unity parallax system
3. Verify transparency and layering

### Phase 5: Remaining Environments (Week 8)
1. Generate Mountain (13 assets)
2. Generate Desert (13 assets)
3. Generate Underwater (13 assets)
4. Generate Ocean (13 assets)
5. Test all environments in Unity

---

## 💰 Credit Budget Estimate

| Category | Count | Estimated Credits |
|----------|-------|-------------------|
| Cart | 1 | 5-10 credits |
| Animals | 13 | 50-75 credits |
| Forest | 13 | 30-50 credits |
| Mountain | 13 | 30-50 credits |
| Desert | 13 | 30-50 credits |
| Underwater | 13 | 30-50 credits |
| Ocean | 13 | 30-50 credits |
| **TOTAL** | **79 assets** | **200-300 credits** |

**Note:** Generate cart + 2-3 test animals first to validate style before committing to full batch.

---

## 🔗 Related Documentation

- **Full Asset Guide:** `/docs/05-art-assets/ludo-ai-asset-guide.md` - All 80 prompts with detailed specifications
- **Character Reference:** `/docs/05-art-assets/character-reference.md` - Full character personalities and details
- **Project Concept:** `/ludo/project-concept.txt` - Complete game design document from Ludo.ai
- **Asset Metadata:** `/docs/05-art-assets/asset-metadata-system.md` - Unity integration system

---

## 🎯 Quick Reference: When Generating Assets

**Copy-paste this into Ludo.ai project context:**

```
Adventures of the World - 2D auto-scrolling platformer with 13 animal characters
riding a wooden cart through 5 themed environments (Forest, Mountain, Desert,
Underwater, Ocean). Hand-painted 2.5D style inspired by Rayman Legends.

CRITICAL ART DIRECTION:
- Upper-left lighting (45° from top-left)
- Soft shadows to lower-right
- Painterly gradients (NOT flat)
- Transparent PNG, side view only
- Isolated elements (no ground/base)
- Vibrant, saturated colors
- Whimsical, family-friendly
- Mobile-optimized platformer aesthetic

Target: Casual mobile gamers, all ages, United States market.
```

---

**Remember:** Consistency is key. Use the same Ludo.ai settings, lighting direction, and style keywords across ALL 79 assets for a cohesive visual identity.

**Generated:** 2026-01-17
**For:** Adventures of the World - Unity 2022.3 LTS Project
**Style:** Hand-Painted 2.5D (Rayman Legends Inspired)
