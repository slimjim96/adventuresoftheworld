using UnityEngine;

namespace AdventuresOfTheWorld.Obstacles
{
    /// <summary>
    /// Makes an obstacle move back and forth between two points.
    /// Can be used for moving spikes, barriers, or platforms.
    /// </summary>
    public class MovingObstacle : MonoBehaviour
    {
        #region Serialized Fields

        [Header("Movement Settings")]
        [SerializeField] private Vector2 startPosition;
        [SerializeField] private Vector2 endPosition;
        [SerializeField] private float speed = 2f;
        [SerializeField] private bool useLocalPosition = true;

        [Header("Movement Type")]
        [SerializeField] private bool pingPong = true;
        [SerializeField] private bool loop = false;

        [Header("Editor Setup")]
        [SerializeField] private bool setStartPositionOnAwake = true;
        [SerializeField] private Vector2 offsetFromStart = new Vector2(3f, 0f);

        #endregion

        #region Private Fields

        private float _journeyTime;
        private Vector2 _actualStartPos;
        private Vector2 _actualEndPos;

        #endregion

        #region Unity Lifecycle

        private void Awake()
        {
            if (setStartPositionOnAwake)
            {
                // Auto-set start position to current position
                if (useLocalPosition)
                {
                    startPosition = transform.localPosition;
                }
                else
                {
                    startPosition = transform.position;
                }

                // Auto-calculate end position as offset from start
                endPosition = startPosition + offsetFromStart;
            }

            _actualStartPos = startPosition;
            _actualEndPos = endPosition;
        }

        private void Update()
        {
            MoveObstacle();
        }

        #endregion

        #region Movement Logic

        private void MoveObstacle()
        {
            _journeyTime += Time.deltaTime * speed;

            if (pingPong)
            {
                // Move back and forth using PingPong
                float t = Mathf.PingPong(_journeyTime, 1f);
                Vector2 newPosition = Vector2.Lerp(_actualStartPos, _actualEndPos, t);

                if (useLocalPosition)
                {
                    transform.localPosition = newPosition;
                }
                else
                {
                    transform.position = newPosition;
                }
            }
            else if (loop)
            {
                // Move in one direction and loop back
                float t = _journeyTime % 1f;
                Vector2 newPosition = Vector2.Lerp(_actualStartPos, _actualEndPos, t);

                if (useLocalPosition)
                {
                    transform.localPosition = newPosition;
                }
                else
                {
                    transform.position = newPosition;
                }
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Reset movement to start position
        /// </summary>
        public void ResetMovement()
        {
            _journeyTime = 0f;
            if (useLocalPosition)
            {
                transform.localPosition = _actualStartPos;
            }
            else
            {
                transform.position = _actualStartPos;
            }
        }

        /// <summary>
        /// Pause movement
        /// </summary>
        public void PauseMovement()
        {
            enabled = false;
        }

        /// <summary>
        /// Resume movement
        /// </summary>
        public void ResumeMovement()
        {
            enabled = true;
        }

        /// <summary>
        /// Set new movement points at runtime
        /// </summary>
        public void SetMovementPoints(Vector2 start, Vector2 end)
        {
            _actualStartPos = start;
            _actualEndPos = end;
            _journeyTime = 0f;
        }

        #endregion

        #region Gizmos

        private void OnDrawGizmos()
        {
            // Draw movement path in editor
            Vector2 startPos = Application.isPlaying ? _actualStartPos : startPosition;
            Vector2 endPos = Application.isPlaying ? _actualEndPos : endPosition;

            // Handle auto-setup in editor
            if (!Application.isPlaying && setStartPositionOnAwake)
            {
                if (useLocalPosition)
                {
                    startPos = transform.localPosition;
                }
                else
                {
                    startPos = transform.position;
                }
                endPos = startPos + offsetFromStart;
            }

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(startPos, endPos);

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(startPos, 0.2f);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(endPos, 0.2f);
        }

        private void OnDrawGizmosSelected()
        {
            // Draw more detailed path when selected
            Vector2 startPos = Application.isPlaying ? _actualStartPos : startPosition;
            Vector2 endPos = Application.isPlaying ? _actualEndPos : endPosition;

            if (!Application.isPlaying && setStartPositionOnAwake)
            {
                if (useLocalPosition)
                {
                    startPos = transform.localPosition;
                }
                else
                {
                    startPos = transform.position;
                }
                endPos = startPos + offsetFromStart;
            }

            // Draw multiple points along path
            Gizmos.color = Color.cyan;
            int pathPoints = 10;
            for (int i = 0; i <= pathPoints; i++)
            {
                float t = i / (float)pathPoints;
                Vector2 point = Vector2.Lerp(startPos, endPos, t);
                Gizmos.DrawWireSphere(point, 0.1f);
            }
        }

        #endregion
    }
}
