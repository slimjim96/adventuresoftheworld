using UnityEngine;

/// <summary>
/// Triggers level completion when cart reaches the goal.
/// Attach to a GameObject with Collider2D (Is Trigger: checked) at level end.
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class GoalTrigger : MonoBehaviour
{
    [Header("Visual Feedback (Optional)")]
    [Tooltip("Particle effect to play when goal reached")]
    public ParticleSystem goalEffect;

    [Tooltip("Animation to play when goal reached")]
    public Animator goalAnimator;

    [Tooltip("Animation trigger name")]
    public string animationTrigger = "GoalReached";

    private bool goalReached = false;

    void Start()
    {
        // Ensure collider is trigger
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
        {
            col.isTrigger = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if cart entered goal
        if (other.CompareTag("Player") && !goalReached)
        {
            goalReached = true;
            OnGoalReached();
        }
    }

    /// <summary>
    /// Called when goal is reached
    /// </summary>
    void OnGoalReached()
    {
        Debug.Log("Goal reached!");

        // Play effects
        if (goalEffect != null)
        {
            goalEffect.Play();
        }

        if (goalAnimator != null)
        {
            goalAnimator.SetTrigger(animationTrigger);
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
    }

    // Draw gizmo for goal position in editor
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 1.5f);
    }
}
