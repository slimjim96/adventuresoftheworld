# Developer Debug System

**Complete debug and level design toolset for Adventures of the World**

**Purpose:** Visual debugging, jump distance calculation, and level design assistance for placing platforms at optimal distances.

---

## 🚀 Quick Start

### Step 1: Create DevSettings Asset

1. **In Unity Project window:**
   - Right-click `Assets/Resources/` folder (create if doesn't exist)
   - Create → Game → **Dev Settings**
   - Name it: **DevSettings** (must be exact name)

2. **Configure in Inspector:**
   - **Debug Mode:** ✓ Check to enable
   - **Show HUD:** ✓
   - **Show Jump Trajectory:** ✓
   - **Show Reachable Area:** ✓
   - **Show FPS:** ✓

### Step 2: Add DebugManager to Scene

1. **In your StartScene (or first scene):**
   - Create empty GameObject: "DebugManager"
   - Add Component → **DebugManager** script
   - It will auto-load DevSettings from Resources

2. **Configure keyboard shortcuts (optional):**
   - Toggle Debug Key: F12 (default)
   - Toggle HUD Key: F11
   - Cycle Visuals Key: F10

### Step 3: Add Visualizer to Cart

1. **Select Cart prefab**
2. **Add Component → Cart Debug Visualizer**
3. **Auto-configuration:**
   - CartController: Auto-assigned
   - Rigidbody2D: Auto-assigned
   - Trajectory Points: 50 (default)

---

## 🎮 Usage

### Keyboard Shortcuts

| Key | Function | Description |
|-----|----------|-------------|
| **F12** | Toggle Debug Mode | Master on/off switch for all debug features |
| **F11** | Toggle HUD | Show/hide on-screen stats overlay |
| **F10** | Cycle Visuals | Rotate through: All → Trajectory Only → Reachable Only → Off |

### Runtime Controls

**Enable debug mode:**
```csharp
DebugManager.EnableDebugMode(true);
```

**Check if debug enabled:**
```csharp
if (DevSettings.IsDebugEnabled)
{
    // Do debug-only stuff
}
```

---

## 📊 Visual Debug Features

### 1. On-Screen HUD (Top-Left Corner)

**Shows in real-time:**
- ✅ **FPS Counter** - Color-coded (Green ≥60, Yellow ≥30, Red <30)
- ✅ **Cart Physics:**
  - Position (X, Y in units)
  - Velocity (X, Y in m/s)
  - Movement speed
  - Grounded status (Green YES / Red NO)
  - Rotation angle (if terrain following enabled)
- ✅ **Jump Capabilities:**
  - Max horizontal distance (units + pixels)
  - Max vertical height (units + pixels)
  - Total air time (seconds)
- ✅ **Level Design Guide:**
  - Maximum safe platform gap
  - Maximum platform height above cart

**Screenshot Example:**
```
╔═══════════════════════════════════╗
║ DEVELOPER DEBUG MODE              ║
║ F12: Toggle | F11: HUD | F10: Vis ║
║                                   ║
║ FPS: 60.2                         ║
║                                   ║
║ CART PHYSICS                      ║
║ Position: (5.23, 2.15)            ║
║ Velocity: (5.00, 0.00) m/s        ║
║ Speed: 5.00 m/s                   ║
║ Grounded: YES                     ║
║                                   ║
║ JUMP CAPABILITIES                 ║
║ Max Horizontal: 10.20 u (1020 px) ║
║ Max Vertical: 5.10 u (510 px)     ║
║ Air Time: 2.04 seconds            ║
║                                   ║
║ LEVEL DESIGN GUIDE                ║
║ Max platform gap: 10.20 units     ║
║ Max platform height: 5.10 units   ║
╚═══════════════════════════════════╝
```

---

### 2. Jump Trajectory Arc (Yellow Line)

**What it shows:**
- Parabolic arc showing complete jump path
- Updates in real-time as cart settings change
- Visible in both Scene view (Gizmos) and Game view (Debug.DrawLine)

**Uses:**
- See exactly where cart will land
- Visualize jump apex (highest point)
- Test if platforms are within reach

**Configuration:**
- `trajectoryPoints`: Higher = smoother curve (default: 50)
- `trajectoryColor`: Yellow with 80% opacity (default)

---

### 3. Reachable Area Box (Green Transparent)

**What it shows:**
- Green semi-transparent box showing ALL positions cart can reach from current spot
- Width = max horizontal jump distance
- Height = max vertical jump height

**Uses:**
- Quickly check if a platform position is reachable
- Visual guide for platform placement
- Level design planning

**Configuration:**
- `reachableAreaColor`: Green with 30% opacity (default)

---

### 4. Scene View Text Labels

**Shows in Unity Scene view:**
- **Max Distance Label** (Yellow) - At landing position
- **Max Height Label** (Cyan) - At jump apex

**Format:**
```
Max Distance: 10.20u
(1020px)

Max Height: 5.10u
(510px)
```

---

## 🛠️ Jump Calculation API

### Using JumpCalculator Utility

**Calculate max horizontal distance:**
```csharp
float distance = JumpCalculator.CalculateMaxJumpDistance(
    horizontalSpeed: 5f,
    jumpForce: 10f,
    gravity: 1f
);
// Returns: 10.2 units
```

**Calculate max jump height:**
```csharp
float height = JumpCalculator.CalculateMaxJumpHeight(
    jumpForce: 10f,
    gravity: 1f
);
// Returns: 5.1 units
```

**Generate trajectory points:**
```csharp
Vector3[] points = JumpCalculator.CalculateJumpTrajectory(
    startPosition: transform.position,
    horizontalSpeed: 5f,
    jumpForce: 10f,
    gravity: 1f,
    pointCount: 50
);
// Returns: Array of 50 Vector3 positions along arc
```

**Check if position is reachable:**
```csharp
bool canReach = JumpCalculator.IsPositionReachable(
    startPosition: cartPosition,
    targetPosition: platformPosition,
    horizontalSpeed: 5f,
    jumpForce: 10f,
    gravity: 1f,
    tolerance: 0.5f
);
```

**Get formatted stats string:**
```csharp
string stats = JumpCalculator.GetJumpStats(5f, 10f, 1f);
// Returns:
// "Max Distance: 10.20 units (1020px)
//  Max Height: 5.10 units (510px)
//  Air Time: 2.04s"
```

---

## 📐 Level Design Workflow

### Placing Platforms at Optimal Distance

**Step 1: Enable Debug Mode**
- Press **F12** in Play mode
- Or check DevSettings.debugMode in Inspector

**Step 2: Position Cart at Starting Platform**
- Place cart on current platform in Scene view
- Enter Play mode

**Step 3: Read Jump Capabilities**
- Check HUD for "Max Horizontal" value
- This is the MAXIMUM gap between platforms
- **Safe gap = 70-80% of max** (for player error margin)

**Example:**
```
Max Horizontal: 10.20 units
Safe platform gap: 7-8 units (70-80% of max)
```

**Step 4: Visual Placement**
- Green reachable box shows where you CAN place platforms
- Yellow trajectory shows where cart WILL land with perfect timing
- Red endpoint sphere shows exact landing spot

**Step 5: Test Different Settings**
- Adjust `moveSpeed` or `jumpForce` in CartController
- Debug visuals update in real-time
- See how it affects reachable area

---

### Example Platform Spacing

**With default settings (moveSpeed=5, jumpForce=10, gravity=1):**

| Platform Type | Gap Distance | Height Difference | Notes |
|---------------|--------------|-------------------|-------|
| Easy Jump | 5-6 units | 0-2 units up | Very safe, beginner-friendly |
| Medium Jump | 7-8 units | 2-3 units up | Requires timing |
| Hard Jump | 9-10 units | 3-4 units up | Near maximum, challenging |
| Maximum Jump | 10+ units | 4-5 units up | Pixel-perfect, expert only |

**Vertical gaps:**
- Maximum reachable height: ~5.1 units
- Safe upward jump: 3-4 units
- Falling is unlimited (cart can drop from any height)

---

## ⚙️ Configuration Options

### DevSettings Asset

**Master Toggle:**
- `debugMode` - Enable all debug features

**Visual Options:**
- `showHUD` - On-screen stats overlay
- `showJumpTrajectory` - Yellow trajectory arc
- `showReachableArea` - Green reachable box
- `showTextLabels` - Scene view text labels
- `showFPS` - FPS counter
- `showPhysicsInfo` - Velocity, position, grounded status

**Level Design:**
- `showGrid` - Grid overlay (not yet implemented)
- `gridCellSize` - Grid cell size in units

**Colors:**
- `trajectoryColor` - Jump arc color (default: Yellow)
- `reachableAreaColor` - Reachable box color (default: Green transparent)
- `hudTextColor` - HUD text color (default: White)

---

### CartDebugVisualizer Component

**HUD Position:**
- `hudPosition` - Screen position (0-1 normalized)
  - Default: (0.02, 0.02) = top-left corner
  - (0.98, 0.02) = top-right corner
  - (0.02, 0.98) = bottom-left corner

**Font Size:**
- `fontSize` - HUD text size (default: 14)

**Trajectory:**
- `trajectoryPoints` - Arc smoothness (10-100, default: 50)
- `drawInGameView` - Show trajectory in Game view (default: true)

---

## 🎯 Use Cases

### Use Case 1: Initial Level Design

**Goal:** Determine platform spacing for entire game

1. Enable debug mode
2. Test jump with default cart settings
3. Note max distances in different scenarios:
   - Flat ground → platform
   - Low platform → high platform
   - High platform → low platform
4. Document safe ranges
5. Use as guidelines for ALL levels

---

### Use Case 2: Testing Character Multipliers

**Goal:** See how character stats affect jump distance

1. Create CharacterData with different multipliers:
   - Cat: jumpBoost=1.0, speed=1.0 (baseline)
   - Rabbit: jumpBoost=1.2, speed=1.1 (better jumper)
   - Elephant: jumpBoost=0.8, speed=0.9 (heavier)

2. Enable debug mode
3. Play with each character
4. Compare max distances in HUD
5. Balance levels to accommodate different characters

---

### Use Case 3: Dynamic Level Difficulty Scaling

**Goal:** Adjust platform gaps based on difficulty

1. Enable debug mode
2. Note max jump distance
3. Set difficulty tiers:
   - Easy: 60% of max
   - Medium: 75% of max
   - Hard: 90% of max
   - Expert: 95-100% of max

4. Use these percentages when procedurally generating levels

---

### Use Case 4: Finding Bugs

**Goal:** Identify unreachable platforms

1. Enable debug mode in problematic level
2. Play through level
3. Watch reachable area box
4. If platform is OUTSIDE green box → bug found
5. Either:
   - Move platform closer
   - Increase cart's jump force
   - Add intermediate platform

---

## 📊 Technical Details

### Physics Calculations

**Horizontal Distance Formula:**
```
distance = horizontalSpeed × totalAirTime
totalAirTime = (2 × jumpForce) / gravity
```

**Vertical Height Formula:**
```
height = (jumpForce²) / (2 × gravity)
```

**Trajectory Point Calculation:**
```
For each point t along the arc:
x(t) = x₀ + velocityX × t
y(t) = y₀ + jumpForce × t - (0.5 × gravity × t²)
```

### Units Explanation

**Unity Units:**
- 1 unit = 100 pixels (at Pixels Per Unit = 100)
- Cart moves at 5 units/second = 500 pixels/second

**Example:**
- Max horizontal: 10.2 units = 1020 pixels
- Max vertical: 5.1 units = 510 pixels

---

## 🐛 Troubleshooting

### Issue: Debug HUD not showing

**Check:**
1. DevSettings asset exists in `Assets/Resources/DevSettings`
2. DevSettings.debugMode is checked
3. DevSettings.showHUD is checked
4. DebugManager exists in scene
5. Press F11 to toggle HUD visibility

---

### Issue: Trajectory not visible in Scene view

**Check:**
1. DevSettings.showJumpTrajectory is checked
2. Cart is selected in Hierarchy
3. Gizmos are enabled (top-right of Scene view)
4. DevSettings.debugMode is enabled

---

### Issue: Values seem wrong

**Check:**
1. Cart's Rigidbody2D.gravityScale (should be 1.0)
2. Physics2D.gravity in Project Settings (should be -9.81)
3. Cart's moveSpeed and jumpForce in Inspector
4. Character multipliers (jumpBoostMultiplier, speedMultiplier)

---

### Issue: Performance impact in build

**Solution:**
Debug visualizations automatically disable when debugMode=false. For production builds:

```csharp
#if DEVELOPMENT_BUILD || UNITY_EDITOR
    // Debug code only runs in dev builds and editor
    if (DevSettings.IsDebugEnabled)
    {
        // Debug visualization
    }
#endif
```

Or simply uncheck DevSettings.debugMode before building.

---

## 📝 Best Practices

### 1. Document Your Findings

Create a level design document with:
```
Cart Settings:
- Move Speed: 5 units/s
- Jump Force: 10 units/s
- Gravity Scale: 1.0

Jump Capabilities:
- Max Horizontal: 10.2 units (1020px)
- Max Vertical: 5.1 units (510px)
- Air Time: 2.04 seconds

Platform Spacing Guidelines:
- Easy: 5-6 units gap
- Medium: 7-8 units gap
- Hard: 9-10 units gap

Character Modifiers:
- Cat (baseline): 1.0x jump, 1.0x speed
- Rabbit (fast): 1.2x jump, 1.1x speed
- Elephant (slow): 0.8x jump, 0.9x speed
```

### 2. Test with Different Gravity

Try different Rigidbody2D.gravityScale values:
- 1.0 = Normal (default)
- 1.5 = Heavier feel, shorter jumps
- 0.7 = Floaty feel, longer jumps

### 3. Balance for Worst-Case Character

Design levels that are beatable with the character that has:
- Lowest jumpBoostMultiplier
- Lowest speedMultiplier

This ensures ALL characters can complete levels.

### 4. Use Grid for Consistency

Enable `showGrid` once implemented to align platforms to grid cells. This creates more polished, professional-looking levels.

---

## 🚀 Future Enhancements

**Planned features:**
- [ ] Grid overlay for snap-to-grid platform placement
- [ ] Click-to-test: Click anywhere in scene to test if reachable
- [ ] Multi-jump trajectory (show where cart goes if jumping multiple times)
- [ ] Character comparison view (overlay multiple character jump arcs)
- [ ] Export stats to CSV for analysis
- [ ] In-editor level validator (checks all platforms are reachable)

---

## 📚 Related Files

**Scripts:**
- `DevSettings.cs` - ScriptableObject with debug settings
- `DebugManager.cs` - Keyboard shortcuts, toggle management
- `JumpCalculator.cs` - Physics calculation utilities
- `CartDebugVisualizer.cs` - Visual debug rendering

**Documentation:**
- Level design guidelines (create based on debug findings)
- Character balancing guide
- Platform placement cheat sheet

---

**Last Updated:** 2026-01-17
**Version:** 1.0
**Status:** ✅ Complete and ready to use
**Tested On:** Unity 2022.3 LTS

---

## 🎓 Quick Reference Card

**Keyboard Shortcuts:**
- F12 = Toggle Debug
- F11 = Toggle HUD
- F10 = Cycle Visuals

**Key Values to Watch:**
- Max Horizontal Distance = Safe platform gap
- Max Vertical Height = Safe platform height
- FPS = Performance check

**Safe Platform Spacing:**
- Beginner: 60-70% of max
- Intermediate: 75-85% of max
- Expert: 90-100% of max

**Remember:**
- 1 unit = 100 pixels (if PPU=100)
- Green box = reachable area
- Yellow arc = jump path
- Red sphere = landing spot
