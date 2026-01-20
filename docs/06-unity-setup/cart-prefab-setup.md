# Cart Prefab Complete Setup Guide

**How to create a fully-configured Cart prefab with all components**

This guide walks through creating a fresh Cart prefab from scratch with all the latest features (physics, debug, terrain following, etc.).

---

## 🚀 Quick Setup (Step-by-Step)

### Step 1: Create Cart GameObject

1. **In Unity Hierarchy:**
   - Right-click → 2D Object → **Sprite** (or Create Empty)
   - Name it: **Cart**

2. **Add Cart Sprite:**
   - Select Cart GameObject
   - Inspector → Sprite Renderer component
   - Sprite: Drag your cart sprite (e.g., `Cart_Wooden.png`)
   - Sorting Layer: Default (or create "Player" layer)
   - Order in Layer: 5 (above ground, below UI)

---

### Step 2: Add Ground Check Transform

**The cart needs a reference point to check if it's touching the ground:**

1. **Create child GameObject:**
   - Right-click Cart in Hierarchy → Create Empty
   - Name it: **GroundCheck**

2. **Position GroundCheck:**
   - In Inspector, set Transform Position:
     - X: 0
     - Y: -0.5 (half the cart height, at the bottom)
     - Z: 0
   - This should be at the bottom center of the cart

3. **Visual verification:**
   - Select GroundCheck in Hierarchy
   - Should see gizmo at bottom of cart in Scene view

---

### Step 3: Add Character Sprite Renderer

**For displaying the selected animal character:**

1. **Create child GameObject:**
   - Right-click Cart → 2D Object → Sprite
   - Name it: **CharacterSprite**

2. **Position CharacterSprite:**
   - Transform Position:
     - X: 0
     - Y: 0.3 (slightly above cart center, adjust to taste)
     - Z: -0.1 (in front of cart)
   - Scale: Adjust if character sprite is too big/small

3. **Configure Sprite Renderer:**
   - Sprite: Leave empty (will be set by script)
   - Sorting Layer: Same as Cart
   - Order in Layer: 6 (in front of cart)

---

### Step 4: Add Physics Components

**Required for cart movement and collision:**

1. **Add Rigidbody2D:**
   - Select Cart GameObject
   - Add Component → Physics 2D → **Rigidbody 2D**

2. **Configure Rigidbody2D:**
   ```
   Body Type: Dynamic
   Material: (Create Physics Material - see below)
   Simulated: ✓
   Use Auto Mass: ✓ (or set Mass to 1)
   Linear Drag: 0
   Angular Drag: 0.05
   Gravity Scale: 1
   Collision Detection: Continuous ⭐ IMPORTANT
   Sleeping Mode: Never Sleep
   Interpolate: Interpolate
   Constraints:
     - Freeze Position X: ✗
     - Freeze Position Y: ✗
     - Freeze Rotation Z: ✓ ⭐ (unless using terrain following)
   ```

3. **Create Physics Material 2D:**
   - Project window → Right-click → Create → 2D → **Physics Material 2D**
   - Name it: **CartPhysicsMaterial**
   - Friction: **0** (prevents sticking)
   - Bounciness: **0** (prevents bouncing)
   - Assign to Cart: Rigidbody2D → Material → Drag CartPhysicsMaterial

4. **Add Collider:**
   - Add Component → Physics 2D → **Box Collider 2D** (or Circle Collider 2D)

5. **Configure BoxCollider2D:**
   ```
   Is Trigger: ✗ (unchecked)
   Used By Effector: ✗
   Auto Tiling: ✓
   Offset: (0, 0) - center on cart
   Size: Match cart sprite size (e.g., 1, 0.8)
   Edge Radius: 0.05 (smooths corners)
   ```

---

### Step 5: Add Cart Scripts

**Add all the cart behavior scripts:**

1. **Add CartController:**
   - Add Component → **Cart Controller**
   - This is the main script

2. **Add CartDebugVisualizer:**
   - Add Component → **Cart Debug Visualizer**
   - For the debug HUD and trajectory visualization

---

### Step 6: Configure CartController Settings

**Select Cart GameObject, configure in Inspector:**

#### Movement Settings:
```
Move Speed: 5
Jump Force: 10
```

#### Ground Detection:
```
Ground Check: Drag "GroundCheck" child object here ⭐ IMPORTANT
Ground Check Radius: 0.2
Ground Layer: Select "Ground" layer (create if needed)
```

#### Character References:
```
Animal Sprite Renderer: Drag "CharacterSprite" child object here ⭐
```

#### Jump Settings:
```
Jump Cooldown: 0.2
```

#### Terrain Following (Experimental):
```
Follow Terrain Rotation: ✗ (unchecked by default)
Max Rotation Angle: 45
Rotation Speed: 10
Terrain Check Distance: 1
Rotation Deadzone: 1
```

**Note:** If you want terrain following:
- ✓ Check "Follow Terrain Rotation"
- ✗ Uncheck Rigidbody2D → Constraints → Freeze Rotation Z

