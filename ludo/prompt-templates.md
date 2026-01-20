# Ludo.ai Prompt Templates - Quick Reference

**Purpose:** Copy-paste ready templates for consistent asset generation

---

## 🎨 Ludo.ai Global Settings (Copy-Paste for ALL Assets)

```
Art Style: Hand-Painted
Perspective: 2.5D
Genre: Platformer
```

---

## 🎯 Project Context (Paste into Ludo.ai Project Description)

```
Adventures of the World - 2D auto-scrolling platformer with 13 animal characters riding a wooden cart through 5 themed environments (Forest, Mountain, Desert, Underwater, Ocean). Hand-painted 2.5D style inspired by Rayman Legends.

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

## 📝 Ludo.ai Prompting Syntax Guide

**Ludo.ai supports three methods for excluding/de-emphasizing elements:**

### Method 1: `--no` Parameter (Recommended)
**Best for:** Hard exclusions of specific objects or elements

**Syntax:**
```
[Your description] --no [element1] --no [element2] --no [element3]
```

**Example:**
```
Forest tree with vibrant leaves --no ground --no roots --no base --no 3D --no isometric
```

### Method 2: Weighting `::-1`
**Best for:** Fine control over style attributes and subtle de-emphasis

**Syntax:**
```
[Desired element]::1 [Element to reduce]::-1 [Another to reduce]::-1
```

**Example:**
```
Hand-painted tree::1 vibrant gradient::1 flat colors::-1 3D render::-1 vector::-1
```

### Method 3: Natural Language
**Best for:** Complex contextual descriptions

**Syntax:**
```
[Description], without [unwanted elements], excluding [other elements]
```

**Example:**
```
A wooden cart in Rayman Legends style, without any character inside, without ground or base below
```

### When to Use Each Method

| Situation | Recommended Method | Example |
|-----------|-------------------|---------|
| Exclude objects (ground, cart, base) | `--no` | `--no ground --no base` |
| Control art style (3D vs 2D, flat vs gradient) | Weighting `::` | `hand-painted::1 3D render::-1` |
| Complex multi-part exclusions | Natural language | `without character, ground, or rails` |
| Lighting exclusions | `--no` or Natural | `--no bottom lighting --no harsh shadows` |

---

## 🛒 Template 1: The Cart

**Using `--no` (Recommended):**
```
Wooden mine cart for 2D platformer game, Rayman Legends style,
vibrant hand-painted illustration, looking to the right/East, side view profile,
rich brown wood with gradient shading, magical fantasy feel,
sturdy wheels visible, painterly texture,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on top-left wooden planks, rim lighting,
transparent background PNG, isolated cart element, whimsical adventure aesthetic,
empty cart without any character inside
--no character --no ground --no rails --no 3D --no isometric
--no cartoon outlines --no harsh shadows --no bottom lighting
```

**Using Weighting:**
```
Wooden mine cart, Rayman Legends style, hand-painted::1, brown wood, gradient shading,
wheels visible, upper-left lighting, transparent PNG, side view, empty
flat colors::-1 3D render::-1 character::-1 ground::-1 rails::-1
```

---

## 🐾 Template 2: Animal Characters (Fill in [BRACKETS])

**Using `--no` (Recommended):**
```
[ANIMAL NAME] character for 2D platformer game, Rayman Legends inspired,
sitting upright in riding pose, looking to the right/East, side view profile,
[COLOR DESCRIPTION - e.g., "orange tabby fur with white belly"],
gradient shading, vibrant hand-painted illustration,
[EXPRESSION - e.g., "friendly smile, green eyes"],
painterly texture, whimsical fantasy style,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on face and left side, subtle rim lighting,
transparent background PNG, isolated character, full body visible
--no cart --no vehicle --no ground --no standing pose --no 3D --no isometric
--no cartoon outlines --no harsh shadows --no bottom lighting
```

**Using Weighting:**
```
[ANIMAL NAME], Rayman Legends style, hand-painted::1, sitting riding pose::1,
side view, [COLORS], gradient shading, [EXPRESSION], painterly texture,
upper-left lighting, transparent PNG, full body
flat colors::-1 3D render::-1 standing::-1 cart::-1 ground::-1
```

**Using Natural Language:**
```
[ANIMAL NAME] character for 2D platformer, Rayman Legends style, sitting in riding pose,
[COLORS] with gradient shading, [EXPRESSION], painterly hand-painted illustration,
upper-left lighting, transparent PNG side view, without any cart or vehicle,
without ground or base, isolated character only
```

### Animal Character Quick Fill Examples:

**Cat (Free - Default):**
- Color: `orange tabby fur with white belly, gradient shading on fur`
- Expression: `green eyes, friendly smile, cute whiskers`

**Dog (500 coins):**
- Color: `brown fur with cream chest, floppy ears`
- Expression: `happy expression with tongue out`

**Lion (1500 coins):**
- Color: `golden yellow fur with magnificent orange-red mane`
- Expression: `noble expression, confident smile`

**Bunny (700 coins):**
- Color: `fluffy white fur with pink inner ears, cotton tail visible`
- Expression: `happy expression with buckteeth showing, big eyes`

---

## 🌲 Template 3: Environmental Decorations - FAR LAYER

**Using `--no` (Recommended):**
```
[OBJECT - e.g., "Mountain silhouette"] for [THEME] platformer background,
Rayman Legends style, [THEME COLOR PALETTE],
hand-painted illustration, painterly texture,
atmospheric depth, [SPECIFIC DETAILS - e.g., "soft fog effect at base"],
soft directional lighting from upper-left, gentle shadows to lower-right,
[LIGHTING NOTES - e.g., "misty atmosphere, dark blue-green gradient"],
transparent background PNG, side view, isolated element
--no ground --no base --no 3D --no isometric --no harsh edges --no bottom lighting
```

**Using Weighting:**
```
[OBJECT], [THEME] background, Rayman Legends style, hand-painted::1,
[COLOR PALETTE], painterly texture, atmospheric depth, [DETAILS],
upper-left lighting, transparent PNG, side view
flat colors::-1 3D render::-1 ground::-1 base::-1
```

### Far Layer Examples:

**Forest Mountain:**
```
Distant mountain silhouette for forest platformer background,
Rayman Legends style, dark blue-green gradient shading,
soft fog effect at base, hand-painted illustration,
painterly texture, atmospheric depth, fantasy landscape,
soft directional lighting from upper-left, gentle shadows to lower-right,
transparent background PNG, side view, layered peaks
--no ground --no base --no 3D --no isometric --no harsh edges
```

**Desert Dune:**
```
Sand dune silhouette for desert platformer background,
warm orange to pale yellow gradient, soft curves,
hand-painted illustration, heat shimmer effect,
atmospheric depth, painterly texture, side view,
soft directional lighting from upper-left, gentle shadows to lower-right,
transparent background PNG, rolling dune
--no ground --no base --no harsh edges --no 3D
```

---

## 🌳 Template 4: Environmental Decorations - MID LAYER

**Using `--no` (Recommended):**
```
[OBJECT - e.g., "Oak tree"] for [THEME] platformer midground,
Rayman Legends style, [THEME COLOR PALETTE],
hand-painted illustration, painterly texture,
[SPECIFIC DETAILS - e.g., "full leafy canopy, rich brown bark"],
soft directional lighting from upper-left, gentle shadows to lower-right,
[LIGHTING NOTES - e.g., "brighter foliage on left, darker gradient on right"],
transparent background PNG, looking to the right/East, side view profile, isolated element
--no ground --no roots --no base --no 3D --no isometric --no cartoon outlines
```

**Using Weighting:**
```
[OBJECT], [THEME] midground, Rayman Legends style, hand-painted::1,
[COLORS], painterly texture, [DETAILS], upper-left lighting, side view
flat colors::-1 3D render::-1 ground::-1 roots::-1
```

### Mid Layer Examples:

**Forest Tree:**
```
Large oak tree for forest platformer midground,
Rayman Legends style, vibrant green gradient leaves from dark to bright,
rich brown bark with texture gradient, full leafy canopy,
hand-painted illustration, soft highlights, painterly texture,
magical forest atmosphere, looking to the right/East, side view profile,
soft directional lighting from upper-left, gentle shadows to lower-right,
brighter foliage on left side, darker gradient on right,
warm highlights on top-left branches,
transparent background PNG, isolated tree
--no ground --no roots --no 3D --no isometric --no cartoon outlines
```

**Mountain Rock:**
```
Large rocky outcrop for mountain platformer midground,
gray stone with gradient shading, angular facets,
hand-painted illustration, cool blue-gray tones,
painterly texture, looking to the right/East, side view profile, rugged appearance,
soft directional lighting from upper-left, gentle shadows to lower-right,
highlighted top-left surface, darker lower-right,
transparent background PNG, isolated rock formation
--no ground --no 3D --no cartoon outlines
```

---

## 🌿 Template 5: Environmental Decorations - NEAR LAYER

**Using `--no` (Recommended):**
```
[OBJECT - e.g., "Bush"] for [THEME] platformer foreground,
Rayman Legends style, [THEME COLOR PALETTE],
hand-painted illustration, painterly texture,
[SPECIFIC DETAILS - e.g., "leafy clusters, rounded organic shape"],
soft directional lighting from upper-left, gentle shadows to lower-right,
[LIGHTING NOTES - e.g., "warm highlights on left, soft shadow on right"],
transparent background PNG, looking to the right/East, side view profile, isolated element
--no ground --no base --no 3D --no cartoon outlines
```

**Using Weighting:**
```
[OBJECT], [THEME] foreground, Rayman Legends style, hand-painted::1,
[COLORS], painterly texture, [DETAILS], upper-left lighting, side view
flat colors::-1 3D render::-1 ground::-1 base::-1
```

### Near Layer Examples:

**Forest Bush:**
```
Lush bush for forest platformer foreground,
vibrant bright green gradient foliage, leafy clusters,
hand-painted illustration, Rayman Legends inspired,
soft highlights and shadows, painterly texture,
rounded organic shape, looking to the right/East, side view profile,
soft directional lighting from upper-left, gentle shadows to lower-right,
warm highlights on top-left leaves, darker gradient on right,
transparent background PNG, isolated bush
--no ground --no 3D --no cartoon outlines
```

**Desert Rock:**
```
Desert rock for platformer foreground,
orange-red with gradient shading, angular shape,
hand-painted illustration, warm tones, painterly texture,
looking to the right/East, side view profile,
soft directional lighting from upper-left, gentle shadows to lower-right,
highlighted top-left surface, darker lower-right side,
transparent background PNG
--no ground --no sand --no 3D --no cartoon outlines
```

---

## 🎨 Color Palette Quick Reference

### Forest
```
Primary: #6ABF4B (vibrant green)
Secondary: #2D5016 (dark forest green)
Accent: #5C4033 (rich brown)
Sky: #87CEEB (soft blue)
```

### Mountain
```
Primary: #4A5A6A (blue-gray stone)
Secondary: #BFBFBF (light gray)
Accent: #B8B8D1 (purple-gray)
Highlight: #F0F8FF (snow white)
```

### Desert
```
Primary: #FF8C42 (warm orange)
Secondary: #D2691E (orange-brown)
Accent: #FFE4B5 (pale yellow)
Vegetation: #9CAF88 (sage green)
```

### Underwater
```
Primary: #00CED1 (aqua blue)
Secondary: #003D5C (deep blue)
Accent: #9370DB (purple)
Coral: #FF6F91 (pink)
```

### Ocean/Beach
```
Primary: #0077BE (ocean blue)
Secondary: #C2B280 (sandy tan)
Accent: #00A86B (tropical green)
Highlight: #FF7F50 (coral orange)
```

---

## 📝 Universal Exclusions (Use with ALL Assets)

### Basic Exclusions (Use `--no`)

**Add to every prompt:**
```
--no ground --no base --no 3D --no isometric --no cartoon outlines
```

### Comprehensive Exclusions (For Problematic Generations)

**When getting unwanted results, use:**
```
--no ground --no base --no floor --no 3D --no isometric --no cartoon outlines
--no harsh shadows --no bottom lighting --no flat lighting --no vector style
--no realistic --no anime --no cel-shaded
```

### Using Weighting for Style Control

**Alternative approach:**
```
hand-painted gradient::1 painterly texture::1 soft edges::1
flat colors::-1 3D render::-1 vector::-1 outlines::-1 ground::-1
```

---

## ⚡ Quick Generation Checklist

Before submitting prompt, verify:

- [ ] Ludo.ai settings: Hand-Painted + 2.5D + Platformer
- [ ] Upper-left lighting phrase included
- [ ] "transparent background PNG" included
- [ ] "side view profile" included
- [ ] Theme color palette referenced (if environmental)
- [ ] Rayman Legends style mentioned
- [ ] `--no` exclusions added (at minimum: `--no ground --no base --no 3D`)
- [ ] Specific details unique to this asset included

---

## 🔄 Batch Generation Tips

**When generating multiple similar assets:**

1. **Start with 1-2 test assets** to validate style
2. **Use consistent base template** for the category
3. **Only change:** Object name, specific colors, unique details
4. **Keep constant:** Lighting, style keywords, negative prompts, format requirements
5. **Test in Unity** before generating full batch

**Example Batch: Forest Trees**

Tree 1 (Oak):
```
Large oak tree for forest platformer midground,
Rayman Legends style, vibrant green gradient leaves...
[REST OF MID LAYER TEMPLATE]
```

Tree 2 (Pine):
```
Tall pine tree for forest platformer midground,
darker green gradient needles, brown trunk, conical shape...
[REST OF MID LAYER TEMPLATE]
```

Tree 3 (Birch):
```
Birch tree for forest platformer midground,
white bark with dark markings, light green gradient leaves...
[REST OF MID LAYER TEMPLATE]
```

**Notice:** Only the first line changes. Base template stays identical.

---

## 💡 Troubleshooting Common Issues

### Issue: Getting 3D/Isometric Results
**Fix using `--no`:**
```
--no 3D --no isometric --no 3/4 view --no perspective --no depth angle
```
**Strengthen in main prompt:** `pure 2D side view, flat side profile`

### Issue: Getting Ground/Base Under Objects
**Fix using `--no`:**
```
--no ground --no base --no floor --no platform --no terrain --no shadow below
```
**Strengthen in main prompt:** `isolated element, floating`

### Issue: Flat Vector Style (Not Painterly)
**Fix using weighting:**
```
painterly brushstrokes::1 gradient shading::1 soft texture::1
flat colors::-1 vector graphics::-1 hard edges::-1
```
**Strengthen in main prompt:** `hand-painted illustration, traditional painting feel`

### Issue: Wrong Lighting Direction
**Fix using `--no`:**
```
--no bottom lighting --no right-side lighting --no top-down lighting --no flat lighting
```
**Strengthen in main prompt:** `IMPORTANT: light source from upper-left at 45 degrees, shadows cast to lower-right`

### Issue: Thick Cartoon Outlines
**Fix using `--no`:**
```
--no outlines --no cartoon outlines --no black borders --no vector lines
```
**Strengthen in main prompt:** `soft edges, blended transitions`

---

## 📊 Asset Generation Order (Recommended)

1. **Cart** (1 asset) - Test first, all characters need it
2. **Cat, Dog, Lion, Bunny** (4 animals) - Validate character style
3. **Remaining 9 animals** - Batch generate once style confirmed
4. **Forest Far Layer** (3 assets) - Test parallax system
5. **Forest Mid Layer** (5 assets)
6. **Forest Near Layer** (5 assets)
7. **Mountain, Desert, Underwater, Ocean** (13 each) - Full environment batches

---

**Last Updated:** 2026-01-17
**For:** Adventures of the World - Hand-Painted 2.5D Platformer
**See Also:** `/ludo/ludo-ai-project-brief.md` for comprehensive reference
