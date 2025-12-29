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

### Input System

- [ ] **Active Input Handling**: Both (legacy + new)
- [ ] Restarted Unity after changing (if prompted)

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

### Core Scripts
- [ ] `CartController.cs`
- [ ] `GameManager.cs`

### Managers
- [ ] `InputManager.cs`
- [ ] `AudioManager.cs`
- [ ] `LivesManager.cs`
- [ ] `CoinManager.cs`

### Utilities
- [ ] `CameraFollow.cs`

**Verify scripts compile:**
- [ ] No errors in Console
- [ ] Scripts appear in Add Component menu

---

## ✅ Player Cart Setup

**PlayerCart GameObject:**
- [ ] Tag set to "Player"
- [ ] Layer set to "Player"
- [ ] **Rigidbody2D** component added
  - Gravity Scale: 2
  - Freeze Rotation Z: ✅
  - Collision Detection: Continuous
- [ ] **BoxCollider2D** component added
  - Size matches sprite
- [ ] **CartController** script added
  - Move Speed: 5
  - Jump Force: 12
  - Ground Layer: "Ground"
- [ ] Placeholder sprite (Square, colored)

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
- [ ] InputManager in scene?
- [ ] Ground layer assigned in CartController?
- [ ] Ground platforms have "Ground" layer?
- [ ] Cart has Rigidbody2D?

### Cart falls through ground
- [ ] Collision Matrix: Player collides with Ground?
- [ ] Ground has BoxCollider2D?
- [ ] Rigidbody2D Collision Detection: Continuous?

### Camera doesn't follow
- [ ] CameraFollow script on camera?
- [ ] Target assigned (or Player tag set on cart)?
- [ ] Camera not parented to anything?

### Scripts won't compile
- [ ] Check Console for errors
- [ ] All scripts have correct namespace?
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

*Last Updated: 2025-11-22*
