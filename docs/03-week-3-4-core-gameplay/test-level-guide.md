# Test Level Creation Guide - Adventures of the World

This guide walks through building your **first complete test level** with platforms, gaps, coins, obstacles, and a finish line.

---

## Prerequisites

- Unity 2022.3.62f3
- Core mechanics working (cart movement, jumping, death/respawn)
- HUD displaying (lives + coins)
- Prefabs created:
  - Ground platform
  - Coin
  - Spike (or other obstacle)
- LivesManager and CoinManager in scene

---

## Part 1: Level Planning

### Level Design Goals

**Test Level 1 Objectives:**
- Test all core mechanics in one level
- Short duration (30-60 seconds to complete)
- Progressive difficulty (easy → medium → hard)
- Contains all gameplay elements:
  - Platforms (solid ground)
  - Gaps (test jumping)
  - Coins (test collection)
  - Obstacles (test death/respawn)
  - Finish line (test level completion)

### Level Layout Blueprint

```
[START] → [Easy Section] → [Gap + Coins] → [Obstacles] → [Final Challenge] → [FINISH]
  0-10        10-20            20-30          30-40          40-50           50+
```

**Section Breakdown:**
1. **Start (X: 0-10)**: Safe flat ground, tutorial area
2. **Easy (X: 10-20)**: Small gap + scattered coins
3. **Medium (X: 20-30)**: Medium gap + coin trail
4. **Hard (X: 30-40)**: Spikes + gap combo
5. **Finish (X: 40-50)**: Final platform + finish line

---

## Part 2: Building the Level

### Step 1: Create Level Container

1. **In Hierarchy**, right-click → **Create Empty**
2. Rename to `Level_Test`
3. Set **Transform** Position: (0, 0, 0)
4. This will hold all level pieces

### Step 2: Build Starting Platform

