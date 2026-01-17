# Unity Basics Setup Guide

**Quick reference for common Unity setup tasks and element configuration**

---

## 📋 Overview

This guide covers:
1. Unity Project Settings
2. Canvas & UI Element Setup
3. Sprite Import Settings
4. Prefab Creation Basics
5. Component Setup
6. Build Settings

---

## ⚙️ 1. Unity Project Settings (Initial Setup)

### 1.1 Player Settings

**Edit → Project Settings → Player**

**Company Name:** Your name/studio
**Product Name:** Adventures of the World
**Default Icon:** Your game icon (512×512)

**Resolution and Presentation:**
- **Default Screen Width:** 1920
- **Default Screen Height:** 1080
- **Fullscreen Mode:** Fullscreen Window (or Windowed for testing)
- **Allowed Orientations for Mobile:**
  - Portrait ✓
  - Landscape Right ✓
  - Landscape Left ✓

### 1.2 Quality Settings

**Edit → Project Settings → Quality**

**Levels:**
- Create 3 levels: Low, Medium, High
- **Default:** Medium
- **Anti Aliasing:** 2x Multi Sampling (Medium/High)
- **VSync Count:** Every V Blank (prevents tearing)

### 1.3 Physics 2D Settings

**Edit → Project Settings → Physics 2D**

**Gravity:** Y = -20 (adjust for platformer feel)

**Layer Collision Matrix:**
- Player collides with: Ground, Obstacles
- Collectibles collide with: Player only
- Background collides with: Nothing

### 1.4 Tags and Layers

**Edit → Project Settings → Tags and Layers**

**Tags:**
- Player
- Ground
- Obstacle
- Collectible
- Coin
- Enemy

**Layers:**
- Player (Layer 6)
- Ground (Layer 7)
- Obstacles (Layer 8)
- Collectibles (Layer 9)
- Background_Far (Layer 10)
- Background_Mid (Layer 11)
- Background_Near (Layer 12)

---

## 🎨 2. Sprite Import Settings

### 2.1 Import Sprites from Ludo.ai

**When importing PNG sprites:**

1. **Drag sprites into** `Assets/Sprites/` folder (organize by category)

2. **Select sprite in Project window**

3. **Inspector → Import Settings:**
   - **Texture Type:** Sprite (2D and UI)
   - **Sprite Mode:** Single (or Multiple if sprite sheet)
   - **Pixels Per Unit:** 100 (standard, adjust if needed)
   - **Filter Mode:** Bilinear (smooth) or Point (pixel-perfect)
   - **Compression:** None (best quality) or Low Quality (better performance)
   - **Max Size:** 2048 or 4096 (for high-res sprites)

4. **Click "Apply"**

### 2.2 Creating Sprite Atlases (Optional - Performance)

**For many small sprites (coins, obstacles):**

1. Window → 2D → Sprite Atlas
2. Create new Sprite Atlas asset
3. Add sprites to "Objects for Packing"
4. Unity automatically batches these sprites in one draw call

---

## 🖼️ 3. Canvas & UI Element Setup

### 3.1 Create Canvas

1. **Right-click Hierarchy → UI → Canvas**

2. **Canvas Component Settings:**
   - **Render Mode:** Screen Space - Overlay (UI always on top)
   - OR **Screen Space - Camera** (if you need depth sorting with 3D)

3. **Canvas Scaler Component:**
   - **UI Scale Mode:** Scale With Screen Size
   - **Reference Resolution:** 1920 × 1080
   - **Screen Match Mode:** Match Width Or Height
   - **Match:** 0.5 (balance between width and height scaling)

4. **Graphic Raycaster:** Leave default (allows UI interaction)

### 3.2 Create UI Button

**Basic Button Setup:**

1. **Right-click Canvas → UI → Button - TextMeshPro**
   - (First time: Import TMP Essentials)

2. **Button GameObject:**
   - **RectTransform:**
     - Width: 400
     - Height: 100
     - Position: Centered or as needed

3. **Image Component (Button background):**
   - **Source Image:** Your wooden button sprite (if using 9-slice)
   - **Image Type:** Sliced (if using 9-slice sprite)
   - **Color:** White (or tint as needed)

