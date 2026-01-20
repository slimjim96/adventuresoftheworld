# Unity Project Folder Structure

**Complete Assets folder organization for Adventures of the World**

This guide shows exactly where to put every file in your Unity project.

---

## 📁 Complete Folder Structure

```
Assets/
├── Scenes/                                 ← All Unity scenes
│   ├── StartScene.unity
│   ├── CharacterSelectScene.unity
│   ├── LevelSelectScene.unity
│   └── Levels/
│       ├── Level01_Forest.unity
│       ├── Level02_Forest.unity
│       ├── Level03_Forest.unity
│       ├── Level04_Mountain.unity
│       ├── Level05_Mountain.unity
│       ├── Level06_Mountain.unity
│       ├── Level07_Desert.unity
│       ├── Level08_Desert.unity
│       ├── Level09_Desert.unity
│       ├── Level10_Underwater.unity
│       ├── Level11_Underwater.unity
│       └── Level12_Ocean.unity
│
├── Scripts/                                ← All C# scripts
│   ├── Managers/
│   │   ├── GameManager.cs                  ← Singleton, persists across scenes
│   │   ├── LevelManager.cs                 ← Per-level logic
│   │   ├── AudioManager.cs                 ← (Future) Sound management
│   │   └── SaveManager.cs                  ← (Future) Save/load system
│   │
│   ├── Player/
│   │   ├── CartController.cs               ← Cart movement, jump, loads character
│   │   └── WheelRotation.cs                ← (Optional) Wheel animation
│   │
│   ├── UI/
│   │   ├── StartButton.cs                  ← Main menu start button
│   │   ├── CharacterSlot.cs                ← Character selection UI slot
│   │   ├── CharacterSelectManager.cs       ← Character select scene manager
│   │   ├── LevelSlot.cs                    ← Level selection UI slot
│   │   ├── HUDManager.cs                   ← Lives, coins display
│   │   └── PauseMenu.cs                    ← Pause menu logic
│   │
│   ├── Collectibles/
│   │   ├── CoinCollector.cs                ← Coin collection logic
│   │   └── PowerUp.cs                      ← (Future) Power-up collectibles
│   │
│   ├── Obstacles/
│   │   ├── Hazard.cs                       ← Generic obstacle damage
│   │   └── MovingObstacle.cs               ← (Future) Moving hazards
│   │
│   ├── Environment/
│   │   ├── ParallaxLayer.cs                ← Parallax scrolling background
│   │   ├── BackgroundSpawner.cs            ← Procedural decoration spawning
│   │   └── DecorationMover.cs              ← Scroll decorations with camera
│   │
│   └── ScriptableObjects/
│       ├── CharacterData.cs                ← Character data definition
│       ├── LevelData.cs                    ← Level configuration data
│       └── DecorationData.cs               ← Environmental decoration data
│
├── Prefabs/                                ← Reusable GameObjects
│   ├── Player/
│   │   └── Cart.prefab                     ← Main cart (used in all 12 levels)
│   │
│   ├── UI/
│   │   ├── CharacterSlot.prefab            ← Character selection slot
│   │   ├── LevelSlot.prefab                ← Level selection slot
│   │   └── HUD.prefab                      ← Heads-up display (lives, coins)
│   │
│   ├── Collectibles/
│   │   ├── Coin.prefab                     ← Collectible coin
│   │   └── PowerUp.prefab                  ← (Future) Power-ups
│   │
│   ├── Obstacles/
│   │   ├── Spike.prefab
│   │   ├── Rock.prefab
│   │   └── Gap.prefab
│   │
│   └── Environment/
│       ├── Forest/
│       │   ├── Forest_Tree_Mid_01.prefab
│       │   ├── Forest_Bush_Near_01.prefab
│       │   └── ... (all Forest decorations)
│       │
│       ├── Mountain/
│       ├── Desert/
│       ├── Underwater/
│       └── Ocean/
│
├── Sprites/                                ← All PNG images from Ludo.ai
│   ├── Characters/
│   │   ├── Cart/
│   │   │   └── Cart_Wooden.png
│   │   │
│   │   └── Animals/
│   │       ├── Cat_Riding.png
│   │       ├── Dog_Riding.png
│   │       ├── Elephant_Riding.png
│   │       └── ... (13 animal sprites)
│   │
│   ├── UI/
│   │   ├── Icons/                          ← Player select icons
│   │   │   ├── Cat_Icon.png
│   │   │   ├── Dog_Icon.png
│   │   │   └── ... (14 icon sprites)
│   │   │
│   │   ├── Buttons/                        ← Menu buttons
│   │   │   ├── Button_Wooden_Small.png
│   │   │   ├── Button_Round.png
│   │   │   └── ... (UI element sprites)
│   │   │
│   │   ├── Panels/                         ← UI panels
│   │   │   ├── Panel_Wooden.png
│   │   │   └── Frame_Decorative.png
│   │   │
│   │   └── Backgrounds/                    ← Welcome screens
│   │       ├── WelcomeScreen_Desktop.png
│   │       └── WelcomeScreen_Mobile.png
│   │
│   ├── Borders/                            ← Platform borders (tileable)
│   │   ├── Forest/
│   │   │   ├── Forest_Border_Vines.png
│   │   │   ├── Forest_Border_Moss.png
│   │   │   └── Forest_Border_Mushroom.png
│   │   │
│   │   ├── Mountain/
│   │   ├── Desert/
│   │   ├── Underwater/
│   │   └── Ocean/
│   │
│   ├── Environment/                        ← Background decorations
│   │   ├── Forest/
│   │   │   ├── Far/
│   │   │   │   ├── Forest_Mountain_Far_01.png
│   │   │   │   ├── Forest_Cloud_Far_01.png
│   │   │   │   └── Forest_Cloud_Far_02.png
│   │   │   │
│   │   │   ├── Mid/
│   │   │   │   ├── Forest_Tree_Mid_01.png
│   │   │   │   ├── Forest_Tree_Mid_02.png
│   │   │   │   ├── Forest_Hill_Mid_01.png
│   │   │   │   └── ... (5 mid-layer assets)
│   │   │   │
│   │   │   └── Near/
│   │   │       ├── Forest_Bush_Near_01.png
│   │   │       ├── Forest_Rock_Near_01.png
│   │   │       └── ... (5 near-layer assets)
│   │   │
│   │   ├── Mountain/
│   │   │   ├── Far/
│   │   │   ├── Mid/
│   │   │   └── Near/
│   │   │
│   │   ├── Desert/
│   │   ├── Underwater/
│   │   └── Ocean/
│   │
│   ├── Obstacles/
│   │   ├── Spike.png
│   │   ├── Rock.png
│   │   └── Gap.png
│   │
│   └── Collectibles/
│       ├── Coin.png
│       └── PowerUp.png
│
├── Data/                                   ← ScriptableObject assets
│   ├── Characters/
│   │   ├── Cat_Data.asset
│   │   ├── Dog_Data.asset
│   │   ├── Elephant_Data.asset
│   │   ├── Bear_Data.asset
│   │   ├── Unicorn_Data.asset
│   │   ├── Fish_Data.asset
│   │   ├── Fox_Data.asset
│   │   ├── Duck_Data.asset
│   │   ├── Lion_Data.asset
│   │   ├── Bunny_Data.asset
│   │   ├── Mouse_Data.asset
│   │   ├── Snowman_Data.asset
│   │   └── Dragon_Data.asset
│   │
│   ├── Levels/
│   │   ├── Level01_Config.asset
│   │   ├── Level02_Config.asset
│   │   └── ... (12 level config assets)
│   │
│   └── Decorations/
│       ├── Forest/
│       │   ├── Forest_Tree_01_Data.asset
│       │   └── ... (decoration metadata)
│       │
│       ├── Mountain/
│       ├── Desert/
│       ├── Underwater/
│       └── Ocean/
│
├── Audio/                                  ← Sound effects & music (Future)
│   ├── Music/
│   │   ├── Menu_Theme.mp3
│   │   ├── Forest_Theme.mp3
│   │   └── ... (level music)
│   │
│   └── SFX/
│       ├── Jump.wav
│       ├── Coin_Collect.wav
│       ├── Death.wav
│       └── ... (sound effects)
│
├── Fonts/                                  ← TextMeshPro fonts
│   └── GameFont.asset
│
└── Materials/                              ← (Optional) Sprite materials
    └── SpriteLit.mat
```

