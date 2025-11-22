# Unity Scene Setup Guide

This guide will walk you through creating the initial scenes in Unity for Adventures of the World.

---

## Step 1: Configure Project Settings

### A. Tags Setup

1. Go to **Edit → Project Settings → Tags and Layers**
2. Add the following **Tags**:

| Tag | Usage |
|-----|-------|
| `Player` | The player's cart |
| `Ground` | Platform surfaces |
| `Obstacle` | Non-deadly obstacles |
| `Hazard` | Deadly obstacles |
| `Coin` | Collectible coins |
| `ExtraLife` | Extra life pickups |
| `FinishLine` | Level end trigger |

**How to add tags:**
- Click **+ (Plus icon)** under "Tags"
- Enter tag name
- Click **Save**

### B. Layers Setup

Add the following **Layers**:

| Layer | Layer # | Usage |
|-------|---------|-------|
| `Ground` | 8 | Ground and platforms |
| `Player` | 9 | Player cart |
| `Obstacles` | 10 | All obstacles |
| `Collectibles` | 11 | Coins and pickups |
| `UI` | 5 | UI elements (default) |

**How to add layers:**
- Click on empty layer slot
- Enter layer name
- Unity will auto-assign layer number

### C. Physics 2D Settings

1. Go to **Edit → Project Settings → Physics 2D**
2. Set **Gravity**: Y = **-9.81** (default is fine)
3. Configure **Layer Collision Matrix**:

Disable collisions between:
- ✅ Player ↔ Collectibles (use triggers instead)
- ✅ Collectibles ↔ Ground
- ✅ Collectibles ↔ Obstacles

### D. Input System Setup

1. Go to **Edit → Project Settings → Player**
2. Scroll to **Other Settings**
3. Under **Active Input Handling**, select **Both** (legacy + new)
4. Click **Apply** and restart Unity if prompted

---

## Step 2: Create Main Menu Scene

### A. Create Scene

1. **File → New Scene** → Choose **Basic (Built-in)** or **2D Template**
2. **File → Save As** → `Assets/Scenes/MainMenu.unity`

### B. Setup Camera

Select **Main Camera** in Hierarchy:

