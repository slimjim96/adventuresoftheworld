# Unity Project Configuration Checklist

Use this checklist to ensure your Unity project is properly configured for Adventures of the World.

---

## ✅ Initial Setup

- [ ] **Unity 2022.3 LTS installed**
  - Verify version in Unity Hub
  - Minimum: 2022.3.0f1

- [ ] **Project opened successfully**
  - No errors in Console on first open
  - All packages imported

- [ ] **IDE configured**
  - External Script Editor set (Visual Studio/Rider/VSCode)
  - Project files generated

---

## ✅ Project Settings

### Player Settings

- [ ] **Company Name** set
- [ ] **Product Name**: "Adventures of the World"
- [ ] **Default Icon** (can set later)
- [ ] **Version**: 0.1.0

### Quality Settings

- [ ] **V Sync**: Every V Blank (enabled)
- [ ] **Target Frame Rate**: 60 FPS (set in code)
- [ ] Quality levels reviewed (Low/Medium/High/Ultra)

### Physics 2D

- [ ] **Gravity**: (0, -9.81)
- [ ] **Layer Collision Matrix** configured
  - Player collides with Ground ✅
  - Player collides with Obstacles ✅
  - Player doesn't collide with Collectibles ❌ (use triggers)

### Tags and Layers

**Tags created:**
- [ ] Player
- [ ] Ground
- [ ] Obstacle
- [ ] Hazard
- [ ] Coin
- [ ] ExtraLife
- [ ] FinishLine

**Layers created:**
- [ ] Ground (Layer 8)
- [ ] Player (Layer 9)
- [ ] Obstacles (Layer 10)
- [ ] Collectibles (Layer 11)

### Input System (IMPORTANT)

- [ ] **Install Input System Package**
  - Window → Package Manager → Input System → Install
- [ ] **Active Input Handling**: Both (or "Input System Package (New)")
  - Edit → Project Settings → Player → Active Input Handling
- [ ] Restarted Unity after changing (if prompted)
- [ ] **InputManager script** added to scene (creates input actions)

See [input-system-setup.md](../06-unity-setup/input-system-setup.md) for complete setup guide.

### Editor Settings

- [ ] **Asset Serialization Mode**: Force Text
- [ ] **Line Endings**: Unix (for cross-platform)

---

## ✅ Package Installation

Verify these packages are installed (**Window → Package Manager**):

### Essential 2D Packages
- [ ] **2D Animation** (9.0.4+)
- [ ] **2D Pixel Perfect** (5.0.3+)
- [ ] **2D Sprite** (1.0.0)
- [ ] **2D Sprite Shape** (9.0.2+)
- [ ] **2D Tilemap** (1.0.0)

### Core Packages
- [ ] **TextMesh Pro** (3.0.6+)
- [ ] **Input System** (1.6.3+)
- [ ] **Vector Graphics** (2.0.0-preview.24+)

### Monetization & Analytics
- [ ] **Unity Purchasing** (4.9.3+)
- [ ] **Unity Analytics** (3.8.1+)

### IDE Integration
- [ ] **Visual Studio Editor** (2.0.18+) OR
- [ ] **JetBrains Rider** (3.0.24+) OR
- [ ] **Visual Studio Code** (1.2.5+)

---

## ✅ Scenes Setup

- [ ] **MainMenu.unity** created
  - Camera configured (Orthographic, Size: 5)
  - Canvas added with UI Scale Mode

- [ ] **Gameplay.unity** created
  - Camera configured with CameraFollow script
  - PlayerCart GameObject with CartController
  - Ground platform(s) created
  - GameManagers GameObject with manager scripts

- [ ] **Scenes added to Build Settings**
  - MainMenu (index 0)
  - Gameplay (index 1)

---

## ✅ Scripts Imported

### Core Scripts (Assets/Scripts/Core/)
- [ ] `CartController.cs` - Cart movement and jumping
- [ ] `PlayerInput.cs` - Connects Input System to cart (requires CartController)
- [ ] `CameraFollow.cs` - Camera following with look-ahead

