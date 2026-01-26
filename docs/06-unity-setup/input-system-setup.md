# Unity New Input System Setup Guide

**Purpose:** Guide for setting up and using Unity's new Input System in Adventures of the World.

**Last Updated:** 2026-01-25

---

## Overview

The project uses Unity's **new Input System** package for cross-platform input handling. This provides unified support for:

- Keyboard
- Mouse
- Touch screens (mobile)
- Gamepads (Xbox, PlayStation, etc.)
- Future devices

---

## Installation (One-Time Setup)

### Step 1: Install Input System Package

1. **Window → Package Manager**
2. In the dropdown, select **Unity Registry**
3. Search for **Input System**
4. Click **Install**

### Step 2: Enable New Input System

1. **Edit → Project Settings → Player**
2. Find **Active Input Handling**
3. Select **Both** (recommended) or **Input System Package (New)**
4. Click **Yes** when prompted to restart Unity

### Step 3: Verify Installation

After restart, check:
- No console errors related to `UnityEngine.InputSystem`
- The InputManager script compiles without errors

---

## Project Input Architecture

```
InputManager (Singleton)
    ├── Handles all input detection
    ├── Provides JumpPressed, JumpHeld, PausePressed
    └── Works across all input devices

PlayerInput (on Cart)
    ├── Reads from InputManager
    └── Calls CartController.Jump()

CartController
    ├── Receives jump calls from PlayerInput
    └── No direct input handling

HUDManager
    └── Reads PausePressed from InputManager
```

---

## Supported Input Bindings

### Jump Action

| Device | Input |
|--------|-------|
| Keyboard | Space, Up Arrow, W |
| Mouse | Left Click |
| Touch | Tap anywhere |
| Xbox Controller | A Button |
| PlayStation Controller | X Button |

### Pause Action

| Device | Input |
|--------|-------|
| Keyboard | Escape, P |
| Xbox Controller | Start/Menu |
| PlayStation Controller | Options |

---

## Script Reference

### InputManager.cs

**Location:** `Assets/Scripts/Managers/InputManager.cs`

**Key Properties:**
```csharp
// True only on the frame jump was pressed
InputManager.Instance.JumpPressed

// True while jump is held
InputManager.Instance.JumpHeld

// True only on the frame pause was pressed
InputManager.Instance.PausePressed
```

**Key Methods:**
```csharp
// Get jump pressed this frame
bool jumped = InputManager.Instance.GetJumpDown();

// Get jump held
bool holding = InputManager.Instance.GetJump();

// Get pause pressed this frame
bool paused = InputManager.Instance.GetPauseDown();

// Trigger haptic feedback
InputManager.Instance.Vibrate(duration: 0.1f, intensity: 0.5f);
```

### PlayerInput.cs

**Location:** `Assets/Scripts/Core/PlayerInput.cs`

**Inspector Options:**
- **Use Input Manager:** Toggle between using InputManager singleton or direct input
- **Input Actions:** Optional reference to an InputActionAsset

**Public Methods:**
```csharp
// Manually trigger jump (for UI buttons)
playerInput.TriggerJump();
```

---

## Scene Setup

### Required for Input to Work

1. **InputManager must exist in scene:**
   - Create empty GameObject named `InputManager`
   - Add `InputManager` script
   - Or: It auto-creates if accessed and missing

2. **Cart must have PlayerInput:**
   - Cart GameObject needs `PlayerInput` component
   - `PlayerInput` requires `CartController` on same object

### Recommended Hierarchy

```
Scene
├── Managers
│   └── InputManager (with InputManager script)
├── Cart
│   ├── CartController
│   └── PlayerInput
└── ...
```

---

## Adding New Input Actions

To add a new action (e.g., "Dash"):

### In InputManager.cs

```csharp
// 1. Add the action field
private InputAction _dashAction;

// 2. Add property
public bool DashPressed { get; private set; }

// 3. In InitializeInputActions(), add bindings:
_dashAction = new InputAction("Dash", InputActionType.Button);
_dashAction.AddBinding("<Keyboard>/leftShift");
_dashAction.AddBinding("<Gamepad>/buttonWest");  // X on Xbox

// 4. In OnEnable/OnDisable, enable/disable:
_dashAction?.Enable();
_dashAction?.Disable();

// 5. In HandleInput(), check it:
DashPressed = _dashAction.WasPressedThisFrame();

// 6. Add public method:
public bool GetDashDown() => DashPressed;
```

---

## Using InputActionAsset (Alternative)

For more complex games, you can use an `.inputactions` file:

### Create InputActionAsset

1. **Right-click in Project → Create → Input Actions**
2. Name it `GameInputActions`
3. Double-click to open Input Actions editor
4. Create Action Maps (e.g., "Gameplay", "UI")
5. Add Actions with bindings

### Reference in Script

```csharp
[SerializeField] private InputActionAsset inputActions;

private void Awake()
{
    var jumpAction = inputActions.FindAction("Gameplay/Jump");
    jumpAction.performed += ctx => Jump();
    jumpAction.Enable();
}
```

---

## Troubleshooting

### "InputSystem" namespace not found

**Cause:** Input System package not installed

**Fix:**
1. Window → Package Manager → Input System → Install
2. Restart Unity if prompted

### Input not responding

**Cause:** Input actions not enabled

**Fix:** Check that `OnEnable()` calls `_jumpAction.Enable()`

### Touch not working on mobile

**Cause:** Enhanced Touch not enabled

**Fix:** Ensure `EnhancedTouchSupport.Enable()` is called in `OnEnable()`

### Old Input (legacy) still being used

**Cause:** Active Input Handling set to "Input Manager (Old)"

**Fix:** Edit → Project Settings → Player → Active Input Handling → "Both"

### Jump triggers multiple times

**Cause:** Using `IsPressed()` instead of `WasPressedThisFrame()`

**Fix:** Use `WasPressedThisFrame()` for single-fire actions

---

## Migration from Legacy Input

| Legacy (Old) | New Input System |
|--------------|------------------|
| `Input.GetKeyDown(KeyCode.Space)` | `_jumpAction.WasPressedThisFrame()` |
| `Input.GetKey(KeyCode.Space)` | `_jumpAction.IsPressed()` |
| `Input.GetMouseButtonDown(0)` | Binding: `<Mouse>/leftButton` |
| `Input.touchCount > 0` | `Touch.activeTouches.Count > 0` |
| `Input.GetTouch(0).phase` | `touch.phase` (EnhancedTouch) |

---

## Platform-Specific Notes

### Mobile (iOS/Android)

- Touch input automatically works via `<Touchscreen>/primaryTouch/tap`
- Enhanced Touch provides gesture support
- Haptic feedback via `Handheld.Vibrate()`

### Console (Xbox/PlayStation)

- Gamepad bindings included by default
- Rumble support via `Gamepad.current.SetMotorSpeeds()`

### PC (Keyboard/Mouse)

- Multiple key bindings (Space, W, Up Arrow)
- Mouse click for jump (accessibility)

---

**Document Version:** 1.0
**Created:** 2026-01-25
**For:** Adventures of the World - Unity 2022.3 LTS
