using UnityEngine;

/// <summary>
/// Platform component for forest/level platforms.
/// Uses PlatformEffector2D so cart can only land from above (no side collision).
/// Edit the BoxCollider2D directly in the Inspector.
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlatformEffector2D))]
public class Platform : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private PlatformEffector2D effector;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        effector = GetComponent<PlatformEffector2D>();

        // Configure the collider to use the effector
        boxCollider.usedByEffector = true;

        // Configure effector: only collide from above
        effector.useOneWay = true;
        effector.surfaceArc = 180f; // Top half only

        // Ensure we're on Ground layer
        if (gameObject.layer != 7)
        {
            Debug.LogWarning($"Platform '{name}' is not on Ground layer (7). Cart won't detect it!");
        }
    }

    void OnDrawGizmos()
    {
        // Draw the collision area in green so you can see where the cart will land
        if (boxCollider == null)
            boxCollider = GetComponent<BoxCollider2D>();

        if (boxCollider != null)
        {
            Gizmos.color = new Color(0f, 1f, 0f, 0.3f);
            Vector3 center = transform.position + (Vector3)boxCollider.offset;
            Vector3 size = boxCollider.size;
            Gizmos.DrawCube(center, size);

            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(center, size);
        }
    }
}
