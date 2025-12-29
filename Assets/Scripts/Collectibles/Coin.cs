using UnityEngine;
using AdventuresOfTheWorld.Managers;

namespace AdventuresOfTheWorld.Collectibles
{
    /// <summary>
    /// Collectible coin that adds points when player touches it.
    /// Automatically communicates with CoinManager to update score.
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class Coin : MonoBehaviour
    {
        #region Serialized Fields

        [Header("Coin Settings")]
        [SerializeField] private int coinValue = 1;
        [SerializeField] private bool playCollectionSound = true;
        [SerializeField] private bool playCollectionEffect = true;

        [Header("Animation (Optional)")]
        [SerializeField] private bool rotateAnimation = true;
        [SerializeField] private float rotationSpeed = 180f;
        [SerializeField] private bool bobAnimation = false;
        [SerializeField] private float bobSpeed = 2f;
        [SerializeField] private float bobHeight = 0.2f;

        #endregion

        #region Private Fields

        private Vector3 _startPosition;
        private bool _collected = false;

        #endregion

        #region Unity Lifecycle

        private void Start()
        {
            _startPosition = transform.position;

            // Ensure trigger is enabled
            Collider2D collider = GetComponent<Collider2D>();
            if (collider != null)
            {
                collider.isTrigger = true;
            }
        }

        private void Update()
        {
            if (_collected) return;

            // Optional rotation animation
            if (rotateAnimation)
            {
                transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            }

            // Optional bobbing animation
            if (bobAnimation)
            {
                float newY = _startPosition.y + Mathf.Sin(Time.time * bobSpeed) * bobHeight;
                transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            }
        }

        #endregion

        #region Collision Detection

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Check if player collected the coin
            if (!_collected && collision.CompareTag("Player"))
            {
                CollectCoin();
            }
        }

        #endregion

        #region Collection Logic

        private void CollectCoin()
        {
            _collected = true;

            // Add coin to CoinManager
            if (CoinManager.Instance != null)
            {
                CoinManager.Instance.AddCoins(coinValue);
                Debug.Log($"Coin collected! Value: {coinValue}");
            }
            else
            {
                Debug.LogWarning("CoinManager instance not found! Coin not counted.");
            }

            // Play sound effect
            if (playCollectionSound && AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySFX("CoinCollect");
            }

            // Play particle effect
            if (playCollectionEffect)
            {
                PlayCollectionEffect();
            }

            // Destroy the coin
            Destroy(gameObject);
        }

        private void PlayCollectionEffect()
        {
            // TODO: Add particle effect prefab instantiation here when available
            // Example:
            // if (collectionEffectPrefab != null)
            // {
            //     Instantiate(collectionEffectPrefab, transform.position, Quaternion.identity);
            // }

            Debug.Log("Coin collection effect would play here");
        }

        #endregion

        #region Gizmos

        private void OnDrawGizmos()
        {
            // Draw a yellow circle to visualize coin in editor
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, 0.3f);
        }

        #endregion
    }
}
