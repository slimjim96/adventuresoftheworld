# Ludo.ai Complete Asset Generation Guide - 2.5D Hand-Painted Style

**Updated for Hand-Painted 2.5D aesthetic inspired by Rayman Legends**

---

## 🎨 Global Ludo.ai Settings

**Use these settings for ALL asset generation unless noted otherwise:**

```
Art Style: Hand-Painted
Perspective: 2.5D
Genre: Platformer
```

**Critical for every prompt:**
- Always include: `transparent background PNG`
- Always include: `isolated element, no ground, no base`
- Side view only (never isometric or 3D rotation)

---

## 💡 Lighting Direction Standards

**Global Light Source: Upper-Left (Northwest, ~45° from top-left)**

### Why Upper-Left?

1. **Rayman Legends Inspiration:** The Hand-Painted 2.5D style traditionally uses soft upper-left lighting for artistic, painterly feel
2. **Movement Harmony:** Cart moves left→right; upper-left lighting creates natural rim lighting on right edges as objects pass
3. **Character Appeal:** Front-left lighting flatters character designs, creates warm highlights on animal faces
4. **Atmospheric Depth:** Enhances parallax layers with consistent shadow direction (lower-right)
5. **Unique Identity:** Less common than corporate upper-right, more whimsical and artistic

### Lighting Specifications for Ludo.ai

**Add to ALL prompts:**
```
soft directional lighting from upper-left, gentle shadows to lower-right,
painterly highlights on top-left surfaces, warm rim lighting
```

**Shadow Guidelines:**
- **Direction:** Shadows cast toward lower-right (45° down-right)
- **Softness:** Soft edges, painterly (not harsh vector shadows)
- **Intensity:** Subtle - this is whimsical, not dramatic noir
- **Color:** Warm dark browns/purples (not pure black)

**Per-Asset Type:**

| Asset Type | Lighting Notes |
|-----------|----------------|
| **Cart** | Highlight on top-left wooden planks, soft shadow under right edge |
| **Animals** | Face/front illuminated, subtle rim light on right ear/back |
| **Trees/Bushes** | Left side of foliage brighter, right side has gentle gradient to shadow |
| **Rocks** | Top-left surface catches light, lower-right in soft shadow |
| **Mountains** | Left slope illuminated, right slope darker (atmospheric perspective applies) |
| **Clouds** | Bright puffy tops on left, soft gray undersides on right |

### Example Prompt Integration

**Before (no lighting specified):**
```
Tree for forest level, hand-painted, vibrant green leaves
```

**After (with lighting):**
```
Tree for forest level, hand-painted, vibrant green leaves,
soft directional lighting from upper-left, gentle shadows to lower-right,
painterly highlights on top-left branches, warm rim lighting on left foliage
```

### Environment-Specific Lighting Variations

While maintaining upper-left as base direction:

- **Forest:** Dappled morning light, softer shadows (canopy filtering)
- **Mountain:** Crisp alpine light, slightly stronger contrast
- **Desert:** Warm golden-hour glow, soft but visible shadows
- **Underwater:** Diffused upper lighting, very soft shadows (water scatter)
- **Ocean:** Sunset/sunrise tones, warm highlights, cool shadows

**IMPORTANT:** These are *tonal* variations, not direction changes. Light source remains upper-left for all environments.

### Negative Prompts (Avoid)

Always include in negative prompts:
```
NEGATIVE: bottom lighting, flat lighting, no shadows, harsh shadows,
multiple light sources, rim lighting from right, top-down lighting
```

---

## 🛒 Part 1: The Cart (1 Asset)

**Priority:** Generate first - this is your reusable base for all characters.

### Cart with Animated Wheels

**Ludo.ai Settings:**
```
Art Style: Hand-Painted
Perspective: 2.5D
Genre: Platformer
```

**Prompt:**
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

**Expected Result:**
- Empty cart in side profile
- Visible wheels (for animation reference)
- Rich wood texture with gradients
- No character inside
- Transparent background

**Animation Strategy:**
You'll need wheel rotation frames. Generate 3-4 variations:

**Wheel Frame 1 (0°):**
```
Same prompt as above
```

**Wheel Frame 2 (90°):**
```
Same prompt + add: "cart wheels rotated 90 degrees"
```

**Wheel Frame 3 (180°):**
```
Same prompt + add: "cart wheels rotated 180 degrees"
```

**OR** - Easier approach:
- Generate one cart with clear wheel spokes
- Rotate wheels in Unity using simple rotation animation
- No need for multiple frames if wheels are circular

