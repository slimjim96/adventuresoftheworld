using UnityEngine;
using UnityEngine.InputSystem;
using AdventuresOfTheWorld.Managers;

namespace AdventuresOfTheWorld.Core
{
    /// <summary>
    /// Connects player input to cart controls using Unity's new Input System.
    /// Reads from InputManager and calls CartController methods.
    ///
    /// This script provides two input modes:
    /// 1. Via InputManager singleton (recommended for centralized input)
    /// 2. Direct InputAction (for standalone cart testing)
    /// </summary>
    [RequireComponent(typeof(CartController))]
    public class PlayerInput : MonoBehaviour
    {
        #region Inspector Fields

        [Header("Input Mode")]
        [Tooltip("Use InputManager singleton (recommended) or direct input actions")]
        [SerializeField] private bool useInputManager = true;

        [Header("Direct Input Actions (if not using InputManager)")]
        [Tooltip("Reference to an InputActionAsset for direct input handling")]
        [SerializeField] private InputActionAsset inputActions;

        #endregion

        #region Private Fields

        private CartController _cartController;
        private InputAction _jumpAction;
        private InputAction _pauseAction;

        #endregion

        #region Unity Lifecycle

        private void Awake()
        {
            _cartController = GetComponent<CartController>();

            // If not using InputManager, set up direct input actions
            if (!useInputManager)
            {
                InitializeDirectInputActions();
            }
        }

        private void OnEnable()
        {
            if (!useInputManager && _jumpAction != null)
            {
                _jumpAction.Enable();
                _pauseAction?.Enable();
            }
        }

        private void OnDisable()
        {
            if (!useInputManager && _jumpAction != null)
            {
                _jumpAction.Disable();
                _pauseAction?.Disable();
            }
        }

        private void Update()
        {
            HandleInput();
        }

        private void OnDestroy()
        {
            if (!useInputManager)
            {
                _jumpAction?.Dispose();
                _pauseAction?.Dispose();
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initialize input actions for direct input mode (not using InputManager)
        /// </summary>
        private void InitializeDirectInputActions()
        {
            // If an InputActionAsset is assigned, use it
            if (inputActions != null)
            {
                _jumpAction = inputActions.FindAction("Gameplay/Jump");
                _pauseAction = inputActions.FindAction("UI/Pause");
            }
            else
            {
                // Create inline input actions as fallback
                _jumpAction = new InputAction("Jump", InputActionType.Button);
                _jumpAction.AddBinding("<Keyboard>/space");
                _jumpAction.AddBinding("<Keyboard>/upArrow");
                _jumpAction.AddBinding("<Keyboard>/w");
                _jumpAction.AddBinding("<Gamepad>/buttonSouth");
                _jumpAction.AddBinding("<Mouse>/leftButton");
                _jumpAction.AddBinding("<Touchscreen>/primaryTouch/tap");

                _pauseAction = new InputAction("Pause", InputActionType.Button);
                _pauseAction.AddBinding("<Keyboard>/escape");
                _pauseAction.AddBinding("<Gamepad>/start");
            }
        }

        /// <summary>
        /// Process input and trigger cart actions
        /// </summary>
        private void HandleInput()
        {
            bool jumpPressed = false;

            // Check for jump input
            if (useInputManager && InputManager.Instance != null)
            {
                // Use centralized InputManager
                jumpPressed = InputManager.Instance.GetJumpDown();
            }
            else if (_jumpAction != null)
            {
                // Use direct input action
                jumpPressed = _jumpAction.WasPressedThisFrame();
            }

            // Trigger jump on cart
            if (jumpPressed && _cartController != null)
            {
                _cartController.Jump();
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Manually trigger a jump (useful for UI buttons).
        /// Public so it can be assigned to Button.onClick in the Unity Inspector.
        /// </summary>
        public void TriggerJump()
        {
            if (_cartController != null)
            {
                _cartController.Jump();
            }
        }

        /// <summary>
        /// Switch between InputManager and direct input mode at runtime
        /// </summary>
        public void SetUseInputManager(bool use)
        {
            useInputManager = use;

            if (!use && _jumpAction == null)
            {
                InitializeDirectInputActions();
                _jumpAction?.Enable();
            }
        }

        #endregion
    }
}
