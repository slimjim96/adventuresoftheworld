# Ludo.ai UI & Platform Assets Guide

**Additional asset prompts for UI elements, platform borders, and menu systems**

Hand-Painted 2.5D style inspired by Rayman Legends

---

## 📋 Overview

This guide covers **non-gameplay assets** needed for UI, menus, and platform decoration:

| Category | Count | Purpose |
|----------|-------|---------|
| **Platform Borders** | 15 patterns (3 per theme × 5 themes) | Tileable borders for platforms |
| **Player Select Icons** | 14 icons (13 animals + 1 cart) | Character selection screen |
| **Menu UI Elements** | 8-10 assets | Buttons, panels, frames (9-slice compatible) |
| **Welcome Screen** | 1 background | Title/splash screen |
| **TOTAL** | **38-40 UI assets** | ~75-100 credits estimated |

---

## 🎨 Universal UI Asset Settings

**Ludo.ai Settings (same as all assets):**
```
Art Style: Hand-Painted
Perspective: 2.5D
Genre: Platformer
```

**Critical for ALL UI assets:**
- Hand-painted 2.5D style (Rayman Legends inspired)
- Vibrant, saturated colors with gradient shading
- Painterly textures (brushstroke feel)
- Whimsical, fantasy aesthetic
- Upper-left lighting (45° from top-left)
- Soft shadows to lower-right

---

## 🧱 Part 1: Platform Borders (15 Assets)

### Purpose
Repeatable patterns that tile horizontally as borders/edges for platforms. Think decorative trim that adds visual interest to platform edges.

### Requirements
- **Seamless tiling:** Left and right edges must connect perfectly
- **Horizontal orientation:** Pattern repeats left-to-right
- **Theme-matched:** Uses corresponding world theme colors
- **Multiple variations:** 3 different patterns per theme (like skins)
- **Transparent background:** PNG format
- **Width:** Suggest ~512-1024px wide for tiling

---

### 🌲 Forest Platform Borders (3 Variations)

**Color Palette:** Vibrant green `#6ABF4B`, Deep forest green `#2D5016`, Rich brown `#5C4033`

#### Forest Border - Variation 1 (Vines & Leaves)

**Using `--no`:**
```
Seamless tileable horizontal border pattern for forest platformer,
Rayman Legends style, hand-painted illustration,
decorative vine with green leaves and small flowers,
vibrant green #6ABF4B leaves, brown #5C4033 vine,
gradient shading, painterly texture, whimsical fantasy style,
organic flowing pattern, repeatable design,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on top-left leaves, natural botanical trim,
transparent background PNG, side view, seamless left-right edges
--no ground --no base --no 3D --no isometric --no cartoon outlines
--no platform --no harsh shadows --no gaps in pattern
```

**Using Weighting:**
```
Seamless forest border pattern, Rayman Legends style, hand-painted::1,
vine with green leaves, gradient shading, organic flowing design,
painterly texture, upper-left lighting, transparent PNG, tileable edges
flat colors::-1 3D render::-1 gaps::-1 non-seamless::-1
```

#### Forest Border - Variation 2 (Mossy Wood)

```
Seamless tileable horizontal border pattern for forest platformer,
Rayman Legends style, hand-painted illustration,
weathered wood planks with green moss patches,
rich brown #5C4033 wood, vibrant moss #6ABF4B accents,
gradient shading, painterly texture, fantasy woodland trim,
rustic natural pattern, repeatable design,
soft directional lighting from upper-left, gentle shadows to lower-right,
highlighted moss on top-left, wood grain texture,
transparent background PNG, side view, seamless left-right edges
--no ground --no base --no 3D --no isometric --no cartoon outlines
--no platform --no harsh shadows --no gaps
```

#### Forest Border - Variation 3 (Mushroom Chain)

```
Seamless tileable horizontal border pattern for forest platformer,
Rayman Legends style, hand-painted illustration,
connected small fantasy mushrooms in a decorative chain,
red caps with white spots, green #6ABF4B stems,
gradient shading, painterly texture, magical forest trim,
whimsical repeating pattern, fairy tale aesthetic,
soft directional lighting from upper-left, gentle shadows to lower-right,
highlighted mushroom tops, fantasy botanical design,
transparent background PNG, side view, seamless left-right edges
--no ground --no base --no 3D --no isometric --no cartoon outlines
--no platform --no harsh shadows --no gaps
```

---

### ⛰️ Mountain Platform Borders (3 Variations)

**Color Palette:** Blue-gray stone `#4A5A6A`, Light gray `#BFBFBF`, Purple-gray `#B8B8D1`

#### Mountain Border - Variation 1 (Stone Bricks)