| Property | Value |
|----------|-------|
| **Projection** | Orthographic |
| **Size** | 5 |
| **Background** | Solid Color (#87CEEB - Light Blue) |
| **Position** | (0, 0, -10) |

### C. Add UI Canvas

1. **Right-click in Hierarchy → UI → Canvas**
2. Canvas settings:
   - **Render Mode**: Screen Space - Overlay
   - **UI Scale Mode**: Scale With Screen Size
   - **Reference Resolution**: 1920 x 1080

### D. Add Placeholder UI (Optional)

You can add a simple text for now:

1. **Right-click Canvas → UI → Text - TextMeshPro**
2. Name it "TitleText"
3. Set text to: **"Adventures of the World"**
4. Font Size: 60
5. Center it on screen

### E. Save Scene

**File → Save** (or Ctrl+S)

---

## Step 3: Create Gameplay Scene

### A. Create Scene

1. **File → New Scene** → Choose **2D Template**
2. **File → Save As** → `Assets/Scenes/Gameplay.unity`

### B. Setup Camera

Select **Main Camera**:

| Property | Value |
|----------|-------|
| **Projection** | Orthographic |
| **Size** | 5 (adjust after testing) |
| **Background** | Solid Color (#5DADE2 - Sky Blue) |
| **Position** | (0, 0, -10) |

**Add CameraFollow script:**
1. Select **Main Camera**
2. Click **Add Component**
3. Search for **Camera Follow**
4. Target will be assigned automatically (looks for "Player" tag)
5. Set **Offset**: (3, 2, -10) - Camera slightly ahead and above cart
6. Set **Smooth Speed**: 0.125

### C. Create Player Cart

1. **Right-click in Hierarchy → Create Empty**
2. Rename to **"PlayerCart"**
3. Set **Tag** to **"Player"**
4. Set **Layer** to **"Player"**
5. Position: (0, 0, 0)

**Add Visual (temporary sprite):**
1. Right-click **PlayerCart → 2D Object → Sprite → Square**
2. Rename to "CartSprite"
3. Set **Color** to brown/wooden color
4. Set **Scale**: (1, 0.5, 1) - Make it rectangular like a cart

**Add Components to PlayerCart:**

1. **Add Rigidbody2D**:
   - Body Type: Dynamic
   - Gravity Scale: 2
   - Constraints: Freeze Rotation Z (check)
   - Collision Detection: Continuous

2. **Add BoxCollider2D**:
   - Size: (1, 0.5) - Match sprite size
   - Is Trigger: False

3. **Add CartController Script**:
   - Click **Add Component**
   - Search **CartController**
   - Configure:
     - Move Speed: 5
     - Jump Force: 12
     - Ground Layer: Select "Ground"

### D. Create Ground Platform

1. **Right-click in Hierarchy → 2D Object → Sprite → Square**
2. Rename to **"Ground"**
3. Set **Tag** to **"Ground"**
4. Set **Layer** to **"Ground"**
5. Position: (0, -3, 0)
6. Scale: (20, 1, 1) - Make it a long platform
7. Color: Green (grass) or Brown (dirt)

**Add Components:**
1. **Add BoxCollider2D**:
   - Size: Auto (matches sprite)
   - Is Trigger: False

**Optional - Add more platforms:**
- Duplicate ground (Ctrl+D)
- Position them to create a simple test level
- Place gaps between platforms (1-2 units wide)

### E. Create Level Bounds

Create a **GameObject** for spawn point:

1. **Right-click → Create Empty**
2. Rename to **"SpawnPoint"**
3. Position: (0, 0, 0)
4. Add **Gizmo icon** (click cube icon next to name in Inspector)

Create finish line trigger:

1. **Right-click → Create Empty**
2. Rename to **"FinishLine"**
3. Position: (50, 0, 0) - Far end of level
4. Tag: "FinishLine"
5. **Add BoxCollider2D**:
   - Size: (2, 10)
   - Is Trigger: True

### F. Add Game Managers

Create an empty GameObject for managers:

1. **Right-click → Create Empty**
2. Rename to **"GameManagers"**
3. Position: (0, 0, 0)

Add manager scripts:
1. Click **Add Component** → **GameManager**
2. Click **Add Component** → **Input Manager**
3. Click **Add Component** → **Audio Manager**
4. Click **Add Component** → **Lives Manager**
5. Click **Add Component** → **Coin Manager**

Configure **LivesManager**:
- Starting Lives: 3
- Max Lives: 5
- Respawn Point: Drag **SpawnPoint** from Hierarchy

### G. Save Scene

**File → Save** (Ctrl+S)

---

## Step 4: Add Scenes to Build Settings

1. **File → Build Settings**
2. Click **Add Open Scenes** (with MainMenu open)
3. Open **Gameplay** scene
4. **File → Build Settings → Add Open Scenes**

Your build settings should show:
```
0. MainMenu
1. Gameplay
```

Click **Close**

---

## Step 5: Test the Gameplay Scene

### A. Play Mode Test

1. Open **Gameplay** scene
2. Click **Play** button ▶️

**Expected behavior:**
- Cart should move forward automatically
- Press **Space** or **Up Arrow** to jump
- Cart should land back on ground
- Camera should follow the cart smoothly

### B. Verify Ground Detection

1. Enter Play Mode
2. Select **PlayerCart** in Hierarchy
3. Watch **CartController** component in Inspector
4. **Is Grounded** should be TRUE when on ground, FALSE when jumping

### C. Test Jump Mechanic

- Jump over gaps (if you created multiple platforms)
- Verify cart doesn't double-jump mid-air
- Check jump height is appropriate

### D. Common Issues

| Issue | Solution |
|-------|----------|
| Cart falls through ground | Check Collision Matrix, ensure Player/Ground layers collide |
| Cart doesn't jump | Check Input Manager is in scene, verify ground layer assigned |
| Camera doesn't follow | Ensure CameraFollow target is set to PlayerCart |
| Cart rotates when jumping | Freeze Z rotation in Rigidbody2D |

---

## Step 6: Create Additional Scenes (Optional)

You can create these scenes now or later:

### Level Select Scene
```
File → New Scene → 2D Template
Save as: Assets/Scenes/LevelSelect.unity
```

### Shop Scene
```
File → New Scene → 2D Template
Save as: Assets/Scenes/Shop.unity
```

### Settings Scene
```
File → New Scene → 2D Template
Save as: Assets/Scenes/Settings.unity
```

Add each to **Build Settings** after creation.

---

## Step 7: Scene Organization Best Practices

### Hierarchy Organization

Organize your Gameplay scene like this:

```
Gameplay
├── === MANAGEMENT ===
│   └── GameManagers
├── === CAMERA ===
│   └── Main Camera
├── === PLAYER ===
│   └── PlayerCart
├── === LEVEL ===
│   ├── SpawnPoint
│   ├── FinishLine
│   ├── Ground
│   ├── Platforms
│   └── Obstacles
├── === COLLECTIBLES ===
│   └── Coins
└── === UI ===
    └── Canvas (HUD)
```

**Create empty GameObjects as folders:**
1. Right-click → Create Empty
2. Rename (e.g., "=== LEVEL ===")
3. Drag related objects into them
4. Use **=== NAME ===** for section headers (easy to see)

---

## Step 8: Save and Commit

### Save Scene
- **File → Save Project** (saves all scenes)

### Commit to Git

Open your terminal and commit the scene files:

```bash
git add Assets/Scenes/
git commit -m "Create initial Unity scenes (MainMenu and Gameplay)"
git push
```

---

## Next Steps

Once your scenes are set up:

✅ Test cart movement and jumping
✅ Add more platforms to create a complete test level
✅ Create obstacle prefabs (Week 2 task)
✅ Implement coin collection (Week 3 task)
✅ Build UI and HUD (Week 4 task)

Refer to **TODO.md** for detailed Week 1-4 tasks!

---

## Quick Reference: Keyboard Shortcuts

| Action | Shortcut |
|--------|----------|
| Save Scene | Ctrl+S (Cmd+S on Mac) |
| Play Mode | Ctrl+P |
| Pause | Ctrl+Shift+P |
| Step Frame | Ctrl+Alt+P |
| Focus GameObject | F (with object selected) |
| Frame All | A (in Scene view) |

---

**You're ready to start developing! 🎮**

*Last Updated: 2025-11-22*
