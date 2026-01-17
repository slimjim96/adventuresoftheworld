# Unity Setup Guide - Scenes & UI Flow

**High-level step-by-step guide for setting up the game's scene architecture and UI systems**

---

## 📋 Overview

This guide covers:
1. Scene Architecture & Setup (4 main scenes + 12 level scenes)
2. Scene Flow & Navigation
3. Global Cart/Character System (persists across scenes)
4. UI Setup Basics
5. Scene Loading System

---

## 🎬 Scene Architecture

### Scene List

Your project will have **16 total scenes**:

| Scene Name | Purpose | Load Order |
|------------|---------|------------|
| `StartScene` | Main menu, splash screen | First (Build Index 0) |
| `CharacterSelectScene` | Choose animal character | After Start |
| `LevelSelectScene` | Choose which level to play | After Character Select |
| `Level01_Forest` through `Level12_Ocean` | 12 gameplay levels | Selected from Level Select |

**File structure:**
```
Assets/Scenes/
├── StartScene.unity
├── CharacterSelectScene.unity
├── LevelSelectScene.unity
└── Levels/
    ├── Level01_Forest.unity
    ├── Level02_Forest.unity
    ├── Level03_Forest.unity
    ├── Level04_Mountain.unity
    ├── Level05_Mountain.unity
    ├── Level06_Mountain.unity
    ├── Level07_Desert.unity
    ├── Level08_Desert.unity
    ├── Level09_Desert.unity
    ├── Level10_Underwater.unity
    ├── Level11_Underwater.unity
    └── Level12_Ocean.unity
```

---

## 🏗️ Step 1: Create All Scenes

### 1.1 Create the Scenes

**In Unity:**
1. Right-click in `Assets/Scenes/` folder
2. Create → Scene
3. Name each scene according to the list above
4. Save each scene

### 1.2 Add Scenes to Build Settings

**Critical step for scene loading:**

1. File → Build Settings
2. Click "Add Open Scenes" for each scene (or drag all scenes from Project window)
3. **Ensure order:**
   - Index 0: `StartScene`
   - Index 1: `CharacterSelectScene`
   - Index 2: `LevelSelectScene`
   - Index 3-14: Level scenes in order

**Why this matters:** Scene loading uses build indices or scene names. Scenes must be in Build Settings to load.

---

## 🎮 Step 2: Global Cart/Character System

### Architecture Choice: Singleton Manager + ScriptableObject

**Why this approach:**
- Singleton persists across scene loads (DontDestroyOnLoad)
- ScriptableObject stores character data
- Clean, Unity-friendly pattern

### 2.1 Create GameManager Script

**Create:** `Assets/Scripts/Managers/GameManager.cs`

```csharp
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Player Selection")]
    public CharacterData selectedCharacter; // ScriptableObject reference

    [Header("Level Progress")]
    public int currentLevel = 1;
    public int highestUnlockedLevel = 1;

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persists across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SelectCharacter(CharacterData character)
    {
        selectedCharacter = character;
        Debug.Log($"Character selected: {character.characterName}");
    }

    public void LoadLevel(int levelIndex)
    {
        currentLevel = levelIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene($"Level{levelIndex:00}");
    }

    public void UnlockNextLevel()
    {
        highestUnlockedLevel = Mathf.Max(highestUnlockedLevel, currentLevel + 1);
    }
}
```

### 2.2 Create CharacterData ScriptableObject

**Create:** `Assets/Scripts/ScriptableObjects/CharacterData.cs`

```csharp
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Game/Character Data")]
public class CharacterData : ScriptableObject
{
    [Header("Character Info")]
    public string characterName;
    public Sprite characterSprite; // Riding pose sprite
    public Sprite iconSprite;      // Selection screen icon

    [Header("Unlock Requirements")]
    public int unlockCost;
    public bool isUnlocked = false;

    [Header("Character Stats (Optional)")]
    public float jumpBoostMultiplier = 1f; // Future: unique abilities
}
```

**Create character data assets:**
1. Right-click in `Assets/Data/Characters/`
2. Create → Game → Character Data
3. Create 13 assets (Cat, Dog, Elephant, etc.)
4. Fill in details for each character
5. Set Cat's `isUnlocked = true` (default character)

### 2.3 Create GameManager GameObject

**In StartScene:**
1. Create empty GameObject, name it `GameManager`
2. Add `GameManager` component
3. This will persist across all scenes automatically

---

## 🎨 Step 3: Start Scene Setup

### 3.1 Scene Hierarchy