```
Seamless tileable horizontal border pattern for mountain platformer,
Rayman Legends style, hand-painted illustration,
carved stone bricks with alpine runes,
blue-gray stone #4A5A6A, light gray #BFBFBF mortar,
gradient shading, painterly texture, ancient mountain trim,
geometric yet organic pattern, repeatable stone design,
soft directional lighting from upper-left, gentle shadows to lower-right,
highlighted stone edges, weathered carved texture,
transparent background PNG, side view, seamless left-right edges
--no ground --no base --no 3D --no isometric --no cartoon outlines
--no platform --no harsh shadows --no gaps
```

#### Mountain Border - Variation 2 (Ice Crystals)

```
Seamless tileable horizontal border pattern for mountain platformer,
Rayman Legends style, hand-painted illustration,
frozen ice crystal formation in decorative line,
light gray #BFBFBF ice, purple-gray #B8B8D1 shadows,
gradient shading with icy shimmer, painterly texture,
magical crystalline pattern, repeatable frozen design,
soft directional lighting from upper-left, gentle shadows to lower-right,
bright highlights on crystal points, frosted glass effect,
transparent background PNG, side view, seamless left-right edges
--no ground --no base --no 3D --no isometric --no cartoon outlines
--no platform --no harsh shadows --no gaps
```

#### Mountain Border - Variation 3 (Pine Garland)

```
Seamless tileable horizontal border pattern for mountain platformer,
Rayman Legends style, hand-painted illustration,
hardy pine branch garland with small pinecones,
dark green needles, brown pinecones, blue-gray #4A5A6A accents,
gradient shading, painterly texture, alpine botanical trim,
organic draped pattern, repeatable winter design,
soft directional lighting from upper-left, gentle shadows to lower-right,
highlighted pine needles, rustic mountain aesthetic,
transparent background PNG, side view, seamless left-right edges
--no ground --no base --no 3D --no isometric --no cartoon outlines
--no platform --no harsh shadows --no gaps
```

---

### 🏜️ Desert Platform Borders (3 Variations)

**Color Palette:** Warm orange `#FF8C42`, Orange-brown `#D2691E`, Pale yellow `#FFE4B5`

#### Desert Border - Variation 1 (Sandstone Carvings)

```
Seamless tileable horizontal border pattern for desert platformer,
Rayman Legends style, hand-painted illustration,
carved sandstone blocks with ancient desert symbols,
warm orange #FF8C42 stone, orange-brown #D2691E carvings,
gradient shading, painterly texture, ancient ruins trim,
geometric tribal pattern, repeatable sandstone design,
soft directional lighting from upper-left, gentle shadows to lower-right,
sun-baked stone highlights, weathered carved texture,
transparent background PNG, side view, seamless left-right edges
--no ground --no base --no 3D --no isometric --no cartoon outlines
--no platform --no harsh shadows --no gaps
```

#### Desert Border - Variation 2 (Cactus Chain)

```
Seamless tileable horizontal border pattern for desert platformer,
Rayman Legends style, hand-painted illustration,
small barrel cacti in decorative line with desert flowers,
sage green cacti, warm orange #FF8C42 flowers, pale yellow spines,
gradient shading, painterly texture, southwestern botanical trim,
whimsical repeating pattern, desert garden aesthetic,
soft directional lighting from upper-left, gentle shadows to lower-right,
highlighted cactus tops, warm golden-hour glow,
transparent background PNG, side view, seamless left-right edges
--no ground --no base --no 3D --no isometric --no cartoon outlines
--no platform --no harsh shadows --no gaps
```

#### Desert Border - Variation 3 (Rope & Beads)

```
Seamless tileable horizontal border pattern for desert platformer,
Rayman Legends style, hand-painted illustration,
decorative rope with colorful desert beads and tassels,
orange-brown #D2691E rope, warm orange and turquoise beads,
gradient shading, painterly texture, nomadic trim aesthetic,
organic draped pattern, repeatable textile design,
soft directional lighting from upper-left, gentle shadows to lower-right,
highlighted bead surfaces, woven rope texture,
transparent background PNG, side view, seamless left-right edges
--no ground --no base --no 3D --no isometric --no cartoon outlines
--no platform --no harsh shadows --no gaps
```

---

### 🌊 Underwater Platform Borders (3 Variations)

**Color Palette:** Aqua blue `#00CED1`, Bright teal `#0891B2`, Purple `#9370DB`, Coral pink `#FF6F91`

#### Underwater Border - Variation 1 (Coral Reef)