---

### Step 7: Configure CartDebugVisualizer

**Settings for the debug system:**

```
Cart Controller: Auto-assigned ✓
Rb: Auto-assigned ✓
HUD Position: (0.02, 0.02) - top-left corner
Font Size: 14
Trajectory Points: 50
Draw In Game View: ✓
```

---

### Step 8: Create Prefab

**Save as reusable prefab:**

1. **Drag Cart to Project window:**
   - Drag Cart GameObject from Hierarchy
   - Drop into `Assets/Prefabs/Player/` folder
   - Cart turns blue in Hierarchy (prefab instance)

2. **Verify prefab:**
   - Double-click Cart prefab in Project window
   - Should open in Prefab editing mode
   - All child objects and components should be there

---

## 📋 Complete Component Checklist

**Your Cart GameObject should have:**

**Cart (Parent GameObject):**
- ✓ Sprite Renderer (cart sprite)
- ✓ Rigidbody2D (configured as above)
- ✓ Box Collider 2D (configured as above)
- ✓ Cart Controller script
- ✓ Cart Debug Visualizer script

**GroundCheck (Child GameObject):**
- ✓ Transform at bottom of cart (Y: -0.5)
- ✓ Referenced in CartController → Ground Check field

**CharacterSprite (Child GameObject):**
- ✓ Sprite Renderer (empty sprite, will be loaded by script)
- ✓ Transform above cart center
- ✓ Referenced in CartController → Animal Sprite Renderer field

---

## 🎯 Visual Hierarchy

```
Cart (Prefab)
├── Sprite Renderer (cart body)
├── Rigidbody2D
├── Box Collider 2D
├── CartController
├── CartDebugVisualizer
│
├── GroundCheck (Child)
│   └── Transform (Y: -0.5)
│
└── CharacterSprite (Child)
    ├── Sprite Renderer (character)
    └── Transform (Y: 0.3, Z: -0.1)
```

---

## 🔧 Setting Up Ground Layer

**If you don't have a Ground layer:**

1. **Create Layer:**
   - Top-right of Inspector → Layers → Edit Layers
   - User Layer 7: "Ground"

2. **Assign to Platforms:**
   - Select all platform GameObjects
   - Top of Inspector → Layer → Ground

3. **Configure CartController:**
   - Ground Layer → Check "Ground"

---

## 🎮 Testing the Setup

### Test 1: Cart Exists in Scene

1. Drag Cart prefab into level scene
2. Position above a platform
3. Enter Play mode
4. Cart should:
   - ✓ Fall down (gravity working)
   - ✓ Land on platform (collision working)
   - ✓ Auto-scroll right (moveSpeed working)

### Test 2: Jumping Works

1. Press Space or tap screen
2. Cart should:
   - ✓ Jump (if grounded)
   - ✓ NOT jump in air (air jump prevention working)
   - ✓ NOT jump if pressed too fast (cooldown working)

### Test 3: Debug HUD Shows

1. Press F12 (enable debug mode)
2. Top-left should show:
   - ✓ FPS counter
   - ✓ Cart position
   - ✓ Velocity
   - ✓ Grounded status
   - ✓ Max jump distances

### Test 4: Visual Debug Works

1. With debug mode on (F12)
2. In Scene view, select Cart
3. Should see:
   - ✓ Red circle at GroundCheck position
   - ✓ Yellow jump trajectory arc
   - ✓ Green reachable area box

---

## 🐛 Troubleshooting

### Issue: Cart doesn't move

**Check:**
- [ ] CartController script attached
- [ ] moveSpeed > 0 (default: 5)
- [ ] Rigidbody2D is Dynamic (not Kinematic or Static)
- [ ] Simulated is checked on Rigidbody2D

---

### Issue: Cart falls through ground

**Check:**
- [ ] Platform has Collider2D component
- [ ] Platform layer is set to "Ground"
- [ ] CartController → Ground Layer includes "Ground"
- [ ] Rigidbody2D → Collision Detection is "Continuous"
- [ ] Cart Collider → Is Trigger is UNCHECKED

---

### Issue: Can't jump

**Check:**
- [ ] Ground Check transform is assigned
- [ ] Ground Check is positioned at BOTTOM of cart
- [ ] Ground Layer is set correctly
- [ ] Platform is on Ground layer
- [ ] jumpForce > 0 (default: 10)
- [ ] isGrounded showing TRUE in debug HUD when on ground

---

### Issue: Jump check gizmo not visible

**In Scene view:**
- [ ] Cart is selected in Hierarchy
- [ ] Gizmos button is enabled (top-right of Scene view)
- [ ] Red circle should appear at GroundCheck position

---

### Issue: Character sprite doesn't show

**Check:**
- [ ] CharacterSprite child object exists
- [ ] CharacterSprite has Sprite Renderer component
- [ ] CartController → Animal Sprite Renderer is assigned
- [ ] GameManager has a selected character
- [ ] Selected character has characterSprite assigned

