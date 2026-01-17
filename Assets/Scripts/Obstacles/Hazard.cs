using UnityEngine;

/// <summary>
/// Generic obstacle/hazard that damages player on contact.
/// Attach to obstacle prefabs (spikes, rocks, etc.) with Collider2D.
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class Hazard : MonoBehaviour
{
    [Header("Hazard Settings")]
    [Tooltip("Damage dealt to player (usually causes life loss)")]
    public int damage = 1;

    [Tooltip("Is this a trigger (player passes through) or solid collision?")]
    public bool isTrigger = false;

    [Header("Effects (Optional)")]
    [Tooltip("Particle effect to play on impact")]
    public ParticleSystem impactEffect;

    [Tooltip("Destroy hazard after hit?")]
    public bool destroyOnHit = false;

    void Start()
    {
        // Configure collider
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
        {
            col.isTrigger = isTrigger;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isTrigger) return; // Handle with OnTriggerEnter2D instead

        // Check if player hit this hazard
        if (collision.gameObject.CompareTag("Player"))
        {
            DamagePlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isTrigger) return; // Handle with OnCollisionEnter2D instead

        // Check if player hit this hazard
        if (other.CompareTag("Player"))
        {
            DamagePlayer();
        }
    }

    /// <summary>
    /// Deal damage to player
    /// </summary>
    void DamagePlayer()
    {
        Debug.Log($"Player hit {gameObject.name}!");

        // Play impact effect
        if (impactEffect != null)
        {
            impactEffect.Play();
        }

        // Play sound effect (if AudioManager exists)
        // AudioManager.Instance?.PlaySFX("HitObstacle");

        // Deal damage via GameManager
        if (GameManager.Instance != null)
        {
            GameManager.Instance.LoseLife();
        }

        // Destroy hazard if configured
        if (destroyOnHit)
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