```
Seamless tileable horizontal border pattern for underwater platformer,
Rayman Legends style, hand-painted illustration,
colorful coral reef formation in decorative line,
coral pink #FF6F91 coral, aqua blue #00CED1 accents, purple #9370DB polyps,
gradient shading with underwater glow, painterly texture,
organic reef pattern, repeatable ocean design,
soft diffused lighting from upper-left, very gentle shadows,
magical underwater shimmer, bioluminescent highlights,
transparent background PNG, side view, seamless left-right edges
--no ground --no base --no 3D --no isometric --no cartoon outlines
--no platform --no harsh shadows --no gaps --no ocean floor
```

#### Underwater Border - Variation 2 (Seaweed Garland)

```
Seamless tileable horizontal border pattern for underwater platformer,
Rayman Legends style, hand-painted illustration,
flowing seaweed kelp with small bubbles,
aqua blue #00CED1 kelp, bright teal #0891B2 shadows, white bubbles,
gradient shading with water movement, painterly texture,
organic flowing pattern, repeatable aquatic design,
soft diffused lighting from upper-left, gentle underwater glow,
wavy motion effect, magical ocean trim,
transparent background PNG, side view, seamless left-right edges
--no ground --no base --no 3D --no isometric --no cartoon outlines
--no platform --no harsh shadows --no gaps --no ocean floor
```

#### Underwater Border - Variation 3 (Pearl String)

```
Seamless tileable horizontal border pattern for underwater platformer,
Rayman Legends style, hand-painted illustration,
decorative string of pearls with small seashells,
white pearls with pink #FF6F91 iridescence, purple #9370DB shells,
gradient shading with pearl shimmer, painterly texture,
elegant repeating pattern, magical jewelry design,
soft diffused lighting from upper-left, gentle underwater glow,
lustrous pearl highlights, treasure aesthetic,
transparent background PNG, side view, seamless left-right edges
--no ground --no base --no 3D --no isometric --no cartoon outlines
--no platform --no harsh shadows --no gaps --no ocean floor
```

---

### 🌴 Ocean/Beach Platform Borders (3 Variations)

**Color Palette:** Ocean blue `#0077BE`, Sandy tan `#C2B280`, Tropical green `#00A86B`, Coral `#FF7F50`

#### Ocean Border - Variation 1 (Bamboo Fence)

```
Seamless tileable horizontal border pattern for ocean platformer,
Rayman Legends style, hand-painted illustration,
tropical bamboo fence with palm leaf accents,
sandy tan #C2B280 bamboo, tropical green #00A86B leaves,
gradient shading, painterly texture, tiki island trim,
geometric organic pattern, repeatable tropical design,
soft directional lighting from upper-left, gentle shadows to lower-right,
sun-kissed bamboo highlights, beach resort aesthetic,
transparent background PNG, side view, seamless left-right edges
--no ground --no base --no 3D --no isometric --no cartoon outlines
--no platform --no harsh shadows --no gaps --no sand
```

#### Ocean Border - Variation 2 (Tropical Flower Lei)

```
Seamless tileable horizontal border pattern for ocean platformer,
Rayman Legends style, hand-painted illustration,
tropical flower lei garland with hibiscus blooms,
coral #FF7F50 hibiscus, tropical green #00A86B leaves, ocean blue accents,
gradient shading, painterly texture, Hawaiian botanical trim,
organic draped pattern, repeatable floral design,
soft directional lighting from upper-left, gentle shadows to lower-right,
bright petal highlights, island paradise aesthetic,
transparent background PNG, side view, seamless left-right edges
--no ground --no base --no 3D --no isometric --no cartoon outlines
--no platform --no harsh shadows --no gaps --no sand
```

#### Ocean Border - Variation 3 (Nautical Rope)

```
Seamless tileable horizontal border pattern for ocean platformer,
Rayman Legends style, hand-painted illustration,
thick nautical rope with starfish and shell decorations,
sandy tan #C2B280 rope, coral #FF7F50 starfish, ocean blue details,
gradient shading, painterly texture, maritime trim aesthetic,
organic twisted pattern, repeatable sailor design,
soft directional lighting from upper-left, gentle shadows to lower-right,
highlighted rope fibers, beach shack decor style,
transparent background PNG, side view, seamless left-right edges
--no ground --no base --no 3D --no isometric --no cartoon outlines
--no platform --no harsh shadows --no gaps --no sand
```

---

## 🎭 Part 2: Player Select Icons (14 Assets)

### Purpose
Character portraits for character selection screen. Small, recognizable icons showing each animal + the cart.

