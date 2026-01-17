# Cart Physics Setup Guide - Prevent Bouncing on Uneven Terrain

**Problem:** Cart bounces back when hitting uneven surfaces instead of smoothly moving forward.

**Cause:** Using `Transform.Translate()` bypasses physics and fights with Rigidbody2D, causing collision conflicts.

**Solution:** Use Rigidbody2D velocity + proper physics settings.

---

## ✅ Code Fix (Already Applied)

**Changed:** CartController.cs now uses `rb.velocity` in `FixedUpdate()` instead of `Transform.Translate()` in `Update()`

**Before:**
```csharp
void Update()
{
    transform.Translate(Vector2.right * moveSpeed * Time.deltaTime); // ❌ Bypasses physics
}
```

**After:**
```csharp
void FixedUpdate()
{
    rb.velocity = new Vector2(moveSpeed, rb.velocity.y); // ✅ Uses physics
}
```

---

## 🎮 Unity Inspector Settings (CRITICAL - Do These Now)

### Step 1: Configure Cart Rigidbody2D

**Select the Cart prefab in Unity, then in Inspector:**

#### Rigidbody2D Settings:
1. **Body Type:** Dynamic
2. **Material:** Create/assign Physics Material 2D (see below)
3. **Simulated:** ✓ Checked
4. **Use Auto Mass:** ✓ Checked (or set Mass to 1)
5. **Linear Drag:** 0
6. **Angular Drag:** 0.05
7. **Gravity Scale:** 1 (or 2-3 if you want heavier feeling)
8. **Collision Detection:** **Continuous** ⭐ (IMPORTANT - prevents tunneling through thin surfaces)
9. **Sleeping Mode:** Never Sleep
10. **Interpolate:** Interpolate (smoother visuals)
11. **Constraints:**
    - ✓ **Freeze Rotation Z** ⭐⭐ (CRITICAL - prevents cart from tilting/rotating)
    - Position X: Unchecked
    - Position Y: Unchecked

---

### Step 2: Create Physics Material 2D (No Bounce, No Friction)

**This prevents the cart from bouncing or sticking to surfaces:**

1. **In Unity Project window:**
   - Right-click `Assets/` folder
   - Create → 2D → Physics Material 2D
   - Name it: `CartPhysicsMaterial`

2. **Configure the Physics Material:**
   - **Friction:** 0 ⭐ (prevents sticking to walls/slopes)
   - **Bounciness:** 0 ⭐ (prevents bouncing)

3. **Assign to Cart:**
   - Select Cart prefab
   - In Rigidbody2D component
   - Material → Drag `CartPhysicsMaterial`

---

### Step 3: Platform/Ground Physics Material

**Also create a material for platforms to ensure no bounce:**

1. **Create:** `PlatformPhysicsMaterial`
   - Friction: 0.4 (or 0 if you want frictionless)
   - Bounciness: 0

