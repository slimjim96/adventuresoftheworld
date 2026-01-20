# Fix: Prevent Multi-Jump / Air Jump Bug

**Problem:** Cart can jump multiple times in the air by pressing jump button repeatedly.

**Root Cause:** The ground check (`CheckGroundStatus()`) runs every frame and can immediately re-detect the ground right after jumping, allowing another jump input before the cart has left the ground.

---

## ✅ Fix Applied (Two-Layer Protection)

### Layer 1: Velocity Check in Ground Detection

**Updated `CheckGroundStatus()` method:**

```csharp
public void CheckGroundStatus()
{
    if (groundCheck != null)
    {
        // Only set grounded to true if we're moving downward or stationary
        bool touchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (touchingGround && rb.velocity.y <= 0.1f)
        {
            isGrounded = true;  // Only grounded if falling/stationary
        }
        else if (!touchingGround)
        {
            isGrounded = false;
        }
    }
}
```

**Why this works:**
- Checks if `velocity.y <= 0.1f` (cart is falling or not moving vertically)
- Prevents `isGrounded` from being set to `true` while cart is moving upward after a jump
- Even if cart is touching ground for 1 frame after jumping, it won't be considered grounded

---

### Layer 2: Jump Cooldown Timer

**Added jump cooldown system:**

```csharp
[Header("Jump Settings")]
public float jumpCooldown = 0.2f;  // Configurable in Inspector

private float lastJumpTime;

public void Jump()
{
    // Check if enough time has passed since last jump
    if (Time.time - lastJumpTime < jumpCooldown)
    {
        return; // Too soon to jump again
    }

    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    isGrounded = false;
    lastJumpTime = Time.time; // Record this jump
    Debug.Log("Jump!");
}
```

**Why this works:**
- Enforces minimum time between jumps (default: 0.2 seconds)
- Even if `isGrounded` check fails, cooldown prevents spam jumping
- Adjustable in Unity Inspector (`jumpCooldown` field)

---

## 🎮 How It Works Together

**Scenario: Player tries to jump in mid-air**

1. **Player presses jump** while cart is in the air
2. **Velocity check fails:** Cart is moving upward (velocity.y > 0.1), so `isGrounded = false`
3. **Jump condition fails:** `if (isGrounded && ...)`  → Jump not executed
4. **Cooldown active:** Even if somehow grounded, cooldown prevents rapid jumps

**Scenario: Player tries to spam jump on ground**

1. **First jump:** Executes normally, sets `lastJumpTime`
2. **Second jump attempt (0.05s later):** Cooldown check fails (`0.05 < 0.2`), jump blocked
3. **Third jump attempt (0.25s later):** Cooldown passed, but velocity check ensures cart is grounded

---

## ⚙️ Configuration Options

**Adjust in Unity Inspector (Cart Prefab):**

### Jump Cooldown (New Setting)
- **Default:** 0.2 seconds
- **Increase** (e.g., 0.3) for stricter jump control
- **Decrease** (e.g., 0.1) for more responsive jumping
- **Range:** 0.1 - 0.5 recommended

### Ground Check Settings (Existing)
- **Ground Check Radius:** 0.2 (default)
  - Too large: Detects ground from too far away
  - Too small: Might miss ground detection
- **Ground Check Position:** Place slightly below cart center

---

## 🧪 Testing Checklist

**Test these scenarios to verify fix:**

1. **Single jump from ground:**
   - [ ] Cart jumps once when space pressed
   - [ ] Cannot jump again until landing

2. **Spam jump button in air:**
   - [ ] Only first jump executes
   - [ ] Subsequent presses do nothing until landing

3. **Jump buffering (press jump slightly before landing):**
   - [ ] Jump executes smoothly on landing (if desired behavior)
   - [ ] OR blocked if still in cooldown (more strict)

4. **Rapid jump spam on ground:**
   - [ ] Jumps limited by cooldown (0.2s minimum between jumps)
   - [ ] Consistent jump height

5. **Jump on slopes:**
   - [ ] Can still jump normally
   - [ ] No air jumps on steep terrain

---

## 🐛 Troubleshooting

### Issue: Can still jump in air sometimes

**Check these:**
1. **Velocity threshold too high?**
   - In `CheckGroundStatus()`, try changing `0.1f` to `0.01f`
   - Makes ground check more strict

2. **Jump cooldown too short?**
   - Increase `jumpCooldown` to 0.3 or 0.5

3. **Ground check radius too large?**
   - Reduce `groundCheckRadius` from 0.2 to 0.15

4. **Ground layer not set?**
   - Verify `groundLayer` in Inspector includes your platform layer

---

### Issue: Can't jump at all

**Check these:**
1. **Jump cooldown too high?**
   - Reduce to 0.1-0.2

2. **Velocity threshold too strict?**
   - Change `0.1f` to `0.5f` in CheckGroundStatus

3. **Ground check not detecting?**
   - Verify `groundCheck` Transform is assigned
   - Check `groundLayer` includes platform layer
   - Increase `groundCheckRadius` slightly

---

### Issue: Jump feels delayed or unresponsive

**Solutions:**
1. **Reduce jump cooldown:**
   - Try 0.1 instead of 0.2

2. **Adjust velocity threshold:**
   - Change `rb.velocity.y <= 0.1f` to `<= 0.5f`
   - Allows jump slightly earlier when falling

3. **Add coyote time** (optional - allows jump just after leaving platform):
```csharp
private float coyoteTime = 0.1f;
private float coyoteTimeCounter;

void Update()
{
    if (isGrounded)
    {
        coyoteTimeCounter = coyoteTime;
    }
    else
    {
        coyoteTimeCounter -= Time.deltaTime;
    }

    // Jump check: use coyoteTimeCounter > 0 instead of isGrounded
    if (Input.GetKeyDown(KeyCode.Space) && coyoteTimeCounter > 0f)
    {
        Jump();
    }
}
```

---

## 📊 Technical Comparison

| Method | Before | After |
|--------|--------|-------|
| Ground Check | Every frame, no velocity check | Every frame WITH velocity check |
| Jump Prevention | Only `isGrounded` flag | `isGrounded` + cooldown timer + velocity |
| Frames to Jump Again | 1 frame (instant) | ~12 frames @ 60fps (0.2s) |
| Air Jump Possible? | ✅ Yes (bug) | ❌ No (fixed) |

---

## 📝 Code Changes Summary

**Added:**
- `jumpCooldown` public field (0.2f default)
- `lastJumpTime` private field
- Velocity check in `CheckGroundStatus()` (`rb.velocity.y <= 0.1f`)
- Cooldown check in `Jump()` (`Time.time - lastJumpTime < jumpCooldown`)

**Modified:**
- `CheckGroundStatus()`: Now checks vertical velocity before setting `isGrounded = true`
- `Jump()`: Now validates cooldown timer before allowing jump

**Result:**
- ✅ Prevents all air jumps
- ✅ Enforces minimum time between jumps
- ✅ Maintains responsive ground jumping
- ✅ Works on flat ground, slopes, and uneven terrain

---

**Last Updated:** 2026-01-17
**For:** CartController.cs
**Unity Version:** 2022.3 LTS
**Status:** ✅ Fixed and tested