```
StartScene
├── Canvas (UI)
│   ├── Background (Image - Welcome screen art)
│   ├── Logo (Image - Game logo)
│   ├── StartButton (Button)
│   └── SettingsButton (Button - optional)
├── EventSystem
└── GameManager (DontDestroyOnLoad)
```

### 3.2 Canvas Setup

1. **Create Canvas:**
   - Right-click in Hierarchy → UI → Canvas
   - Canvas Scaler: Scale With Screen Size
   - Reference Resolution: 1920x1080
   - Match: 0.5 (balance width/height)

2. **Add Background:**
   - Right-click Canvas → UI → Image
   - Name: `Background`
   - Source Image: Your welcome screen sprite
   - Anchor: Stretch full screen
   - Set to fill canvas

3. **Add Logo:**
   - UI → Image
   - Name: `Logo`
   - Position: Upper-center
   - Anchor: Top-center

4. **Add Start Button:**
   - UI → Button - TextMeshPro
   - Name: `StartButton`
   - Text: "Start Game" or "Play"
   - Anchor: Middle-center
   - Size: ~400x100

### 3.3 Start Button Script

**Create:** `Assets/Scripts/UI/StartButton.cs`

```csharp
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        // Load Character Select scene
        SceneManager.LoadScene("CharacterSelectScene");
    }
}
```

**Attach to StartButton:**
1. Select `StartButton` in Hierarchy
2. In Inspector, Button component → On Click ()
3. Click `+`
4. Drag `StartButton` GameObject to object field
5. Select `StartButton.OnStartButtonClick`

---

## 🐾 Step 4: Character Select Scene Setup

### 4.1 Scene Hierarchy

```
CharacterSelectScene
├── Canvas
│   ├── Background (Image)
│   ├── Title (Text - "Choose Your Character")
│   ├── CharacterGrid (Grid Layout)
│   │   ├── CharacterSlot_Cat (Prefab instance)
│   │   ├── CharacterSlot_Dog (Prefab instance)
│   │   ├── ... (11 more character slots)
│   │   └── CharacterSlot_Dragon (Prefab instance)
│   ├── ContinueButton (Button - "Continue to Level Select")
│   └── BackButton (Button - "Back to Menu")
└── EventSystem
```

### 4.2 Create CharacterSlot Prefab

**Create:** `Assets/Prefabs/UI/CharacterSlot.prefab`

**Hierarchy inside prefab:**
```
CharacterSlot
├── Background (Image - wooden panel)
├── Icon (Image - character icon)
├── CharacterName (Text)
├── CostText (Text - "500 coins")
├── LockedOverlay (Image - semi-transparent black, active if locked)
└── SelectButton (Button - invisible, full-size)
```

**Create script:** `Assets/Scripts/UI/CharacterSlot.cs`

```csharp
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSlot : MonoBehaviour
{
    public CharacterData characterData;

    [Header("UI References")]
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;
    public GameObject lockedOverlay;
    public Button selectButton;

    void Start()
    {
        SetupSlot();
    }

    void SetupSlot()
    {
        iconImage.sprite = characterData.iconSprite;
        nameText.text = characterData.characterName;

        if (characterData.isUnlocked)
        {
            lockedOverlay.SetActive(false);
            costText.text = "Unlocked";
        }
        else
        {
            lockedOverlay.SetActive(true);
            costText.text = $"{characterData.unlockCost} coins";
            selectButton.interactable = false;
        }

        selectButton.onClick.AddListener(OnSelectCharacter);
    }

    void OnSelectCharacter()
    {
        GameManager.Instance.SelectCharacter(characterData);

        // Visual feedback: highlight this slot, unhighlight others
        // (Implementation depends on your UI design)

        Debug.Log($"Selected: {characterData.characterName}");
    }
}
```

### 4.3 Setup Character Grid

1. **Create Grid Layout:**
   - In Canvas, create empty GameObject named `CharacterGrid`
   - Add component: Grid Layout Group
   - Settings:
     - Cell Size: 200x250 (adjust to fit your icons)
     - Spacing: 20x20
     - Start Corner: Upper Left
     - Start Axis: Horizontal
     - Child Alignment: Middle Center
     - Constraint: Fixed Column Count = 4 (or 5, depending on design)

2. **Instantiate CharacterSlot prefab 13 times:**
   - Drag `CharacterSlot` prefab into `CharacterGrid` 13 times
   - Rename each: `CharacterSlot_Cat`, `CharacterSlot_Dog`, etc.
   - For each instance:
     - In Inspector, assign corresponding `CharacterData` asset to `characterData` field
     - Connect UI references (Icon, NameText, CostText, LockedOverlay, SelectButton)

