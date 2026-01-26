using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

namespace AdventuresOfTheWorld.Managers
{
    /// <summary>
    /// Handles cross-platform input using Unity's new Input System.
    /// Provides a unified interface for jump input across keyboard, touch, and gamepad.
    ///
    /// SETUP REQUIRED:
    /// 1. Install Input System package: Window → Package Manager → Input System
    /// 2. Enable new Input System: Edit → Project Settings → Player → Active Input Handling → "Both" or "Input System Package (New)"
    /// 3. Restart Unity when prompted
    /// </summary>
    public class InputManager : MonoBehaviour
    {
        #region Singleton

        private static InputManager _instance;
        public static InputManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<InputManager>();
                    if (_instance == null)
                    {
                        GameObject go = new GameObject("InputManager");
                        _instance = go.AddComponent<InputManager>();
                    }
                }
                return _instance;
            }
        }

        #endregion

        #region Input Actions

        private InputAction _jumpAction;
        private InputAction _pauseAction;

        #endregion

        #region Input Properties

        /// <summary>
        /// True only on the frame jump was pressed
        /// </summary>
        public bool JumpPressed { get; private set; }

        /// <summary>
        /// True while jump input is held down
        /// </summary>
        public bool JumpHeld { get; private set; }

        /// <summary>
        /// True only on the frame pause was pressed
        /// </summary>
        public bool PausePressed { get; private set; }

        #endregion

        #region Unity Lifecycle

        private void Awake()
        {
            // Singleton setup
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);

            // Initialize Input Actions
            InitializeInputActions();
        }

        private void OnEnable()
        {
            // Enable input actions
            _jumpAction?.Enable();
            _pauseAction?.Enable();

            // Enable enhanced touch support for mobile
            EnhancedTouchSupport.Enable();
        }

        private void OnDisable()
        {
            // Disable input actions
            _jumpAction?.Disable();
            _pauseAction?.Disable();

            // Disable enhanced touch support
            EnhancedTouchSupport.Disable();
        }

        private void Update()
        {
            HandleInput();
        }

        private void OnDestroy()
        {
            // Clean up input actions
            _jumpAction?.Dispose();
            _pauseAction?.Dispose();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initialize input actions with bindings for all supported input devices
        /// </summary>
        private void InitializeInputActions()
        {
            // Jump Action - responds to spacebar, touch, mouse click, gamepad button
            _jumpAction = new InputAction("Jump", InputActionType.Button);
            _jumpAction.AddBinding("<Keyboard>/space");
            _jumpAction.AddBinding("<Keyboard>/upArrow");
            _jumpAction.AddBinding("<Keyboard>/w");
            _jumpAction.AddBinding("<Gamepad>/buttonSouth");  // A button (Xbox) / X button (PlayStation)
            _jumpAction.AddBinding("<Gamepad>/buttonNorth");  // Y button (Xbox) / Triangle (PlayStation)
            _jumpAction.AddBinding("<Mouse>/leftButton");
            _jumpAction.AddBinding("<Touchscreen>/primaryTouch/tap");

            // Pause Action - responds to escape, start button
            _pauseAction = new InputAction("Pause", InputActionType.Button);
            _pauseAction.AddBinding("<Keyboard>/escape");
            _pauseAction.AddBinding("<Keyboard>/p");
            _pauseAction.AddBinding("<Gamepad>/start");
        }

        /// <summary>
        /// Process input each frame
        /// </summary>
        private void HandleInput()
        {
            // Reset single-frame flags
            JumpPressed = false;
            PausePressed = false;

            // Check jump action
            if (_jumpAction != null)
            {
                JumpPressed = _jumpAction.WasPressedThisFrame();
                JumpHeld = _jumpAction.IsPressed();
            }

            // Check pause action
            if (_pauseAction != null)
            {
                PausePressed = _pauseAction.WasPressedThisFrame();
            }

            // Additional touch handling for multi-touch or specific gestures
            HandleTouchInput();
        }

        /// <summary>
        /// Handle touch-specific input (for gestures or multi-touch)
        /// </summary>
        private void HandleTouchInput()
        {
            // Enhanced touch provides better touch handling
            if (Touch.activeTouches.Count > 0)
            {
                foreach (var touch in Touch.activeTouches)
                {
                    // Any touch that just began triggers jump
                    if (touch.phase == UnityEngine.InputSystem.TouchPhase.Began)
                    {
                        JumpPressed = true;
                    }

                    // Touch being held
                    if (touch.phase == UnityEngine.InputSystem.TouchPhase.Stationary ||
                        touch.phase == UnityEngine.InputSystem.TouchPhase.Moved)
                    {
                        JumpHeld = true;
                    }
                }
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns true if jump was pressed this frame.
        /// Use this for triggering jump actions.
        /// </summary>
        public bool GetJumpDown()
        {
            return JumpPressed;
        }

        /// <summary>
        /// Returns true while jump is being held.
        /// Use this for variable jump height or held actions.
        /// </summary>
        public bool GetJump()
        {
            return JumpHeld;
        }

        /// <summary>
        /// Returns true if pause was pressed this frame.
        /// </summary>
        public bool GetPauseDown()
        {
            return PausePressed;
        }

        /// <summary>
        /// Vibrate the device (mobile) or controller (gamepad).
        /// Useful for jump feedback.
        /// </summary>
        /// <param name="duration">Duration in seconds</param>
        /// <param name="intensity">Intensity from 0 to 1</param>
        public void Vibrate(float duration = 0.1f, float intensity = 0.5f)
        {
            // Gamepad haptics
            if (Gamepad.current != null)
            {
                Gamepad.current.SetMotorSpeeds(intensity, intensity);
                Invoke(nameof(StopVibration), duration);
            }

            // Mobile haptics (requires additional setup on some platforms)
#if UNITY_ANDROID || UNITY_IOS
            Handheld.Vibrate();
#endif
        }

        private void StopVibration()
        {
            if (Gamepad.current != null)
            {
                Gamepad.current.SetMotorSpeeds(0f, 0f);
            }
        }

        #endregion
    }
}