### Requirements
- **Circular or square format:** Suggest 512×512px
- **Consistent framing:** Same composition for all
- **Portrait style:** Head/upper body focus (not full body)
- **Recognizable:** Clear at small sizes (down to 64×64px)
- **Transparent background:** PNG format
- **Upper-left lighting:** Consistent with game aesthetic
- **Friendly expression:** Welcoming, inviting

---

### Universal Icon Prompt Template

**Using `--no`:**
```
Character portrait icon for [ANIMAL/CART] in 2D platformer game,
Rayman Legends style, hand-painted illustration, circular portrait composition,
[COLOR DESCRIPTION], vibrant gradient shading, friendly welcoming expression,
[SPECIFIC DETAILS - facial features, personality],
painterly texture, whimsical fantasy style, portrait close-up,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on face and features, character select screen aesthetic,
transparent background PNG, centered composition, recognizable at small size
--no full body --no cart visible --no ground --no 3D --no isometric
--no cartoon outlines --no harsh shadows --no busy background
```

**Using Weighting:**
```
[ANIMAL] portrait icon, Rayman Legends style, hand-painted::1, circular frame,
[COLORS], gradient shading, friendly expression, close-up, painterly texture,
upper-left lighting, transparent PNG, recognizable
full body::-1 3D render::-1 busy background::-1 outlines::-1
```

---

### Icon Examples

#### Cat Icon (Default Character)

```
Character portrait icon for Cat in 2D platformer game,
Rayman Legends style, hand-painted illustration, circular portrait composition,
orange tabby fur with white chest, green eyes, friendly smile,
vibrant gradient shading on fur, cute whiskers, perky ears,
painterly texture, whimsical fantasy style, portrait close-up,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on face and left ear, character select aesthetic,
curious and agile personality, welcoming expression,
transparent background PNG, centered composition, recognizable at small size
--no full body --no cart --no ground --no 3D --no isometric
--no cartoon outlines --no harsh shadows --no busy background
```

#### Dog Icon

```
Character portrait icon for Dog in 2D platformer game,
Rayman Legends style, hand-painted illustration, circular portrait composition,
brown fur with cream chest, floppy ears, happy expression with tongue out,
vibrant gradient shading on fur, friendly brown eyes,
painterly texture, whimsical fantasy style, portrait close-up,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on face and left ear, character select aesthetic,
loyal and energetic personality, welcoming smile,
transparent background PNG, centered composition, recognizable at small size
--no full body --no cart --no ground --no 3D --no isometric
--no cartoon outlines --no harsh shadows --no busy background
```

#### Unicorn Icon

```
Character portrait icon for Unicorn in 2D platformer game,
Rayman Legends style, hand-painted illustration, circular portrait composition,
white coat with iridescent sheen, rainbow mane, golden horn,
vibrant gradient shading, kind blue eyes, magical sparkles,
painterly texture, whimsical fantasy style, portrait close-up,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on face and golden horn, character select aesthetic,
magical and graceful personality, gentle expression,
transparent background PNG, centered composition, recognizable at small size
--no full body --no cart --no ground --no 3D --no isometric
--no cartoon outlines --no harsh shadows --no busy background
```

#### Cart Icon (Equipment Icon)

```
Equipment icon for Wooden Cart in 2D platformer game,
Rayman Legends style, hand-painted illustration, circular icon composition,
rich brown wood with gradient shading, visible wheels,
vibrant wood texture, magical fantasy feel, empty cart,
painterly texture, whimsical adventure style, isometric-style view for icon,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on top-left planks, equipment select aesthetic,
transparent background PNG, centered composition, recognizable at small size
--no character --no ground --no rails --no 3D full render --no cartoon outlines
--no harsh shadows --no busy background
```

**Note:** Generate all 13 animal icons + 1 cart icon = **14 total icons**

---

## 🎮 Part 3: Menu UI Elements (8-10 Assets)

### Purpose
Reusable UI components for menus, buttons, and panels. Should support 9-slice scaling for different sizes.

### Requirements
- **9-slice compatible:** Corner, edge, and center regions can be identified
- **Consistent style:** All UI elements match aesthetically
- **Hand-painted look:** Not flat digital UI, painterly texture
- **Whimsical theme:** Wooden/fantasy aesthetic matching game
- **Multiple states:** Consider normal, hover, pressed (can generate separately)
- **Transparent background:** PNG format

---

### UI Element Prompts

#### 1. Wooden Button (Small)

**Using `--no`:**
```
Wooden button UI element for fantasy platformer menu,
Rayman Legends style, hand-painted illustration,
rich brown wood planks with carved border,
gradient shading on wood surface, painterly texture,
slightly rounded rectangular shape, whimsical fantasy style,
decorative carved edges, rustic game UI aesthetic,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on top-left corner, button appearance,
transparent background PNG, flat view, 9-slice scalable design,
empty button without text or icons inside
--no 3D --no isometric --no cartoon outlines --no harsh shadows
--no text --no icons --no ground --no overly detailed
```

