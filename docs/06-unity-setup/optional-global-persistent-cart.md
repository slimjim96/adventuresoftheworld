# Optional: Global Persistent Cart Setup

**Alternative approach: Cart persists across all scenes like GameManager**

⚠️ **Warning:** Only use this if you understand the trade-offs. Prefab system is recommended for level-based games.

---

## How It Works

Instead of having a cart in each scene, you:
1. Create cart ONCE in StartScene
2. Cart persists across all scene loads
3. Position cart at level start points via script

---

## Setup Steps

### Step 1: Update CartController for Persistence

Add to the top of `CartController.cs`:

```csharp
void Awake()
{
    // Make cart persist across scenes (optional)
    DontDestroyOnLoad(gameObject);

    // Original Awake code continues...
}
```

### Step 2: Add Level Start Position System

Create new script: `LevelStartPoint.cs`

```csharp
using UnityEngine;

/// <summary>
/// Marks the starting position for the cart in this level.
/// Place this in each level scene where cart should spawn.
/// </summary>
public class LevelStartPoint : MonoBehaviour
{
    void Start()
    {
        // Find the persistent cart
        CartController cart = FindObjectOfType<CartController>();

        if (cart != null)
        {
            // Teleport cart to this position
            cart.transform.position = transform.position;

            // Reset cart state
            cart.ResetCartState();

            Debug.Log($"Cart positioned at level start: {transform.position}");
        }
        else
        {
            Debug.LogWarning("No cart found! Is cart in StartScene?");
        }
    }

    // Draw gizmo in editor
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up);
    }
}
```

### Step 3: Add Reset Method to CartController

Add this method to `CartController.cs`:

```csharp
/// <summary>
/// Reset cart state when entering a new level
/// </summary>
public void ResetCartState()
{
    // Reset velocity
    if (rb != null)
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }

    // Reset rotation
    transform.rotation = Quaternion.identity;

    // Reset jump cooldown
    lastJumpTime = -jumpCooldown;

    Debug.Log("Cart state reset for new level");
}
```

### Step 4: Setup Each Level Scene

In each level scene (Level01, Level02, etc.):

1. Create empty GameObject: "CartStartPoint"
2. Position it where cart should spawn
3. Add component: `LevelStartPoint` script
4. Delete any Cart instances from scene (cart comes from StartScene now)

### Step 5: Create Cart in StartScene Only

1. Create Cart prefab with full setup (as before)
2. Place Cart instance ONLY in StartScene
3. Cart will persist to all other scenes
4. Each level's StartPoint will position it

---

## Pros of This Approach

✅ Single cart instance (no duplicates)
✅ Update cart once, applies everywhere
✅ Cart state can persist between levels (if desired)
✅ Character selection persists automatically

---

## Cons of This Approach

❌ Can't test Level05 directly (cart not in scene)
❌ Need to play from StartScene to test
❌ More complex debugging
❌ Harder to make level-specific cart variations
❌ Must manage cart state manually between levels

---

## When to Use This

**Use global persistent cart if:**
- Game is continuous (no level select)
- Player plays levels in strict sequence
- You want persistent cart upgrades/state
- You have a hub world cart travels through

**Use prefab system if:**
- Game has level select menu ⭐ (your game)
- Levels can be played in any order
- Each level is independent
- You want clean scene isolation

---

## Comparison Example

**Prefab System (Recommended for you):**
```
StartScene (no cart)
  ↓ Player selects Level05
Level05Scene (has Cart prefab instance)
  ↓ Cart spawns fresh at start point
  ↓ No state from previous levels
```

**Persistent System:**
```
StartScene (has Cart - DontDestroyOnLoad)
  ↓ Cart persists to next scene
CharacterSelectScene (Cart still exists, invisible)
  ↓ Cart persists
LevelSelectScene (Cart still exists, invisible)
  ↓ Player selects Level05
Level05Scene (Cart repositioned by LevelStartPoint)
  ↓ Same cart instance from StartScene
```

---

## Recommendation

**For Adventures of the World, stick with prefab system:**
- You have level select menu
- 12 independent levels
- Each level should start fresh
- Easier to test and debug

**Only use persistent cart if:**
- You change to sequential level progression
- You remove level select menu
- You want cart state to persist (upgrades, etc.)

---

**Last Updated:** 2026-01-17
**Status:** Optional alternative approach
**Recommended:** Use prefab system instead for level-based games
