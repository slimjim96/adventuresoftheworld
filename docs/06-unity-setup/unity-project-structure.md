# Unity Project Structure (Current)

**Last Updated:** 2026-01-17
**Status:** Active Unity project structure after cleanup

This document describes the **actual** folder structure and scripts in your Unity project's `Assets/` folder.

---

## 📁 Assets Folder Structure

```
Assets/
├── Scenes/                           ← Unity scene files
│   ├── StartScene.unity
│   ├── CharacterSelectScene.unity
│   ├── LevelSelectScene.unity
│   └── Levels/
│       ├── Level01.unity
│       ├── Level02.unity
│       └── ... (Level03-12)
│
├── Scripts/                          ← All C# scripts ⭐
│   ├── Core/                         ← Core gameplay systems
│   │   ├── CartController.cs         ⭐ Player cart (movement, jump, collision)
│   │   ├── CameraFollow.cs           ⭐ Advanced camera follow
│   │   └── PlayerInput.cs            Input handling
│   │
│   ├── Managers/                     ← Game-wide managers
│   │   ├── GameManager.cs            ⭐⭐ PRIMARY - Global singleton
│   │   ├── AudioManager.cs           Sound & music
│   │   ├── InputManager.cs           Input system wrapper
│   │   ├── CoinManager.cs            Coin tracking
│   │   └── LivesManager.cs           Lives system
│   │
│   ├── ScriptableObjects/            ← Data definitions
│   │   ├── CharacterData.cs          ⭐ Character definition
│   │   ├── DecorationData.cs         Decoration metadata
│   │   └── LevelData.cs              Level configuration
│   │
│   ├── UI/                           ← User interface
│   │   ├── CoinHUD.cs                Coin counter display
│   │   └── LivesHUD.cs               Hearts/lives display
│   │
│   ├── Collectibles/                 ← Pickup items
│   │   └── Coin.cs                   ⭐ Collectible coin
│   │
│   ├── Obstacles/                    ← Hazards & enemies
│   │   ├── Hazard.cs                 Generic obstacle damage
│   │   └── MovingObstacle.cs         Moving platforms/obstacles
│   │
│   ├── Level/                        ← Level-specific scripts
│   │   ├── Checkpoint.cs             Save points
│   │   ├── DeathZone.cs              Kill zones (fall detection)
│   │   ├── FinishLine.cs             Level completion trigger
│   │   └── LevelGoal.cs              Objective tracker
│   │
│   └── Environment/                  ← Background & scenery
│       ├── BackgroundSpawner.cs      Procedural decoration spawner
│       └── ParallexLayer.cs          Parallax scrolling
│
├── Data/                             ← ScriptableObject assets
│   ├── Characters/                   ← Character data assets
│   │   ├── Cat_Data.asset
│   │   ├── Dog_Data.asset
│   │   └── ... (13 characters total)
│   │
│   ├── Levels/                       ← Level configuration assets
│   │   ├── Level01_Config.asset
│   │   ├── Level02_Config.asset
│   │   └── ... (12 levels total)
│   │
│   └── Decorations/                  ← Decoration metadata assets
│       ├── Forest/
│       ├── Mountain/
│       └── ... (5 themes)
│
├── Sprites/                          ← Imported art assets
│   ├── Characters/                   ← Character sprites from Ludo.ai
│   │   ├── Animals/
│   │   │   ├── Cat_Riding.png
│   │   │   ├── Dog_Riding.png
│   │   │   └── ... (13 animals)
│   │   └── Cart/
│   │       └── Cart_Wooden.png
│   │
│   ├── Environment/                  ← Background decorations
│   │   ├── Forest/
│   │   │   ├── Far/
│   │   │   ├── Mid/
│   │   │   └── Near/
│   │   ├── Mountain/
│   │   ├── Desert/
│   │   ├── Underwater/
│   │   └── Ocean/
│   │
│   ├── Borders/                      ← Platform border patterns
│   │   ├── Forest/
│   │   ├── Mountain/
│   │   └── ... (5 themes × 3 variations)
│   │
│   └── UI/                           ← UI graphics
│       ├── Icons/                    ← Character selection icons
│       ├── Buttons/                  ← Menu buttons
│       ├── Panels/                   ← UI panels
│       └── Backgrounds/              ← Welcome screens
│
├── Prefabs/                          ← Reusable GameObjects
│   ├── Player/
│   │   └── Cart.prefab               ⭐ Main player cart prefab
│   │
│   ├── UI/
│   │   ├── CharacterSlot.prefab
│   │   ├── LevelSlot.prefab
│   │   └── HUD.prefab
│   │
│   ├── Collectibles/
│   │   └── Coin.prefab
│   │
│   ├── Obstacles/
│   │   ├── Spike.prefab
│   │   └── MovingPlatform.prefab
│   │
│   └── Environment/
│       ├── Forest/
│       ├── Mountain/
│       └── ... (Decoration prefabs by theme)
│
├── Audio/                            ← Sound files (future)
│   ├── Music/
│   └── SFX/
│
├── Materials/                        ← 2D materials
├── Animations/                       ← Animation clips
├── Fonts/                            ← Custom fonts
└── TextMesh Pro/                     ← TMP package assets (Unity standard)
```

---

## 🔑 Key Scripts Explained

### ⭐⭐ GameManager.cs (CRITICAL - Must Exist)
**Location:** `Assets/Scripts/Managers/GameManager.cs`

**Purpose:** Global singleton that persists across all scenes

**Features:**
- Character selection and unlocking
- Level progression tracking
- Coin management
- Lives system
- DontDestroyOnLoad (persists across scene changes)