**Dimensions:** Suggest 256×128px for 9-slice base

#### 2. Wooden Panel (Large)

```
Wooden panel UI element for fantasy platformer menu,
Rayman Legends style, hand-painted illustration,
weathered wooden board with decorative frame border,
rich brown wood #5C4033, gradient shading, painterly texture,
ornate corner decorations, fantasy medieval aesthetic,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on frame edges, game menu panel appearance,
transparent background PNG, flat view, 9-slice scalable design,
empty panel for content placement
--no 3D --no isometric --no cartoon outlines --no harsh shadows
--no text --no icons --no ground --no characters
```

**Dimensions:** Suggest 512×512px for 9-slice base

#### 3. Decorative Frame (Window Border)

```
Decorative window frame UI element for fantasy platformer menu,
Rayman Legends style, hand-painted illustration,
ornate wooden frame with carved vines and leaves,
rich brown wood with vibrant green leaf accents,
gradient shading, painterly texture, whimsical fantasy border,
nature-themed carved details, storybook aesthetic,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on carved edges, elegant game UI frame,
transparent background PNG, flat view, 9-slice scalable design,
hollow center for content window
--no 3D --no isometric --no cartoon outlines --no harsh shadows
--no text --no solid background --no ground
```

**Dimensions:** Suggest 512×512px for 9-slice base

#### 4. Round Button (Icon Button)

```
Round wooden button UI element for fantasy platformer menu,
Rayman Legends style, hand-painted illustration,
circular wood disc with carved rim border,
gradient shading on wood surface, painterly texture,
slightly beveled appearance, whimsical fantasy style,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on top-left edge, icon button aesthetic,
transparent background PNG, centered circular design,
empty button for icon placement
--no 3D --no isometric --no cartoon outlines --no harsh shadows
--no text --no icons --no ground --no square shape
```

**Dimensions:** Suggest 256×256px circular

#### 5. Progress Bar Container

```
Progress bar container UI element for fantasy platformer menu,
Rayman Legends style, hand-painted illustration,
long horizontal wooden plank with carved groove channel,
rich brown wood, gradient shading, painterly texture,
decorative carved ends, fantasy game UI aesthetic,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on top edge, progress bar frame appearance,
transparent background PNG, flat view, 9-slice horizontal scalable,
empty groove for progress fill
--no 3D --no isometric --no cartoon outlines --no harsh shadows
--no fill --no text --no ground --no vertical orientation
```

**Dimensions:** Suggest 512×128px for 9-slice base

#### 6. Progress Bar Fill

```
Progress bar fill element for fantasy platformer menu,
Rayman Legends style, hand-painted illustration,
smooth gradient fill bar with magical glow effect,
vibrant green #6ABF4B to yellow gradient, soft shimmer,
painterly texture, whimsical energy aesthetic,
soft internal glow, magical progress indicator,
transparent background PNG, flat view, horizontal scalable,
clean simple shape for easy stretching
--no 3D --no isometric --no cartoon outlines --no harsh shadows
--no border --no frame --no ground --no vertical orientation
```

**Dimensions:** Suggest 512×96px stretchable

#### 7. Tab Button (Top)

```
Tab button UI element for fantasy platformer menu,
Rayman Legends style, hand-painted illustration,
wooden tab shape with curved top edge,
rich brown wood, gradient shading, painterly texture,
slightly raised appearance, fantasy game UI aesthetic,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on top edge, menu tab appearance,
transparent background PNG, flat view, horizontally scalable,
empty tab for text or icon placement
--no 3D --no isometric --no cartoon outlines --no harsh shadows
--no text --no icons --no ground --no rectangular shape
```

**Dimensions:** Suggest 256×128px for 9-slice base

#### 8. Dialog Box (Speech Bubble)

```
Dialog box UI element for fantasy platformer game,
Rayman Legends style, hand-painted illustration,
wooden speech bubble with ornate carved border,
rich brown wood, gradient shading, painterly texture,
whimsical speech tail pointer, storybook aesthetic,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on frame edges, character dialog appearance,
transparent background PNG, flat view, 9-slice scalable design,
empty interior for text content
--no 3D --no isometric --no cartoon outlines --no harsh shadows
--no text --no characters --no ground
```

**Dimensions:** Suggest 512×256px for 9-slice base

---

## 🎨 Part 4: Full Screen Backgrounds (5 Assets)

