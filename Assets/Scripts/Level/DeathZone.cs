using UnityEngine;
using AdventuresOfTheWorld.Managers;

namespace AdventuresOfTheWorld.Level
{
    /// <summary>
    /// Detects when player falls off the platform into the death zone.
    /// Triggers death/respawn through LivesManager.
    /// </summary>
    public class DeathZone : MonoBehaviour
    {
        #region Unity Lifecycle

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Check if the player fell into the death zone
            if (collision.CompareTag("Player"))
            {
                Debug.Log("Player fell off the platform!");

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
            // Draw the death zone in the editor (red line)
            BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
            if (boxCollider != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireCube(transform.position, new Vector3(boxCollider.size.x, boxCollider.size.y, 0));
            }
        }

        #endregion
    }
}