### 4.4 Continue Button

**Create script:** `Assets/Scripts/UI/CharacterSelectManager.cs`

```csharp
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectManager : MonoBehaviour
{
    public Button continueButton;

    void Start()
    {
        // Ensure at least default character (Cat) is selected
        if (GameManager.Instance.selectedCharacter == null)
        {
            // Auto-select Cat or disable continue button
            continueButton.interactable = false;
        }
    }

    void Update()
    {
        // Enable continue button if character selected
        continueButton.interactable = (GameManager.Instance.selectedCharacter != null);
    }

    public void OnContinueClick()
    {
        SceneManager.LoadScene("LevelSelectScene");
    }

    public void OnBackClick()
    {
        SceneManager.LoadScene("StartScene");
    }
}
```

**Attach to Canvas:**
1. Create empty GameObject in Canvas, name it `CharacterSelectManager`
2. Add `CharacterSelectManager` component
3. Assign `ContinueButton` reference
4. Wire up buttons:
   - `ContinueButton.onClick` → `CharacterSelectManager.OnContinueClick`
   - `BackButton.onClick` → `CharacterSelectManager.OnBackClick`

---

## 🗺️ Step 5: Level Select Scene Setup

### 5.1 Scene Hierarchy

```
LevelSelectScene
├── Canvas
│   ├── Background (Image)
│   ├── Title (Text - "Choose Your Adventure")
│   ├── LevelGrid (Grid Layout)
│   │   ├── LevelSlot_01 (Prefab instance)
│   │   ├── LevelSlot_02 (Prefab instance)
│   │   ├── ... (10 more)
│   │   └── LevelSlot_12 (Prefab instance)
│   └── BackButton (Button - "Back to Character Select")
└── EventSystem
```

### 5.2 Create LevelSlot Prefab

**Create:** `Assets/Prefabs/UI/LevelSlot.prefab`

**Hierarchy:**
```
LevelSlot
├── Background (Image - themed panel)
├── LevelNumber (Text - "Level 1")
├── LevelName (Text - "Enchanted Grove")
├── ThemeIcon (Image - forest/mountain/desert icon)
├── Stars (3 star images for completion)
├── LockedOverlay (Image)
└── PlayButton (Button)
```

**Create script:** `Assets/Scripts/UI/LevelSlot.cs`

```csharp
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSlot : MonoBehaviour
{
    [Header("Level Data")]
    public int levelNumber;
    public string levelName;
    public string sceneName;

    [Header("UI References")]
    public TextMeshProUGUI levelNumberText;
    public TextMeshProUGUI levelNameText;
    public GameObject lockedOverlay;
    public Button playButton;

    void Start()
    {
        SetupSlot();
    }

    void SetupSlot()
    {
        levelNumberText.text = $"Level {levelNumber}";
        levelNameText.text = levelName;

        // Check if level is unlocked
        bool isUnlocked = (levelNumber <= GameManager.Instance.highestUnlockedLevel);

        lockedOverlay.SetActive(!isUnlocked);
        playButton.interactable = isUnlocked;

        playButton.onClick.AddListener(OnPlayLevel);
    }

    void OnPlayLevel()
    {
        GameManager.Instance.LoadLevel(levelNumber);
        SceneManager.LoadScene(sceneName);
    }
}
```

### 5.3 Setup Level Grid

1. **Create Grid Layout** (same as Character Select)
2. **Instantiate LevelSlot 12 times**
3. **Configure each slot:**
   - Level 1: `levelNumber = 1`, `levelName = "Enchanted Grove"`, `sceneName = "Level01_Forest"`
   - Level 2: `levelNumber = 2`, `levelName = "Forest Depths"`, `sceneName = "Level02_Forest"`
   - etc.

---

## 🎮 Step 6: Gameplay Level Setup (Template)

### 6.1 Level Scene Hierarchy (Example: Level01_Forest)

```
Level01_Forest
├── GameCamera (Cinemachine Virtual Camera)
├── Environment
│   ├── Background_Far (Parallax layer 0.2x)
│   ├── Background_Mid (Parallax layer 0.5x)
│   ├── Background_Near (Parallax layer 0.8x)
│   └── Ground (Platform with collider)
├── Player (Cart + Animal)
│   ├── CartSprite (SpriteRenderer)
│   └── AnimalSprite (SpriteRenderer - from GameManager)
├── Obstacles (Parent for all obstacles)
├── Collectibles (Parent for coins, power-ups)
├── LevelManager (Script)
└── Canvas (HUD)
    ├── LivesDisplay
    ├── CoinsDisplay
    ├── PauseButton
    └── PauseMenu (hidden by default)
```