### Purpose
Full-screen background images for main menu screens. Each screen has a distinct purpose and visual focus while maintaining the unified hand-painted aesthetic.

### Requirements (All Backgrounds)
- **Full screen:** 16:9 aspect ratio (1920×1080px)
- **UI-friendly:** Darker or muted areas where UI elements will overlay
- **Layered composition:** Background + midground + foreground depth
- **Hand-painted style:** Consistent with Rayman Legends aesthetic
- **Upper-left lighting:** 45° from top-left with soft shadows

---

### 4.1 Welcome/Start Screen Background

**Purpose:** Title/splash screen that showcases the game's artistic theme and sets the tone.

**Requirements:**
- **Logo space:** Leave clean space in upper/center for game logo
- **Character showcase:** Optional - can include silhouettes of animals
- **Whimsical atmosphere:** Inviting, magical, adventurous

---

**Prompt (Desktop 16:9):**

```
Title screen background illustration for Adventures of the World platformer game,
Rayman Legends inspired, hand-painted 2.5D style,
whimsical fantasy landscape with all five world themes represented,
left side: magical forest with vibrant green trees and colorful mushrooms,
center background: snow-capped alpine mountains under fluffy clouds,
right side: golden desert dunes with cacti at sunset,
lower corners: underwater coral reef and tropical beach elements,
layered composition with atmospheric depth, magical adventure aesthetic,
vibrant hand-painted illustration, rich gradients on all elements,
painterly texture throughout, storybook fantasy atmosphere,
soft directional lighting from upper-left, warm golden-hour glow,
gentle shadows to lower-right, rim lighting on featured elements,
clean open space in upper center for game logo placement,
welcoming and inviting composition, family-friendly visual,
full 16:9 widescreen format, detailed background illustration
--no characters --no text --no logos --no UI elements --no 3D render
--no isometric --no harsh shadows --no busy center area --no dark atmosphere
```

**Alternative with emphasis on character silhouettes:**
```
Title screen background for Adventures of the World platformer,
Rayman Legends style, hand-painted illustration,
whimsical fantasy world panorama with animal character silhouettes,
magical landscape blending forest, mountains, desert, ocean, underwater themes,
foreground: wooden mine cart with silhouettes of playable animals,
mid-ground: vibrant themed environments transitioning left to right,
background: atmospheric mountains and sky with puffy clouds,
rich gradients, painterly texture, storybook adventure aesthetic,
soft directional lighting from upper-left, warm inviting glow,
clean space at top for logo, 16:9 widescreen composition,
welcoming title screen atmosphere, family-friendly fantasy art
--no detailed character faces --no text --no logos --no UI --no 3D
--no isometric --no harsh shadows --no dark tone
```

---

### 4.2 Settings Screen Background

**Purpose:** Calm, focused background for game settings/options. Should feel cozy and functional without distracting from UI controls.

**Requirements:**
- **Calm atmosphere:** Less visual activity than other screens
- **Warm tones:** Cozy workshop/library aesthetic
- **Central focus area:** Darker/muted center for settings panel overlay
- **Mechanical hints:** Gears, dials, or workshop elements suggest "adjustable" theme

**Prompt (Desktop 16:9):**

```
Settings menu background illustration for fantasy platformer game,
Rayman Legends inspired, hand-painted 2.5D style,
cozy fantasy workshop interior with magical atmosphere,
wooden walls with decorative carved panels and shelving,
soft warm lighting from lanterns and candles, evening ambiance,
large wooden workbench in center-right (muted for UI overlay area),
decorative gears, dials, and mechanical elements on walls suggesting adjustability,
bottles, books, and magical trinkets on shelves in corners,
rich brown wood tones with warm orange candlelight accents,
gradient shading throughout, painterly texture on all surfaces,
soft directional lighting from upper-left, gentle shadows to lower-right,
darker central area for settings panel placement,
warm inviting craftsman workshop atmosphere, fantasy game aesthetic,
full 16:9 widescreen format, cozy interior composition
--no characters --no text --no UI elements --no 3D render --no isometric
--no harsh shadows --no bright center --no exterior views --no cold tones
```

---

### 4.3 Choose Your Player Screen Background

**Purpose:** Character selection screen showcasing the animal theme. Should feel like a gathering place where characters await selection.

**Requirements:**
- **Character showcase space:** Central area for character portraits/carousel
- **Gathering atmosphere:** Cozy barn, stable, or camp where animals would gather
- **Warm lighting:** Inviting, friendly feeling
- **Forest theme dominance:** First world theme as primary aesthetic

**Prompt (Desktop 16:9):**

