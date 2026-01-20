# Unity Asset Import Checklist

**Step-by-step guide for importing Ludo.ai assets into Unity**

Use this checklist each time you receive assets from Ludo.ai to ensure proper import and configuration.

---

## 📋 Pre-Import Preparation

### ✅ 1. Download Assets from Ludo.ai

- [ ] Download all generated assets from Ludo.ai
- [ ] Extract to temporary folder on your computer
- [ ] Count files to verify all assets received
- [ ] Check image quality (no corruption, proper resolution)

### ✅ 2. Rename Assets

**Before importing to Unity, rename ALL files using naming conventions:**

- [ ] Review naming conventions (`/docs/06-unity-setup/asset-naming-conventions.md`)
- [ ] Rename character sprites: `[CharacterName]_Riding.png`
- [ ] Rename character icons: `[CharacterName]_Icon.png`
- [ ] Rename environment decorations: `[Theme]_[Object]_[Layer]_[Number].png`
- [ ] Rename platform borders: `[Theme]_Border_[Variation].png`
- [ ] Rename UI elements: `[Type]_[Description].png`
- [ ] Verify all names follow PascalCase with underscores

### ✅ 3. Organize Files Locally

**Create folder structure matching Unity organization:**

```
Downloaded_Assets/
├── Characters/
│   ├── Animals/
│   │   ├── Cat_Riding.png
│   │   ├── Dog_Riding.png
│   │   └── ...
│   └── Cart/
│       └── Cart_Wooden.png
│
├── Icons/
│   ├── Cat_Icon.png
│   ├── Dog_Icon.png
│   └── ...
│
├── Environment/
│   ├── Forest/
│   │   ├── Far/
│   │   ├── Mid/
│   │   └── Near/
│   ├── Mountain/
│   ├── Desert/
│   ├── Underwater/
│   └── Ocean/
│
├── Borders/
│   ├── Forest/
│   ├── Mountain/
│   ├── Desert/
│   ├── Underwater/
│   └── Ocean/
│
└── UI/
    ├── Buttons/
    ├── Panels/
    └── Backgrounds/
```

- [ ] Folder structure created
- [ ] All assets moved to appropriate folders

---

## 📥 Import to Unity

### ✅ 4. Import Assets

**Drag organized folders into Unity:**

1. **Open Unity project**
2. **Verify folder structure exists** (`Assets/Sprites/` with subfolders)
3. **Drag folders** from file explorer into Unity Project window
   - Drag `Characters/` into `Assets/Sprites/Characters/`
   - Drag `Icons/` into `Assets/Sprites/UI/Icons/`
   - Drag `Environment/` folders into `Assets/Sprites/Environment/[Theme]/`
   - Drag `Borders/` folders into `Assets/Sprites/Borders/[Theme]/`
   - Drag `UI/` elements into `Assets/Sprites/UI/`

- [ ] All character sprites imported
- [ ] All character icons imported
- [ ] All environment decorations imported (check each theme)
- [ ] All platform borders imported
- [ ] All UI elements imported
- [ ] No import errors in Console

---

## ⚙️ Configure Sprite Import Settings

### ✅ 5. Character Sprites

**For each character riding sprite (`Cat_Riding.png`, etc.):**

1. **Select sprite** in Project window
2. **Inspector → Texture Type:** Sprite (2D and UI)
3. **Sprite Mode:** Single
4. **Pixels Per Unit:** 100
5. **Filter Mode:** Bilinear
6. **Compression:** None (best quality)
7. **Max Size:** 2048
8. **Click "Apply"**

- [ ] All 13 animal sprites configured
- [ ] Cart sprite configured

### ✅ 6. Character Icons

**For each icon sprite (`Cat_Icon.png`, etc.):**

1. **Select sprite**
2. **Texture Type:** Sprite (2D and UI)
3. **Sprite Mode:** Single
4. **Pixels Per Unit:** 100
5. **Filter Mode:** Bilinear
6. **Compression:** None
7. **Max Size:** 512 (icons are smaller)
8. **Click "Apply"**

- [ ] All 14 icon sprites configured (13 animals + cart)

### ✅ 7. Environment Decorations

**For each decoration sprite:**

1. **Select all sprites in a folder** (Shift+Click)
2. **Texture Type:** Sprite (2D and UI)
3. **Sprite Mode:** Single
4. **Pixels Per Unit:** 100
5. **Filter Mode:** Bilinear
6. **Compression:** None or Low Quality (if performance needed)
7. **Max Size:** 2048 or 4096 (depending on asset size)
8. **Click "Apply"**

- [ ] Forest Far layer configured (3 assets)
- [ ] Forest Mid layer configured (5 assets)
- [ ] Forest Near layer configured (5 assets)
- [ ] Mountain Far layer configured
- [ ] Mountain Mid layer configured
- [ ] Mountain Near layer configured
- [ ] Desert Far layer configured
- [ ] Desert Mid layer configured
- [ ] Desert Near layer configured
- [ ] Underwater Far layer configured
- [ ] Underwater Mid layer configured
- [ ] Underwater Near layer configured
- [ ] Ocean Far layer configured
- [ ] Ocean Mid layer configured
- [ ] Ocean Near layer configured