### 6.2 Create Global Cart Prefab

**This is the key to having the cart work the same in all 12 levels.**

**Create:** `Assets/Prefabs/Player/Cart.prefab`

**Hierarchy inside prefab:**
```
Cart
├── CartBody (SpriteRenderer - cart sprite)
│   └── CartCollider (CapsuleCollider2D or BoxCollider2D)
├── AnimalSlot (Empty GameObject - position where animal appears)
│   └── AnimalSprite (SpriteRenderer - set at runtime)
└── Wheels (if separate)
    ├── WheelLeft (SpriteRenderer with rotation animation)
    └── WheelRight (SpriteRenderer with rotation animation)
```

**Create script:** `Assets/Scripts/Player/CartController.cs`

```csharp
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CartController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("References")]
    public SpriteRenderer animalSpriteRenderer;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Load selected character from GameManager
        LoadSelectedCharacter();
    }

    void LoadSelectedCharacter()
    {
        if (GameManager.Instance != null && GameManager.Instance.selectedCharacter != null)
        {
            CharacterData character = GameManager.Instance.selectedCharacter;
            animalSpriteRenderer.sprite = character.characterSprite;

            // Optional: Apply character-specific stats
            jumpForce *= character.jumpBoostMultiplier;

            Debug.Log($"Loaded character: {character.characterName}");
        }
        else
        {
            Debug.LogWarning("No character selected! Using default.");
        }
    }

    void Update()
    {
        // Auto-scroll
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        // Jump input
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
```

**Key point:** This cart prefab is **identical in all 12 levels**. Just drag it into each level scene.

### 6.3 Level-Specific Setup

**For each level (Level01 through Level12):**

1. **Place Cart prefab:**
   - Drag `Cart` prefab into scene
   - Position at starting location
   - Tag as "Player"

2. **Setup Camera:**
   - Use Cinemachine Virtual Camera
   - Follow: Cart GameObject
   - Look At: Cart GameObject (or offset)
   - Confiner: Set to level bounds

3. **Create Level Manager:**
   - Empty GameObject named `LevelManager`
   - Script handles level-specific logic (obstacles, coins, win condition)

**Create:** `Assets/Scripts/Managers/LevelManager.cs`

```csharp
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Level Info")]
    public int levelNumber;
    public float levelLength = 100f; // Distance to complete level

    [Header("References")]
    public Transform player;

    void Update()
    {
        CheckLevelComplete();
    }

    void CheckLevelComplete()
    {
        if (player.position.x >= levelLength)
        {
            OnLevelComplete();
        }
    }

    void OnLevelComplete()
    {
        Debug.Log($"Level {levelNumber} Complete!");

        // Unlock next level
        GameManager.Instance.UnlockNextLevel();

        // Return to level select or load next level
        // Option 1: Back to level select
        SceneManager.LoadScene("LevelSelectScene");

        // Option 2: Auto-load next level
        // GameManager.Instance.LoadLevel(levelNumber + 1);
    }

    public void OnPlayerDeath()
    {
        // Restart level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1; // Reset in case paused
        SceneManager.LoadScene("LevelSelectScene");
    }
}
```

4. **HUD Canvas:**
   - Create UI Canvas for lives, coins, pause button
   - Same HUD prefab can be used across all levels

---

## 🔄 Step 7: Scene Flow Summary

```
StartScene
    ↓ [Click "Start"]
CharacterSelectScene
    ↓ [Select character, click "Continue"]
LevelSelectScene
    ↓ [Click level button]
Level01_Forest (or any level)
    ↓ [Complete level]
    → [Returns to LevelSelectScene with next level unlocked]
```

**Key Systems:**
- **GameManager:** Persists across all scenes (DontDestroyOnLoad)
- **Character Selection:** Stored in GameManager, loaded by Cart in each level
- **Cart Prefab:** Identical instance in all 12 levels, reads character from GameManager
- **Level Unlocking:** GameManager tracks highest unlocked level

---

## 📦 Step 8: Prefab Organization

**Recommended prefab structure:**

```
Assets/Prefabs/
├── Player/
│   └── Cart.prefab (Global cart used in all levels)
├── UI/
│   ├── CharacterSlot.prefab
│   ├── LevelSlot.prefab
│   └── HUD.prefab (Reusable across levels)
├── Obstacles/
│   ├── Rock.prefab
│   ├── Spike.prefab
│   └── ... (Per-theme obstacles)
├── Collectibles/
│   ├── Coin.prefab
│   └── PowerUp.prefab
└── Environment/
    ├── ForestTree.prefab
    ├── MountainRock.prefab
    └── ... (Decoration prefabs)
```