1. **Right-click Level_Test** → **2D Object** → **Sprites** → **Square**
2. Rename to `Platform_Start`
3. Configure:
   - **Position**: X: 5, Y: 0, Z: 0
   - **Scale**: X: 10, Y: 1, Z: 1
   - **Color**: Green (#00AA00) - indicates safe start
4. **Add Component** → **Box Collider 2D**
   - **Is Trigger**: Unchecked (solid platform)
5. Set **Layer**: Ground
6. Set **Tag**: Ground

### Step 3: Set Player Spawn Point

1. **Right-click Level_Test** → **Create Empty**
2. Rename to `PlayerSpawn`
3. **Position**: X: 2, Y: 2, Z: 0 (above starting platform)
4. **Select GameManager** (or LivesManager)
5. **Drag PlayerSpawn** to **Respawn Point** field

### Step 4: Position Player Cart

1. **Select PlayerCart** in Hierarchy
2. **Position**: X: 2, Y: 2, Z: 0 (same as spawn point)
3. **Verify** player spawns on start platform

---

## Part 3: Add Easy Section (X: 10-20)

### Step 1: Create Second Platform

1. **Duplicate Platform_Start** (Ctrl+D)
2. Rename to `Platform_01`
3. **Position**: X: 17, Y: 0, Z: 0
4. **Scale**: X: 8, Y: 1, Z: 1
5. **Color**: Gray (#888888) - standard platform color

**Result**: 2-unit gap between platforms (X: 10 to 15)

### Step 2: Add Coins Over Gap

1. **Create Coin** (or use prefab)
2. **Position**: X: 12, Y: 2, Z: 0 (mid-air over gap)
3. **Duplicate** 2 more coins:
   - Coin 2: X: 13, Y: 2.5, Z: 0
   - Coin 3: X: 14, Y: 2, Z: 0
4. **Parent all coins** to `Level_Test`

**Result**: Player must jump gap and can collect coins mid-air

---

## Part 4: Add Medium Section (X: 20-30)

### Step 1: Create Third Platform

1. **Duplicate Platform_01**
2. Rename to `Platform_02`
3. **Position**: X: 27, Y: 0, Z: 0
4. **Scale**: X: 8, Y: 1, Z: 1

**Result**: 3-unit gap (X: 21 to 24)

### Step 2: Add Coin Trail

1. **Create 5 coins** in an arc over the gap:
   - Coin 1: X: 22, Y: 2, Z: 0
   - Coin 2: X: 23, Y: 3, Z: 0
   - Coin 3: X: 24, Y: 3.5, Z: 0
   - Coin 4: X: 25, Y: 3, Z: 0
   - Coin 5: X: 26, Y: 2, Z: 0

**Result**: Coins guide player's jump arc

---

## Part 5: Add Hard Section (X: 30-40)

### Step 1: Create Fourth Platform

1. **Duplicate Platform_02**
2. Rename to `Platform_03`
3. **Position**: X: 37, Y: 0, Z: 0
4. **Scale**: X: 8, Y: 1, Z: 1

**Result**: 3-unit gap

### Step 2: Add Spike on Platform

1. **Create Spike** (or use Spike prefab)
2. **Position**: X: 35, Y: 0.5, Z: 0 (on Platform_03)
3. Verify **Hazard** script attached

### Step 3: Add Coins Around Spike

1. **Create 2 coins** that tempt risky play:
   - Coin 1: X: 34, Y: 1.5, Z: 0 (before spike)
   - Coin 2: X: 36, Y: 1.5, Z: 0 (after spike)

**Result**: Player must jump over spike or carefully navigate around it

---

## Part 6: Add Final Platform and Finish Line

### Step 1: Create Final Platform

1. **Duplicate Platform_03**
2. Rename to `Platform_Finish`
3. **Position**: X: 47, Y: 0, Z: 0
4. **Scale**: X: 6, Y: 1, Z: 1
5. **Color**: Gold (#FFD700) - indicates finish area

### Step 2: Create Finish Line

1. **Right-click Level_Test** → **2D Object** → **Sprites** → **Square**
2. Rename to `FinishLine`
3. Configure:
   - **Position**: X: 50, Y: 1.5, Z: 0
   - **Scale**: X: 0.5, Y: 3, Z: 1
   - **Color**: Green with transparency (#00FF0066)
4. **Add Component** → **Box Collider 2D**
   - **Is Trigger**: Checked ✅
5. **Add Component** → **FinishLine** script (create below)
6. Set **Tag**: FinishLine

---

## Part 7: Create FinishLine Script

Save this as `Assets/Scripts/Level/FinishLine.cs`:

```csharp
using UnityEngine;
using AdventuresOfTheWorld.Core;
using AdventuresOfTheWorld.Managers;

namespace AdventuresOfTheWorld.Level
{
    [RequireComponent(typeof(Collider2D))]
    public class FinishLine : MonoBehaviour
    {
        [SerializeField] private bool stopCartOnFinish = true;
        [SerializeField] private string victoryMessage = "Level Complete!";

        private bool _finished = false;

        private void Awake()
        {
            GetComponent<Collider2D>().isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!_finished && collision.CompareTag("Player"))
            {
                _finished = true;
                Debug.Log(victoryMessage);

                if (stopCartOnFinish)
                {
                    CartController cart = collision.GetComponent<CartController>();
                    if (cart != null)
                    {
                        cart.StopMovement();
                    }
                }

                if (GameManager.Instance != null)
                {
                    GameManager.Instance.LevelComplete();
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            BoxCollider2D col = GetComponent<BoxCollider2D>();
            if (col != null)
            {
                Gizmos.DrawWireCube(transform.position, new Vector3(col.size.x, col.size.y, 0));
            }
        }
    }
}
```

**Note**: This requires adding `StopMovement()` method to CartController (see Part 9).

---

## Part 8: Add Death Zone

The DeathZone should already exist from earlier setup. Verify:

1. **Select DeathZone** in Hierarchy
2. **Position**: X: 25, Y: -10, Z: 0 (center under level)
3. **Box Collider 2D Size**: X: 100, Y: 1 (covers entire level width)
4. Verify **Is Trigger**: Checked
5. Verify **DeathZone** script attached

---

## Part 9: Update CartController for Finish Line

Add `StopMovement()` method to CartController.cs:

**Good news**: CartController already has the `StopMovement()` method! (See line 121-125 in CartController.cs)

No changes needed - the FinishLine script will work as is.

---

## Part 10: Camera Bounds

Ensure camera follows the cart properly:

1. **Select Main Camera** in Hierarchy
2. If using **Cinemachine**:
   - **Follow**: PlayerCart
   - **Dead Zone**: X: 0.3, Y: 0.3
   - **Lookahead Time**: 0.5
3. Camera should smoothly follow cart through entire level

---

## Part 11: Testing the Complete Level

### Pre-Flight Checklist

Before testing, verify:

- [ ] All platforms positioned correctly (no overlaps)
- [ ] Gaps are jumpable (2-4 units wide)
- [ ] Coins are collectible (within jump reach)
- [ ] Spikes have Hazard script + trigger collider
- [ ] DeathZone covers area under all platforms
- [ ] Finish line has trigger collider + FinishLine script
- [ ] LivesManager exists with respawn point set
- [ ] CoinManager exists in scene
- [ ] HUD displaying (lives + coins)

### Test Run #1: Full Playthrough

1. **Press Play**
2. Complete objectives:
   - ✅ Cart starts moving automatically
   - ✅ Jump over first gap (X: 10-15)
   - ✅ Collect coins in mid-air
   - ✅ Jump over second gap (X: 21-24)
   - ✅ Navigate around spike (X: 35)
   - ✅ Reach finish line (X: 50)
   - ✅ Cart stops at finish
   - ✅ "Level Complete!" appears in console

**Expected time**: 30-60 seconds

### Test Run #2: Death Mechanics

1. **Press Play**
2. Test falling death:
   - Jump short and fall into gap
   - ✅ Cart hits DeathZone (Y: -10)
   - ✅ Lives decrease by 1
   - ✅ Cart respawns at start
   - ✅ Velocity resets (no momentum)
3. Test hazard death:
   - Touch spike
   - ✅ Cart dies immediately
   - ✅ Lives decrease
   - ✅ Respawn works

### Test Run #3: Coin Collection

1. **Press Play**
2. Collect all coins (3 in first gap + 5 in second gap + 2 near spike = 10 total)
3. Verify:
   - ✅ Coin counter increments to 10
   - ✅ Coin icon bounces on each collect
   - ✅ Coins disappear when collected
   - ✅ No duplicate collection (coins don't respawn)

### Test Run #4: Game Over

1. **Press Play**
2. Die 3 times (fall or hit spikes)
3. Verify:
   - ✅ Hearts decrease: 3 → 2 → 1 → 0
   - ✅ "Game Over" triggers after 0 lives
   - ✅ Scene restarts or game over screen appears

---

## Part 12: Common Issues and Fixes

### Cart doesn't move?

- Check `CartController.cs` attached to PlayerCart
- Verify **Move Speed** > 0 (default: 5)
- Check Rigidbody2D is not kinematic

### Can't jump gaps?

- Increase **Jump Force** in CartController (try 15-18)
- Reduce gap width (make platforms closer)
- Verify Ground Layer assigned correctly

### Coins not collecting?

- Check Coin has **Circle Collider 2D** with **Is Trigger** checked
- Verify player has **"Player"** tag
- Ensure **CoinManager** exists in scene

### Spike not killing?

- Verify **Hazard** script attached
- Check **Kill On Contact** is checked
- Ensure collider has **Is Trigger** checked
- Verify **LivesManager** exists

### Finish line not working?

- Check **FinishLine** script attached
- Verify collider is **Trigger**
- Ensure player tagged as **"Player"**
- Check console for "Level Complete!" message

### Camera not following?

- Verify Cinemachine **Follow** target is PlayerCart
- Check camera **Position Z** is -10 (negative, in front)
- Adjust **Damping** settings if too slow/fast

---

## Part 13: Level Refinement

Once basic test passes, polish the level:

### Visual Improvements

1. **Color code platforms**:
   - Start: Green (#00AA00)
   - Standard: Gray (#888888)
   - Finish: Gold (#FFD700)
2. **Add background**:
   - Simple gradient sky
   - Far background sprites (trees, clouds)
3. **Improve obstacle visuals**:
   - Make spikes more prominent (brighter red)
   - Add warning markers before hazards

### Gameplay Tweaks

1. **Adjust difficulty**:
   - Too easy? Add more spikes, wider gaps
   - Too hard? Reduce gaps, add more coins
2. **Fine-tune jump**:
   - Feels floaty? Increase gravity scale
   - Too snappy? Decrease jump force
3. **Speed variation**:
   - Try different cart speeds (3-7)
   - Faster = harder, slower = easier

### Audio (Optional for Week 3-4)

1. **Add background music**:
   - Import music file to `Assets/Audio/Music/`
   - Assign in AudioManager
2. **Add sound effects**:
   - Jump sound
   - Coin collection sound
   - Death sound
   - Victory sound

---

## Part 14: Save as Prefab or Scene

### Option A: Save as Scene

1. **File** → **Save Scene As...**
2. Save to: `Assets/Scenes/Levels/Level_Test.unity`
3. Can duplicate and modify for more levels

### Option B: Convert to Prefab

1. **Drag Level_Test** from Hierarchy to `Assets/Prefabs/Levels/`
2. Creates reusable level prefab
3. Can instantiate dynamically (for procedural generation later)

---

## Part 15: Next Steps

With the test level complete, you can now:

1. ✅ **Week 3-4 Complete**: Lives, Coins, Obstacles all working
2. ⏭️ **Create 2-3 more static levels** (vary difficulty)
3. ⏭️ **Begin procedural generation** (Week 5)
4. ⏭️ **Add parallax backgrounds** (Week 5-6)
5. ⏭️ **Generate final art with Ludo.ai** (Week 6+)

---

## Summary Checklist

Before marking Week 3-4 complete:

- [ ] Test level playable start to finish
- [ ] All mechanics working (movement, jump, death, respawn)
- [ ] Lives HUD displaying and updating
- [ ] Coins collectible with counter working
- [ ] Obstacles killing player correctly
- [ ] Finish line triggers level complete
- [ ] Camera follows smoothly
- [ ] No console errors during gameplay
- [ ] Level saved as scene or prefab

---

**Congratulations! Your first complete level is done!** 🎉

You now have a fully functional test level that validates all core gameplay mechanics. This level will serve as the template for future static levels and procedural generation.

---

*Last Updated: 2025-11-23*
*Phase: Week 3-4 - Lives, Coins, Obstacles*
*Status: Test Level Complete*