### ✅ 8. Platform Borders

**For each border sprite:**

1. **Select sprite**
2. **Texture Type:** Sprite (2D and UI)
3. **Sprite Mode:** Single
4. **Pixels Per Unit:** 100
5. **Filter Mode:** Bilinear
6. **Compression:** None
7. **Max Size:** 2048
8. **Mesh Type:** Tight (for better edge detection)
9. **Click "Apply"**

- [ ] All 3 Forest borders configured
- [ ] All 3 Mountain borders configured
- [ ] All 3 Desert borders configured
- [ ] All 3 Underwater borders configured
- [ ] All 3 Ocean borders configured

### ✅ 9. UI Elements

**For buttons, panels (9-slice compatible):**

1. **Select sprite**
2. **Texture Type:** Sprite (2D and UI)
3. **Sprite Mode:** Single
4. **Pixels Per Unit:** 100
5. **Filter Mode:** Bilinear
6. **Compression:** None
7. **Max Size:** 2048
8. **Sprite Editor → Border:** Set 9-slice borders (drag edges)
9. **Click "Apply"**

**For welcome screens:**

1. **Select sprite**
2. **Texture Type:** Sprite (2D and UI)
3. **Sprite Mode:** Single
4. **Pixels Per Unit:** 100
5. **Filter Mode:** Bilinear
6. **Compression:** High Quality (large images)
7. **Max Size:** 4096 (or 2048 if file too large)
8. **Click "Apply"**

- [ ] All button sprites configured (with 9-slice if needed)
- [ ] All panel sprites configured (with 9-slice)
- [ ] Welcome screen desktop configured
- [ ] Welcome screen mobile configured
- [ ] All other UI elements configured

---

## 🎨 Create Prefabs

### ✅ 10. Character Prefabs (Optional)

**If using character prefabs for selection:**

1. **Create empty GameObject** in scene
2. **Add SpriteRenderer** component
3. **Assign character sprite**
4. **Drag to** `Assets/Prefabs/Characters/`
5. **Name:** `[CharacterName]_Character.prefab`

- [ ] Character prefabs created (if needed)

### ✅ 11. Environment Decoration Prefabs

**For each decoration:**

1. **Create 2D Sprite** GameObject in scene
2. **Assign decoration sprite** to SpriteRenderer
3. **Configure sorting layer:**
   - Far layer sprites → Sorting Layer: Background_Far
   - Mid layer sprites → Sorting Layer: Background_Mid
   - Near layer sprites → Sorting Layer: Background_Near
4. **Drag to** `Assets/Prefabs/Environment/[Theme]/`
5. **Name prefab** matching sprite name

- [ ] All Forest decoration prefabs created
- [ ] All Mountain decoration prefabs created
- [ ] All Desert decoration prefabs created
- [ ] All Underwater decoration prefabs created
- [ ] All Ocean decoration prefabs created

### ✅ 12. UI Prefabs

**CharacterSlot prefab:**

1. **In CharacterSelectScene:** Create UI Image
2. **Add child Image** for character icon
3. **Add child TextMeshPro** for character name
4. **Add child TextMeshPro** for unlock cost
5. **Add lock icon Image**
6. **Add Button component**
7. **Attach CharacterSlot.cs script**
8. **Drag to** `Assets/Prefabs/UI/CharacterSlot.prefab`

**LevelSlot prefab:**

1. **In LevelSelectScene:** Create UI Image
2. **Add child TextMeshPro** for level number
3. **Add lock icon Image**
4. **Add Button component**
5. **Attach LevelSlot.cs script**
6. **Drag to** `Assets/Prefabs/UI/LevelSlot.prefab`

- [ ] CharacterSlot prefab created
- [ ] LevelSlot prefab created
- [ ] HUD prefab created (if using)

---

## 📦 Create ScriptableObjects

### ✅ 13. Create Character Data Assets

**For each character:**

1. **Right-click** `Assets/Data/Characters/`
2. **Create → Game → Character Data**
3. **Name:** `[CharacterName]_Data.asset`
4. **Configure in Inspector:**
   - Character Name: "Cat"
   - Character Sprite: Drag `Cat_Riding.png`
   - Icon Sprite: Drag `Cat_Icon.png`
   - Unlock Cost: 0 (or set value)
   - Is Unlocked: ✓ (for starters) or unchecked
   - Jump Boost Multiplier: 1.0 (or adjust)
   - Speed Multiplier: 1.0 (or adjust)
   - Description: "A curious cat on an adventure!"