**Usage:**
```csharp
// Access from any script
GameManager.Instance.AddCoins(10);
GameManager.Instance.SelectCharacter(characterData);
GameManager.Instance.LoadLevel(1);
```

**Setup:** Create GameObject named "GameManager" in StartScene, attach this script

---

### ⭐ CartController.cs
**Location:** `Assets/Scripts/Core/CartController.cs`

**Purpose:** Player cart movement, jumping, and collision handling

**Features:**
- Auto-scroll movement
- Jump mechanics (keyboard + mobile touch)
- Loads selected character from GameManager
- Collision detection (obstacles, coins)
- Ground detection

**Setup:** Attach to Cart prefab

---

### ⭐ CharacterData.cs (ScriptableObject)
**Location:** `Assets/Scripts/ScriptableObjects/CharacterData.cs`

**Purpose:** Defines each playable character's properties

**Create Assets:**
1. Right-click `Assets/Data/Characters/`
2. Create → Game → Character Data
3. Configure: name, sprites, unlock cost, stats

**Fields:**
- Character name
- Character sprite (riding pose)
- Icon sprite (selection screen)
- Unlock cost (coins)
- Is unlocked (bool)
- Jump/speed multipliers
- Description

---

### ⭐ CameraFollow.cs (Advanced)
**Location:** `Assets/Scripts/Core/CameraFollow.cs`
**Namespace:** `AdventuresOfTheWorld.Core`

**Purpose:** Smooth camera follow with advanced features

**Features:**
- Look-ahead prediction
- Dead zone (smooth following)
- Camera boundaries
- Camera shake support
- Vertical/horizontal smoothing

**Setup:** Attach to Main Camera, assign Cart as target

---

### ⭐ Coin.cs (Collectible)
**Location:** `Assets/Scripts/Collectibles/Coin.cs`
**Namespace:** `AdventuresOfTheWorld.Collectibles`

**Purpose:** Collectible coin with animation and scoring

**Features:**
- Trigger-based collection
- Rotation/scale animation
- Communicates with CoinManager
- Particle effects (TODO)

**Setup:** Attach to Coin prefab with Collider2D (trigger)

---

## 🎯 Script Dependencies

### Scripts That Require GameManager:
- CartController.cs
- FinishLine.cs
- LevelGoal.cs
- LivesManager.cs

**Critical:** GameManager MUST exist in StartScene (first scene loaded)

### Namespaces Used:
- `AdventuresOfTheWorld.Core` - Core gameplay
- `AdventuresOfTheWorld.Managers` - Manager classes
- `AdventuresOfTheWorld.Collectibles` - Pickup items
- `AdventuresOfTheWorld.Obstacles` - Hazards
- `AdventuresOfTheWorld.Utilities` - Helper classes

### Using Directives Needed:
```csharp
using UnityEngine;
using AdventuresOfTheWorld.Managers;  // For GameManager, CoinManager, etc.
using AdventuresOfTheWorld.Core;      // For CameraFollow
```

---

## 📝 Script Comparison: Unity Project vs. Repository Templates

Your Unity project has **evolved** from the original `/unity-scripts/` templates:

| Feature | Repository Templates | Your Unity Project |
|---------|---------------------|-------------------|
| **GameManager** | No namespace, basic | Namespace: None, in Managers/ |
| **CameraFollow** | Simple version | Advanced with namespaces |
| **Coin** | CoinCollector.cs | Coin.cs in Collectibles |
| **Organization** | Flat structure | Organized by namespaces |
| **TODOs** | None | 8 placeholder TODOs |

**Note:** The `/unity-scripts/` templates are **reference only**. Your Unity project is the active codebase.

---

## ⚠️ Important Notes

### Deleted Duplicates (2026-01-17 Cleanup):
- ❌ `Assets/Scripts/Core/GameManager.cs` (duplicate, kept Managers version)
- ❌ `Assets/Scripts/Utilities/CameraFollow.cs` (simpler, kept Core version)
- ❌ `Assets/Scripts/Obstacles/Coin.cs` (wrong location, kept Collectibles version)

See `CLEANUP-SUMMARY.md` for details.

### TextMesh Pro:
- Standard Unity package
- 50 example scripts in `Assets/TextMesh Pro/Examples & Extras/Scripts/`
- Safe to keep, not counted in project script total

### TODO Comments:
- 8 TODO placeholders for future features
- Mostly audio and save/load system
- Safe to leave until implementation phase

---

## 🔧 Setup Checklist

**For new scenes:**
- [ ] GameManager exists in StartScene (persists to all other scenes)
- [ ] Main Camera has CameraFollow script
- [ ] Cart prefab has CartController script
- [ ] Coins have Collectibles.Coin script (not Obstacles.Coin - deleted)
- [ ] Obstacles have Hazard.cs script
- [ ] HUD has CoinHUD and LivesHUD scripts

**For character system:**
- [ ] Created CharacterData assets (13 animals)
- [ ] Assigned sprites to each CharacterData
- [ ] Set unlock costs
- [ ] GameManager references CharacterData assets

---

## 📚 Related Documentation

- **Cleanup Details:** `CLEANUP-SUMMARY.md`
- **Scene Architecture:** `scene-architecture-guide.md`
- **Script Templates:** `/unity-scripts/README.md` (reference only)
- **Import Guide:** `how-to-import-scripts.md`

---

**Last Verified:** 2026-01-17
**Total Custom Scripts:** 24 (after cleanup)
**Status:** ✅ Clean, organized, no duplicates
