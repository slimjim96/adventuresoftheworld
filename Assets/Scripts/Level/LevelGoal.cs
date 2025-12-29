using UnityEngine;
using UnityEngine.Events;
using AdventuresOfTheWorld.Core;
using AdventuresOfTheWorld.Managers;

namespace AdventuresOfTheWorld.Level
{
    /// <summary>
    /// Finish line trigger that completes the level when the player reaches it.
    /// Triggers level completion through GameManager.
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class LevelGoal : MonoBehaviour
    {
        #region Serialized Fields

        [Header("Goal Settings")]
        [SerializeField] private string nextLevelName = "";
        [Tooltip("Name of the next level scene (leave empty for no auto-load)")]

        [SerializeField] private int nextLevelIndex = -1;
        [Tooltip("Build index of next level (-1 to use name instead)")]

        [SerializeField] private float completionDelay = 2f;
        [Tooltip("Delay before showing completion screen or loading next level")]

        [Header("Events")]
        public UnityEvent OnLevelComplete;
        [Tooltip("Triggered when player reaches the goal")]

        #endregion

        #region Private Fields

        private bool _isTriggered = false;

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
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Check if player reached the goal
            if (!_isTriggered && collision.CompareTag("Player"))
            {
                TriggerLevelComplete(collision.gameObject);
            }
        }

        #endregion

        #region Private Methods

        private void TriggerLevelComplete(GameObject player)
        {
            _isTriggered = true;

            Debug.Log("Level Complete!");

            // Stop the cart
            CartController cart = player.GetComponent<CartController>();
            if (cart != null)
            {
                cart.StopMovement();
            }

            // Play victory sound
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySFX("LevelComplete");
            }

            // Invoke custom event
            OnLevelComplete?.Invoke();

            // Notify GameManager
            if (GameManager.Instance != null)
            {
                GameManager.Instance.LevelComplete();
            }

            // Start completion sequence
            StartCoroutine(CompletionSequence());
        }

        private System.Collections.IEnumerator CompletionSequence()
        {
            // Wait for celebration/animation
            yield return new WaitForSeconds(completionDelay);

            // Load next level if specified
            if (nextLevelIndex >= 0)
            {
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.StartLevel(nextLevelIndex);
                }
            }
            else if (!string.IsNullOrEmpty(nextLevelName))
            {
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.StartLevel(nextLevelName);
                }
            }
            // If no next level specified, stay on completion screen
        }

        #endregion

        #region Debug Visualization

        private void OnDrawGizmos()
        {
            // Draw goal as a green vertical line in the editor
            Gizmos.color = Color.green;

            BoxCollider2D box = GetComponent<BoxCollider2D>();
            if (box != null)
            {
                Vector3 size = new Vector3(box.size.x, box.size.y, 0);
                Gizmos.DrawWireCube(transform.position + (Vector3)box.offset, size);
            }
            else
            {
                // Default visualization
                Gizmos.DrawLine(
                    transform.position + Vector3.down * 3,
                    transform.position + Vector3.up * 3
                );
            }

            // Draw "FINISH" label
            #if UNITY_EDITOR
            UnityEditor.Handles.Label(transform.position + Vector3.up * 3.5f, "FINISH");
            #endif
        }

        #endregion
    }
}