4. **Button Component:**
   - **Interactable:** ✓ (checked)
   - **Transition:** Color Tint (or Sprite Swap for different button states)
   - **Normal Color:** White
   - **Highlighted Color:** Light Gray
   - **Pressed Color:** Dark Gray
   - **Selected Color:** Light Gray
   - **Disabled Color:** Dark Gray (50% alpha)
   - **Color Multiplier:** 1
   - **Fade Duration:** 0.1

5. **Text (Child of Button):**
   - Select TextMeshPro component
   - **Text:** "Start Game"
   - **Font:** Your font asset
   - **Font Size:** 48
   - **Alignment:** Center + Middle
   - **Color:** Black or White (readable on button)

6. **Add Click Event:**
   - Button component → On Click ()
   - Click `+`
   - Drag script GameObject to object field
   - Select function: `ScriptName.FunctionName`

### 3.3 Create UI Image (For Backgrounds, Icons)

1. **Right-click Canvas → UI → Image**

2. **Image Component:**
   - **Source Image:** Drag sprite here
   - **Color:** White (or tint)
   - **Raycast Target:** Uncheck if not interactive (performance)

3. **RectTransform:**
   - **Anchors:** For backgrounds, use stretch-stretch preset
     - Min: (0, 0), Max: (1, 1)
     - Left, Right, Top, Bottom: 0
   - **Pivot:** (0.5, 0.5) center

### 3.4 Create UI Text (TextMeshPro)

1. **Right-click Canvas → UI → Text - TextMeshPro**

2. **TextMeshPro Component:**
   - **Text:** Your text content
   - **Font Asset:** Select font
   - **Font Size:** Adjust as needed
   - **Color:** Readable color
   - **Alignment:** Horizontal + Vertical alignment
   - **Wrapping:** Enable if multi-line
   - **Overflow:** Ellipsis or Truncate

---

## 🎮 4. Prefab Creation Basics

### 4.1 Create a Prefab from GameObject

**Example: Creating Cart Prefab**

1. **Setup GameObject in Scene:**
   - Create empty GameObject: `Cart`
   - Add child: SpriteRenderer for cart body
   - Add child: SpriteRenderer for animal (empty for now)
   - Add components: Rigidbody2D, Collider2D, CartController script

2. **Configure all components** (see Section 5)

3. **Drag to Project Window:**
   - Create folder `Assets/Prefabs/Player/`
   - Drag `Cart` GameObject from Hierarchy to Prefabs folder
   - **Original GameObject turns blue** (connected to prefab)

4. **Editing Prefab:**
   - **Option 1:** Double-click prefab in Project window → Edit in Prefab Mode
   - **Option 2:** Select instance in Hierarchy → Inspector → Open Prefab
   - **Option 3:** Edit instance, then click "Overrides" → Apply All

### 4.2 Using Prefabs in Scenes

**To use Cart prefab in all 12 levels:**

1. Drag `Cart.prefab` from Project window into each level scene
2. Position at start location
3. **All instances linked** - change prefab, all levels update

**Prefab Variants (Optional):**
- Right-click prefab → Create → Prefab Variant
- Create variants for different themes (ForestCart, DesertCart, etc.)
- Override sprite, color, but keep same behavior

---

## 🔧 5. Component Setup

### 5.1 SpriteRenderer Setup

**Used for: Cart body, animal sprites, background elements**

1. **Add Component → Rendering → Sprite Renderer**

2. **Settings:**
   - **Sprite:** Drag sprite here
   - **Color:** White (or tint)
   - **Flip X/Y:** If sprite is facing wrong direction
   - **Sorting Layer:** Create layers (Background_Far, Background_Mid, Background_Near, Default, Player)
   - **Order in Layer:** Higher = drawn on top (within same layer)
   - **Material:** Default (Sprites-Default)

### 5.2 Rigidbody2D Setup

**Used for: Cart (player), obstacles with physics**

1. **Add Component → Physics 2D → Rigidbody 2D**