### Managers (Assets/Scripts/Managers/)
- [ ] `GameManager.cs` - Global singleton, character selection, level progression
- [ ] `InputManager.cs` - **NEW INPUT SYSTEM** - Cross-platform input handling
- [ ] `LevelManager.cs` - Per-level logic, goal detection
- [ ] `AudioManager.cs` - Music and SFX management
- [ ] `LivesManager.cs` - Lives/health system
- [ ] `CoinManager.cs` - Coin tracking

### UI Scripts (Assets/Scripts/UI/)
- [ ] `StartButton.cs` - Start menu button
- [ ] `CharacterSelectManager.cs` - Character selection screen
- [ ] `CharacterSlot.cs` - Individual character slot
- [ ] `LevelSlot.cs` - Individual level slot
- [ ] `HUDManager.cs` - In-game HUD (lives, coins, pause)

### ScriptableObjects (Assets/Scripts/ScriptableObjects/)
- [ ] `CharacterData.cs` - Character properties
- [ ] `LevelData.cs` - Level configuration
- [ ] `DecorationData.cs` - Decoration metadata

**Verify scripts compile:**
- [ ] No errors in Console (check for `UnityEngine.InputSystem` errors)
- [ ] Scripts appear in Add Component menu
- [ ] All UI event methods are `public` (for Inspector visibility)

---

## ✅ Player Cart Setup

**Cart GameObject structure:**
```
Cart (GameObject)
├── CartBody (SpriteRenderer)
├── WheelLeft (SpriteRenderer or Animated)
├── WheelRight (SpriteRenderer or Animated)
├── GroundCheck (empty GameObject at bottom)
└── AnimalMount (SpriteRenderer for character)
```

**Cart parent GameObject:**
- [ ] Tag set to "Player"
- [ ] Layer set to "Player"
- [ ] **Transform Position Z = 0** (not behind camera!)
- [ ] **Rigidbody2D** component added
  - Gravity Scale: 2
  - Freeze Rotation Z: ✅
  - Collision Detection: Continuous
- [ ] **BoxCollider2D** component added
  - Size matches cart body (not wheels)
  - Offset Y adjusted if needed
- [ ] **CartController** script added
  - Move Speed: 5
  - Jump Force: 12
  - Ground Layer: "Ground"
  - Ground Check: (assign GroundCheck child)
- [ ] **PlayerInput** script added
  - Use Input Manager: ✅ (checked)

**GroundCheck child:**
- [ ] Empty GameObject
- [ ] Position at bottom of cart (where wheels touch ground)
- [ ] Assigned to CartController's Ground Check field

---

## ✅ Camera Setup

**Main Camera:**
- [ ] **CameraFollow** script attached
- [ ] Target: PlayerCart (auto-assigned via Player tag)
- [ ] Offset: (3, 2, -10)
- [ ] Smooth Speed: 0.125
- [ ] Projection: Orthographic
- [ ] Size: 5

---

## ✅ Game Managers Setup

**GameManagers GameObject exists with:**
- [ ] GameManager script
- [ ] InputManager script
- [ ] AudioManager script
- [ ] LivesManager script
  - Respawn Point assigned
- [ ] CoinManager script

---

## ✅ Test Level Elements

- [ ] **Ground platform(s)** created
  - Tag: "Ground"
  - Layer: "Ground"
  - BoxCollider2D added

- [ ] **SpawnPoint** GameObject created
  - Position: (0, 0, 0)

- [ ] **FinishLine** trigger created
  - Tag: "FinishLine"
  - BoxCollider2D with Is Trigger: ✅

---

## ✅ Testing & Verification

### Play Mode Tests

- [ ] **Enter Play Mode** - no errors
- [ ] **Cart moves forward** automatically
- [ ] **Jump works** (Space/Up Arrow)
- [ ] **Cart lands** on ground properly
- [ ] **Camera follows** cart smoothly
- [ ] **Ground detection** works (check Inspector)

### Input Tests
- [ ] Keyboard jump (Space) works
- [ ] Keyboard jump (Up Arrow) works
- [ ] Mouse click jump works (for testing)
- [ ] ESC pauses game (if pause menu added)

### Physics Tests
- [ ] Cart doesn't rotate when jumping
- [ ] Cart doesn't fall through ground
- [ ] Cart can't double-jump mid-air
- [ ] Gravity feels right (not too floaty/heavy)

