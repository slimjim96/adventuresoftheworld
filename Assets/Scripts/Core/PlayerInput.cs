using UnityEngine;
using AdventuresOfTheWorld.Core;
using AdventuresOfTheWorld.Managers;

namespace AdventuresOfTheWorld.Core
{
    /// <summary>
    /// Connects player input to cart controls.
    /// Reads from InputManager and calls CartController methods.
    /// </summary>
    [RequireComponent(typeof(CartController))]
    public class PlayerInput : MonoBehaviour
    {
        #region Private Fields

        private CartController _cartController;

        #endregion

        #region Unity Lifecycle

        private void Awake()
        {
            _cartController = GetComponent<CartController>();
        }

        private void Update()
        {
            HandleInput();
        }

        #endregion

        #region Private Methods

        private void HandleInput()
        {
            // Check for jump input from InputManager
            if (InputManager.Instance != null && InputManager.Instance.GetJumpDown())
            {
                _cartController.Jump();
            }

            // Fallback: Direct input check if InputManager not available
            else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                _cartController.Jump();
            }
        }

        #endregion
    }
}