2. **For Player (Cart):**
   - **Body Type:** Dynamic
   - **Mass:** 1 (default)
   - **Linear Drag:** 0
   - **Angular Drag:** 0.05
   - **Gravity Scale:** 1 (affected by gravity)
   - **Constraints:**
     - Freeze Rotation Z: ✓ (prevent cart from rotating)

3. **For Static Obstacles:**
   - **Body Type:** Kinematic (moves programmatically)
   - OR **Static** (never moves)

### 5.3 Collider2D Setup

**Options: BoxCollider2D, CircleCollider2D, CapsuleCollider2D, PolygonCollider2D**

**For Cart:**
1. **Add Component → Physics 2D → Capsule Collider 2D** (or Box Collider 2D)

2. **Settings:**
   - **Is Trigger:** Unchecked (solid collision)
   - **Size:** Adjust to fit cart sprite (green outline in Scene view)
   - **Offset:** Center of cart
   - **Edit Collider:** Click "Edit Collider" button to adjust in Scene view

**For Collectibles (Coins):**
1. **Add Collider2D**
2. **Is Trigger:** ✓ Checked (pass through, but detect collision)

### 5.4 Script Component Setup

**Example: Adding CartController to Cart**

1. **Create Script:**
   - In Project, right-click `Assets/Scripts/Player/`
   - Create → C# Script
   - Name: `CartController`

2. **Add to GameObject:**
   - Select Cart GameObject
   - Inspector → Add Component
   - Search "CartController"
   - OR drag script from Project to Inspector

3. **Public Variables (Serialized Fields):**
   - Appear in Inspector when script has `public` variables
   - Example: `public float moveSpeed = 5f;`
   - Adjust values in Inspector (overrides script defaults)

4. **Assigning References:**
   - For `public SpriteRenderer animalSprite;`
   - Drag SpriteRenderer component or GameObject from Hierarchy to field in Inspector

---

## 📦 6. Build Settings

### 6.1 Add Scenes to Build

**File → Build Settings**

1. **Click "Add Open Scenes"** for current scene
   - OR drag scenes from Project window to "Scenes In Build"

2. **Order matters:**
   - Index 0: StartScene (first to load)
   - Index 1: CharacterSelectScene
   - Index 2: LevelSelectScene
   - Index 3+: Level scenes

3. **Remove scenes:** Click scene, press Delete

### 6.2 Platform Settings

**Select Platform:**
- **PC, Mac & Linux Standalone** (for desktop)
- **Android** (for mobile)
- **iOS** (for mobile)
- **WebGL** (for browser)

**Click "Switch Platform"** if not already selected

**Platform-specific settings:**
- **Windows:** Default settings usually fine
- **Android:** Set package name, min API level
- **iOS:** Set bundle identifier, target SDK

### 6.3 Build the Game

1. **Click "Build"** (or "Build And Run")
2. Choose save location
3. Name executable: `AdventuresOfTheWorld.exe` (Windows)
4. Unity compiles and creates build

---

## 🎯 7. Common Setup Patterns

### 7.1 Parallax Background Setup

**See also:** `/docs/04-week-5-procedural/parallax-background-setup.md`

**Quick Setup:**

1. **Create 3 empty GameObjects:**
   - `Background_Far`
   - `Background_Mid`
   - `Background_Near`

2. **Add ParallaxLayer script to each**

3. **Settings:**
   - Far: `parallaxSpeed = 0.2f`
   - Mid: `parallaxSpeed = 0.5f`
   - Near: `parallaxSpeed = 0.8f`

4. **Add decoration sprites as children**

### 7.2 Cinemachine Camera Setup

1. **Window → Package Manager**
2. **Install "Cinemachine"**

3. **GameObject → Cinemachine → 2D Camera**

4. **Virtual Camera Settings:**
   - **Follow:** Drag Cart GameObject here
   - **Dead Zone:** Adjust comfort zone (cart can move within before camera follows)
   - **Soft Zone:** Smooth follow area
   - **Damping:** Smoothness of camera movement (0 = instant, higher = smoother)

5. **Confiner (Optional):**
   - Add PolygonCollider2D to level bounds
   - Virtual Camera → Add Extension → Cinemachine Confiner
   - Assign collider to Bounding Shape 2D