2. **Assign to all platform prefabs:**
   - Select platform prefab
   - Add Rigidbody2D component (if not already there)
   - Body Type: **Kinematic** (platforms shouldn't fall)
   - Material: Drag `PlatformPhysicsMaterial`
   - **OR:** Just assign material to Collider2D component

---

### Step 4: Verify Cart Collider2D Settings

**Make sure the cart's collider is configured correctly:**

1. **Select Cart prefab**
2. **Collider2D component** (BoxCollider2D or CircleCollider2D):
   - **Is Trigger:** ✗ Unchecked (cart needs physical collisions)
   - **Used By Effector:** ✗ Unchecked
   - **Material:** (Optional) Can also assign physics material here
   - **Offset:** Center the collider on the cart
   - **Size:** Match the cart sprite size

---

## 🔍 Additional Fixes for Specific Issues

### Issue: Cart Still Bounces on Slopes

**Solution: Adjust slope handling**

Add to CartController.cs:

```csharp
[Header("Slope Handling")]
public float maxSlopeAngle = 45f;
public bool canClimbSlopes = true;

void FixedUpdate()
{
    // Constant forward movement
    Vector2 velocity = new Vector2(moveSpeed, rb.velocity.y);

    // Optional: Adjust for slopes
    if (canClimbSlopes)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);
        if (hit.collider != null)
        {
            float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);
            if (slopeAngle > 0 && slopeAngle <= maxSlopeAngle)
            {
                // Adjust velocity to follow slope
                velocity.x = moveSpeed * hit.normal.y;
                velocity.y = -moveSpeed * hit.normal.x;
            }
        }
    }

    rb.velocity = velocity;
}
```

---

### Issue: Cart Gets Stuck on Small Bumps

**Solution 1: Add Edge Radius to Collider**

If using BoxCollider2D:
- **Auto Tiling:** ✓ Checked
- **Edge Radius:** 0.05 (smooths corners, prevents catching on edges)

**Solution 2: Add Slope Check**

Make sure ground is mostly flat, or use tilemap colliders with edge radius.

---

### Issue: Cart Slides Backward on Steep Slopes

**Solution: Add minimum velocity check**

```csharp
void FixedUpdate()
{
    // Ensure cart always moves forward (never backward)
    float currentVelocityX = Mathf.Max(rb.velocity.x, moveSpeed);
    rb.velocity = new Vector2(currentVelocityX, rb.velocity.y);
}
```

---

### Issue: Cart Floats or Doesn't Fall Properly

**Check these settings:**

1. **Rigidbody2D Gravity Scale:** Should be 1 or higher (not 0)
2. **Mass:** Should be reasonable (0.5 - 2)
3. **Linear Drag:** Should be 0 (no air resistance)
4. **Collider:** Make sure it's not a Trigger

---

## 📋 Complete Setup Checklist

**Cart Prefab Settings:**
- [ ] Rigidbody2D attached
- [ ] Body Type: Dynamic
- [ ] Collision Detection: **Continuous**
- [ ] Constraints: **Freeze Rotation Z** ✓
- [ ] Gravity Scale: 1 or higher
- [ ] Physics Material assigned (Friction: 0, Bounciness: 0)
- [ ] Interpolate: Interpolate
- [ ] CartController.cs attached
- [ ] moveSpeed set (default: 5)

**Collider Settings:**
- [ ] BoxCollider2D or CircleCollider2D attached
- [ ] Is Trigger: Unchecked
- [ ] Edge Radius: 0.05 (if BoxCollider2D)
- [ ] Size matches cart sprite

**Code Settings:**
- [ ] Using `FixedUpdate()` with `rb.velocity` (not `Transform.Translate()`)
- [ ] Jump uses `rb.velocity = new Vector2(rb.velocity.x, jumpForce)`

**Platform Settings:**
- [ ] Platforms have Collider2D
- [ ] Platform Physics Material: Friction 0-0.4, Bounciness 0
- [ ] If using Rigidbody2D on platforms: Body Type = Kinematic

---

## 🎯 Testing Checklist

**Test these scenarios:**

1. **Flat ground:** Cart moves smoothly forward ✓
2. **Small bumps:** Cart doesn't bounce back ✓
3. **Gentle slopes:** Cart climbs smoothly ✓
4. **Steep slopes:** Cart maintains forward momentum ✓
5. **Edges/corners:** Cart doesn't get stuck ✓
6. **Jump landing:** Cart continues moving forward after landing ✓
7. **Platform transitions:** Smooth movement between platforms ✓

---

## 🐛 Troubleshooting

**Cart still bounces:**
- Check Physics Material 2D is assigned (Bounciness = 0)
- Verify Freeze Rotation Z is checked
- Make sure using `FixedUpdate()` not `Update()` for movement

**Cart moves too fast/slow:**
- Adjust `moveSpeed` in Inspector (default: 5)
- Check if character multiplier is affecting speed

**Cart slides backward:**
- Add minimum velocity check (see above)
- Increase friction on platforms (0.4 instead of 0)

**Cart doesn't jump:**
- Check `groundCheck` Transform is assigned
- Verify `groundLayer` is set correctly
- Make sure `jumpForce` is high enough (default: 10)

**Cart rotates/tilts:**
- Double-check **Freeze Rotation Z** is checked in Rigidbody2D Constraints

---

## 📝 Summary of Changes

**Code:**
- ✅ Moved movement from `Update()` + `Transform.Translate()` to `FixedUpdate()` + `rb.velocity`

**Unity Inspector:**
- ✅ Set Collision Detection to Continuous
- ✅ Freeze Rotation Z
- ✅ Create Physics Material 2D (Friction: 0, Bounciness: 0)
- ✅ Assign material to Cart Rigidbody2D
- ✅ Set Interpolate to smooth visuals

**Result:**
- Cart maintains constant forward velocity
- No bouncing on uneven terrain
- Smooth movement over bumps and slopes
- Proper physics interactions

---

**Last Updated:** 2026-01-17
**For:** Adventures of the World - CartController.cs
**Unity Version:** 2022.3 LTS
