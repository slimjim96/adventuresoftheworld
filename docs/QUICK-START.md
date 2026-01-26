# Quick Start Guide - Adventures of the World

**Purpose:** Get your Unity project running in 15 minutes with all core systems working.

**Last Updated:** 2026-01-25

---

## Prerequisites

- Unity 2022.3 LTS installed
- Project opened in Unity
- Scripts copied to `Assets/Scripts/` folder

---

## Step 1: Install Required Packages (2 min)

**Window → Package Manager → Unity Registry**

Install these packages:
1. **Input System** - Required for cross-platform input
2. **TextMesh Pro** - Required for UI text
3. **Cinemachine** - Recommended for camera

After installing Input System:
1. Go to **Edit → Project Settings → Player**
2. Set **Active Input Handling** to **"Both"**
3. Click **Yes** to restart Unity

---

## Step 2: Create Layers and Tags (2 min)

**Edit → Project Settings → Tags and Layers**

### Create Layers:
| Layer # | Name |
|---------|------|
| 8 | Ground |
| 9 | Player |
| 10 | Obstacles |
| 11 | Collectibles |

### Create Tags:
- Player
- Ground
- Obstacle
- Coin
- FinishLine

---

## Step 3: Create InputManager (1 min)

1. In Hierarchy, right-click → **Create Empty**
2. Name it `InputManager`
3. Add Component → **InputManager** script
4. This handles all input (keyboard, touch, gamepad)

---

## Step 4: Create Cart (5 min)

### 4.1 Create Structure
In Hierarchy, right-click → Create Empty → name it `Cart`

Create children under Cart:
```
Cart
├── CartBody (Create Empty)
├── GroundCheck (Create Empty)
└── AnimalMount (Create Empty)
```

### 4.2 Position GroundCheck
- Select `GroundCheck`
- Set **Transform Y = -0.5** (or wherever wheels touch ground)

### 4.3 Add Visuals (Temporary)
- Select `CartBody`
- Add Component → **Sprite Renderer**
- Set Sprite to any square (or your cart sprite)
- Set **Order in Layer = 10**

### 4.4 Add Components to Cart Parent

Select `Cart` and add:

**Rigidbody2D:**
- Body Type: Dynamic
- Gravity Scale: 2
- Freeze Rotation Z: ✅ Checked
- Collision Detection: Continuous

**BoxCollider2D:**
- Adjust size to match cart body
- Offset Y if needed

**CartController:**
- Move Speed: 5
- Jump Force: 12
- Ground Check: (drag GroundCheck child here)
- Ground Check Radius: 0.2
- Ground Layer: Ground (select from dropdown)

**PlayerInput:**
- Use Input Manager: ✅ Checked

### 4.5 Set Cart Properties
- Tag: Player
- Layer: Player
- **Transform Z = 0** (important!)

---

## Step 5: Create Platform (2 min)

1. Right-click Hierarchy → **2D Object → Sprite → Square**
2. Name it `Platform`
3. Scale: X = 20, Y = 1
4. Position: Y = -3, **Z = 0**
5. Add Component → **BoxCollider2D**
6. Tag: Ground
7. Layer: Ground

---

## Step 6: Set Up Camera (2 min)

### Option A: Simple Camera (Quick)
1. Select **Main Camera**
2. Set **Transform Z = -10** (negative!)
3. Projection: Orthographic
4. Size: 5

### Option B: Cinemachine (Recommended)
1. Select Main Camera
2. Add Component → **CinemachineBrain**
3. Right-click Hierarchy → **Cinemachine → 2D Camera**
4. Select the new Virtual Camera
5. Set **Follow** = Cart
6. Body: **Framing Transposer**
7. Camera Distance: **10**

---

## Step 7: Create GameManager (1 min)

1. Create Empty → name it `GameManager`
2. Add Component → **GameManager** script
3. This persists across scenes (DontDestroyOnLoad)

---

## Step 8: Test! (1 min)

1. Press **Play**
2. Press **Space** to jump
3. Cart should:
   - Auto-scroll to the right
   - Jump when you press Space
   - Land on platform
   - Be visible (not behind platform)

---

## Troubleshooting

### Cart not jumping?
- Check Console for "Attempting to jump" message
- Verify InputManager exists in scene
- Verify PlayerInput is on Cart
- Check Ground Layer is set on both CartController AND Platform

### Cart invisible or behind platform?
- Camera Z must be **-10** (negative)
- Cart Z must be **0**
- Platform Z must be **0**
- If using Cinemachine: Camera Distance = 10

### Input System errors?
- Install Input System package
- Set Active Input Handling to "Both"
- Restart Unity

### Method not showing in Button onClick?
- Make method `public void MethodName()`
- Save script, return to Unity

---

## What's Next?

Once basic cart is working:

1. **Add more platforms** - Create level layout
2. **Add coins** - See `Coin.cs` and tag as "Coin"
3. **Add obstacles** - See `Hazard.cs` and tag as "Obstacle"
4. **Create UI** - Add HUDManager for lives/coins display
5. **Create character select** - See CharacterSelectManager

---

## Key Files Reference

| File | Purpose |
|------|---------|
| `InputManager.cs` | Handles all input (keyboard, touch, gamepad) |
| `PlayerInput.cs` | Connects InputManager to CartController |
| `CartController.cs` | Cart movement, jumping, ground detection |
| `GameManager.cs` | Global state, persists across scenes |
| `HUDManager.cs` | In-game UI (lives, coins, pause) |

---

## Documentation Links

- [Full Configuration Checklist](02-unity-basics/unity-configuration-checklist.md)
- [Input System Setup](06-unity-setup/input-system-setup.md)
- [Cart Prefab Setup](06-unity-setup/cart-prefab-setup.md)
- [Scene Architecture](06-unity-setup/scene-architecture-guide.md)

---

**You should now have a working cart that jumps!** 🎮
