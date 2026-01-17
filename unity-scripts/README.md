# Unity Scripts Library

**Complete collection of ready-to-use C# scripts for Adventures of the World**

⚠️ **IMPORTANT:** These scripts are **template files in the repository**. You need to **manually copy** them to your Unity project's `Assets/Scripts/` folder.

📖 **New to Unity or having import issues?** → See [how-to-import-scripts.md](/docs/06-unity-setup/how-to-import-scripts.md)

---

## ⚡ Quick Start

**These files are NOT automatically in Unity. You must copy them:**

1. **Copy** each `.cs` file from this folder (`/unity-scripts/`)
2. **Paste** into your Unity project's `Assets/Scripts/` folder (see organization below)
3. **Wait** for Unity to auto-compile
4. **Use** the scripts in your game

**No namespaces needed** - Unity finds classes automatically once files are in `Assets/` folder.

---

## 📁 Script Organization

Copy these scripts to the following folders in your Unity project:

### Managers (`Assets/Scripts/Managers/`)
- **GameManager.cs** - Global singleton, persists across scenes, handles character selection, level progression, coins, and lives
- **LevelManager.cs** - Per-level logic, level completion detection, scene transitions

### Player (`Assets/Scripts/Player/`)
- **CartController.cs** - Cart movement, jumping, character loading, collision handling

### UI (`Assets/Scripts/UI/`)
- **StartButton.cs** - Simple start button for main menu
- **CharacterSlot.cs** - Individual character selection slot UI
- **CharacterSelectManager.cs** - Manages character selection scene
- **LevelSlot.cs** - Individual level selection slot UI
- **HUDManager.cs** - In-game HUD (lives, coins, pause menu)

### Collectibles (`Assets/Scripts/Collectibles/`)
- **CoinCollector.cs** - Collectible coin with animation and effects

### Obstacles (`Assets/Scripts/Obstacles/`)
- **Hazard.cs** - Generic obstacle that damages player
- **GoalTrigger.cs** - Level completion trigger at finish line

### Environment (`Assets/Scripts/Environment/`)
- **ParallaxLayer.cs** - Parallax scrolling for background layers
- **BackgroundSpawner.cs** - Procedural decoration spawning system

### ScriptableObjects (`Assets/Scripts/ScriptableObjects/`)
- **CharacterData.cs** - Character data definition (create via Assets → Create → Game → Character Data)
- **LevelData.cs** - Level configuration data (create via Assets → Create → Game → Level Data)
- **DecorationData.cs** - Decoration metadata (create via Assets → Create → Game → Decoration Data)

---

## 🎯 Quick Setup Guide

### Step 1: Copy Scripts to Unity

1. Open Unity project
2. Create folder structure (see `/docs/06-unity-setup/folder-structure.md`)
3. Copy each script to corresponding folder listed above

### Step 2: Create ScriptableObjects

**Create Character Data Assets (13 animals + cart):**
1. In Unity: Right-click `Assets/Data/Characters/` → Create → Game → Character Data
2. Name it: `Cat_Data`
3. Configure in Inspector:
   - Character Name: "Cat"
   - Character Sprite: Drag `Cat_Riding.png`
   - Icon Sprite: Drag `Cat_Icon.png`
   - Unlock Cost: 0 (free starter)
   - Is Unlocked: ✓ (checked)
   - Jump Boost: 1.0
   - Speed: 1.0
4. Repeat for all 13 animals

**Create Level Data Assets (12 levels):**
1. Right-click `Assets/Data/Levels/` → Create → Game → Level Data
2. Name it: `Level01_Config`
3. Configure settings for Level 1
4. Repeat for all 12 levels

### Step 3: Setup Scenes

**StartScene:**
1. Create Canvas
2. Add Button (Start button)
3. Attach `StartButton.cs` to button
4. Set Next Scene Name: "CharacterSelectScene"

**CharacterSelectScene:**
1. Create Canvas
2. Create Grid Layout for character slots
3. Create CharacterSlot prefab (see scene architecture guide)
4. Attach `CharacterSlot.cs` to prefab
5. Create 13 instances in grid
6. Create manager GameObject, attach `CharacterSelectManager.cs`
7. Assign references in Inspector

**LevelSelectScene:**
1. Create Canvas
2. Create Grid Layout for level slots
3. Create LevelSlot prefab
4. Attach `LevelSlot.cs` to prefab
5. Create 12 instances
6. Configure each with level number and scene name

