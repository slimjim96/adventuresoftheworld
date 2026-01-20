# Experimental Feature: Terrain Following Rotation

**Status:** Experimental - Easy to toggle on/off for testing

**Purpose:** Makes the cart rotate to follow uneven terrain angles, creating a more dynamic visual effect while preventing the cart from flipping over.

---

## 🎮 Quick Setup

### Step 1: Enable in Unity Inspector

**Select Cart Prefab → CartController Component:**

**New "Terrain Following (Experimental)" section:**

1. **Follow Terrain Rotation:** ✓ Check this to enable
2. **Max Rotation Angle:** 45 (degrees, prevents flipping)
3. **Rotation Speed:** 10 (how quickly it rotates, 1-20 range)
4. **Terrain Check Distance:** 1 (raycast distance for terrain detection)

### Step 2: Update Rigidbody2D Constraints

**CRITICAL:** You must unfreeze rotation for this to work.

**Cart Prefab → Rigidbody2D Component:**
- **Constraints → Freeze Rotation Z:** ✗ **UNCHECK THIS**

**Why:** Previously we froze rotation to prevent cart from tilting. Now we're controlling rotation manually with angle limits.

---

## ⚙️ How It Works

### Terrain Detection
1. Every physics frame, cart raycasts downward to detect terrain
2. Calculates the terrain angle from the surface normal
3. Clamps angle to ±45 degrees (prevents flipping)
4. Smoothly rotates cart to match terrain angle

### Rotation Limits
- **-45° to +45°** rotation range (configurable)
- Cart **cannot flip over** no matter how steep the terrain
- Smooth interpolation prevents jerky rotation
- Auto-returns to upright when in air or feature disabled

### Visual Feedback (Editor Only)
- **Yellow line:** Shows terrain detection raycast in Scene view
- **Red circle:** Ground check position (existing feature)

---

## 🎛️ Configuration Guide

### Follow Terrain Rotation (Toggle)
- **Enabled:** Cart rotates with terrain
- **Disabled:** Cart stays upright (resets smoothly to 0°)

**Use Case:** Toggle on/off during gameplay testing to compare feel

---

### Max Rotation Angle (0-90°)
**Default:** 45°

**Examples:**
- **30°:** More conservative, cart stays more upright
- **45°:** Balanced (recommended for testing)
- **60°:** Aggressive tilting, more dramatic on steep slopes
- **90°:** Maximum tilt (cart can be completely vertical on walls)

**Recommendation:** Start with 45°, adjust based on your level design

---

### Rotation Speed (1-20)
**Default:** 10

**Examples:**
- **5:** Slow, smooth transitions (feels heavy/sluggish)
- **10:** Balanced (recommended)
- **15:** Fast response (snappy, more arcade-like)
- **20:** Instant rotation (minimal interpolation)

**Recommendation:**
- Use 10 for realistic cart physics
- Use 15+ for more responsive arcade feel

---

### Terrain Check Distance (0.5-2.0)
**Default:** 1

**What it does:** How far down the cart looks for terrain

**Examples:**
- **0.5:** Short range, only detects very close terrain
- **1.0:** Standard (recommended)
- **1.5:** Longer range, detects terrain earlier (anticipatory rotation)
- **2.0:** Very long, cart starts rotating before touching ground

**Recommendation:**
- 1.0 for most cases
- Increase to 1.5 if cart seems to react too late on bumps

---

## 🧪 Testing Scenarios

### Test 1: Flat Ground
**Expected:** Cart stays upright (0° rotation)
**Check:** No jittering or unwanted rotation

### Test 2: Gentle Slope (15° terrain)
**Expected:** Cart tilts smoothly to ~15°
**Check:** Smooth transition, no sudden snaps

### Test 3: Steep Slope (60° terrain)
**Expected:** Cart tilts to max angle (45° if default)
**Check:** Cart doesn't flip, stays at 45° max

### Test 4: Bumpy Terrain (alternating angles)
**Expected:** Cart smoothly follows bumps
**Check:** Rotation is smooth, not jerky

### Test 5: Jumping
**Expected:** Cart maintains angle briefly, then returns to upright in air
**Check:** Smooth transition back to 0° while airborne

### Test 6: Toggle On/Off
**Expected:** When disabled, cart smoothly returns to upright
**Check:** No sudden snap to 0°, smooth transition

---

## 🎨 Visual Impact

### With Terrain Following (followTerrainRotation = true):
```
Uphill:    Cart tilts forward slightly
           /
          / ← Cart rotates forward
Downhill:  Cart tilts backward slightly
         \
          \ ← Cart rotates backward
```

### Without Terrain Following (followTerrainRotation = false):
```
Uphill:    Cart stays upright
           |
          / ← Cart always vertical
Downhill:  Cart stays upright
         |
          \ ← Cart always vertical
```

---

## 🐛 Troubleshooting

### Issue: Cart flips over completely

**Cause:** Max rotation angle too high or Freeze Rotation Z unchecked but feature disabled

