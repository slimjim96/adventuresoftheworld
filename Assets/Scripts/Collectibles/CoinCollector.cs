using UnityEngine;

/// <summary>
/// Collectible coin that adds to player's total when collected.
/// Attach to coin prefab with Collider2D (Is Trigger: checked).
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class CoinCollector : MonoBehaviour
{
    [Header("Coin Settings")]
    [Tooltip("Value of this coin (usually 1)")]
    public int coinValue = 1;

    [Tooltip("Rotate coin continuously")]
    public bool rotateAnimation = true;

    [Tooltip("Rotation speed (degrees per second)")]
    public float rotationSpeed = 180f;

    [Header("Effects (Optional)")]
    [Tooltip("Particle effect to play on collection")]
    public ParticleSystem collectEffect;

    [Tooltip("Animation to play on collection")]
    public Animator coinAnimator;

    [Tooltip("Animation trigger name")]
    public string collectAnimationTrigger = "Collect";

    [Tooltip("Delay before destroying coin (for animation)")]
    public float destroyDelay = 0f;

    private bool collected = false;

    void Start()
    {
        // Ensure collider is trigger
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
        {
            col.isTrigger = true;
        }
    }

    void Update()
    {
        // Rotate coin animation
        if (rotateAnimation && !collected)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if player collected coin
        if (other.CompareTag("Player") && !collected)
        {
            CollectCoin();
        }
    }

    /// <summary>
    /// Collect this coin
    /// </summary>
    void CollectCoin()
    {
        collected = true;

        // Add coins to GameManager
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddCoins(coinValue);
        }

        // Play effects
        if (collectEffect != null)
        {
            collectEffect.Play();
        }

        if (coinAnimator != null)
        {
            coinAnimator.SetTrigger(collectAnimationTrigger);
        }

        // Play sound effect (if AudioManager exists)
        // AudioManager.Instance?.PlaySFX("CoinCollect");

        // Hide sprite immediately
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }

        // Disable collider
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
        {
            col.enabled = false;
        }

        // Destroy coin after delay (allows animation/particles to finish)
        Destroy(gameObject, destroyDelay);
    }
}
