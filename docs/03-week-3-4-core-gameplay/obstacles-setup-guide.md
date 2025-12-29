# Obstacles Setup Guide - Adventures of the World

This guide covers creating and configuring obstacle prefabs (spikes, barriers, gaps) for the game.

---

## Prerequisites

- Unity 2022.3.62f3 (or newer)
- Gameplay scene created
- LivesManager script in scene
- Hazard.cs script created (Assets/Scripts/Obstacles/)

---

## Part 1: Creating Spike Obstacles

### Step 1: Create Basic Spike GameObject

1. **In Hierarchy**, right-click → **2D Object** → **Sprites** → **Triangle**
2. Rename to `Spike`
3. Configure **Transform**:
   - **Position**: X: 10, Y: 0, Z: 0 (on ground level)
   - **Rotation**: Z: 0 (pointing up)
   - **Scale**: X: 0.5, Y: 1, Z: 1

### Step 2: Configure Sprite

1. Select **Sprite Renderer** component:
   - **Sprite**: Triangle (default)
   - **Color**: Dark Red (#CC0000)
   - **Sorting Layer**: Default
   - **Order in Layer**: 3 (above ground, below player)
   - **Flip Y**: Unchecked (point should be up)

### Step 3: Add Collision

1. **Add Component** → **Polygon Collider 2D** (better fit for triangle)
   - **Is Trigger**: Checked ✅
   - **Edit Collider**: Optional - adjust points to match sprite shape

Alternative option:
- **Box Collider 2D** with adjusted size (simpler but less precise)

### Step 4: Add Hazard Script

1. **Add Component** → Search for `Hazard`
2. Configure **Hazard** script:
   - **Kill On Contact**: Checked ✅
   - **Play Death Animation**: Unchecked (save for later)

### Step 5: Create Spike Prefab

1. Create folder structure: `Assets/Prefabs/Obstacles/`
2. **Drag Spike from Hierarchy** to `Obstacles` folder
3. Prefab saved as `Spike.prefab`
4. You can delete the instance from Hierarchy or leave for testing

---

## Part 2: Spike Variations

Create multiple spike types for visual variety:

### Variation 1: Small Spikes

1. **Duplicate Spike** prefab
2. Rename to `SpikeSmall.prefab`
3. Edit prefab:
   - **Scale**: X: 0.3, Y: 0.6, Z: 1
   - **Color**: Slightly lighter red

### Variation 2: Spike Cluster (3 spikes)

1. Create **Empty GameObject** → Rename to `SpikeCluster`
2. **Add 3 child Triangle sprites**:
   - Position them side by side
   - Scale: X: 0.4, Y: 0.8, Z: 1
   - Spacing: 0.5 units apart
3. **Add Box Collider 2D** to parent:
   - Size covers all 3 spikes
   - **Is Trigger**: Checked
4. **Add Hazard script** to parent
5. Save as `SpikeCluster.prefab`

### Variation 3: Ceiling Spikes (upside down)

1. Duplicate `Spike.prefab`
2. Rename to `SpikeCeiling.prefab`
3. Edit prefab:
   - **Rotation**: Z: 180 (pointing down)
   - **Color**: Darker red or gray (#888888)

---

## Part 3: Moving Obstacles (Advanced)

### Step 1: Create Moving Platform Script

Create a simple moving hazard script:

```csharp
// Save as: Assets/Scripts/Obstacles/MovingObstacle.cs
using UnityEngine;

namespace AdventuresOfTheWorld.Obstacles
{
    public class MovingObstacle : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private Vector2 startPosition;
        [SerializeField] private Vector2 endPosition;
        [SerializeField] private float speed = 2f;
        [SerializeField] private bool pingPong = true;

        private float _journeyTime;
        private bool _movingForward = true;

        private void Start()
        {
            startPosition = transform.position;
            endPosition = startPosition + new Vector2(3f, 0f); // Default 3 units right
        }

        private void Update()
        {
            _journeyTime += Time.deltaTime * speed;

            if (pingPong)
            {
                float t = Mathf.PingPong(_journeyTime, 1f);
                transform.position = Vector2.Lerp(startPosition, endPosition, t);
            }
            else
            {
                float t = _journeyTime % 1f;
                transform.position = Vector2.Lerp(startPosition, endPosition, t);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(startPosition, endPosition);
            Gizmos.DrawWireSphere(startPosition, 0.2f);
            Gizmos.DrawWireSphere(endPosition, 0.2f);
        }
    }
}
```

### Step 2: Create Moving Spike Obstacle

1. **Duplicate Spike prefab**
2. Rename to `SpikeMoving.prefab`
3. **Add Component** → `MovingObstacle` script
4. Configure:
   - **Start Position**: Will auto-set to current position
   - **End Position**: Set in Inspector (e.g., 3 units right)
   - **Speed**: 2
   - **Ping Pong**: Checked

---

## Part 4: Barrier Obstacles

### Step 1: Create Barrier GameObject

1. **In Hierarchy**, create **2D Object** → **Sprites** → **Square**
2. Rename to `Barrier`
3. Configure **Transform**:
   - **Position**: X: 15, Y: 1.5, Z: 0
   - **Scale**: X: 0.3, Y: 3, Z: 1 (tall thin barrier)

### Step 2: Configure Barrier

1. **Sprite Renderer**:
   - **Color**: Dark Gray (#444444)
   - **Sorting Layer**: Default
   - **Order in Layer**: 3
2. **Add Component** → **Box Collider 2D**
   - **Is Trigger**: Checked
   - **Size**: Auto-sized to sprite
3. **Add Component** → **Hazard** script
   - **Kill On Contact**: Checked

### Step 3: Save Barrier Prefab

1. **Drag to** `Assets/Prefabs/Obstacles/`
2. Save as `Barrier.prefab`

---

## Part 5: Gap Obstacles

Gaps are simply **empty space** between platforms.

### Step 1: Create Gap Marker (Optional, for Editor Only)

1. Create **Empty GameObject** → Rename to `GapMarker`
2. **Add Component** → **Gizmo Script** (for visualization)
3. This is just for level design reference

### Step 2: Position Platforms with Gaps

1. Create multiple **Ground** platforms
2. Position them with spacing:
   - Platform 1: X: 0 to 10
   - **Gap**: X: 10 to 12 (2 units gap)
   - Platform 2: X: 12 to 22

The **DeathZone** (already created) will handle falling into gaps.

---

## Part 6: Testing Obstacles

### Test 1: Spike Collision

1. **Play the scene**
2. Move cart into spike
3. Verify:
   - ✅ Cart dies on contact
   - ✅ Lives decrease by 1
   - ✅ Cart respawns at spawn point
   - ✅ Console shows "Player hit hazard: Spike"

### Test 2: Gap Falling

1. **Play the scene**
2. Jump over a gap but land short
3. Verify:
   - ✅ Cart falls through gap
   - ✅ Hits DeathZone (Y: -10)
   - ✅ Lives decrease
   - ✅ Respawns correctly

### Test 3: Multiple Obstacles

1. Place several obstacles in sequence:
   - Spike at X: 10
   - Gap at X: 15-17
   - Barrier at X: 20
2. **Play** and navigate through
3. Verify all obstacles work correctly

---

## Part 7: Obstacle Placement Best Practices

### Difficulty Progression

**Easy (Early Game):**
- Single spikes with clear spacing
- Small gaps (1-2 units)
- No moving obstacles

**Medium (Mid Game):**
- Spike clusters
- Medium gaps (2-3 units)
- Introduce moving obstacles

**Hard (Late Game):**
- Complex spike patterns
- Large gaps (3-4 units)
- Fast moving obstacles
- Ceiling spikes + floor spikes combo

### Spacing Guidelines

- **Minimum gap between obstacles**: 3 units (gives player time to react)
- **Maximum gap jump distance**: 4 units (depends on cart jump force)
- **Spike cluster spacing**: 0.5 units between individual spikes

### Visual Clarity

- **Color code obstacles**:
  - Red = Instant death (spikes)
  - Orange = Damage (future feature)
  - Gray = Solid barrier
- **Use contrasting colors** against background
- **Ensure obstacles are visible** before entering screen

---

## Part 8: Obstacle Organization

### Folder Structure

```
Assets/
├── Prefabs/
│   └── Obstacles/
│       ├── Spike.prefab
│       ├── SpikeSmall.prefab
│       ├── SpikeCluster.prefab
│       ├── SpikeCeiling.prefab
│       ├── SpikeMoving.prefab
│       ├── Barrier.prefab
│       └── BarrierMoving.prefab
├── Scripts/
│   └── Obstacles/
│       ├── Hazard.cs ✅ (already created)
│       └── MovingObstacle.cs (create if needed)
```

### Prefab Naming Convention

- `Spike.prefab` - Standard spike
- `Spike[Variant].prefab` - Variations (e.g., SpikeSmall, SpikeCluster)
- `[Type]Moving.prefab` - Moving versions
- `[Type]Ceiling.prefab` - Ceiling-mounted versions

---

## Part 9: Advanced Features (Optional)

### Breakable Obstacles

Add health to obstacles that break after being hit:

```csharp
public class BreakableObstacle : MonoBehaviour
{
    [SerializeField] private int health = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
```

### Rotating Obstacles

Add rotation to spikes for visual effect:

```csharp
public class RotatingObstacle : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50f;

    private void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
```

---

## Part 10: Troubleshooting

### Obstacle not killing player?

- Check **Hazard.cs** script is attached
- Verify **Kill On Contact** is checked
- Ensure collider has **Is Trigger** checked
- Player must have **"Player"** tag
- Check **LivesManager.Instance** exists

### Player passes through obstacle?

- Collider might not be trigger (should be trigger)
- Check **Collision Matrix**: Edit → Project Settings → Physics 2D
- Verify obstacle is on correct layer

### Moving obstacle not moving?

- Check **MovingObstacle** script is attached
- Verify **Start/End Position** are different
- Ensure **Speed** > 0
- Check no other scripts are overriding position

---

## Summary Checklist

Before moving to level design:

- [ ] Spike prefab created and tested
- [ ] Spike kills player on contact
- [ ] Lives decrease when hitting spike
- [ ] Gap hazard working (DeathZone catches falls)
- [ ] Barrier obstacle created
- [ ] At least 3-4 obstacle variations created
- [ ] Prefabs saved in correct folders
- [ ] All obstacles have proper colliders (triggers)
- [ ] No console errors during obstacle testing

---

**Next Step: Build First Complete Test Level** 🎮

See `test-level-guide.md` for instructions on assembling your first complete level using these obstacles.

---

*Last Updated: 2025-11-23*
*Phase: Week 3-4 - Lives, Coins, Obstacles*