---

## 📝 How to Create This Structure

### Option 1: Create Manually in Unity

1. **In Unity Project window:**
2. Right-click in Assets folder → Create → Folder
3. Create each folder according to structure above
4. Repeat for subfolders

### Option 2: Create via Script (Faster)

Create this script in Unity Editor folder:

`Assets/Editor/CreateFolderStructure.cs`

```csharp
using UnityEngine;
using UnityEditor;
using System.IO;

public class CreateFolderStructure : MonoBehaviour
{
    [MenuItem("Tools/Create Folder Structure")]
    static void CreateFolders()
    {
        string[] folders = new string[]
        {
            "Assets/Scenes",
            "Assets/Scenes/Levels",
            "Assets/Scripts",
            "Assets/Scripts/Managers",
            "Assets/Scripts/Player",
            "Assets/Scripts/UI",
            "Assets/Scripts/Collectibles",
            "Assets/Scripts/Obstacles",
            "Assets/Scripts/Environment",
            "Assets/Scripts/ScriptableObjects",
            "Assets/Prefabs",
            "Assets/Prefabs/Player",
            "Assets/Prefabs/UI",
            "Assets/Prefabs/Collectibles",
            "Assets/Prefabs/Obstacles",
            "Assets/Prefabs/Environment",
            "Assets/Prefabs/Environment/Forest",
            "Assets/Prefabs/Environment/Mountain",
            "Assets/Prefabs/Environment/Desert",
            "Assets/Prefabs/Environment/Underwater",
            "Assets/Prefabs/Environment/Ocean",
            "Assets/Sprites",
            "Assets/Sprites/Characters",
            "Assets/Sprites/Characters/Cart",
            "Assets/Sprites/Characters/Animals",
            "Assets/Sprites/UI",
            "Assets/Sprites/UI/Icons",
            "Assets/Sprites/UI/Buttons",
            "Assets/Sprites/UI/Panels",
            "Assets/Sprites/UI/Backgrounds",
            "Assets/Sprites/Borders",
            "Assets/Sprites/Borders/Forest",
            "Assets/Sprites/Borders/Mountain",
            "Assets/Sprites/Borders/Desert",
            "Assets/Sprites/Borders/Underwater",
            "Assets/Sprites/Borders/Ocean",
            "Assets/Sprites/Environment",
            "Assets/Sprites/Environment/Forest",
            "Assets/Sprites/Environment/Forest/Far",
            "Assets/Sprites/Environment/Forest/Mid",
            "Assets/Sprites/Environment/Forest/Near",
            "Assets/Sprites/Environment/Mountain",
            "Assets/Sprites/Environment/Mountain/Far",
            "Assets/Sprites/Environment/Mountain/Mid",
            "Assets/Sprites/Environment/Mountain/Near",
            "Assets/Sprites/Environment/Desert",
            "Assets/Sprites/Environment/Desert/Far",
            "Assets/Sprites/Environment/Desert/Mid",
            "Assets/Sprites/Environment/Desert/Near",
            "Assets/Sprites/Environment/Underwater",
            "Assets/Sprites/Environment/Underwater/Far",
            "Assets/Sprites/Environment/Underwater/Mid",
            "Assets/Sprites/Environment/Underwater/Near",
            "Assets/Sprites/Environment/Ocean",
            "Assets/Sprites/Environment/Ocean/Far",
            "Assets/Sprites/Environment/Ocean/Mid",
            "Assets/Sprites/Environment/Ocean/Near",
            "Assets/Sprites/Obstacles",
            "Assets/Sprites/Collectibles",
            "Assets/Data",
            "Assets/Data/Characters",
            "Assets/Data/Levels",
            "Assets/Data/Decorations",
            "Assets/Data/Decorations/Forest",
            "Assets/Data/Decorations/Mountain",
            "Assets/Data/Decorations/Desert",
            "Assets/Data/Decorations/Underwater",
            "Assets/Data/Decorations/Ocean",
            "Assets/Audio",
            "Assets/Audio/Music",
            "Assets/Audio/SFX",
            "Assets/Fonts",
            "Assets/Materials"
        };

        foreach (string folder in folders)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
                Debug.Log($"Created folder: {folder}");
            }
        }

        AssetDatabase.Refresh();
        Debug.Log("Folder structure created successfully!");
    }
}
```

