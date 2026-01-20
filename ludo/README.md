# Ludo.ai Project Resources

This directory contains all resources related to Ludo.ai asset generation for Adventures of the World.

---

## 📁 Files in This Directory

### 📋 `ludo-ai-project-brief.md` ⭐ **START HERE**

**Purpose:** Single-page consolidated reference for consistent asset generation

**Use this when:**
- Starting a new Ludo.ai generation session
- Need quick reference for color palettes
- Want copy-paste project context
- Checking lighting standards
- Verifying quality requirements

**Contains:**
- Critical global Ludo.ai settings
- Universal art direction (lighting, style)
- All 5 world theme specifications with color palettes
- Character design standards for all 13 animals
- Cart specifications
- Environmental decoration system
- Quality control checklist
- Credit budget estimates

---

### 📝 `prompt-templates.md`

**Purpose:** Copy-paste ready prompt templates for each asset type

**Use this when:**
- Actively generating assets in Ludo.ai
- Need quick template for specific asset type
- Want consistent prompt structure
- Troubleshooting generation issues

**Contains:**
- Ready-to-use templates for cart, animals, decorations
- Quick-fill examples for common assets
- Color palette reference
- Universal negative prompts
- Batch generation tips
- Troubleshooting common issues

---

### 🌲 `background-assets-prompts.md` ⭐ **NEW - COMPREHENSIVE**

**Purpose:** Detailed prompts for ALL background/environmental assets with variety and cross-theme reusability

**Use this when:**
- Generating background assets for any of the 5 themes
- Need variety in environmental decorations
- Want to reuse assets across multiple themes (boulders, cliffs, clouds)
- Creating large far-distance elements

**Contains:**
- **Cross-Theme Reusable Assets:**
  - 4 Boulder variations (Forest, Mountain, Desert, Ocean compatible)
  - 3 Cliff variations (Mountain, Desert, Ocean compatible)
  - 4 Cloud variations (all above-water themes)
  - 3 Generic rock variations (all themes)
- **Per-Theme Assets (5 themes × 3 layers):**
  - 5 Far Layer prompts per theme (large distant elements)
  - 7 Mid Layer prompts per theme (trees, structures, formations)
  - 7 Near Layer prompts per theme (bushes, rocks, details)
- **Total:** 100+ detailed, copy-paste ready prompts
- Asset variation tips for color adjustments
- Quick reference tables for compatibility

---

### 🧱 `platform-patterns-prompts.md` ⭐ **NEW**

**Purpose:** Tileable patterns and vector-style curved platforms for all themes

**Use this when:**
- Creating seamless tileable textures for platform surfaces
- Designing curved or non-rectangular platforms
- Need material wrapping for varied platform shapes
- Want vector-clean edges for scalable platform assets

**Contains:**
- **Tileable Surface Patterns (25 prompts):**
  - 5 seamless patterns per theme (stone, wood, organic, decorative)
  - Designed to wrap horizontally without visible seams
- **Vector-Style Curved Platforms (25 prompts):**
  - 5 curved platform shapes per theme (arches, bridges, slopes, domes)
  - Clean vector edges for scalable design
  - Built-in pattern fills matching theme aesthetic
- **Pattern Modifiers:** Weathering, glow, and density variations
- **Implementation Notes:** Unity integration guidance

---

### 🎮 `ui-assets-guide.md`

**Purpose:** Complete prompts for UI elements, platform borders, and menu systems

**Use this when:**
- Generating platform border patterns (tileable)
- Creating player select icons for character menu
- Designing menu UI elements (buttons, panels, frames)
- Creating welcome/title screen backgrounds

**Contains:**
- 15 platform border patterns (3 per theme, seamless tiling)
- 14 player select icons (13 animals + cart)
- 8-10 menu UI elements (9-slice compatible)
- Welcome screen (desktop + mobile versions)
- Total: 39-41 UI assets (~75-110 credits)

---

### 📄 `project-concept.txt`

**Purpose:** Plain text export of complete game concept from Ludo.ai

**Use this for:**
- Reference to original Ludo.ai game concept input
- Understanding core mechanics and specifications
- Development planning context

**Contains:**
- High-level concept
- Playable characters (13 animals)
- Core mechanics breakdown
- Detailed specifications (jump, collision, cart speeds)
- World themes overview
- Technical implementation notes

---

### 🌐 `project.html`

**Purpose:** Saved HTML snapshot of Ludo.ai web interface with project

**Use this for:**
- Visual reference of how project was set up in Ludo.ai
- Understanding Ludo.ai interface structure
- Archival/backup purposes

**Note:** This is a static HTML file for reference only.

---

## 🎯 Quick Start Guide

### First Time Using Ludo.ai for This Project:

1. **Read:** `ludo-ai-project-brief.md` (5 minutes)
2. **Open:** Ludo.ai and create new project or session
3. **Copy:** Project context from brief into Ludo.ai
4. **Set:** Art Style: Hand-Painted, Perspective: 2.5D, Genre: Platformer
5. **Start:** Generate cart first (1 asset) to test
6. **Then:** Generate 2-3 test animals to validate style
7. **Use:** `prompt-templates.md` for copy-paste prompts