```
Character select screen background for fantasy platformer game,
Rayman Legends inspired, hand-painted 2.5D style,
magical forest clearing with cheerful animal gathering spot,
large ancient tree in background with fairy lights and glowing mushrooms,
cozy wooden platform or stage area in center (muted for character display overlay),
forest floor with soft grass and scattered wildflowers in foreground corners,
warm dappled sunlight filtering through canopy, morning forest atmosphere,
vibrant green #6ABF4B foliage, rich brown #5C4033 wood tones,
small wooden sign posts and carved animal totems on sides,
magical sparkles and fireflies floating in background,
gradient shading throughout, painterly texture on all elements,
soft directional lighting from upper-left, gentle shadows to lower-right,
darker muted center-stage area for character showcase UI,
welcoming animal sanctuary atmosphere, fantasy adventure aesthetic,
full 16:9 widescreen format, magical forest clearing composition
--no characters --no animals visible --no text --no UI elements --no 3D render
--no isometric --no harsh shadows --no busy center --no dark atmosphere
```

---

### 4.4 Choose Your Level/World Screen Background

**Purpose:** Level selection screen that previews all five themed worlds. Should feel like a world map or journey overview.

**Requirements:**
- **All 5 themes represented:** Forest, Mountain, Desert, Underwater, Ocean visible
- **Map/journey aesthetic:** Paths connecting different areas
- **Adventure feeling:** Exciting destinations awaiting exploration
- **Central navigation space:** Area for level select UI/carousel

**Prompt (Desktop 16:9):**

```
Level select world map background for fantasy platformer game,
Rayman Legends inspired, hand-painted 2.5D style,
panoramic fantasy world map showing five distinct biomes,
top-left: magical forest with vibrant green trees and colorful mushrooms,
top-center: snow-capped alpine mountains with rocky peaks and pine trees,
top-right: golden desert with sand dunes and ancient ruins at sunset,
bottom-left: sparkling underwater realm with coral and glowing sea life,
bottom-right: tropical beach paradise with palm trees and ocean waves,
winding adventure path connecting all five regions,
magical floating islands and clouds in sky background,
treasure map aesthetic with hand-painted terrain textures,
central area slightly muted for level selection UI overlay,
vibrant colors for each biome matching theme palettes,
gradient shading throughout, painterly storybook texture,
soft directional lighting from upper-left, warm adventure glow,
exciting destinations atmosphere, journey ahead feeling,
full 16:9 widescreen format, world map overview composition
--no characters --no text --no UI elements --no 3D render --no isometric
--no harsh shadows --no single theme dominance --no realistic map style
```

---

### 4.5 Shop/Store Screen Background (Bonus)

**Purpose:** In-game shop where players unlock characters with coins. Should feel like a magical marketplace.

**Requirements:**
- **Merchant/shop aesthetic:** Market stall or magical emporium
- **Coin/treasure accents:** Hints of currency and rewards
- **Display areas:** Shelving/display spots suggesting items for sale
- **Warm inviting atmosphere:** Encouraging exploration and purchase

**Prompt (Desktop 16:9):**

```
Shop menu background for fantasy platformer game,
Rayman Legends inspired, hand-painted 2.5D style,
magical fantasy marketplace stall interior,
colorful wooden market booth with carved decorations and fabric canopy,
display shelves on left and right sides with glowing magical items,
treasure chests and scattered gold coins in foreground corners,
warm lantern lighting creating inviting merchant atmosphere,
vibrant purple and gold fabric accents, rich wood tones,
magical sparkles and floating price tags aesthetic,
central counter area muted for shop UI overlay,
whimsical fantasy bazaar feeling, storybook merchant booth,
gradient shading throughout, painterly texture on all surfaces,
soft directional lighting from upper-left, warm golden glow,
treasure and rewards atmosphere, exciting unlock anticipation,
full 16:9 widescreen format, fantasy shop interior composition
--no characters --no merchants visible --no text --no UI elements --no 3D render
--no isometric --no harsh shadows --no busy center --no modern store aesthetic
```

---

## 📊 UI Asset Summary

### Total Asset Count

| Category | Assets | Est. Credits |
|----------|--------|--------------|
| Platform Borders | 15 (3 per theme × 5) | 30-40 |
| Player Select Icons | 14 (13 animals + cart) | 20-30 |
| Menu UI Elements | 8-10 | 15-25 |
| Full Screen Backgrounds | 5 (start, settings, player, level, shop) | 25-35 |
| **TOTAL** | **42-44 UI assets** | **100-130 credits** |

---

## 🔄 Generation Workflow

### Phase 1: Platform Borders (Week 8)
1. Start with **Forest borders** (3 variations) - test seamless tiling
2. Import to Unity, test as repeating patterns on platforms
3. If tiling works, batch generate remaining 4 themes (12 more)

