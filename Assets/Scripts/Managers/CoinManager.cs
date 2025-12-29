using UnityEngine;
using UnityEngine.Events;

namespace AdventuresOfTheWorld.Managers
{
    /// <summary>
    /// Manages coin collection and total coin currency.
    /// Tracks both session coins and persistent total coins.
    /// </summary>
    public class CoinManager : MonoBehaviour
    {
        #region Singleton

        private static CoinManager _instance;
        public static CoinManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<CoinManager>();
                }
                return _instance;
            }
        }

        #endregion

        #region Serialized Fields

        [Header("Coin Settings")]
        [SerializeField] private int coinValue = 10;
        [Tooltip("Points awarded per coin")]

        #endregion

        #region Events

        public UnityEvent<int> OnCoinsChanged;
        public UnityEvent<int> OnCoinCollected;

        #endregion

        #region Private Fields

        private int _sessionCoins = 0;  // Coins collected this level
        private int _totalCoins = 0;    // Total coins (persistent)

        #endregion

        #region Properties

        public int SessionCoins => _sessionCoins;
        public int TotalCoins => _totalCoins;
        public int CoinValue => coinValue;

        #endregion

        #region Unity Lifecycle

        private void Awake()
        {
            _instance = this;
            LoadTotalCoins();
        }

        private void Start()
        {
            // Notify UI of initial coin count
            OnCoinsChanged?.Invoke(_sessionCoins);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Called when player collects a coin
        /// </summary>
        public void CollectCoin()
        {
            CollectCoins(1);
        }

        /// <summary>
        /// Collects multiple coins at once
        /// </summary>
        public void CollectCoins(int amount)
        {
            _sessionCoins += amount;
            OnCoinsChanged?.Invoke(_sessionCoins);
            OnCoinCollected?.Invoke(amount);

            // Optional: Play coin collection sound
            // AudioManager.Instance?.PlaySFX("CoinCollect");

            Debug.Log($"Coins collected: {amount} | Session total: {_sessionCoins}");
        }

        /// <summary>
        /// Adds coins to session without collection event (for bonuses)
        /// </summary>
        public void AddCoins(int amount)
        {
            _sessionCoins += amount;
            OnCoinsChanged?.Invoke(_sessionCoins);
        }

        /// <summary>
        /// Saves session coins to total at level end
        /// </summary>
        public void SaveSessionCoins()
        {
            _totalCoins += _sessionCoins;
            SaveTotalCoins();

            Debug.Log($"Session coins saved! Total coins: {_totalCoins}");
        }

        /// <summary>
        /// Spends coins from total (for shop purchases)
        /// </summary>
        public bool SpendCoins(int amount)
        {
            if (_totalCoins >= amount)
            {
                _totalCoins -= amount;
                SaveTotalCoins();

                Debug.Log($"Spent {amount} coins. Remaining: {_totalCoins}");
                return true;
            }
            else
            {
                Debug.LogWarning($"Not enough coins! Need {amount}, have {_totalCoins}");
                return false;
            }
        }

        /// <summary>
        /// Resets session coins (for new level)
        /// </summary>
        public void ResetSessionCoins()
        {
            _sessionCoins = 0;
            OnCoinsChanged?.Invoke(_sessionCoins);
        }

        /// <summary>
        /// Adds coins directly to total (for IAP or rewards)
        /// </summary>
        public void AddTotalCoins(int amount)
        {
            _totalCoins += amount;
            SaveTotalCoins();

            Debug.Log($"Added {amount} to total coins. Total: {_totalCoins}");
        }

        #endregion

        #region Save/Load

        private void SaveTotalCoins()
        {
            PlayerPrefs.SetInt("TotalCoins", _totalCoins);
            PlayerPrefs.Save();
        }

        private void LoadTotalCoins()
        {
            _totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
            Debug.Log($"Loaded total coins: {_totalCoins}");
        }

        #endregion
    }
}
