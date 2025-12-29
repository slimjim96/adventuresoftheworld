# HUD Setup Guide - Adventures of the World

This guide walks through setting up the player HUD (Heads-Up Display) with Lives and Coins displays.

---

## Prerequisites

- Unity 2022.3.62f3 (or newer 2022.3 LTS patch)
- Gameplay scene created
- LivesManager and CoinManager in scene
- TextMeshPro package imported (should be automatic)

---

## Part 1: Canvas Setup

### Step 1: Create UI Canvas

1. **In Hierarchy**, right-click → **UI** → **Canvas**
2. Rename to `GameHUD`
3. Select the Canvas and configure in Inspector:
   - **Render Mode**: Screen Space - Overlay
   - **Canvas Scaler** component:
     - UI Scale Mode: **Scale With Screen Size**
     - Reference Resolution: **1920 x 1080**
     - Screen Match Mode: **Match Width Or Height**
     - Match: **0.5** (balanced between width and height)

### Step 2: Configure EventSystem

- Unity automatically creates an EventSystem
- Keep it as is (required for UI input)

---

## Part 2: Lives HUD Setup

### Step 1: Create Hearts Container

1. **Right-click Canvas** → **UI** → **Empty** (create empty GameObject)
2. Rename to `HeartsContainer`
3. Set **RectTransform** properties:
   - **Anchors**: Top-Left
   - **Pivot**: X: 0, Y: 1
   - **Pos X**: 20
   - **Pos Y**: -20
   - **Width**: 300
   - **Height**: 60

### Step 2: Create Heart Prefab

1. **Right-click HeartsContainer** → **UI** → **Image**
2. Rename to `Heart`
3. Configure **RectTransform**:
   - **Width**: 50
   - **Height**: 50
