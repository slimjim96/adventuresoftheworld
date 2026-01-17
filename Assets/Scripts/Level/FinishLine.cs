using UnityEngine;
using AdventuresOfTheWorld.Core;
using AdventuresOfTheWorld.Managers;

namespace AdventuresOfTheWorld.Level
{
    /// <summary>
    /// Detects when player reaches the finish line and triggers level completion.
    /// Stops the cart and notifies GameManager of victory.
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class FinishLine : MonoBehaviour
    {
        #region Serialized Fields

        [Header("Finish Settings")]
        [SerializeField] private bool stopCartOnFinish = true;
        [SerializeField] private bool playVictorySound = true;
        [SerializeField] private string victoryMessage = "Level Complete!";

        [Header("Visual Feedback")]
        [SerializeField] private bool changeColorOnFinish = true;
        [SerializeField] private Color finishColor = Color.green;

        #endregion

        #region Private Fields

        private bool _finished = false;
        private SpriteRenderer _spriteRenderer;

        #endregion

        #region Unity Lifecycle

        private void Awake()
        {
            // Ensure trigger is enabled
            Collider2D collider = GetComponent<Collider2D>();
            if (collider != null)
            {
                collider.isTrigger = true;
            }
            else
            {
                Debug.LogError("FinishLine requires a Collider2D component!");
            }

            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        #endregion

        #region Collision Detection

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!_finished && collision.CompareTag("Player"))
            {
                TriggerLevelComplete(collision.gameObject);
            }
        }

        #endregion

        #region Level Completion

        private void TriggerLevelComplete(GameObject player)
        {
            _finished = true;

            Debug.Log(victoryMessage);

            // Stop the cart
            if (stopCartOnFinish)
            {
                CartController cart = player.GetComponent<CartController>();
                if (cart != null)
                {
                    //TODO: Stop cart
                    //cart.StopMovement();
                }
                else
                {
                    Debug.LogWarning("CartController not found on player!");
                }
            }

            // Play victory sound
            if (playVictorySound && AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySFX("Victory");
            }

            // Visual feedback
            if (changeColorOnFinish && _spriteRenderer != null)
            {
                _spriteRenderer.color = finishColor;
            }

             // Notify level manager
            LevelManager levelManager = FindObjectOfType<LevelManager>();
            if (levelManager != null)
            {
                levelManager.OnGoalReached();
            }
            else
            {
                Debug.LogWarning("LevelManager not found!");
            }

            // TODO: Show victory UI, display final score, unlock next level, etc.
        }

        #endregion

        #region Gizmos

        private void OnDrawGizmos()
        {
            // Draw green line to visualize finish line in editor
            BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
            if (boxCollider != null)
            {
                Gizmos.color = new Color(0f, 1f, 0f, 0.5f); // Semi-transparent green
                Gizmos.DrawWireCube(transform.position, new Vector3(boxCollider.size.x, boxCollider.size.y, 0));
            }
            else
            {
                // Fallback if no BoxCollider2D
                Gizmos.color = Color.green;
                Gizmos.DrawLine(
                    transform.position + Vector3.up * 2f,
                    transform.position + Vector3.down * 2f
                );
            }
        }

        private void OnDrawGizmosSelected()
        {
            // Draw more prominent visualization when selected
            Gizmos.color = Color.green;
            Gizmos.DrawLine(
                transform.position + Vector3.up * 3f,
                transform.position + Vector3.down * 3f
            );

            // Draw label
            #if UNITY_EDITOR
            UnityEditor.Handles.Label(transform.position + Vector3.up * 3.5f, "FINISH LINE");
            #endif
        }

        #endregion
    }
}