**Fix:**
1. Check `maxRotationAngle` is set to 45° or less
2. Verify `followTerrainRotation` is enabled (if you want rotation)
3. If disabled, re-check Freeze Rotation Z in Rigidbody2D

---

### Issue: Cart rotates too slowly/quickly

**Cause:** Rotation speed setting

**Fix:** Adjust `rotationSpeed` slider (1-20)
- Increase for faster response
- Decrease for smoother, slower transitions

---

### Issue: Cart jitters or shakes on flat ground

**Cause:** Terrain check distance too long or uneven collider mesh

**Fix:**
1. Reduce `terrainCheckDistance` to 0.8 or 0.5
2. Check your platform colliders are smooth (not jagged)
3. Reduce `rotationSpeed` slightly (from 10 to 7)

---

### Issue: Cart doesn't rotate at all

**Cause:** Rotation still frozen or feature disabled

**Fix:**
1. Verify `followTerrainRotation` is checked (enabled)
2. **Check Rigidbody2D → Constraints → Freeze Rotation Z is UNCHECKED**
3. Verify `groundLayer` is set correctly
4. Check `terrainCheckDistance` is reasonable (1.0)

---

### Issue: Cart overshoots angles on steep slopes

**Cause:** Rotation speed too high

**Fix:**
1. Reduce `rotationSpeed` from 10 to 5-7
2. Or reduce `maxRotationAngle` to 30-35°

---

### Issue: Cart stays tilted after jumping

**Cause:** Rotation reset logic not working

**Fix:** This should auto-correct in code. If persistent:
1. Check `isGrounded` is working correctly
2. Verify raycast isn't hitting unexpected colliders in air

---

## 🎯 Gameplay Considerations

### Pros of Terrain Following:
- ✅ More dynamic, visually interesting
- ✅ Cart feels "connected" to terrain
- ✅ Adds weight and physicality
- ✅ Works well with realistic art styles

### Cons of Terrain Following:
- ❌ Can feel less precise for tight platforming
- ❌ Character sprite rotation might look odd
- ❌ May not fit arcade-style gameplay
- ❌ Adds visual complexity

### Recommendation:
**Test both modes** with your actual level designs:
1. Play through levels with feature ON
2. Play through levels with feature OFF
3. Get playtest feedback from others
4. Choose what feels better for your game's style

---

## 🔧 Unity Inspector Setup Checklist

**When Terrain Following is ENABLED:**
- [ ] CartController → Follow Terrain Rotation = ✓ Checked
- [ ] CartController → Max Rotation Angle = 45
- [ ] CartController → Rotation Speed = 10
- [ ] CartController → Terrain Check Distance = 1
- [ ] Rigidbody2D → Constraints → Freeze Rotation Z = ✗ **Unchecked**

**When Terrain Following is DISABLED:**
- [ ] CartController → Follow Terrain Rotation = ✗ Unchecked
- [ ] Rigidbody2D → Constraints → Freeze Rotation Z = ✓ **Checked** (prevents unwanted rotation)

---

## 📊 Code Details

### New Fields Added:
```csharp
[Header("Terrain Following (Experimental)")]
public bool followTerrainRotation = false;        // Master toggle
public float maxRotationAngle = 45f;              // Clamp to prevent flipping
public float rotationSpeed = 10f;                 // Interpolation speed
public float terrainCheckDistance = 1f;           // Raycast range
```

### How Rotation is Calculated:
1. **Raycast** from cart position downward (`terrainCheckDistance`)
2. **Get surface normal** from raycast hit
3. **Calculate angle** using `Atan2(normal.y, normal.x)`
4. **Clamp** to `[-maxRotationAngle, +maxRotationAngle]`
5. **Lerp** smoothly to target angle using `rotationSpeed`

### Auto-Reset When Disabled:
When `followTerrainRotation = false`, cart smoothly returns to 0° rotation

### Debug Visualization:
Yellow line in Scene view shows raycast when cart is selected

---

## 🚀 Performance Notes

**Impact:** Minimal
- 1 raycast per frame (only when grounded and enabled)
- Simple angle calculations
- No expensive operations

**Mobile-Friendly:** Yes, negligible performance cost

---

## 📝 Summary

**To Enable:**
1. Check `Follow Terrain Rotation` in Inspector
2. Uncheck `Freeze Rotation Z` in Rigidbody2D
3. Adjust `Max Rotation Angle` (30-45° recommended)
4. Test and tune `Rotation Speed` (10 default)

**To Disable:**
1. Uncheck `Follow Terrain Rotation` in Inspector
2. Cart smoothly returns to upright
3. (Optional) Re-check `Freeze Rotation Z` to prevent any rotation

**Easy Testing:**
- Toggle checkbox on/off during Play mode to compare instantly
- No code changes needed, all controlled via Inspector
- Easy to remove later if you decide not to use it

---

**Last Updated:** 2026-01-17
**Feature Status:** Experimental (toggleable)
**Default State:** Disabled (followTerrainRotation = false)
**Safe to Remove:** Yes, simply leave disabled