---

## ✅ Git & Version Control

- [ ] **.gitignore** file present
- [ ] **Library/** folder NOT in git (ignored)
- [ ] **Temp/** folder NOT in git (ignored)
- [ ] Only **Assets/**, **Packages/**, **ProjectSettings/** tracked
- [ ] All scripts committed
- [ ] Scenes committed (.unity files)

---

## ✅ Build Settings

- [ ] **Platform**: PC, Mac & Linux Standalone (default)
- [ ] **Architecture**: x86_64 (64-bit)
- [ ] **Target Platform**: Windows / macOS / Linux

### For Android (if building now):
- [ ] Android Build Support module installed
- [ ] Platform switched to Android
- [ ] Minimum API Level: 24 (Android 7.0)
- [ ] Target API Level: 33+ (latest)

### For iOS (if building now):
- [ ] iOS Build Support module installed
- [ ] Platform switched to iOS
- [ ] Minimum iOS Version: 12.0

---

## ✅ Performance Settings

- [ ] **Quality Settings** appropriate for platforms
- [ ] **V-Sync** enabled for consistent frame rate
- [ ] **Target Frame Rate** set to 60 (in GameManager)

---

## ✅ Optional but Recommended

- [ ] Git LFS configured for large files
- [ ] README.md reviewed
- [ ] TODO.md tasks started
- [ ] Documentation read (requirements, scope, design)

---

## 🚨 Common Issues Checklist

If something isn't working, check these:

### Cart won't jump
- [ ] **PlayerInput** script on Cart? (handles input)
- [ ] **InputManager** in scene? (or auto-creates if missing)
- [ ] Input System package installed?
- [ ] Active Input Handling set to "Both" in Player Settings?
- [ ] Ground layer assigned in CartController?
- [ ] Ground platforms have "Ground" layer?
- [ ] GroundCheck child positioned at bottom of cart?
- [ ] Cart has Rigidbody2D?

### Cart floating / invisible / behind platforms
- [ ] **Camera Z = -10** (negative, in front of objects)
- [ ] **Cart Z = 0**
- [ ] **Platforms Z = 0**
- [ ] If using Cinemachine: Virtual Camera → Body → Camera Distance = 10
- [ ] Cart collider offset correct? (not floating above sprite)

### Cart falls through ground
- [ ] Collision Matrix: Player collides with Ground?
- [ ] Ground has BoxCollider2D?
- [ ] Rigidbody2D Collision Detection: Continuous?

### Camera doesn't follow
- [ ] CameraFollow script on camera? (or Cinemachine Virtual Camera)
- [ ] Target assigned (or Player tag set on cart)?
- [ ] If Cinemachine: Virtual Camera → Follow = Cart transform
- [ ] If Cinemachine: Body = Framing Transposer (for 2D)

### Input not responding
- [ ] Input System package installed?
- [ ] Active Input Handling = "Both" or "Input System Package"?
- [ ] Restarted Unity after changing input setting?
- [ ] InputManager script in scene and enabled?
- [ ] PlayerInput script on Cart and enabled?

### Method not showing in Button.onClick dropdown
- [ ] Method is `public`? (not just `void`)
- [ ] Script saved and compiled?
- [ ] See [how-to-import-scripts.md](../06-unity-setup/how-to-import-scripts.md)

### Scripts won't compile
- [ ] Check Console for errors
- [ ] Input System errors? Install package: Window → Package Manager → Input System
- [ ] Missing namespace? Add `using UnityEngine.InputSystem;`
- [ ] IDE integration set up?
- [ ] Try: Assets → Reimport All

### Scene won't load
- [ ] Scene added to Build Settings?
- [ ] Scene file not corrupted?
- [ ] No errors in Console?

---

## 📋 Sign-Off

Once all checkboxes are complete:

✅ **Project is properly configured**
✅ **Ready to start development**
✅ **Proceed to Week 1 tasks in TODO.md**

---

**Configuration Date**: _____________
**Configured By**: _____________
**Notes**: _________________________________

---

*Last Updated: 2026-01-25*