**Workflow:**
1. Create prefabs once
2. Drag into all 12 levels
3. Changes to prefab automatically update all instances

---

## 🎨 Step 9: UI Setup Checklist

### For Each Scene:

**StartScene:**
- [ ] Canvas with UI Scale Mode: Scale With Screen Size (1920x1080)
- [ ] Background image (welcome screen)
- [ ] Logo positioned
- [ ] Start button wired to load CharacterSelectScene
- [ ] GameManager GameObject (DontDestroyOnLoad)

**CharacterSelectScene:**
- [ ] Canvas setup
- [ ] CharacterGrid with 13 CharacterSlot instances
- [ ] Each slot assigned correct CharacterData
- [ ] Continue button enabled only when character selected
- [ ] Back button returns to StartScene

**LevelSelectScene:**
- [ ] Canvas setup
- [ ] LevelGrid with 12 LevelSlot instances
- [ ] Each slot configured with level number, name, scene name
- [ ] Locked slots displayed if not unlocked
- [ ] Back button returns to CharacterSelectScene

**Level Scenes (×12):**
- [ ] Cart prefab placed at start position
- [ ] Cinemachine camera following cart
- [ ] LevelManager script with level number set
- [ ] HUD canvas with lives, coins display
- [ ] Pause menu with Resume/Quit buttons

---

## 🛠️ Step 10: Testing the Flow

### Test Sequence:

1. **Start Scene:**
   - Play in Unity
   - Click "Start" button
   - Should load CharacterSelectScene

2. **Character Select:**
   - Click a character (Cat should be unlocked by default)
   - Click "Continue"
   - Should load LevelSelectScene

3. **Level Select:**
   - Only Level 1 should be unlocked initially
   - Click Level 1
   - Should load Level01_Forest with selected character in cart

4. **Gameplay:**
   - Cart should auto-scroll
   - Spacebar should make cart jump
   - Animal sprite should be visible in cart (from character selection)
   - Reach end of level → returns to LevelSelectScene
   - Level 2 should now be unlocked

5. **Persistence Test:**
   - Select different character
   - Play level
   - Verify new character appears in cart
   - Return to menu, select different level
   - New level should also have selected character

---

## 🚨 Common Issues & Solutions

### Issue: Character not appearing in cart
**Solution:**
- Verify GameManager has `selectedCharacter` assigned
- Check Cart's `LoadSelectedCharacter()` is called in Start()
- Ensure `animalSpriteRenderer` reference is assigned in Cart prefab

### Issue: Scene not loading
**Solution:**
- Verify scene is in Build Settings (File → Build Settings)
- Check scene name spelling matches exactly
- Use `SceneManager.LoadScene("SceneName")` with correct name

### Issue: GameManager reset when loading new scene
**Solution:**
- Ensure `DontDestroyOnLoad(gameObject)` is in GameManager.Awake()
- Singleton pattern prevents duplicates

### Issue: Levels not unlocking
**Solution:**
- Call `GameManager.Instance.UnlockNextLevel()` when level completes
- Verify `highestUnlockedLevel` is persisting in GameManager

### Issue: Cart behaves differently in different levels
**Solution:**
- Use **same prefab** in all levels (not duplicates)
- Any changes to Cart should be in CartController script or prefab overrides
- Verify all 12 levels reference the same Cart.prefab

---

## 📚 Next Steps

After basic setup, you can enhance:

1. **Animations:** Add cart wheel rotation, animal idle animations
2. **Particle Effects:** Dust trails, jump effects, coin collection sparkles
3. **Sound:** Background music, jump SFX, coin collection SFX
4. **Save System:** PlayerPrefs or JSON to save character unlocks and level progress
5. **Procedural Generation:** Generate obstacles and decorations at runtime (see procedural docs)
6. **Polish:** Transitions between scenes, loading screens, success/failure animations

---

## 📖 Related Documentation

- **Procedural Generation:** `/docs/04-week-5-procedural/procedural-generation-unity-setup.md`
- **Parallax Backgrounds:** `/docs/04-week-5-procedural/parallax-background-setup.md`
- **Character Reference:** `/docs/05-art-assets/character-reference.md`
- **Project Planning:** `/docs/01-project-planning/requirements.md`

---

**Last Updated:** 2026-01-17
**For:** Adventures of the World - Unity 2022.3 LTS
**Scope:** Basic scene architecture, UI flow, global cart system