### Returning to Asset Generation:

1. **Check:** `prompt-templates.md` for quick template
2. **Verify:** Current world theme color palette in `ludo-ai-project-brief.md`
3. **Copy:** Relevant template
4. **Customize:** Fill in [BRACKETS] with specific details
5. **Generate:** Asset in Ludo.ai
6. **Verify:** Against quality checklist in brief

---

## 🔗 Related Documentation

**Main Asset Documentation:**
- `/docs/05-art-assets/ludo-ai-asset-guide.md` - All 80 detailed asset prompts
- `/docs/05-art-assets/character-reference.md` - Character personalities and details
- `/docs/05-art-assets/asset-metadata-system.md` - Unity integration system

**Project Documentation:**
- `/docs/INDEX.md` - Master documentation index
- `/docs/README.md` - Documentation structure

---

## 💰 Credit Budget Overview

### Gameplay Assets
**Total Assets:** 79-80
**Estimated Credits:** 200-300

| Category | Assets | Credits |
|----------|--------|---------|
| Cart | 1 | 5-10 |
| Animals | 13 | 50-75 |
| Forest | 13 | 30-50 |
| Mountain | 13 | 30-50 |
| Desert | 13 | 30-50 |
| Underwater | 13 | 30-50 |
| Ocean | 13 | 30-50 |

### UI & Menu Assets (NEW)
**Total Assets:** 39-41
**Estimated Credits:** 75-110

| Category | Assets | Credits |
|----------|--------|---------|
| Platform Borders | 15 (3 per theme) | 30-40 |
| Player Select Icons | 14 (13 animals + cart) | 20-30 |
| Menu UI Elements | 8-10 | 15-25 |
| Welcome Screen | 2 (desktop + mobile) | 10-15 |

### Grand Total
**Total Assets:** 118-121
**Estimated Credits:** 275-410

**Recommendation:** Generate cart + 2-3 test animals first (~20-30 credits) to validate style before committing to full production.

---

## ⚠️ Critical Consistency Rules

**ALWAYS use across ALL 79 assets:**

1. **Ludo.ai Settings:** Hand-Painted + 2.5D + Platformer
2. **Lighting:** Upper-left source, lower-right shadows
3. **Format:** Transparent PNG, side view, isolated
4. **Style:** Painterly gradients, Rayman Legends aesthetic
5. **Quality:** No ground/base, no outlines, whimsical tone

**NEVER:**
- Change Ludo.ai base settings mid-project
- Use different lighting directions
- Accept 3D/isometric results
- Include ground/base in assets
- Use flat colors or thick outlines

---

## 📊 Generation Workflow

### Gameplay Assets (Weeks 6-8)

#### Phase 1: Validation (Week 6 Day 1)
- Generate cart (1 asset)
- Test in Unity
- Verify style matches vision

#### Phase 2: Character Test (Week 6 Days 2-3)
- Generate Cat, Dog, Lion, Bunny (4 animals)
- Test in Unity with cart
- Validate consistency
- **DECISION POINT:** If style correct, proceed. If not, adjust prompts.

#### Phase 3: Character Production (Week 7)
- Generate remaining 9 animals
- Test each in Unity
- Ensure all 13 match

#### Phase 4: Environment Test (Week 7)
- Generate Forest environment (13 assets)
- Test parallax system in Unity
- Verify layering works

#### Phase 5: Environment Production (Week 8)
- Generate Mountain (13 assets)
- Generate Desert (13 assets)
- Generate Underwater (13 assets)
- Generate Ocean (13 assets)
- Final Unity integration

### UI & Menu Assets (Weeks 8-9)

#### Phase 6: Platform Borders (Week 8)
- Generate Forest borders (3 variations) - test tiling
- Import to Unity, verify seamless repeat
- Batch generate remaining 4 themes (12 more)

#### Phase 7: Player Icons (Week 9)
- Generate Cat + Dog + Cart icons (3 test icons)
- Verify consistent framing at small size
- Batch generate remaining 11 animal icons

#### Phase 8: Menu UI (Week 9)
- Generate Button + Panel (2 core elements)
- Test 9-slice scaling in Unity
- Generate remaining UI elements (6-8 more)

#### Phase 9: Welcome Screen (Week 9)
- Generate Desktop version (16:9)
- Test composition with logo overlay
- Generate Mobile version (9:16)

---

## 📞 Support Resources

**Ludo.ai Issues:**
- See troubleshooting section in `prompt-templates.md`
- Check negative prompts if getting wrong style
- Strengthen keywords if results inconsistent

**Project Questions:**
- See main documentation: `/docs/INDEX.md`
- Unity integration: `/docs/05-art-assets/asset-metadata-system.md`

---

**Last Updated:** 2026-01-20
**Project:** Adventures of the World - Unity 2022.3 LTS
**Style:** Hand-Painted 2.5D (Rayman Legends Inspired)