4. Configure **Image** component:
   - **Source Image**: UI/Skin/Knob (placeholder - we'll use sprites later)
   - **Color**: Red (#FF0000)
   - **Preserve Aspect**: Checked

5. **Drag Heart from Hierarchy to Project** window:
   - Create new folder: `Assets/Prefabs/UI/`
   - Save as `HeartIcon.prefab`
6. **Delete Heart from Hierarchy** (we'll spawn them via script)

### Step 3: Add LivesHUD Script

1. **Select HeartsContainer** in Hierarchy
2. **Add Component** → Search for `Lives HUD`
3. Configure the script:
   - **Heart Prefab**: Drag `HeartIcon.prefab` from Project
   - **Hearts Container**: Drag `HeartsContainer` (itself)
   - **Full Heart Sprite**: Leave empty for now (use default)
   - **Empty Heart Sprite**: Leave empty for now (use default)
   - **Max Lives To Display**: 5
   - **Heart Spacing**: 40

---

## Part 3: Coin HUD Setup

### Step 1: Create Coin Display Container

1. **Right-click Canvas** → **UI** → **Empty**
2. Rename to `CoinDisplay`
3. Set **RectTransform** properties:
   - **Anchors**: Top-Right
   - **Pivot**: X: 1, Y: 1
   - **Pos X**: -20
   - **Pos Y**: -20
   - **Width**: 200
   - **Height**: 60

### Step 2: Create Coin Icon

1. **Right-click CoinDisplay** → **UI** → **Image**
2. Rename to `CoinIcon`
3. Configure **RectTransform**:
   - **Anchors**: Middle-Left
   - **Pivot**: X: 0.5, Y: 0.5
   - **Pos X**: 30
   - **Pos Y**: 0
   - **Width**: 50
   - **Height**: 50
4. Configure **Image** component:
   - **Source Image**: UI/Skin/Knob (placeholder)
   - **Color**: Gold (#FFD700)
   - **Preserve Aspect**: Checked

### Step 3: Create Coin Text

1. **Right-click CoinDisplay** → **UI** → **Text - TextMeshPro**
   - If prompted to import TMP Essentials, click **Import TMP Essentials**
2. Rename to `CoinText`
3. Configure **RectTransform**:
   - **Anchors**: Middle-Left
   - **Pivot**: X: 0, Y: 0.5
   - **Pos X**: 70
   - **Pos Y**: 0
   - **Width**: 120
   - **Height**: 60
4. Configure **TextMeshPro** component:
   - **Text**: "0" (default)
   - **Font Style**: Bold
   - **Font Size**: 36
   - **Alignment**: Left, Middle
   - **Color**: White (#FFFFFF)
   - **Extra Settings** → **Outline**: Enabled
     - **Outline Color**: Black (#000000)
     - **Outline Width**: 0.2

### Step 4: Add CoinHUD Script

1. **Select CoinDisplay** in Hierarchy
2. **Add Component** → Search for `Coin HUD`
3. Configure the script:
   - **Coin Text**: Drag `CoinText` from Hierarchy
   - **Coin Icon**: Drag `CoinIcon` from Hierarchy
   - **Coin Prefix**: "" (leave empty, or use "x " if you want)
   - **Show Session Coins**: Checked
   - **Animate On Collect**: Checked
   - **Animation Scale**: 1.2
   - **Animation Duration**: 0.2

---

## Part 4: Testing the HUD

### Step 1: Verify Manager Setup

1. **Select GameManager** in Hierarchy
2. Ensure **LivesManager** and **CoinManager** scripts are attached
3. Configure **LivesManager**:
   - **Starting Lives**: 3
   - **Max Lives**: 5
   - **Respawn Delay**: 1.5
   - **Respawn Point**: Drag your spawn point Transform

### Step 2: Test Lives Display

1. **Play the scene**
2. You should see **3 red hearts** in the top-left corner
3. Test losing a life:
   - Fall off the platform into the DeathZone
   - Hearts should decrease to 2, then 1, then 0 (Game Over)

### Step 3: Test Coin Display

1. **Create a test coin** (see Part 5 below)
2. **Play the scene**
3. Collect the coin
4. Coin counter should increment
5. Coin icon should briefly scale up (bounce animation)

---

## Part 5: Creating Collectible Coins

### Step 1: Create Coin Prefab

1. **In Hierarchy**, create **2D Object** → **Sprites** → **Circle**
2. Rename to `Coin`
3. Configure **Transform**:
   - **Position**: X: 5, Y: 1, Z: 0 (near player spawn)
   - **Scale**: X: 0.3, Y: 0.3, Z: 1
4. Configure **Sprite Renderer**:
   - **Color**: Gold (#FFD700)
   - **Sorting Layer**: Default
   - **Order in Layer**: 5

### Step 2: Add Coin Components

1. **Add Component** → **Circle Collider 2D**
   - **Is Trigger**: Checked
   - **Radius**: 0.5
2. **Add Component** → Search for `Coin` script
3. Configure **Coin** script:
   - **Coin Value**: 1
   - **Play Collection Sound**: Checked
   - **Play Collection Effect**: Checked
   - **Rotate Animation**: Checked
   - **Rotation Speed**: 180
   - **Bob Animation**: True
   - **Bob Speed**: 2
   - **Bob Height**: 0.2

### Step 3: Save Coin as Prefab

1. Create folder: `Assets/Prefabs/Collectibles/`
2. **Drag Coin from Hierarchy** to this folder
3. Prefab saved as `Coin.prefab`
4. You can now duplicate this prefab throughout your level

### Step 4: Test Coin Collection

1. **Play the scene**
2. Move the cart to touch the coin
3. Verify:
   - ✅ Coin disappears
   - ✅ Coin counter increments
   - ✅ Console shows "Coin collected! Value: 1"
   - ✅ Coin icon bounces briefly

---

## Part 6: Placeholder Sprites

Until you generate final art with Ludo.ai, use these placeholder options:

### Option 1: Unity Built-in Sprites

**For Hearts:**
- Full Heart: UI/Skin/Knob (Red color)
- Empty Heart: UI/Skin/Knob (Dark gray color #333333)

**For Coins:**
- Coin Icon: 2D Sprites/Circle (Gold color #FFD700)

### Option 2: Simple Shapes

Create placeholder sprites using Unity's Sprite Editor:

1. **Create** → **2D** → **Sprites** → **Square**
2. Tint with appropriate colors
3. Use for now, replace later

### Option 3: Free Assets (Optional)

Download free UI packs from:
- Unity Asset Store (search "Free UI")
- Kenney.nl (free game assets)
- itch.io (free asset packs)

---

## Part 7: Heart Sprite Variations

To show full vs empty hearts, you have two options:

### Option A: Color Tinting (Easier)

- **Full Heart**: Red (#FF0000)
- **Empty Heart**: Dark Red (#660000) or Gray (#666666)

The `LivesHUD.cs` script will handle switching colors automatically.

### Option B: Different Sprites (Better Visual Quality)

1. Create or find two sprite images:
   - `heart_full.png` - Solid filled heart
   - `heart_empty.png` - Outline heart or grayed out
2. Import to `Assets/Sprites/UI/`
3. Assign in **LivesHUD** script:
   - **Full Heart Sprite**: heart_full
   - **Empty Heart Sprite**: heart_empty

---

## Part 8: Troubleshooting

### Hearts not appearing?

- Check that **Heart Prefab** is assigned in LivesHUD
- Verify **Hearts Container** is assigned to itself
- Ensure **LivesManager.Instance** exists in scene
- Check Console for error messages

### Coin counter not updating?

- Verify **CoinManager** script is in the scene
- Check that **Coin Text** reference is assigned in CoinHUD
- Ensure Coin prefab has **Coin.cs** script attached
- Verify coin's **Collider2D** has **Is Trigger** checked

### Coin collection not working?

- Player must have **"Player"** tag
- Coin **Collider2D** must be a **Trigger**
- Check that **CoinManager.Instance** exists
- Look for errors in Console when collecting

### HUD scaling incorrectly on different resolutions?

- Check **Canvas Scaler** settings:
  - UI Scale Mode: Scale With Screen Size
  - Reference Resolution: 1920x1080
- Adjust **Match** slider (0.5 for balanced scaling)

---

## Part 9: Next Steps

Once HUD is working:

1. ✅ Lives HUD displaying correctly
2. ✅ Coin collection working
3. ⏭️ Create obstacle prefabs (spikes, gaps)
4. ⏭️ Build first complete test level
5. ⏭️ Add sound effects for coin collection
6. ⏭️ Replace placeholder sprites with Ludo.ai generated art (Week 6+)

---

## Summary Checklist

Before moving on, verify:

- [ ] Canvas created with proper scaling settings
- [ ] Hearts display in top-left corner (3 hearts at start)
- [ ] Hearts decrease when player dies
- [ ] Coin display in top-right corner (starts at 0)
- [ ] Coin counter increments when collecting coins
- [ ] Coin icon animates when collecting
- [ ] No console errors
- [ ] HUD visible and readable at different resolutions

---

**Ready to continue with obstacles and level design!** 🎮

*Last Updated: 2025-11-23*
*Phase: Week 3-4 - Lives, Coins, Obstacles*