---

### Issue: Debug HUD missing values

**This means you're using old CartController:**
- [ ] Delete old CartController script
- [ ] Add new CartController script (from repository)
- [ ] Reconfigure all settings (see Step 6)
- [ ] Add CartDebugVisualizer script
- [ ] Create DevSettings asset (see debug system guide)

---

### Issue: Cart bounces on terrain

**Check:**
- [ ] Physics Material assigned (Friction: 0, Bounciness: 0)
- [ ] Rigidbody2D → Collision Detection is "Continuous"
- [ ] Platform also has Physics Material (Bounciness: 0)
- [ ] Using rb.velocity in FixedUpdate (not Transform.Translate)

---

### Issue: Cart rotates/flips

**Check:**
- [ ] Rigidbody2D → Constraints → Freeze Rotation Z is CHECKED
- [ ] Unless using terrain following feature (then uncheck)

---

## 📝 Quick Reference Values

**Recommended Cart Settings:**

```yaml
Movement:
  moveSpeed: 5
  jumpForce: 10

Ground Detection:
  groundCheckRadius: 0.2
  groundLayer: Ground (Layer 7)

Jump:
  jumpCooldown: 0.2

Physics (Rigidbody2D):
  gravityScale: 1
  mass: 1
  linearDrag: 0
  angularDrag: 0.05
  collisionDetection: Continuous
  interpolate: Interpolate
  freezeRotationZ: true (unless terrain following)

Physics Material:
  friction: 0
  bounciness: 0

Collider (BoxCollider2D):
  isTrigger: false
  edgeRadius: 0.05
  size: (1.0, 0.8) - adjust to sprite
```

---

## 🎨 Sprite Requirements

**Cart Sprite:**
- Size: 100-200 pixels
- Format: PNG with transparency
- Pivot: Center
- Pixels Per Unit: 100

**Character Sprite:**
- Size: 80-120 pixels (smaller than cart)
- Format: PNG with transparency
- Should be "riding pose" (sitting in cart)
- Pixels Per Unit: 100

---

## 🔄 Upgrading Old Cart to New Cart

**If you have an old cart and want to upgrade:**

### Option 1: Replace with New Prefab (Easiest)

1. Note old cart's position in scene
2. Delete old cart GameObject
3. Drag new Cart prefab into scene
4. Set position to match old cart
5. Test in Play mode

### Option 2: Update Existing Cart (Preserve Settings)

1. **Add missing components:**
   - Add CartDebugVisualizer script

2. **Update CartController:**
   - Delete old CartController script
   - Add new CartController script
   - Reconfigure all settings

3. **Add missing child objects:**
   - Create GroundCheck child (if missing)
   - Create CharacterSprite child (if missing)
   - Assign references in CartController

4. **Update Rigidbody2D settings:**
   - Set Collision Detection to Continuous
   - Set Interpolate to Interpolate
   - Add Physics Material

5. **Test thoroughly**

---

## 📦 Template Inspector Values

**Copy-paste these values into Inspector:**

```
CartController:
  moveSpeed: 5
  jumpForce: 10
  groundCheck: [GroundCheck Transform]
  groundCheckRadius: 0.2
  groundLayer: Ground
  animalSpriteRenderer: [CharacterSprite SpriteRenderer]
  jumpCooldown: 0.2
  followTerrainRotation: false
  maxRotationAngle: 45
  rotationSpeed: 10
  terrainCheckDistance: 1
  rotationDeadzone: 1

Rigidbody2D:
  bodyType: Dynamic
  material: CartPhysicsMaterial
  mass: 1
  linearDrag: 0
  angularDrag: 0.05
  gravityScale: 1
  collisionDetection: Continuous
  sleepingMode: NeverSleep
  interpolate: Interpolate
  freezePositionX: false
  freezePositionY: false
  freezeRotationZ: true

BoxCollider2D:
  isTrigger: false
  edgeRadius: 0.05
  offset: (0, 0)
  size: (1, 0.8)

CartDebugVisualizer:
  hudPosition: (0.02, 0.02)
  fontSize: 14
  trajectoryPoints: 50
  drawInGameView: true
```

---

## ✅ Final Verification Checklist

**Before saving as prefab:**

- [ ] Cart GameObject has all components
- [ ] GroundCheck child exists and positioned correctly
- [ ] CharacterSprite child exists and configured
- [ ] CartController has all references assigned
- [ ] Rigidbody2D is configured correctly
- [ ] Physics Material created and assigned
- [ ] Collider size matches sprite
- [ ] Ground Layer created and assigned
- [ ] Debug visualizer added
- [ ] Tested in Play mode (movement, jumping, debug HUD)
- [ ] Saved as prefab in Assets/Prefabs/Player/

---

**Last Updated:** 2026-01-17
**For:** Adventures of the World - Unity 2022.3 LTS
**Prefab Version:** Complete with debug system
**Status:** ✅ Ready to use