**Unity Setup:**
- Cart body: Static sprite (doesn't move)
- Wheels: Child sprites with rotation animation

---

## 🐾 Part 2: Playable Animals (13 Assets)

**All animals in "riding pose" - seated/positioned as if in cart**

### Animal Design Guidelines

**Pose:** Sitting upright, facing right (same direction as cart movement)
**Expression:** Happy, adventurous, friendly
**Size:** Similar size across all animals (scalable in Unity)
**Style:** Hand-painted, vibrant colors, gradient shading
**View:** Pure side profile

### Universal Animal Prompt Template

**Ludo.ai Settings:**
```
Art Style: Hand-Painted
Perspective: 2.5D
Genre: Platformer
```

**Template:**
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

---

### 🐱 1. Cat (Starter Character - FREE)

**Character Profile:**
- Color: Orange tabby with white belly
- Personality: Curious and agile
- Unlock: Free (default character)

**Prompt:**
```
Cat character for 2D platformer game, Rayman Legends style,
sitting upright in riding pose, side view profile,
orange tabby fur with white belly, gradient shading on fur,
vibrant hand-painted illustration, green eyes, friendly smile,
cute whiskers, painterly texture, whimsical adventure aesthetic,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on face and left ear, subtle rim lighting on back,
transparent background PNG, isolated character,
no cart, no ground, full body visible

NEGATIVE: flat colors, 3D render, isometric, thick outlines,
standing, cart, ground, harsh shadows, bottom lighting,
flat lighting, multiple light sources
```

---

### 🐶 2. Dog (500 coins)

**Character Profile:**
- Color: Brown with floppy ears
- Personality: Loyal and energetic
- Unlock: 500 coins

**Prompt:**
```
Dog character for 2D platformer game, Rayman Legends inspired,
sitting upright in riding pose, side view profile,
brown fur with cream chest, floppy ears, gradient shading,
vibrant hand-painted illustration, happy expression with tongue out,
painterly texture, friendly adventure vibe,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on face and left ear, subtle rim lighting on back,
transparent background PNG, isolated character,
no cart, no ground, full body visible

NEGATIVE: flat colors, 3D render, isometric, thick outlines,
standing, cart, ground, harsh shadows, bottom lighting,
flat lighting, multiple light sources
```

---

### 🐘 3. Elephant (750 coins)

**Character Profile:**
- Color: Gray with pink ears
- Personality: Gentle and strong
- Unlock: 750 coins

**Prompt:**
```
Elephant character for 2D platformer game, Rayman Legends style,
sitting upright in riding pose, side view profile,
gray body with pink inner ears, trunk raised playfully,
gradient shading on wrinkled skin, vibrant hand-painted illustration,
kind eyes, painterly texture, whimsical fantasy aesthetic,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on face and left side, subtle rim lighting on trunk,
transparent background PNG, isolated character,
no cart, no ground, full body visible

NEGATIVE: flat colors, 3D render, isometric, thick outlines,
standing, cart, ground, harsh shadows, realistic, bottom lighting,
flat lighting, multiple light sources
```

---

### 🐻 4. Bear (1000 coins)

**Character Profile:**
- Color: Brown with lighter muzzle
- Personality: Strong but cuddly
- Unlock: 1000 coins

**Prompt:**
```
Bear character for 2D platformer game, Rayman Legends inspired,
sitting upright in riding pose, side view profile,
brown fluffy fur with tan muzzle, gradient shading on fur,
vibrant hand-painted illustration, friendly smile, round ears,
painterly texture, huggable appearance, whimsical adventure style,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on face and left ear, subtle rim lighting on fluffy fur,
transparent background PNG, isolated character,
no cart, no ground, full body visible

NEGATIVE: flat colors, 3D render, isometric, thick outlines,
standing, cart, ground, harsh shadows, scary, bottom lighting,
flat lighting, multiple light sources
```

---

### 🦄 5. Unicorn (1200 coins)

**Character Profile:**
- Color: White with rainbow mane
- Personality: Magical and graceful
- Unlock: 1200 coins

**Prompt:**
```
Unicorn character for 2D platformer game, Rayman Legends style,
sitting upright in riding pose, side view profile,
white coat with iridescent sheen, rainbow colored mane and tail,
golden horn, gradient shading, vibrant hand-painted illustration,
magical sparkle effect, kind eyes, painterly texture,
whimsical fantasy aesthetic,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on face and golden horn, subtle rim lighting on mane,
transparent background PNG, isolated character,
no cart, no ground, full body visible

NEGATIVE: flat colors, 3D render, isometric, thick outlines,
standing, cart, ground, harsh shadows, realistic horse, bottom lighting,
flat lighting, multiple light sources
```

---

### 🐟 6. Fish (800 coins)

**Character Profile:**
- Color: Bright orange with blue fins
- Personality: Bubbly and optimistic
- Unlock: 800 coins

**Prompt:**
```
Fish character for 2D platformer game, Rayman Legends inspired,
sitting upright in riding pose (with fins), side view profile,
bright orange body with blue fins, gradient shading with shimmer,
vibrant hand-painted illustration, big happy eyes, smiling,
water droplets around, painterly texture,
whimsical underwater charm, magical atmosphere,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on face and top fins, subtle rim lighting on scales,
transparent background PNG, isolated character,
no cart, no bowl, no ground, full body visible

NEGATIVE: flat colors, 3D render, isometric, thick outlines,
swimming, water tank, cart, ground, harsh shadows, bottom lighting,
flat lighting, multiple light sources
```

---

### 🦊 7. Fox (900 coins)

**Character Profile:**
- Color: Orange-red with white chest and black paws
- Personality: Clever and quick
- Unlock: 900 coins

**Prompt:**
```
Fox character for 2D platformer game, Rayman Legends style,
sitting upright in riding pose, side view profile,
orange-red fur with white chest and black paw tips,
bushy tail with white tip, gradient shading on fur,
vibrant hand-painted illustration, clever smile, bright eyes,
painterly texture, adventure ready, whimsical fantasy aesthetic,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on face and left ear, subtle rim lighting on bushy tail,
transparent background PNG, isolated character,
no cart, no ground, full body visible

NEGATIVE: flat colors, 3D render, isometric, thick outlines,
standing, cart, ground, harsh shadows, bottom lighting,
flat lighting, multiple light sources
```

---

### 🦆 8. Duck (600 coins)

**Character Profile:**
- Color: Yellow with orange beak
- Personality: Cheerful and quirky
- Unlock: 600 coins

**Prompt:**
```
Duck character for 2D platformer game, Rayman Legends inspired,
sitting upright in riding pose, side view profile,
bright yellow feathers with orange beak and feet,
gradient shading on fluffy feathers, vibrant hand-painted illustration,
cheerful expression, wings tucked at sides, painterly texture,
whimsical charm,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on face and left side, subtle rim lighting on fluffy feathers,
transparent background PNG, isolated character,
no cart, no water, no ground, full body visible

NEGATIVE: flat colors, 3D render, isometric, thick outlines,
swimming, pond, cart, ground, harsh shadows, bottom lighting,
flat lighting, multiple light sources
```

---

### 🦁 9. Lion (1500 coins)

**Character Profile:**
- Color: Golden with large mane
- Personality: Brave and regal
- Unlock: 1500 coins

**Prompt:**
```
Lion character for 2D platformer game, Rayman Legends style,
sitting upright in riding pose, side view profile,
golden yellow fur with magnificent orange-red mane,
gradient shading on fur and mane, vibrant hand-painted illustration,
noble expression, confident smile, painterly texture,
majestic but friendly, whimsical fantasy aesthetic,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on face and mane, subtle rim lighting on left side,
transparent background PNG, isolated character,
no cart, no ground, full body visible

NEGATIVE: flat colors, 3D render, isometric, thick outlines,
standing, cart, ground, harsh shadows, scary, realistic, bottom lighting,
flat lighting, multiple light sources
```

---

### 🐰 10. Bunny (700 coins)

**Character Profile:**
- Color: White with pink ears
- Personality: Energetic and cheerful
- Unlock: 700 coins

**Prompt:**
```
Bunny character for 2D platformer game, Rayman Legends inspired,
sitting upright in riding pose, side view profile,
fluffy white fur with pink inner ears, cotton tail visible,
gradient shading on soft fur, vibrant hand-painted illustration,
happy expression with buckteeth showing, big eyes,
painterly texture, adorable charm, whimsical adventure style,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on face and left ear, subtle rim lighting on fluffy fur,
transparent background PNG, isolated character,
no cart, no ground, full body visible

NEGATIVE: flat colors, 3D render, isometric, thick outlines,
standing, hopping, cart, ground, harsh shadows, bottom lighting,
flat lighting, multiple light sources
```

---

### 🐭 11. Mouse (500 coins)

**Character Profile:**
- Color: Gray with pink ears and nose
- Personality: Brave despite small size
- Unlock: 500 coins

**Prompt:**
```
Mouse character for 2D platformer game, Rayman Legends style,
sitting upright in riding pose, side view profile,
gray fur with pink ears, nose and tail, round ears,
gradient shading on fur, vibrant hand-painted illustration,
determined cute expression, whiskers visible, painterly texture,
tiny but brave appearance, whimsical fantasy aesthetic,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on face and left ear, subtle rim lighting on tail,
transparent background PNG, isolated character,
no cart, no ground, full body visible

NEGATIVE: flat colors, 3D render, isometric, thick outlines,
standing, cheese, cart, ground, harsh shadows, bottom lighting,
flat lighting, multiple light sources
```

---

### ⛄ 12. Snowman (1000 coins - Winter Special)

**Character Profile:**
- Color: White snow with carrot nose, coal buttons
- Personality: Cool and friendly
- Unlock: 1000 coins

**Prompt:**
```
Snowman character for 2D platformer game, Rayman Legends inspired,
sitting upright in riding pose (snow body with stick arms), side view,
white snow body with orange carrot nose, black coal buttons and eyes,
colorful scarf around neck, gradient shading with icy shimmer,
vibrant hand-painted illustration, happy smile, stick arms,
painterly texture, magical winter charm,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on left side of snow body, subtle rim lighting creating icy glow,
transparent background PNG, isolated character,
no cart, no ground, no snow pile, full body visible

NEGATIVE: flat colors, 3D render, isometric, thick outlines,
standing, melting, cart, ground, harsh shadows, bottom lighting,
flat lighting, multiple light sources
```

---

### 🐉 13. Dragon (2000 coins - Premium)

**Character Profile:**
- Color: Purple with green wings
- Personality: Powerful but friendly
- Unlock: 2000 coins (most expensive)

**Prompt:**
```
Dragon character for 2D platformer game, Rayman Legends style,
sitting upright in riding pose (with wings folded), side view,
purple scales with green wings, small friendly dragon,
gradient shading on scales with iridescent shine,
vibrant hand-painted illustration, cute friendly expression,
tiny horns, painterly texture, magical fantasy charm,
whimsical not scary,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on face and horns, subtle rim lighting on wings and scales,
transparent background PNG, isolated character,
no cart, no ground, full body visible, wings folded

NEGATIVE: flat colors, 3D render, isometric, thick outlines,
flying, scary, realistic, cart, ground, harsh shadows, fire, bottom lighting,
flat lighting, multiple light sources
```

---

## 🌳 Part 3: Environmental Decorations (65 Assets)

### Organization by Theme and Parallax Layer

Each environment has decorations for 3 parallax layers:
- **Far Layer (0.2x speed):** Mountains, clouds, distant elements
- **Mid Layer (0.5x speed):** Trees, hills, buildings
- **Near Layer (0.8x speed):** Bushes, rocks, grass, flowers

---

## 🌲 Theme 1: Forest (13 Assets)

**Color Palette:**
- Dark green: #2D5016
- Bright green: #6ABF4B
- Brown: #5C4033
- Sky blue: #87CEEB

### Far Layer - Forest (3 assets)

#### Forest_Mountain_Far_01

**Settings:** Hand-Painted + 2.5D + Platformer

**Prompt:**
```
Distant mountain silhouette for forest platformer background,
Rayman Legends style, dark blue-green gradient shading,
soft fog effect at base, hand-painted illustration,
painterly texture, atmospheric depth, fantasy landscape,
transparent background PNG, side view, layered peaks

NEGATIVE: flat colors, 3D render, isometric, harsh edges, ground
```

#### Forest_Cloud_Far_01

**Prompt:**
```
Fluffy cloud for forest platformer background,
Rayman Legends inspired, white with soft gray gradient shading,
hand-painted illustration, dreamy atmosphere, volumetric feel,
painterly texture, soft edges, magical sky element,
transparent background PNG, side view, isolated cloud

NEGATIVE: flat colors, 3D render, cartoon outlines, sky background
```

#### Forest_Cloud_Far_02

**Prompt:**
```
Small wispy cloud for forest platformer background,
lighter and smaller than main clouds, soft white gradient,
hand-painted style, painterly texture, ethereal feel,
transparent background PNG, side view, delicate

NEGATIVE: flat colors, 3D render, thick, heavy, background
```

### Mid Layer - Forest (5 assets)

#### Forest_Tree_Mid_01

**Prompt:**
```
Large oak tree for forest platformer midground,
Rayman Legends style, vibrant green gradient leaves from dark to bright,
rich brown bark with texture gradient, full leafy canopy,
hand-painted illustration, soft highlights, painterly texture,
magical forest atmosphere, side view profile,
transparent background PNG, isolated tree, no ground

NEGATIVE: flat colors, 3D render, isometric, cartoon outlines, ground, roots
```

#### Forest_Tree_Mid_02

**Prompt:**
```
Tall pine tree for forest platformer midground,
darker green gradient needles, brown trunk, conical shape,
hand-painted illustration, Rayman Legends inspired,
painterly texture, side view profile,
soft directional lighting from upper-left, gentle shadows to lower-right,
brighter foliage on left side, darker gradient on right,
warm highlights on top-left branches,
transparent background PNG, isolated tree, no ground

NEGATIVE: flat colors, 3D render, thick outlines, ground,
harsh shadows, bottom lighting, flat lighting
```

#### Forest_Tree_Mid_03

**Prompt:**
```
Birch tree for forest platformer midground,
white bark with dark markings, light green gradient leaves,
hand-painted style, soft highlights, painterly texture,
side view profile, whimsical forest aesthetic,
transparent background PNG, isolated tree, no ground

NEGATIVE: flat colors, 3D render, ground, roots
```

#### Forest_Hill_Mid_01

**Prompt:**
```
Rolling hill silhouette for forest platformer midground,
green gradient from dark to light, grassy texture suggestion,
hand-painted illustration, soft atmospheric shading,
painterly texture, gentle curve, side view,
transparent background PNG, no ground line below

NEGATIVE: flat colors, 3D render, harsh edges, base
```

#### Forest_Mushroom_Mid_01

**Prompt:**
```
Large fantasy mushroom for forest platformer midground,
red cap with white spots, gradient shading on cap,
cream colored stem, hand-painted illustration,
Rayman Legends style, magical atmosphere, painterly texture,
side view profile, transparent background PNG, no ground

NEGATIVE: flat colors, 3D render, cartoon outlines, ground
```

### Near Layer - Forest (5 assets)

#### Forest_Bush_Near_01

**Prompt:**
```
Lush bush for forest platformer foreground,
vibrant bright green gradient foliage, leafy clusters,
hand-painted illustration, Rayman Legends inspired,
soft highlights and shadows, painterly texture,
rounded organic shape, side view profile,
transparent background PNG, isolated bush, no ground

NEGATIVE: flat colors, 3D render, cartoon outlines, ground
```

#### Forest_Bush_Near_02

**Prompt:**
```
Small shrub for forest platformer foreground,
darker green gradient leaves, compact bushy shape,
hand-painted style, painterly texture, side view,
transparent background PNG, no ground

NEGATIVE: flat colors, 3D render, ground
```

#### Forest_Rock_Near_01

**Prompt:**
```
Mossy rock boulder for forest platformer foreground,
gray stone with gradient shading, green moss patches,
hand-painted illustration, painterly texture, side view profile,
soft directional lighting from upper-left, gentle shadows to lower-right,
highlighted top-left surface, darker lower-right side,
warm rim lighting on left edge,
transparent background PNG, isolated rock, no ground

NEGATIVE: flat colors, 3D render, cartoon outlines, ground,
harsh shadows, bottom lighting, flat lighting, multiple light sources
```

#### Forest_Flower_Near_01

**Prompt:**
```
Colorful wildflowers for forest platformer foreground,
red and yellow blooms with green stems, gradient shading,
hand-painted illustration, Rayman Legends style,
painterly texture, whimsical charm, side view,
transparent background PNG, small flower cluster, no ground

NEGATIVE: flat colors, 3D render, ground
```

#### Forest_Grass_Near_01

**Prompt:**
```
Grass tuft for forest platformer foreground,
bright green blades with gradient shading, wispy strands,
hand-painted style, painterly texture, side view profile,
transparent background PNG, isolated grass, no ground base

NEGATIVE: flat colors, 3D render, ground, soil
```

---

## ⛰️ Theme 2: Mountain (13 Assets)

**Color Palette:**
- Dark blue-gray: #4A5A6A
- Light gray: #BFBFBF
- Purple-gray: #B8B8D1
- Snow white: #F0F8FF

### Far Layer - Mountain (3 assets)

#### Mountain_Peak_Far_01

**Prompt:**
```
Jagged mountain peaks for platformer background,
dark blue-gray to purple-gray gradient, snow-capped tips,
hand-painted illustration, Rayman Legends inspired,
atmospheric perspective, soft fog at base, painterly texture,
dramatic fantasy landscape, side view,
transparent background PNG, layered peaks, no ground

NEGATIVE: flat colors, 3D render, isometric, harsh edges
```

#### Mountain_Peak_Far_02

**Prompt:**
```
Distant smaller mountain range for platformer background,
lighter purple-gray gradient, misty atmosphere,
hand-painted style, soft shading, painterly texture,
side view silhouette, transparent background PNG

NEGATIVE: flat colors, 3D render, ground
```

#### Mountain_Cloud_Far_01

**Prompt:**
```
Wispy mountain cloud for platformer background,
white with cool gray gradient, thin stretched shape,
hand-painted illustration, painterly texture,
atmospheric feel, transparent background PNG, side view

NEGATIVE: flat colors, 3D render, thick, puffy
```

### Mid Layer - Mountain (5 assets)

#### Mountain_Rock_Mid_01

**Prompt:**
```
Large rocky outcrop for mountain platformer midground,
gray stone with gradient shading, angular facets,
hand-painted illustration, cool blue-gray tones,
painterly texture, side view profile, rugged appearance,
transparent background PNG, isolated rock formation, no ground

NEGATIVE: flat colors, 3D render, cartoon outlines, ground
```

#### Mountain_Tree_Mid_01

**Prompt:**
```
Hardy pine tree for mountain platformer midground,
dark green gradient needles, brown trunk, windswept shape,
hand-painted style, Rayman Legends inspired, painterly texture,
sparse foliage, side view profile,
transparent background PNG, isolated tree, no ground

NEGATIVE: flat colors, 3D render, thick outlines, ground
```

#### Mountain_Tree_Mid_02

**Prompt:**
```
Small twisted tree for mountain platformer midground,
gnarled branches, sparse green-gray foliage gradient,
hand-painted illustration, weathered appearance,
painterly texture, side view, transparent background PNG, no ground

NEGATIVE: flat colors, 3D render, ground
```

#### Mountain_Cliff_Mid_01

**Prompt:**
```
Cliff face for mountain platformer midground,
layered gray stone with gradient shading, stratified rock,
hand-painted style, cool tones, painterly texture,
side view profile, vertical emphasis,
transparent background PNG, no ground below

NEGATIVE: flat colors, 3D render, ground base
```

#### Mountain_Snow_Mid_01

**Prompt:**
```
Snow drift for mountain platformer midground,
white with blue-gray gradient shadows, soft mounded shape,
hand-painted illustration, cold atmosphere, painterly texture,
side view, transparent background PNG, no ground line

NEGATIVE: flat colors, 3D render, ground, flat base
```

### Near Layer - Mountain (5 assets)

#### Mountain_Rock_Near_01

**Prompt:**
```
Boulder for mountain platformer foreground,
gray stone with gradient shading, angular shape,
hand-painted illustration, cool tones, painterly texture,
side view profile, transparent background PNG, no ground

NEGATIVE: flat colors, 3D render, cartoon outlines, ground, shadow
```

#### Mountain_Rock_Near_02

**Prompt:**
```
Small rock for mountain platformer foreground,
lighter gray with subtle gradient, rounded shape,
hand-painted style, painterly texture, side view,
transparent background PNG, no ground

NEGATIVE: flat colors, 3D render, ground
```

#### Mountain_Bush_Near_01

**Prompt:**
```
Hardy shrub for mountain platformer foreground,
dark green-gray gradient foliage, tough appearance,
hand-painted illustration, painterly texture, compact shape,
side view profile, transparent background PNG, no ground

NEGATIVE: flat colors, 3D render, ground
```

#### Mountain_Grass_Near_01

**Prompt:**
```
Mountain grass tuft for platformer foreground,
blue-green gradient blades, windswept look,
hand-painted style, painterly texture, side view,
transparent background PNG, no ground base

NEGATIVE: flat colors, 3D render, ground
```

#### Mountain_Crystal_Near_01

**Prompt:**
```
Magical crystal for mountain platformer foreground,
blue-purple gradient with inner glow, faceted geometric shape,
hand-painted illustration, Rayman Legends inspired,
magical shimmer, painterly texture, side view,
transparent background PNG, isolated crystal, no ground

NEGATIVE: flat colors, 3D render, cartoon outlines, ground
```

---

## 🏜️ Theme 3: Desert (13 Assets)

**Color Palette:**
- Orange-brown: #D2691E
- Pale yellow: #FFE4B5
- Sage green: #9CAF88
- Warm orange: #FF8C42

### Far Layer - Desert (3 assets)

#### Desert_Dune_Far_01

**Prompt:**
```
Sand dune silhouette for desert platformer background,
warm orange to pale yellow gradient, soft curves,
hand-painted illustration, heat shimmer effect,
atmospheric depth, painterly texture, side view,
transparent background PNG, rolling dune, no ground line

NEGATIVE: flat colors, 3D render, harsh edges, ground base
```

#### Desert_Dune_Far_02

**Prompt:**
```
Distant smaller dune for desert platformer background,
lighter yellow-orange gradient, soft shading,
hand-painted style, painterly texture, side view,
transparent background PNG

NEGATIVE: flat colors, 3D render, ground
```

#### Desert_Sun_Far_01

**Prompt:**
```
Stylized sun for desert platformer background,
bright yellow-orange gradient with warm glow,
hand-painted illustration, radial soft rays,
painterly texture, magical atmosphere,
transparent background PNG, circular sun

NEGATIVE: flat colors, 3D render, realistic, sky background
```

### Mid Layer - Desert (5 assets)

#### Desert_Cactus_Mid_01

**Prompt:**
```
Tall saguaro cactus for desert platformer midground,
dark to sage green gradient, classic arms shape,
hand-painted illustration, Rayman Legends style,
painterly texture, side view profile,
transparent background PNG, isolated cactus, no ground

NEGATIVE: flat colors, 3D render, cartoon outlines, ground, sand
```

#### Desert_Cactus_Mid_02

**Prompt:**
```
Round barrel cactus for desert platformer midground,
green gradient with yellow spines, ribbed texture,
hand-painted style, painterly texture, side view,
transparent background PNG, no ground

NEGATIVE: flat colors, 3D render, ground
```

#### Desert_Rock_Mid_01

**Prompt:**
```
Desert rock formation for platformer midground,
orange-brown to tan gradient, weathered stone,
hand-painted illustration, warm tones, painterly texture,
side view profile, transparent background PNG, no ground

NEGATIVE: flat colors, 3D render, ground
```

#### Desert_DeadTree_Mid_01

**Prompt:**
```
Dead twisted tree for desert platformer midground,
gray-brown gradient bare branches, weathered wood texture,
hand-painted style, dramatic silhouette, painterly texture,
side view profile, transparent background PNG, no ground

NEGATIVE: flat colors, 3D render, leaves, ground
```

#### Desert_Dune_Mid_01

**Prompt:**
```
Sand dune for desert platformer midground,
warm orange to yellow gradient, soft curves with ripples,
hand-painted illustration, painterly texture, side view,
transparent background PNG, no flat ground line

NEGATIVE: flat colors, 3D render, harsh edges, ground base
```

### Near Layer - Desert (5 assets)

#### Desert_Rock_Near_01

**Prompt:**
```
Desert rock for platformer foreground,
orange-red with gradient shading, angular shape,
hand-painted illustration, warm tones, painterly texture,
side view profile, transparent background PNG, no ground

NEGATIVE: flat colors, 3D render, cartoon outlines, ground, sand
```

#### Desert_Plant_Near_01

**Prompt:**
```
Small desert succulent for platformer foreground,
blue-green gradient with red tips, compact rosette shape,
hand-painted style, painterly texture, side view,
transparent background PNG, no ground

NEGATIVE: flat colors, 3D render, ground
```

#### Desert_Skull_Near_01

**Prompt:**
```
Cartoon animal skull for desert platformer foreground,
white with warm gray gradient shadows, friendly not scary,
hand-painted illustration, Rayman Legends style,
whimsical charm, painterly texture, side view,
transparent background PNG, no ground

NEGATIVE: flat colors, 3D render, scary, realistic, ground
```

#### Desert_Tumbleweed_Near_01

**Prompt:**
```
Tumbleweed for desert platformer foreground,
tan to brown gradient, spherical tangled branches,
hand-painted style, painterly texture, side view,
transparent background PNG, no ground

NEGATIVE: flat colors, 3D render, ground
```

#### Desert_Grass_Near_01

**Prompt:**
```
Dry grass tuft for desert platformer foreground,
tan-yellow gradient blades, sparse wispy strands,
hand-painted illustration, painterly texture, side view,
transparent background PNG, no ground base

NEGATIVE: flat colors, 3D render, green, lush, ground
```

---

## 🌊 Theme 4: Underwater (13 Assets)

**Color Palette:**
- Deep blue: #003D5C
- Aqua: #00CED1
- Purple: #9370DB
- Coral pink: #FF6F91

### Far Layer - Underwater (3 assets)

#### Underwater_Reef_Far_01

**Prompt:**
```
Distant coral reef silhouette for underwater platformer background,
deep blue to purple gradient, soft organic shapes,
hand-painted illustration, magical underwater atmosphere,
painterly texture, side view, mysterious depth,
transparent background PNG, no ocean floor

NEGATIVE: flat colors, 3D render, harsh edges, ground
```

#### Underwater_Rock_Far_01

**Prompt:**
```
Underwater rock formation for platformer background,
dark blue-gray with gradient shading, covered in growth,
hand-painted style, atmospheric depth, painterly texture,
side view, transparent background PNG

NEGATIVE: flat colors, 3D render, ground
```

#### Underwater_Kelp_Far_01

**Prompt:**
```
Tall kelp strand for underwater platformer background,
dark green to teal gradient, flowing wavy shape,
hand-painted illustration, painterly texture, side view,
transparent background PNG, no ocean floor

NEGATIVE: flat colors, 3D render, straight, ground
```

### Mid Layer - Underwater (5 assets)

#### Underwater_Coral_Mid_01

**Prompt:**
```
Brain coral for underwater platformer midground,
vibrant coral pink to orange gradient, rounded bumpy texture,
hand-painted illustration, Rayman Legends inspired,
magical glow, painterly texture, side view profile,
transparent background PNG, isolated coral, no ocean floor

NEGATIVE: flat colors, 3D render, cartoon outlines, ground
```

#### Underwater_Coral_Mid_02

**Prompt:**
```
Branch coral for underwater platformer midground,
purple to pink gradient, delicate branching structure,
hand-painted style, painterly texture, side view,
transparent background PNG, no ground

NEGATIVE: flat colors, 3D render, ground
```

#### Underwater_Kelp_Mid_01

**Prompt:**
```
Seaweed kelp for underwater platformer midground,
green to teal gradient, flowing organic shape,
hand-painted illustration, painterly texture, wavy motion,
side view profile, transparent background PNG, no ocean floor

NEGATIVE: flat colors, 3D render, straight, rigid, ground
```

#### Underwater_Rock_Mid_01

**Prompt:**
```
Underwater rock for platformer midground,
blue-gray with gradient shading, covered in algae patches,
hand-painted style, soft highlights, painterly texture,
side view, transparent background PNG, no ocean floor

NEGATIVE: flat colors, 3D render, ground
```

#### Underwater_Anemone_Mid_01

**Prompt:**
```
Sea anemone for underwater platformer midground,
pink to purple gradient tentacles, swaying organic form,
hand-painted illustration, Rayman Legends style,
magical underwater life, painterly texture, side view,
transparent background PNG, no ocean floor

NEGATIVE: flat colors, 3D render, cartoon outlines, ground
```

### Near Layer - Underwater (5 assets)

#### Underwater_Shell_Near_01

**Prompt:**
```
Seashell for underwater platformer foreground,
pink-orange gradient with pearl sheen, spiral conch shape,
hand-painted illustration, painterly texture, side view profile,
transparent background PNG, no ocean floor

NEGATIVE: flat colors, 3D render, cartoon outlines, ground, sand
```

#### Underwater_Plant_Near_01

**Prompt:**
```
Small underwater plant for platformer foreground,
bright green to aqua gradient leaves, flowing shape,
hand-painted style, painterly texture, side view,
transparent background PNG, no ocean floor

NEGATIVE: flat colors, 3D render, ground
```

#### Underwater_Rock_Near_01

**Prompt:**
```
Small rock for underwater platformer foreground,
teal-gray gradient with colorful algae, rounded shape,
hand-painted illustration, painterly texture, side view,
transparent background PNG, no ocean floor

NEGATIVE: flat colors, 3D render, ground
```

#### Underwater_Bubble_Near_01

**Prompt:**
```
Bubble cluster for underwater platformer foreground,
translucent white with blue gradient shimmer, spherical bubbles,
hand-painted style, magical sparkle, painterly texture,
side view, transparent background PNG

NEGATIVE: flat colors, 3D render, realistic
```

#### Underwater_Crystal_Near_01

**Prompt:**
```
Magical underwater crystal for platformer foreground,
aqua to purple gradient with inner glow, faceted shape,
hand-painted illustration, Rayman Legends inspired,
mystical shimmer, painterly texture, side view,
transparent background PNG, no ocean floor

NEGATIVE: flat colors, 3D render, cartoon outlines, ground
```

---

## 🌴 Theme 5: Ocean/Beach (13 Assets)

**Color Palette:**
- Sandy tan: #C2B280
- Ocean blue: #0077BE
- Tropical green: #00A86B
- Coral: #FF7F50

### Far Layer - Ocean (3 assets)

#### Ocean_Island_Far_01

**Prompt:**
```
Distant tropical island silhouette for ocean platformer background,
dark blue-green gradient, palm tree shapes visible,
hand-painted illustration, atmospheric depth, painterly texture,
side view, transparent background PNG, no water line

NEGATIVE: flat colors, 3D render, isometric, ground, water
```

#### Ocean_Cloud_Far_01

**Prompt:**
```
Tropical cloud for ocean platformer background,
white with warm gray gradient, fluffy cumulus shape,
hand-painted style, soft shading, painterly texture,
side view, transparent background PNG

NEGATIVE: flat colors, 3D render, sky background
```

#### Ocean_Wave_Far_01

**Prompt:**
```
Distant ocean wave for platformer background,
deep blue gradient with white foam cap, rolling curve,
hand-painted illustration, painterly texture, side view,
transparent background PNG, no water line below

NEGATIVE: flat colors, 3D render, ground, water surface
```

### Mid Layer - Ocean (5 assets)

#### Ocean_Palm_Mid_01

**Prompt:**
```
Palm tree for ocean platformer midground,
tropical green gradient fronds, brown trunk texture,
hand-painted illustration, Rayman Legends style,
curved swaying shape, painterly texture, side view profile,
transparent background PNG, isolated tree, no ground

NEGATIVE: flat colors, 3D render, cartoon outlines, ground, sand
```

#### Ocean_Palm_Mid_02

**Prompt:**
```
Smaller palm tree for ocean platformer midground,
bright green gradient leaves, leaning trunk,
hand-painted style, painterly texture, side view,
transparent background PNG, no ground

NEGATIVE: flat colors, 3D render, ground
```

#### Ocean_Rock_Mid_01

**Prompt:**
```
Beach rock formation for ocean platformer midground,
tan to gray gradient, weathered stone with tide pools,
hand-painted illustration, warm tones, painterly texture,
side view profile, transparent background PNG, no ground

NEGATIVE: flat colors, 3D render, ground
```

#### Ocean_Boat_Mid_01

**Prompt:**
```
Small wooden boat for ocean platformer midground,
brown to tan gradient wood, simple sailboat shape,
hand-painted style, Rayman Legends inspired,
whimsical charm, painterly texture, side view,
transparent background PNG, no water

NEGATIVE: flat colors, 3D render, cartoon outlines, water, waves
```

#### Ocean_Pier_Mid_01

**Prompt:**
```
Wooden pier section for ocean platformer midground,
weathered brown wood gradient, planks and posts visible,
hand-painted illustration, painterly texture, side view,
transparent background PNG, no water line

NEGATIVE: flat colors, 3D render, ground, water
```

### Near Layer - Ocean (5 assets)

#### Ocean_Shell_Near_01

**Prompt:**
```
Large seashell for ocean platformer foreground,
pink-orange gradient with mother of pearl sheen,
spiral conch shape, hand-painted illustration,
painterly texture, side view profile,
transparent background PNG, no sand

NEGATIVE: flat colors, 3D render, cartoon outlines, ground, sand
```

#### Ocean_Starfish_Near_01

**Prompt:**
```
Starfish for ocean platformer foreground,
orange to coral pink gradient, five-pointed shape,
hand-painted style, textured surface, painterly texture,
side view, transparent background PNG, no sand

NEGATIVE: flat colors, 3D render, ground
```

#### Ocean_Rock_Near_01

**Prompt:**
```
Beach rock for ocean platformer foreground,
tan-gray gradient with barnacles, rounded shape,
hand-painted illustration, warm tones, painterly texture,
side view, transparent background PNG, no sand

NEGATIVE: flat colors, 3D render, ground
```

#### Ocean_Plant_Near_01

**Prompt:**
```
Tropical beach plant for platformer foreground,
bright green gradient leaves, broad leaf shape,
hand-painted style, Rayman Legends inspired,
painterly texture, side view, transparent background PNG, no ground

NEGATIVE: flat colors, 3D render, ground
```

#### Ocean_Crab_Near_01

**Prompt:**
```
Friendly crab for ocean platformer foreground,
red-orange gradient shell, cartoon eyes, cute expression,
hand-painted illustration, whimsical charm,
painterly texture, side view profile,
transparent background PNG, no sand

NEGATIVE: flat colors, 3D render, scary, realistic, ground
```

---

## 📊 Asset Generation Summary

### Total Assets: 79 base (or 80 with wheel animation frames)

| Category | Count | Credits (Estimate) |
|----------|-------|-------------------|
| **Cart** | 1 base (+ optional 3-4 wheel frames) | 5-10 credits |
| **Animals** | 13 | 50-75 credits |
| **Forest** | 13 | 30-50 credits |
| **Mountain** | 13 | 30-50 credits |
| **Desert** | 13 | 30-50 credits |
| **Underwater** | 13 | 30-50 credits |
| **Ocean** | 13 | 30-50 credits |
| **TOTAL** | **79 base assets (80 if wheel frames generated)** | **200-300 credits** |

**Asset Count Note:**
- **79 base assets** = 1 cart + 13 animals + 65 environmental decorations (13 per theme × 5 themes)
- **Optional:** Generate 3-4 wheel rotation frames for cart animation (+1-4 assets)
- **Recommended:** Use Unity's rotation script instead of multiple wheel frames to save credits

---

## 🔄 Generation Workflow

### Phase 1: Cart (Week 6 Day 1)
1. Generate main cart (1 asset)
2. Test in Unity with placeholder animal
3. Verify wheel animation approach

### Phase 2: Core Animals (Week 6 Day 2-3)
1. Generate Cat, Dog, Lion, Bunny (4 animals)
2. Test in Unity positioned behind cart
3. Verify scale and positioning work
4. Adjust prompt if needed

### Phase 3: Remaining Animals (Week 7)
1. Batch generate remaining 9 animals
2. Test each in Unity
3. Ensure consistency across all characters

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

## ✅ Quality Checklist

**For every asset, verify:**

- [ ] Transparent background (PNG format)
- [ ] No ground/base visible below element
- [ ] Proper side view (not isometric)
- [ ] Hand-painted style with gradients
- [ ] Consistent with Rayman Legends aesthetic
- [ ] Appropriate size (scalable in Unity)
- [ ] No harsh cartoon outlines
- [ ] Colors match theme palette
- [ ] Isolated element (no extra objects)

---

## 🎮 Unity Integration Notes

### Cart + Animal Setup

**Cart GameObject:**
- Sprite: Cart asset
- Child: Wheels (if separate) with rotation animation
- Collider: CapsuleCollider2D or BoxCollider2D
- Scripts: CartController.cs

**Animal GameObject:**
- Sprite: Animal in riding pose
- Parent to Cart OR position as child
- Position: Slightly behind and inside cart visually
- No collider (collision handled by cart)
- Z-position: Cart at 0, Animal at -0.1 (renders in front)

**Character Switching:**
```csharp
// Swap animal sprite when changing character
public void SetCharacter(Sprite animalSprite)
{
    animalSpriteRenderer.sprite = animalSprite;
}
```

### Environmental Decorations

**Import each PNG:**
- Texture Type: Sprite (2D and UI)
- Pixels Per Unit: 100
- Filter Mode: Bilinear (smooth) or Point (crisp)
- Compression: None or Low Quality

**Assign to Parallax Layers:**
- Far assets → Background_Far sorting layer
- Mid assets → Background_Mid sorting layer
- Near assets → Background_Near sorting layer

**Use BackgroundSpawner.cs** to procedurally place decorations across levels.

---

## 🔧 Post-Processing in Your Software

If you have editing software, you can:

### Consistency Pass:
1. Adjust colors to perfectly match palette
2. Strengthen gradients if too subtle
3. Add soft glow effects to magical elements
4. Ensure all assets have same outline thickness (or none)

### Optimization:
1. Crop excess transparent space
2. Resize to reasonable dimensions (512-2048px height)
3. Save as PNG with transparency preserved

### Variations:
1. Flip assets horizontally for variety
2. Tint duplicates for color variations
3. Scale for different sizes (large/small trees)

---

**Ready to generate!** Start with the cart and 2-3 test animals to validate the style before batch generating all 80 assets. 🎨

---

*Last Updated: 2025-12-29*
*Style: Hand-Painted 2.5D (Rayman Legends Inspired)*
*Total Assets: 80 (1 cart + 13 animals + 65 environmental decorations)*