**Usage:**
1. Save script in `Assets/Editor/`
2. In Unity: **Tools → Create Folder Structure**
3. All folders created instantly

---

## 🎯 Folder Usage Guide

### When Ludo.ai Assets Arrive:

**Characters (13 animals + 1 cart):**
- Cart PNG → `Assets/Sprites/Characters/Cart/`
- Animal PNGs → `Assets/Sprites/Characters/Animals/`
- Icon PNGs → `Assets/Sprites/UI/Icons/`

**Environment Decorations (65 assets):**
- Forest assets → `Assets/Sprites/Environment/Forest/Far|Mid|Near/`
- Mountain assets → `Assets/Sprites/Environment/Mountain/Far|Mid|Near/`
- Desert assets → `Assets/Sprites/Environment/Desert/Far|Mid|Near/`
- Underwater assets → `Assets/Sprites/Environment/Underwater/Far|Mid|Near/`
- Ocean assets → `Assets/Sprites/Environment/Ocean/Far|Mid|Near/`

**Platform Borders (15 assets):**
- Forest borders → `Assets/Sprites/Borders/Forest/`
- Mountain borders → `Assets/Sprites/Borders/Mountain/`
- etc.

**UI Elements (8-10 assets):**
- Button sprites → `Assets/Sprites/UI/Buttons/`
- Panel sprites → `Assets/Sprites/UI/Panels/`
- Welcome screens → `Assets/Sprites/UI/Backgrounds/`