### Phase 2: Player Icons (Week 9)
1. Generate **Cat + Dog + Cart icons** (3 test icons)
2. Verify consistent framing and recognizability at small size
3. Batch generate remaining 11 animal icons

### Phase 3: Menu UI (Week 9)
1. Generate **Button + Panel** (2 core elements)
2. Test 9-slice scaling in Unity
3. Generate remaining UI elements (6-8 more)

### Phase 4: Full Screen Backgrounds (Week 9-10)
1. Generate **Start/Welcome Screen** (16:9) - test logo placement
2. Generate **Settings Screen** - test with settings panel overlay
3. Generate **Choose Player Screen** - test with character carousel
4. Generate **Choose Level Screen** - test with level select UI
5. Generate **Shop Screen** - test with shop UI overlay

---

## ✅ Quality Checklist for UI Assets

### Platform Borders
- [ ] Seamless tiling (left edge connects to right edge)
- [ ] Transparent background PNG
- [ ] Theme colors accurate
- [ ] Hand-painted gradient shading visible
- [ ] Upper-left lighting applied
- [ ] No gaps or misalignment when tiled
- [ ] Painterly texture throughout

### Player Icons
- [ ] Consistent circular/square framing
- [ ] Recognizable at 64×64px
- [ ] Friendly, welcoming expression
- [ ] Upper-left lighting applied
- [ ] Transparent background PNG
- [ ] Character personality visible
- [ ] Same composition style across all icons

### Menu UI Elements
- [ ] Clean 9-slice regions identifiable
- [ ] Transparent background PNG
- [ ] Hand-painted wood texture
- [ ] Upper-left lighting applied
- [ ] No text or icons (empty template)
- [ ] Consistent style across all elements
- [ ] Scales well without distortion

### Full Screen Backgrounds
- [ ] Correct aspect ratio (16:9 at 1920×1080px)
- [ ] Clean UI overlay area (muted center where needed)
- [ ] Hand-painted gradient shading throughout
- [ ] Upper-left lighting applied consistently
- [ ] No characters or text (background only)
- [ ] Inviting, whimsical atmosphere
- [ ] Welcoming family-friendly tone
- [ ] Screen-specific theme applied:
  - Start Screen: Logo space, all 5 themes hinted
  - Settings: Cozy workshop, mechanical elements
  - Player Select: Forest clearing, animal gathering spot
  - Level Select: World map with all 5 biomes visible
  - Shop: Magical marketplace, treasure accents

---

## 💡 Tips for UI Asset Generation

### Platform Borders
- **Test tiling immediately:** Import first generation to Unity and test if edges connect seamlessly
- **Keep patterns simple:** Overly complex patterns may not tile well
- **Emphasize theme identity:** Each theme's borders should be instantly recognizable
- **Consider animation:** Some borders could have subtle animated elements later

### Player Icons
- **Batch with consistent prompt:** Generate all icons in same session for consistency
- **Portrait focus:** Chest-up composition works best for icons
- **Expression matters:** Friendly, inviting expressions encourage selection
- **Test small sizes:** View at 64×64px to ensure recognizability

### Menu UI
- **Plan 9-slice regions:** Clear corners, edges, and center for proper scaling
- **Keep decorations on edges:** Center areas should be simple for stretching
- **Test scaling:** Import to Unity and test 9-slice immediately
- **Generate states separately:** Normal, hover, pressed can be separate assets

### Full Screen Backgrounds
- **Leave breathing room:** UI overlay areas should be clean and uncluttered
- **Layer depth:** Clear foreground, midground, background separation
- **Avoid symmetry:** Natural, organic composition feels more alive
- **Test with UI overlay:** Import and place actual UI elements to verify composition
- **Consistent lighting:** All backgrounds use upper-left 45° lighting
- **Muted centers:** Where UI overlays, keep background slightly darker/less busy
- **Theme matching:** Each screen should match its purpose (cozy for settings, adventurous for levels)

---

## 🔗 Related Documentation

- **Main Project Brief:** `/ludo/ludo-ai-project-brief.md`
- **Prompt Templates:** `/ludo/prompt-templates.md`
- **Full Asset Guide:** `/docs/05-art-assets/ludo-ai-asset-guide.md`
- **Character Reference:** `/docs/05-art-assets/character-reference.md`

---

**Last Updated:** 2026-01-17
**Style:** Hand-Painted 2.5D (Rayman Legends Inspired)
**For:** Adventures of the World - Unity 2022.3 LTS
**Total UI Assets:** 39-41 (75-110 credits estimated)
