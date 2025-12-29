using UnityEngine;

namespace AdventuresOfTheWorld.Utilities
{
    /// <summary>
    /// Smooth camera follow for tracking the player's cart.
    /// Keeps the cart in view while scrolling.
    /// </summary>
    public class CameraFollow : MonoBehaviour
    {
        #region Serialized Fields

        [Header("Follow Settings")]
        [SerializeField] private Transform target;
        [Tooltip("The cart to follow (assign in Inspector)")]

        [SerializeField] private Vector3 offset = new Vector3(0, 2, -10);
        [Tooltip("Camera offset from target")]

        [SerializeField] private float smoothSpeed = 0.125f;
        [Tooltip("How smoothly camera follows (0 = instant, 1 = very slow)")]

        [Header("Boundaries")]
        [SerializeField] private bool useBounds = false;
        [SerializeField] private float minX = -100f;
        [SerializeField] private float maxX = 100f;
        [SerializeField] private float minY = -10f;
        [SerializeField] private float maxY = 10f;

        #endregion

        #region Private Fields

        private Vector3 _velocity = Vector3.zero;

        #endregion

        #region Unity Lifecycle

        private void Start()
        {
            // Auto-find cart if not assigned
            if (target == null)
            {
                GameObject cart = GameObject.FindGameObjectWithTag("Player");
                if (cart != null)
                {
                    target = cart.transform;
                }
                else
                {
                    Debug.LogWarning("CameraFollow: No target assigned and no Player tag found!");
                }
            }
        }

        private void LateUpdate()
        {
            if (target == null) return;

            FollowTarget();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Sets the camera target
        /// </summary>
        public void SetTarget(Transform newTarget)
        {
            target = newTarget;
        }

        /// <summary>
        /// Sets the camera offset
        /// </summary>
        public void SetOffset(Vector3 newOffset)
        {
            offset = newOffset;
        }

        #endregion

        #region Private Methods

        private void FollowTarget()
        {
            // Calculate desired position
            Vector3 desiredPosition = target.position + offset;

            // Apply bounds if enabled
            if (useBounds)
            {
                desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);
                desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);
            }

            // Smoothly move camera to desired position
            Vector3 smoothedPosition = Vector3.SmoothDamp(
                transform.position,
                desiredPosition,
                ref _velocity,
                smoothSpeed
            );

            transform.position = smoothedPosition;
        }

        #endregion

        #region Debug

        private void OnDrawGizmosSelected()
        {
            if (useBounds)
            {
                // Draw bounds in editor
                Gizmos.color = Color.yellow;

                Vector3 bottomLeft = new Vector3(minX, minY, 0);
                Vector3 topLeft = new Vector3(minX, maxY, 0);
                Vector3 topRight = new Vector3(maxX, maxY, 0);
                Vector3 bottomRight = new Vector3(maxX, minY, 0);

                Gizmos.DrawLine(bottomLeft, topLeft);
                Gizmos.DrawLine(topLeft, topRight);
                Gizmos.DrawLine(topRight, bottomRight);
                Gizmos.DrawLine(bottomRight, bottomLeft);
            }
        }

        #endregion
    }
}
