using UnityEngine;
using AdventuresOfTheWorld.Managers;

namespace AdventuresOfTheWorld.Level
{
    /// <summary>
    /// Checkpoint that updates the player's respawn position when passed.
    /// Visual feedback when activated.
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class Checkpoint : MonoBehaviour
    {
        #region Serialized Fields

        [Header("Checkpoint Settings")]
        [SerializeField] private bool isStartCheckpoint = false;
        [Tooltip("Is this the starting checkpoint? (auto-activates)")]

        [SerializeField] private Transform respawnPoint;
        [Tooltip("Where to respawn player (uses this transform if not set)")]

        [Header("Visual Feedback")]
        [SerializeField] private Color inactiveColor = Color.gray;
        [SerializeField] private Color activeColor = Color.green;

        [SerializeField] private GameObject activationEffect;
        [Tooltip("Optional particle effect or animation on activation")]

        #endregion

        #region Private Fields

        private bool _isActivated = false;
        private SpriteRenderer _spriteRenderer;

        #endregion

        #region Properties

        public bool IsActivated => _isActivated;
        public Vector3 RespawnPosition => respawnPoint != null ? respawnPoint.position : transform.position;

        #endregion

        #region Unity Lifecycle

        private void Awake()
        {
            // Ensure the collider is a trigger
            Collider2D col = GetComponent<Collider2D>();
            if (!col.isTrigger)
            {
                col.isTrigger = true;
            }

            _spriteRenderer = GetComponent<SpriteRenderer>();

            // Set up respawn point
            if (respawnPoint == null)
            {
                respawnPoint = transform;
            }
        }

        private void Start()
        {
            // Set initial visual state
            UpdateVisuals();

            // Auto-activate start checkpoint
            if (isStartCheckpoint)
            {
                Activate(silent: true);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Check if player passed the checkpoint
            if (!_isActivated && collision.CompareTag("Player"))
            {
                Activate(silent: false);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Activates this checkpoint and registers it with LivesManager
        /// </summary>
        public void Activate(bool silent = false)
        {
            if (_isActivated) return;

            _isActivated = true;

            // Register with LivesManager as new respawn point
            if (LivesManager.Instance != null)
            {
                LivesManager.Instance.SetRespawnPoint(RespawnPosition);
            }

            if (!silent)
            {
                Debug.Log($"Checkpoint activated: {gameObject.name}");

                // Play activation sound
                if (AudioManager.Instance != null)
                {
                    AudioManager.Instance.PlaySFX("Checkpoint");
                }

                // Show activation effect
                if (activationEffect != null)
                {
                    activationEffect.SetActive(true);
                }
            }

            // Update visuals
            UpdateVisuals();
        }

        /// <summary>
        /// Resets the checkpoint (for level restart)
        /// </summary>
        public void ResetCheckpoint()
        {
            _isActivated = isStartCheckpoint; // Start checkpoint stays active
            UpdateVisuals();

            if (activationEffect != null)
            {
                activationEffect.SetActive(false);
            }
        }

        #endregion

        #region Private Methods

        private void UpdateVisuals()
        {
            if (_spriteRenderer != null)
            {
                _spriteRenderer.color = _isActivated ? activeColor : inactiveColor;
            }
        }

        #endregion

        #region Debug Visualization

        private void OnDrawGizmos()
        {
            // Draw checkpoint flag
            Gizmos.color = _isActivated ? Color.green : Color.gray;
            Gizmos.DrawWireCube(transform.position, new Vector3(0.5f, 2f, 0));

            // Draw respawn point
            Vector3 respawn = respawnPoint != null ? respawnPoint.position : transform.position;
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(respawn, 0.3f);
            Gizmos.DrawLine(transform.position, respawn);

            // Label
            #if UNITY_EDITOR
            string label = isStartCheckpoint ? "START" : (_isActivated ? "✓" : "CHECKPOINT");
            UnityEditor.Handles.Label(transform.position + Vector3.up * 1.5f, label);
            #endif
        }

        #endregion
    }
}
