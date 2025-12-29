using UnityEngine;
using AdventuresOfTheWorld.Managers;

namespace AdventuresOfTheWorld.Obstacles
{
    /// <summary>
    /// Collectible coin that awards points when touched by player.
    /// Uses trigger collision for smooth collection without physics interaction.
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class Coin : MonoBehaviour
    {
        #region Serialized Fields

        [Header("Coin Settings")]
        [SerializeField] private int coinValue = 1;
        [Tooltip("Number of coins this pickup is worth")]

        [SerializeField] private bool destroyOnCollect = true;
        [Tooltip("Should the coin be destroyed after collection?")]

        [Header("Animation")]
        [SerializeField] private float rotationSpeed = 180f;
        [Tooltip("Degrees per second for idle spin animation")]

        [SerializeField] private float bobAmplitude = 0.1f;
        [Tooltip("How high the coin bobs up and down")]

        [SerializeField] private float bobFrequency = 2f;
        [Tooltip("How fast the coin bobs")]

        [Header("Collection Effect")]
        [SerializeField] private float collectAnimationDuration = 0.3f;
        [Tooltip("Duration of the collection animation")]

        [SerializeField] private float collectScaleMultiplier = 1.5f;
        [Tooltip("Scale multiplier during collection animation")]

        #endregion

        #region Private Fields

        private Vector3 _startPosition;
        private bool _isCollected = false;
        private float _collectTimer = 0f;
        private Vector3 _originalScale;

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

            _startPosition = transform.position;
            _originalScale = transform.localScale;
        }

        private void Update()
        {
            if (_isCollected)
            {
                // Play collection animation
                PlayCollectAnimation();
            }
            else
            {
                // Idle animations
                IdleAnimation();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Check if player touched the coin
            if (!_isCollected && collision.CompareTag("Player"))
            {
                Collect();
            }
        }

        #endregion

        #region Private Methods

        private void Collect()
        {
            _isCollected = true;

            // Add coin(s) to the player's total
            if (CoinManager.Instance != null)
            {
                CoinManager.Instance.CollectCoins(coinValue);
            }
            else
            {
                Debug.LogWarning("CoinManager not found! Coin collected but not counted.");
            }

            // Play collection sound
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySFX("CoinCollect");
            }

            // Disable collider to prevent double collection
            GetComponent<Collider2D>().enabled = false;

            // Start collection animation or destroy immediately
            if (collectAnimationDuration <= 0 && destroyOnCollect)
            {
                Destroy(gameObject);
            }
        }

        private void IdleAnimation()
        {
            // Rotate the coin (spinning effect)
            if (rotationSpeed > 0)
            {
                transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            }

            // Bob up and down
            if (bobAmplitude > 0)
            {
                float newY = _startPosition.y + Mathf.Sin(Time.time * bobFrequency) * bobAmplitude;
                transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            }
        }

        private void PlayCollectAnimation()
        {
            _collectTimer += Time.deltaTime;
            float progress = _collectTimer / collectAnimationDuration;

            if (progress >= 1f)
            {
                if (destroyOnCollect)
                {
                    Destroy(gameObject);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                return;
            }

            // Scale up and fade effect
            float scale = 1f + (collectScaleMultiplier - 1f) * progress;
            transform.localScale = _originalScale * scale;

            // Optional: Add upward movement during collection
            transform.position += Vector3.up * Time.deltaTime * 2f;

            // Optional: Fade out sprite
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            if (sprite != null)
            {
                Color color = sprite.color;
                color.a = 1f - progress;
                sprite.color = color;
            }
        }

        #endregion

        #region Debug Visualization

        private void OnDrawGizmos()
        {
            // Draw coin in yellow in the editor
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, 0.3f);
        }

        #endregion
    }
}
