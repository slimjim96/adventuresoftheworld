using UnityEngine;
using UnityEngine.Events;

namespace AdventuresOfTheWorld.Managers
{
    /// <summary>
    /// Manages player lives and death/respawn logic.
    /// </summary>
    public class LivesManager : MonoBehaviour
    {
        #region Singleton

        private static LivesManager _instance;
        public static LivesManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<LivesManager>();
                }
                return _instance;
            }
        }

        #endregion

        #region Serialized Fields

        [Header("Lives Settings")]
        [SerializeField] private int startingLives = 3;
        [SerializeField] private int maxLives = 5;

        [Header("Respawn Settings")]
        [SerializeField] private float respawnDelay = 1.5f;
        [SerializeField] private Transform respawnPoint;

        #endregion

        #region Events

        public UnityEvent<int> OnLivesChanged;
        public UnityEvent OnPlayerDeath;
        public UnityEvent OnGameOver;
        public UnityEvent OnRespawn;

        #endregion

        #region Private Fields

        private int _currentLives;
        private bool _isDead = false;

        #endregion

        #region Properties

        public int CurrentLives => _currentLives;
        public int MaxLives => maxLives;
        public bool IsDead => _isDead;

        #endregion

        #region Unity Lifecycle

        private void Awake()
        {
            _instance = this;
            _currentLives = startingLives;
        }

        private void Start()
        {
            // Notify UI of initial lives
            OnLivesChanged?.Invoke(_currentLives);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Called when player takes damage/dies
        /// </summary>
        public void LoseLife()
        {
            if (_isDead) return;

            _currentLives--;
            OnLivesChanged?.Invoke(_currentLives);

            if (_currentLives <= 0)
            {
                // Game Over
                _currentLives = 0;
                GameOver();
            }
            else
            {
                // Player still has lives - respawn
                Die();
            }
        }

        /// <summary>
        /// Adds an extra life (from pickup or purchase)
        /// </summary>
        public void AddLife()
        {
            if (_currentLives < maxLives)
            {
                _currentLives++;
                OnLivesChanged?.Invoke(_currentLives);

                Debug.Log($"Extra life gained! Lives: {_currentLives}");
            }
            else
            {
                Debug.Log("Already at max lives!");
            }
        }

        /// <summary>
        /// Resets lives to starting amount (for new level)
        /// </summary>
        public void ResetLives()
        {
            _currentLives = startingLives;
            _isDead = false;
            OnLivesChanged?.Invoke(_currentLives);
        }

        /// <summary>
        /// Sets the respawn point
        /// </summary>
        public void SetRespawnPoint(Transform point)
        {
            respawnPoint = point;
        }

        #endregion

        #region Private Methods

        private void Die()
        {
            _isDead = true;
            OnPlayerDeath?.Invoke();

            // Optional: Play death animation/sound
            // AudioManager.Instance?.PlaySFX("Death");

            // Respawn after delay
            Invoke(nameof(Respawn), respawnDelay);
        }

        private void Respawn()
        {
            _isDead = false;

            // Move player back to respawn point
            if (respawnPoint != null)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if (player != null)
                {
                    // Reset position
                    player.transform.position = respawnPoint.position;

                    // Reset velocity (stop falling momentum)
                    Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        rb.velocity = Vector2.zero;
                        rb.angularVelocity = 0f;
                    }

                    Debug.Log($"Respawned at {respawnPoint.position}");
                }
                else
                {
                    Debug.LogError("Player not found for respawn!");
                }
            }
            else
            {
                Debug.LogError("Respawn point not set!");
            }

            OnRespawn?.Invoke();

            Debug.Log($"Respawned! Lives remaining: {_currentLives}");
        }

        private void GameOver()
        {
            _isDead = true;
            OnGameOver?.Invoke();

            // Optional: Show game over screen
            // Core.GameManager.Instance?.GameOver();

            Debug.Log("Game Over!");
        }

        #endregion
    }
}