- [ ] Cat_Data.asset created and configured
- [ ] Dog_Data.asset created and configured
- [ ] Elephant_Data.asset created and configured
- [ ] Bear_Data.asset created and configured
- [ ] Unicorn_Data.asset created and configured
- [ ] Fish_Data.asset created and configured
- [ ] Fox_Data.asset created and configured
- [ ] Duck_Data.asset created and configured
- [ ] Lion_Data.asset created and configured
- [ ] Bunny_Data.asset created and configured
- [ ] Mouse_Data.asset created and configured
- [ ] Snowman_Data.asset created and configured
- [ ] Dragon_Data.asset created and configured

### ✅ 14. Create Level Data Assets (Optional)

**For each level:**

1. **Right-click** `Assets/Data/Levels/`
2. **Create → Game → Level Data**
3. **Name:** `Level[Number]_Config.asset`
4. **Configure settings** (theme, difficulty, etc.)

- [ ] Level data assets created (if using)

---

## 🎮 Test in Unity

### ✅ 15. Visual Verification

**In Unity Scene view:**

1. **Create test scene** (or use existing)
2. **Drag character sprites** into scene
3. **Verify sprites display correctly:**
   - Correct sprite loaded
   - No missing textures (pink squares)
   - Proper transparency (no white backgrounds)
   - Correct size/scale
4. **Test environment decorations:**
   - Drag Far layer sprites
   - Drag Mid layer sprites
   - Drag Near layer sprites
   - Verify sorting order (Far behind Mid behind Near)
5. **Test platform borders:**
   - Place border sprite horizontally
   - Verify seamless tiling (no visible seams)
   - Duplicate and place side-by-side

- [ ] All character sprites display correctly
- [ ] All environment decorations display correctly
- [ ] All platform borders tile seamlessly
- [ ] All UI elements display correctly
- [ ] Transparency works properly
- [ ] Colors match Ludo.ai output

### ✅ 16. Scene Integration Test

**CharacterSelectScene:**

1. **Assign character icons** to CharacterSlot prefabs
2. **Test in Play mode:**
   - Icons display correctly
   - Buttons are clickable
   - Selection highlights work

**Level Scene:**

1. **Place decoration prefabs** in background layers
2. **Test parallax scrolling** in Play mode
3. **Verify depth sorting** (layers render in correct order)
4. **Test cart with character sprite** loaded

- [ ] CharacterSelectScene works with new icons
- [ ] Level scenes work with new decorations
- [ ] Cart displays selected character correctly
- [ ] Parallax layers work properly

---

## 🐛 Troubleshooting

### Common Issues:

**Sprites appear pixelated:**
- [ ] Check Pixels Per Unit is 100
- [ ] Check Filter Mode is Bilinear (not Point)
- [ ] Check Max Size is large enough

**Sprites have white background:**
- [ ] Verify Ludo.ai exported with transparent background
- [ ] Check Texture Type is "Sprite (2D and UI)"
- [ ] Check Alpha Source is "From Input Texture"

**Platform borders show seams:**
- [ ] Verify sprite has seamless edges from Ludo.ai
- [ ] Check Wrap Mode is "Repeat"
- [ ] Try adjusting position by 0.01 units

**UI elements don't scale properly:**
- [ ] Check 9-slice borders are set correctly
- [ ] Verify Image Type is "Sliced" (not "Simple")
- [ ] Check Pixels Per Unit matches other UI (usually 100)

**Character sprites don't show in cart:**
- [ ] Verify CharacterData has sprite assigned
- [ ] Check GameManager has character selected
- [ ] Verify CartController script is attached
- [ ] Check SpriteRenderer reference in Inspector

---

## ✅ Final Checklist

**Before considering import complete:**

- [ ] All assets imported and renamed
- [ ] All sprites configured with correct import settings
- [ ] All prefabs created
- [ ] All ScriptableObjects created and configured
- [ ] Visual verification passed (no pink textures, correct display)
- [ ] Scene integration test passed
- [ ] No errors in Unity Console
- [ ] Project saved
- [ ] Git commit with message: "Import [AssetBatch] from Ludo.ai"

---

## 📊 Asset Count Verification

**Total assets expected from Ludo.ai:**

- [ ] 13 animal riding sprites
- [ ] 1 cart sprite
- [ ] 14 character icons (13 animals + cart)
- [ ] 65 environment decorations (13 per theme × 5 themes)
- [ ] 15 platform borders (3 per theme × 5 themes)
- [ ] 8-10 UI elements (buttons, panels)
- [ ] 2 welcome screens (desktop + mobile)

**Grand Total:** 118-121 assets

If any are missing, check Ludo.ai generation queue or regenerate.

---

## 📚 Related Documentation

- **Naming Conventions:** `/docs/06-unity-setup/asset-naming-conventions.md`
- **Folder Structure:** `/docs/06-unity-setup/folder-structure.md`
- **Unity Basics:** `/docs/06-unity-setup/unity-basics-setup.md`
- **Ludo.ai Guide:** `/ludo/ludo-ai-project-brief.md`

---

**Last Updated:** 2026-01-17
**For:** Adventures of the World - Unity 2022.3 LTS
**Purpose:** Streamlined asset import workflow
