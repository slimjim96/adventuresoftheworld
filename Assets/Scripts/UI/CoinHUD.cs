using UnityEngine;
using UnityEngine.UI;
using TMPro;
using AdventuresOfTheWorld.Managers;

namespace AdventuresOfTheWorld.UI
{
    /// <summary>
    /// Displays coin count in the HUD.
    /// Updates automatically when coins are collected via CoinManager events.
    /// </summary>
    public class CoinHUD : MonoBehaviour
    {
        #region Serialized Fields

        [Header("UI References")]
        [SerializeField] private TextMeshProUGUI coinText;
        [SerializeField] private Image coinIcon;

        [Header("Display Settings")]
        [SerializeField] private string coinPrefix = "";
        [SerializeField] private bool showSessionCoins = true;
        [SerializeField] private bool animateOnCollect = true;
        [SerializeField] private float animationScale = 1.2f;
        [SerializeField] private float animationDuration = 0.2f;

        #endregion

        #region Private Fields

        private int _displayedCoins = 0;
        private Vector3 _originalScale;
        private float _animationTimer = 0f;
        private bool _isAnimating = false;

        #endregion

        #region Unity Lifecycle

        private void Start()
        {
            if (coinIcon != null)
            {
                _originalScale = coinIcon.transform.localScale;
            }

            SubscribeToEvents();
            UpdateCoinDisplay(0);
        }

        private void OnDestroy()
        {
            UnsubscribeFromEvents();
        }

        private void Update()
        {
            if (_isAnimating)
            {
                AnimateCoinIcon();
            }
        }

        #endregion

        #region Event Handling

        private void SubscribeToEvents()
        {
            if (CoinManager.Instance != null)
            {
                CoinManager.Instance.OnCoinsChanged.AddListener(OnCoinsChanged);
            }
        }

        private void UnsubscribeFromEvents()
        {
            if (CoinManager.Instance != null)
            {
                CoinManager.Instance.OnCoinsChanged.RemoveListener(OnCoinsChanged);
            }
        }

        private void OnCoinsChanged(int sessionCoins)
        {
            if (showSessionCoins)
            {
                UpdateCoinDisplay(sessionCoins);

                if (animateOnCollect)
                {
                    StartCoinAnimation();
                }
            }
        }

        private void OnTotalCoinsChanged(int totalCoins)
        {
            if (!showSessionCoins)
            {
                UpdateCoinDisplay(totalCoins);
            }
        }

        #endregion

        #region Coin Display

        private void UpdateCoinDisplay(int coins)
        {
            _displayedCoins = coins;

            if (coinText != null)
            {
                coinText.text = $"{coinPrefix}{coins}";
            }
            else
            {
                Debug.LogWarning("Coin text reference is not assigned in CoinHUD!");
            }
        }

        #endregion

        #region Animation

        private void StartCoinAnimation()
        {
            if (coinIcon == null) return;

            _isAnimating = true;
            _animationTimer = 0f;
        }

        private void AnimateCoinIcon()
        {
            _animationTimer += Time.deltaTime;

            float progress = _animationTimer / animationDuration;

            if (progress < 0.5f)
            {
                // Scale up
                float scale = Mathf.Lerp(1f, animationScale, progress * 2f);
                coinIcon.transform.localScale = _originalScale * scale;
            }
            else if (progress < 1f)
            {
                // Scale back down
                float scale = Mathf.Lerp(animationScale, 1f, (progress - 0.5f) * 2f);
                coinIcon.transform.localScale = _originalScale * scale;
            }
            else
            {
                // Animation complete
                coinIcon.transform.localScale = _originalScale;
                _isAnimating = false;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Manually refresh the coin display (useful for debugging)
        /// </summary>
        public void RefreshDisplay()
        {
            if (CoinManager.Instance != null)
            {
                int coins = showSessionCoins ?
                    CoinManager.Instance.SessionCoins :
                    CoinManager.Instance.TotalCoins;
                UpdateCoinDisplay(coins);
            }
        }

        /// <summary>
        /// Toggle between showing session coins vs total coins
        /// </summary>
        public void ToggleDisplayMode()
        {
            showSessionCoins = !showSessionCoins;
            RefreshDisplay();
        }

        #endregion
    }
}
