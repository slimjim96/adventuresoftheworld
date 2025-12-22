using UnityEngine;

namespace AdventuresOfTheWorld.Core
{
    /// <summary>
    /// Smooth camera follow for the player cart.
    /// Includes boundaries to prevent showing areas outside the level.
    /// </summary>
    public class CameraFollow : MonoBehaviour
    {
        #region Serialized Fields

        [Header("Target")]
        [SerializeField] private Transform target;
        [Tooltip("The cart/player to follow")]

        [Header("Follow Settings")]
        [SerializeField] private Vector3 offset = new Vector3(2f, 1f, -10f);
        [Tooltip("Offset from the target (X = look ahead, Y = height, Z = depth)")]

        [SerializeField] private float smoothSpeed = 5f;
        [Tooltip("How smoothly the camera follows (higher = snappier)")]

        [SerializeField] private bool followX = true;
        [SerializeField] private bool followY = true;

        [Header("Look Ahead")]
        [SerializeField] private float lookAheadDistance = 3f;
        [Tooltip("How far ahead of the cart to look")]

        [SerializeField] private float lookAheadSpeed = 2f;

        [Header("Boundaries")]
        [SerializeField] private bool useBoundaries = true;

        [SerializeField] private float minX = float.NegativeInfinity;
        [SerializeField] private float maxX = float.PositiveInfinity;
        [SerializeField] private float minY = float.NegativeInfinity;
        [SerializeField] private float maxY = float.PositiveInfinity;

        [Header("Dead Zone")]
        [SerializeField] private bool useDeadZone = false;
        [SerializeField] private Vector2 deadZoneSize = new Vector2(1f, 0.5f);
        [Tooltip("Area where target can move without camera following")]

        #endregion

        #region Private Fields

        private Vector3 _currentVelocity;
        private float _currentLookAhead = 0f;

        #endregion

        #region Unity Lifecycle

        private void Awake()
        {
            // Try to find target if not assigned
            if (target == null)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if (player != null)
                {
                    target = player.transform;
                }
            }
        }

        private void Start()
        {
            // Snap to target position initially
            if (target != null)
            {
                Vector3 targetPos = GetTargetPosition();
                transform.position = targetPos;
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
        /// Sets camera boundaries (useful for level-specific bounds)
        /// </summary>
        public void SetBoundaries(float minX, float maxX, float minY, float maxY)
        {
            this.minX = minX;
            this.maxX = maxX;
            this.minY = minY;
            this.maxY = maxY;
            useBoundaries = true;
        }

        /// <summary>
        /// Instantly snaps camera to target position
        /// </summary>
        public void SnapToTarget()
        {
            if (target != null)
            {
                transform.position = GetTargetPosition();
            }
        }

        /// <summary>
        /// Shakes the camera (for impacts, death, etc.)
        /// </summary>
        public void Shake(float duration = 0.2f, float magnitude = 0.3f)
        {
            StartCoroutine(ShakeCoroutine(duration, magnitude));
        }

        #endregion

        #region Private Methods

        private void FollowTarget()
        {
            Vector3 targetPos = GetTargetPosition();

            // Apply dead zone if enabled
            if (useDeadZone)
            {
                targetPos = ApplyDeadZone(targetPos);
            }

            // Smooth follow
            Vector3 smoothedPosition = Vector3.SmoothDamp(
                transform.position,
                targetPos,
                ref _currentVelocity,
                1f / smoothSpeed
            );

            // Apply axis constraints
            if (!followX) smoothedPosition.x = transform.position.x;
            if (!followY) smoothedPosition.y = transform.position.y;

            // Apply boundaries
            if (useBoundaries)
            {
                smoothedPosition = ApplyBoundaries(smoothedPosition);
            }

            transform.position = smoothedPosition;
        }

        private Vector3 GetTargetPosition()
        {
            if (target == null) return transform.position;

            // Calculate look ahead based on cart velocity
            CartController cart = target.GetComponent<CartController>();
            if (cart != null && cart.CurrentSpeed > 0)
            {
                _currentLookAhead = Mathf.Lerp(_currentLookAhead, lookAheadDistance, Time.deltaTime * lookAheadSpeed);
            }
            else
            {
                _currentLookAhead = Mathf.Lerp(_currentLookAhead, 0f, Time.deltaTime * lookAheadSpeed);
            }

            Vector3 targetPos = target.position + offset;
            targetPos.x += _currentLookAhead;

            return targetPos;
        }

        private Vector3 ApplyBoundaries(Vector3 position)
        {
            position.x = Mathf.Clamp(position.x, minX, maxX);
            position.y = Mathf.Clamp(position.y, minY, maxY);
            return position;
        }

        private Vector3 ApplyDeadZone(Vector3 targetPos)
        {
            Vector3 currentPos = transform.position;
            Vector3 delta = targetPos - currentPos;

            // Only follow if target is outside dead zone
            if (Mathf.Abs(delta.x) < deadZoneSize.x)
            {
                targetPos.x = currentPos.x;
            }
            if (Mathf.Abs(delta.y) < deadZoneSize.y)
            {
                targetPos.y = currentPos.y;
            }

            return targetPos;
        }

        private System.Collections.IEnumerator ShakeCoroutine(float duration, float magnitude)
        {
            Vector3 originalPos = transform.localPosition;
            float elapsed = 0f;

            while (elapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;

                transform.localPosition = new Vector3(
                    originalPos.x + x,
                    originalPos.y + y,
                    originalPos.z
                );

                elapsed += Time.deltaTime;
                yield return null;
            }

            transform.localPosition = originalPos;
        }

        #endregion

        #region Debug Visualization

        private void OnDrawGizmos()
        {
            // Draw camera bounds
            if (useBoundaries && minX != float.NegativeInfinity)
            {
                Gizmos.color = Color.blue;

                // Draw boundary rectangle
                Vector3 center = new Vector3((minX + maxX) / 2, (minY + maxY) / 2, 0);
                Vector3 size = new Vector3(maxX - minX, maxY - minY, 0);
                Gizmos.DrawWireCube(center, size);
            }

            // Draw dead zone
            if (useDeadZone)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireCube(transform.position, new Vector3(deadZoneSize.x * 2, deadZoneSize.y * 2, 0));
            }

            // Draw target connection
            if (target != null)
            {
                Gizmos.color = Color.white;
                Gizmos.DrawLine(transform.position, target.position);
            }
        }

        #endregion
    }
}