**Level Scenes (Level01-12):**
1. Create Cart prefab
2. Attach `CartController.cs` to cart
3. Create HUD, attach `HUDManager.cs`
4. Create manager GameObject, attach `LevelManager.cs`
5. Setup parallax layers with `ParallaxLayer.cs`
6. (Optional) Add `BackgroundSpawner.cs` for procedural decorations
7. Place obstacles with `Hazard.cs`
8. Place coins with `CoinCollector.cs`
9. Place goal trigger with `GoalTrigger.cs`

### Step 4: Create GameManager

1. In StartScene: Create empty GameObject named "GameManager"
2. Attach `GameManager.cs` script
3. **Important:** This GameObject persists across all scenes (DontDestroyOnLoad)
4. Only needs to exist in StartScene - will persist automatically

---

## 🔗 Script Dependencies

**GameManager.cs** (Required by almost everything)
- Must exist in first scene (StartScene)
- Persists across all scenes
- Other scripts reference via `GameManager.Instance`

**CharacterData.cs** (Required by character system)
- Create assets for each character
- Referenced by GameManager, CharacterSlot, CartController

**LevelData.cs** (Optional, for advanced level config)
- Create assets for each level
- Can be used by LevelManager for procedural setup

**Tags Required:**
- "Player" (Cart GameObject)
- "Obstacle" (Hazard GameObjects)
- "Coin" (Coin GameObjects)

**Layers Required:**
- Ground (Layer 7)
- Player (Layer 6)
- Collectibles (Layer 9)

See `/docs/06-unity-setup/unity-basics-setup.md` for tag/layer setup.

---

## 📝 Script Features

### GameManager.cs
- ✓ Singleton pattern with DontDestroyOnLoad
- ✓ Character selection and unlocking
- ✓ Level progression and unlocking
- ✓ Coin management
- ✓ Lives system
- ✓ Save/load placeholders (ready to implement)

### CartController.cs
- ✓ Auto-scroll movement
- ✓ Keyboard + mobile touch jump
- ✓ Ground detection
- ✓ Loads character from GameManager
- ✓ Applies character-specific stats
- ✓ Collision handling (obstacles, coins)
- ✓ Level restart on death

### CharacterSelectManager.cs
- ✓ Displays all characters
- ✓ Shows lock status and costs
- ✓ Handles character unlocking
- ✓ Updates UI when coins change
- ✓ Validates selection before proceeding

### HUDManager.cs
- ✓ Displays lives, coins, level number
- ✓ Visual life icons (hearts)
- ✓ Pause menu system
- ✓ Restart and quit functions

### ParallaxLayer.cs
- ✓ Smooth parallax scrolling
- ✓ Auto-finds main camera
- ✓ Configurable speed (0-1)
- ✓ Optional vertical parallax

### BackgroundSpawner.cs
- ✓ Procedural decoration spawning
- ✓ Random spacing and placement
- ✓ Automatic cleanup (destroys behind camera)
- ✓ Supports multiple decoration prefabs

---

## 🛠️ Customization

All scripts include:
- **Tooltips** - Hover over fields in Inspector for help
- **Header sections** - Organized Inspector layout
- **Debug logs** - Track what's happening at runtime
- **Comments** - Explain complex logic

**Common customizations:**
- Adjust movement speed, jump force in CartController
- Modify unlock costs in CharacterData assets
- Change parallax speeds in ParallaxLayer
- Configure spawn rates in BackgroundSpawner
- Adjust HUD layout and styling

---

## 🐛 Troubleshooting

**"GameManager not found" errors:**
- Ensure GameManager exists in StartScene
- Check that it has DontDestroyOnLoad (automatic via script)
- Verify GameManager script is attached

**Cart not loading character:**
- Check that character is selected in CharacterSelectScene
- Verify CharacterData has sprites assigned
- Ensure GameManager.selectedCharacter is not null

**UI buttons not working:**
- Check that EventSystem exists in scene
- Verify Canvas has Graphic Raycaster
- Ensure button OnClick events are assigned

**Parallax not working:**
- Check that Main Camera is tagged as "MainCamera"
- Verify ParallaxLayer has camera reference
- Ensure parallaxSpeed is between 0 and 1

---

## 📚 Related Documentation

- **Scene Architecture:** `/docs/06-unity-setup/scene-architecture-guide.md`
- **Unity Basics:** `/docs/06-unity-setup/unity-basics-setup.md`
- **Folder Structure:** `/docs/06-unity-setup/folder-structure.md`
- **Asset Guide:** `/docs/05-art-assets/ludo-ai-asset-guide.md`

---

**Last Updated:** 2026-01-17
**For:** Adventures of the World - Unity 2022.3 LTS
**Total Scripts:** 16 ready-to-use C# scripts
**Status:** Complete implementation, ready to copy into Unity