### 7.3 Coin Collection Setup

**Coin Prefab:**

1. **Create GameObject: `Coin`**
2. **Add SpriteRenderer** (coin sprite)
3. **Add CircleCollider2D** (Is Trigger: ✓)
4. **Add Script:** `CoinCollector.cs`

```csharp
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public int coinValue = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Add coin to score
            // GameManager.Instance.AddCoins(coinValue);

            // Play sound effect
            // AudioManager.Instance.PlaySFX("CoinCollect");

            // Destroy coin
            Destroy(gameObject);
        }
    }
}
```

5. **Make Prefab** (drag to `Assets/Prefabs/Collectibles/`)

---

## 🛠️ 8. Inspector Tips & Tricks

### 8.1 Locking Inspector

- **Top-right of Inspector:** Click lock icon
- Keeps Inspector showing selected object even when clicking others
- Useful for comparing multiple objects or editing while selecting

### 8.2 Copy/Paste Components

- **Right-click component → Copy Component**
- Select another GameObject
- **Right-click in Inspector → Paste Component As New**
- Copies all values

### 8.3 Reset Transform

- **Right-click Transform component → Reset**
- Sets Position (0,0,0), Rotation (0,0,0), Scale (1,1,1)

### 8.4 Multi-Object Editing

- **Select multiple GameObjects** (Ctrl+Click or Shift+Click)
- Inspector shows shared properties
- Changes apply to all selected

### 8.5 Debug Inspector

- **Inspector window → 3-dot menu → Debug**
- Shows private variables (non-public)
- Shows internal Unity data

---

## 🐛 9. Common Setup Mistakes

### UI Not Visible
- **Check:** Canvas is child of EventSystem
- **Check:** UI elements have RectTransform (not regular Transform)
- **Check:** Canvas Render Mode is correct
- **Check:** Sorting layer/order

### Sprite Not Showing
- **Check:** Sprite assigned in SpriteRenderer
- **Check:** Color is not transparent (alpha = 255)
- **Check:** Camera can see it (within view frustum)
- **Check:** Sorting layer/order (not behind other sprites)

### Physics Not Working
- **Check:** GameObject has Rigidbody2D
- **Check:** GameObject has Collider2D
- **Check:** Layers are set to collide (Physics 2D Settings)
- **Check:** Collider is not trigger (unless intended)

### Script Not Running
- **Check:** Script has no syntax errors (Console window)
- **Check:** Script is attached to GameObject
- **Check:** GameObject is active (checkbox in Inspector)
- **Check:** Function names correct (Start, Update, etc.)

### Button Not Clicking
- **Check:** EventSystem exists in scene
- **Check:** Button has Graphic Raycaster on Canvas
- **Check:** Button's Raycast Target is checked
- **Check:** Nothing blocking button (other UI in front)
- **Check:** Button is Interactable

---

## 📚 Quick Reference

### Keyboard Shortcuts

| Action | Shortcut |
|--------|----------|
| Play/Stop | Ctrl + P |
| Pause | Ctrl + Shift + P |
| Frame Selected | F |
| Create Empty GameObject | Ctrl + Shift + N |
| Duplicate | Ctrl + D |
| Delete | Delete |
| Focus Scene View | Ctrl + Shift + F |
| Lock Inspector | Click lock icon |
| Vertex Snap | Hold V + drag |

### GameObject Menu Shortcuts

| Create | Menu Path |
|--------|-----------|
| Empty | GameObject → Create Empty |
| 2D Sprite | GameObject → 2D Object → Sprite |
| UI Canvas | GameObject → UI → Canvas |
| UI Button | GameObject → UI → Button |
| UI Image | GameObject → UI → Image |

---

## 📖 Related Documentation

- **Scene Architecture:** `/docs/06-unity-setup/scene-architecture-guide.md`
- **Procedural Generation:** `/docs/04-week-5-procedural/procedural-generation-unity-setup.md`
- **Requirements:** `/docs/01-project-planning/requirements.md`

---

**Last Updated:** 2026-01-17
**For:** Adventures of the World - Unity 2022.3 LTS
**Scope:** Unity basics, component setup, common patterns
