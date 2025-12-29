using UnityEngine;
using UnityEngine.UI;
using AdventuresOfTheWorld.Managers;

namespace AdventuresOfTheWorld.UI
{
    /// <summary>
    /// Displays player lives using heart icons in the HUD.
    /// Updates automatically when lives change via LivesManager events.
    /// </summary>
    public class LivesHUD : MonoBehaviour
    {
        #region Serialized Fields

        [Header("Heart Display")]
        [SerializeField] private GameObject heartPrefab;
        [SerializeField] private Transform heartsContainer;
        [SerializeField] private Sprite fullHeartSprite;
        [SerializeField] private Sprite emptyHeartSprite;

        [Header("Settings")]
        [SerializeField] private int maxLivesToDisplay = 5;
        [SerializeField] private float heartSpacing = 40f;

        #endregion

        #region Private Fields

        private Image[] _heartImages;

        #endregion

        #region Unity Lifecycle

        private void Start()
        {
            InitializeHearts();
            SubscribeToEvents();
            UpdateLivesDisplay(LivesManager.Instance != null ? LivesManager.Instance.CurrentLives : 3);
        }

        private void OnDestroy()
        {
            UnsubscribeFromEvents();
        }

        #endregion

        #region Initialization

        private void InitializeHearts()
        {
            // Clear any existing hearts
            foreach (Transform child in heartsContainer)
            {
                Destroy(child.gameObject);
            }

            // Create heart images
            _heartImages = new Image[maxLivesToDisplay];

            for (int i = 0; i < maxLivesToDisplay; i++)
            {
                GameObject heart = Instantiate(heartPrefab, heartsContainer);
                heart.name = $"Heart_{i}";

                Image heartImage = heart.GetComponent<Image>();
                if (heartImage != null)
                {
                    _heartImages[i] = heartImage;
                    heartImage.sprite = fullHeartSprite;
                }
                else
                {
                    Debug.LogError($"Heart prefab must have an Image component! Heart {i} will not display correctly.");
                }
            }
        }

        #endregion

        #region Event Handling

        private void SubscribeToEvents()
        {
            if (LivesManager.Instance != null)
            {
                LivesManager.Instance.OnLivesChanged += UpdateLivesDisplay;
                LivesManager.Instance.OnRespawn += OnPlayerRespawn;
                LivesManager.Instance.OnGameOver += OnGameOver;
            }
        }

        private void UnsubscribeFromEvents()
        {
            if (LivesManager.Instance != null)
            {
                LivesManager.Instance.OnLivesChanged -= UpdateLivesDisplay;
                LivesManager.Instance.OnRespawn -= OnPlayerRespawn;
                LivesManager.Instance.OnGameOver -= OnGameOver;
            }
        }

        #endregion

        #region Lives Display

        private void UpdateLivesDisplay(int currentLives)
        {
            if (_heartImages == null || _heartImages.Length == 0)
            {
                Debug.LogWarning("Heart images not initialized!");
                return;
            }

            for (int i = 0; i < _heartImages.Length; i++)
            {
                if (_heartImages[i] != null)
                {
                    // Show full heart if player has this many lives, otherwise show empty
                    _heartImages[i].sprite = (i < currentLives) ? fullHeartSprite : emptyHeartSprite;
                    _heartImages[i].enabled = true;
                }
            }
        }

        private void OnPlayerRespawn()
        {
            // Optional: Add respawn animation/effect to hearts
            Debug.Log("Player respawned - HUD updated");
        }

        private void OnGameOver()
        {
            // Optional: Add game over animation to hearts (fade out, shake, etc.)
            Debug.Log("Game Over - All lives lost");
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Manually refresh the lives display (useful for debugging)
        /// </summary>
        public void RefreshDisplay()
        {
            if (LivesManager.Instance != null)
            {
                UpdateLivesDisplay(LivesManager.Instance.CurrentLives);
            }
        }

        #endregion
    }
}
