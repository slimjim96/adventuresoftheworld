using UnityEngine;

namespace AdventuresOfTheWorld.Core
{
    /// <summary>
    /// Controls the player's cart movement and jumping mechanics.
    /// The cart automatically scrolls forward at a constant speed.
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class CartController : MonoBehaviour
    {
        #region Serialized Fields

        [Header("Movement Settings")]
        [SerializeField] private float moveSpeed = 5f;
        [Tooltip("Current cart speed - can be adjusted per level")]

        [Header("Jump Settings")]
        [SerializeField] private float jumpForce = 12f;
        [Tooltip("Vertical force applied when jumping")]

        [SerializeField] private float jumpBufferTime = 0.1f;
        [Tooltip("Time window to buffer jump inputs")]

        [Header("Ground Detection")]
        [SerializeField] private Transform groundCheck;
        [Tooltip("Position to check if cart is grounded")]

        [SerializeField] private float groundCheckRadius = 0.2f;
        [SerializeField] private LayerMask groundLayer;
        [Tooltip("What counts as ground for landing")]

        [Header("Physics")]
        [SerializeField] private float gravityScale = 2f;
        [Tooltip("Gravity multiplier for cart physics")]

        #endregion

        #region Private Fields

        private Rigidbody2D _rigidbody;
        private bool _isGrounded;
        private float _jumpBufferCounter;
        private bool _canMove = true;

        #endregion

        #region Properties

        public bool IsGrounded => _isGrounded;
        public float CurrentSpeed => moveSpeed;

        #endregion

        #region Unity Lifecycle

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.gravityScale = gravityScale;

            // Create ground check if not assigned
            if (groundCheck == null)
            {
                GameObject groundCheckObj = new GameObject("GroundCheck");
                groundCheckObj.transform.SetParent(transform);
                groundCheckObj.transform.localPosition = new Vector3(0, -0.5f, 0);
                groundCheck = groundCheckObj.transform;
            }
        }

        private void Update()
        {
            CheckGrounded();
            HandleJumpBuffer();
        }

        private void FixedUpdate()
        {
            if (_canMove)
            {
                MoveForward();
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Attempts to make the cart jump
        /// </summary>
        public void Jump()
        {
            if (_isGrounded)
            {
                PerformJump();
            }
            else
            {
                // Buffer the jump input
                _jumpBufferCounter = jumpBufferTime;
            }
        }

        /// <summary>
        /// Sets the cart's movement speed (useful for different levels)
        /// </summary>
        public void SetSpeed(float speed)
        {
            moveSpeed = speed;
        }

        /// <summary>
        /// Stops cart movement (for game over or level complete)
        /// </summary>
        public void StopMovement()
        {
            _canMove = false;
            _rigidbody.velocity = Vector2.zero;
        }

        /// <summary>
        /// Resumes cart movement
        /// </summary>
        public void ResumeMovement()
        {
            _canMove = true;
        }

        #endregion

        #region Private Methods

        private void MoveForward()
        {
            // Maintain constant horizontal velocity
            Vector2 velocity = _rigidbody.velocity;
            velocity.x = moveSpeed;
            _rigidbody.velocity = velocity;
        }

        private void CheckGrounded()
        {
            // Check if cart is touching ground using overlap circle
            _isGrounded = Physics2D.OverlapCircle(
                groundCheck.position,
                groundCheckRadius,
                groundLayer
            );
        }

        private void HandleJumpBuffer()
        {
            // Handle buffered jump input
            if (_jumpBufferCounter > 0)
            {
                _jumpBufferCounter -= Time.deltaTime;

                if (_isGrounded)
                {
                    PerformJump();
                    _jumpBufferCounter = 0;
                }
            }
        }

        private void PerformJump()
        {
            // Apply vertical force for jump
            Vector2 velocity = _rigidbody.velocity;
            velocity.y = jumpForce;
            _rigidbody.velocity = velocity;

            // Optional: Play jump sound
            // AudioManager.Instance?.PlaySFX("Jump");
        }

        #endregion

        #region Debug

        private void OnDrawGizmosSelected()
        {
            // Visualize ground check in editor
            if (groundCheck != null)
            {
                Gizmos.color = _isGrounded ? Color.green : Color.red;
                Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
            }
        }

        #endregion
    }
}
