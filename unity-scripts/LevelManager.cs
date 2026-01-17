using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages per-level logic such as level completion, goal detection, and scene transitions.
/// Attach to a manager GameObject in each level scene.
/// </summary>
public class LevelManager : MonoBehaviour
{
    [Header("Level Settings")]
    [Tooltip("This level's number (1-12)")]
    public int levelNumber;

    [Tooltip("Distance cart must travel to complete level (if using distance-based)")]
    public float levelCompletionDistance = 100f;

    [Header("Goal Detection (Optional)")]
    [Tooltip("Reference to level goal/finish line GameObject")]
    public GameObject goalObject;

    [Header("Scene Settings")]
    [Tooltip("Scene to load after level completion")]
    public string levelSelectSceneName = "LevelSelectScene";

    private bool levelCompleted = false;
    private Transform cartTransform;

    void Start()
    {
        // Find the cart in the scene
        GameObject cart = GameObject.FindGameObjectWithTag("Player");
        if (cart != null)
        {
            cartTransform = cart.transform;
        }
        else
        {
            Debug.LogWarning("Cart not found! Make sure cart is tagged as 'Player'");
        }

        // Ensure GameManager exists
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager not found! Make sure GameManager exists in scene.");
        }
    }

    void Update()
    {
        // Check if level completed by distance
        if (!levelCompleted && cartTransform != null)
        {
            if (cartTransform.position.x >= levelCompletionDistance)
            {
                CompleteLevel();
            }
        }
    }

    /// <summary>
    /// Called when level goal is reached (can be triggered by goal trigger)
    /// </summary>
    public void OnGoalReached()
    {
        if (!levelCompleted)
        {
            CompleteLevel();
        }
    }

    /// <summary>
    /// Complete the level
    /// </summary>
    void CompleteLevel()
    {
        if (levelCompleted) return;

        levelCompleted = true;
        Debug.Log($"Level {levelNumber} completed!");

        // Unlock next level
        if (GameManager.Instance != null)
        {
            GameManager.Instance.UnlockNextLevel();
        }

        // Wait a moment, then return to level select
        Invoke(nameof(ReturnToLevelSelect), 2f);
    }

    /// <summary>
    /// Return to level select scene
    /// </summary>
    void ReturnToLevelSelect()
    {
        SceneManager.LoadScene(levelSelectSceneName);
    }

    /// <summary>
    /// Restart this level (called when player dies or from pause menu)
    /// </summary>
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
