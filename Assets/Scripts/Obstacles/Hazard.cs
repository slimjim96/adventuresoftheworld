using UnityEngine;
using AdventuresOfTheWorld.Managers;

namespace AdventuresOfTheWorld.Obstacles
{
    /// <summary>
    /// Deadly hazard (spikes, pits, enemies, etc.) that kills player on contact.
    /// Used in advanced levels for additional challenge.
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class Hazard : MonoBehaviour
    {
        #region Serialized Fields

        [Header("Hazard Settings")]
        [SerializeField] private bool killOnContact = true;
        [Tooltip("Should this hazard kill the player instantly?")]

        [SerializeField] private bool playDeathAnimation = false;
        [Tooltip("Play a death animation before respawning")]

        #endregion

        #region Unity Lifecycle

        private void Awake()
        {
            // Ensure the collider is a trigger
            Collider2D col = GetComponent<Collider2D>();
            if (!col.isTrigger)
            {
                Debug.LogWarning($"Hazard {gameObject.name} collider should be a trigger! Setting to trigger.");
                col.isTrigger = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Check if player touched this hazard
            if (collision.CompareTag("Player") && killOnContact)
            {
                Debug.Log($"Player hit hazard: {gameObject.name}");

                // Optional: Play death animation/sound here
                if (playDeathAnimation)
                {
                    // TODO: Trigger death animation
                    // AudioManager.Instance?.PlaySFX("Death");
                }

                // Tell LivesManager the player died
                if (LivesManager.Instance != null)
                {
                    LivesManager.Instance.LoseLife();
                }
                else
                {
                    Debug.LogWarning("LivesManager not found! Cannot handle death.");
                }
            }
        }

        #endregion

        #region Debug Visualization

        private void OnDrawGizmos()
        {
            // Draw hazard in red in the editor
            Collider2D col = GetComponent<Collider2D>();
            if (col != null)
            {
                Gizmos.color = new Color(1f, 0f, 0f, 0.5f); // Transparent red
                Gizmos.DrawCube(transform.position, transform.localScale);
            }
        }

        #endregion
    }
}