---

## 📦 Prefab Organization Strategy

### Create Prefabs in This Order:

1. **Cart.prefab** (Assets/Prefabs/Player/)
   - Create in Level01 scene
   - Configure Rigidbody2D, Collider, CartController script
   - Add Animal sprite slot
   - Drag to Prefabs/Player/ folder
   - **Delete from Level01** (will re-add later)

2. **UI Prefabs** (Assets/Prefabs/UI/)
   - CharacterSlot.prefab (in CharacterSelectScene)
   - LevelSlot.prefab (in LevelSelectScene)
   - HUD.prefab (in Level01)

3. **Collectibles** (Assets/Prefabs/Collectibles/)
   - Coin.prefab
   - PowerUp.prefab (future)

4. **Obstacles** (Assets/Prefabs/Obstacles/)
   - Spike.prefab
   - Rock.prefab
   - Gap.prefab

5. **Environment Decorations** (Assets/Prefabs/Environment/[Theme]/)
   - Create prefab for each Ludo.ai decoration
   - Organize by theme folder

---

## 🔄 Asset Import Workflow

**When importing sprites from Ludo.ai:**

1. **Drag PNG files** into appropriate Sprites subfolder
2. **Select sprite** in Project window
3. **Configure import settings:**
   - Texture Type: Sprite (2D and UI)
   - Pixels Per Unit: 100
   - Filter Mode: Bilinear
   - Compression: None
   - Click "Apply"
4. **Create prefab** (if needed)
5. **Create ScriptableObject data** (if character/decoration)

---

## ✅ Folder Structure Checklist

- [ ] All main folders created (Scenes, Scripts, Prefabs, Sprites, Data, Audio, Fonts, Materials)
- [ ] Scripts subfolders created (Managers, Player, UI, Collectibles, Obstacles, Environment, ScriptableObjects)
- [ ] Prefabs subfolders created (Player, UI, Collectibles, Obstacles, Environment + 5 themes)
- [ ] Sprites subfolders created (Characters, UI, Borders, Environment, Obstacles, Collectibles)
- [ ] Sprites/Environment has 5 theme folders, each with Far/Mid/Near
- [ ] Sprites/Borders has 5 theme folders
- [ ] Data subfolders created (Characters, Levels, Decorations + 5 themes)
- [ ] Audio subfolders created (Music, SFX)
- [ ] Ready to import Ludo.ai assets

---

## 📚 Related Documentation

- **Unity Setup:** `/docs/06-unity-setup/scene-architecture-guide.md`
- **Asset Import:** `/docs/06-unity-setup/unity-basics-setup.md`
- **Ludo.ai Assets:** `/ludo/ui-assets-guide.md`

---

**Last Updated:** 2026-01-17
**For:** Adventures of the World - Unity 2022.3 LTS
**Purpose:** Complete folder organization blueprint
