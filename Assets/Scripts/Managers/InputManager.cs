using UnityEngine;

namespace AdventuresOfTheWorld.Managers
{
    /// <summary>
    /// Handles cross-platform input for PC (keyboard) and Mobile (touch).
    /// Provides a unified interface for jump input.
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

        #region Input Properties

        public bool JumpPressed { get; private set; }
        public bool JumpHeld { get; private set; }

        #endregion

        #region Unity Lifecycle

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            HandleInput();
        }

        #endregion

        #region Private Methods

        private void HandleInput()
        {
            // Reset jump pressed (only true for one frame)
            JumpPressed = false;

            // PC Keyboard Input
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                JumpPressed = true;
            }

            JumpHeld = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow);

            // Mobile Touch Input
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    JumpPressed = true;
                }

                JumpHeld = touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved;
            }

            // Mouse Input (for testing on PC)
            if (Input.GetMouseButtonDown(0))
            {
                JumpPressed = true;
            }

            JumpHeld = JumpHeld || Input.GetMouseButton(0);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns true if jump was pressed this frame
        /// </summary>
        public bool GetJumpDown()
        {
            return JumpPressed;
        }

        /// <summary>
        /// Returns true while jump is held
        /// </summary>
        public bool GetJump()
        {
            return JumpHeld;
        }

        #endregion
    }
}
