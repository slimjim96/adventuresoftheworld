using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
using AdventuresOfTheWorld.Managers;

/// <summary>
/// Manages the in-game HUD (Heads-Up Display).
/// Displays lives, coins, level number, and other gameplay info.
/// Attach to a UI GameObject in each level scene.
/// Uses Unity's new Input System for pause input.
/// </summary>
public class HUDManager : MonoBehaviour
{
    [Header("UI Text References")]
    [Tooltip("Text displaying current lives (e.g., 'Lives: 3')")]
    public TextMeshProUGUI livesText;

    [Tooltip("Text displaying total coins (e.g., 'Coins: 42')")]
    public TextMeshProUGUI coinsText;

    [Tooltip("Text displaying current level (e.g., 'Level 1')")]
    public TextMeshProUGUI levelText;

    [Header("UI Image References (Optional)")]
    [Tooltip("Array of heart/life icons to show visually")]
    public Image[] lifeIcons;

    [Tooltip("Sprite for active life icon")]
    public Sprite lifeActiveSprite;

    [Tooltip("Sprite for lost life icon")]
    public Sprite lifeInactiveSprite;

    [Header("Pause Menu (Optional)")]
    [Tooltip("Reference to pause menu GameObject")]
    public GameObject pauseMenuPanel;

    [Tooltip("Button to toggle pause")]
    public Button pauseButton;

    private bool isPaused = false;

    void Start()
    {
        // Setup pause button
        if (pauseButton != null)
        {
            pauseButton.onClick.AddListener(TogglePause);
        }

        // Hide pause menu initially
        if (pauseMenuPanel != null)
        {
            pauseMenuPanel.SetActive(false);
        }

        // Initialize HUD
        UpdateHUD();
    }

    void Update()
    {
        // Update HUD every frame (could optimize to only update when values change)
        UpdateHUD();

        // Pause input via InputManager (new Input System)
        if (InputManager.Instance != null && InputManager.Instance.GetPauseDown())
        {
            TogglePause();
        }
        // Fallback: Direct keyboard check using new Input System
        else if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            TogglePause();
        }
    }

    /// <summary>
    /// Update all HUD elements
    /// </summary>
    void UpdateHUD()
    {
        if (GameManager.Instance == null) return;

        // Update lives text
        if (livesText != null)
        {
            livesText.text = $"Lives: {GameManager.Instance.currentLives}";
        }

        // Update life icons
        UpdateLifeIcons();

        // Update coins text
        if (coinsText != null)
        {
            coinsText.text = $"Coins: {GameManager.Instance.totalCoins}";
        }

        // Update level text
        if (levelText != null)
        {
            levelText.text = $"Level {GameManager.Instance.currentLevel}";
        }
    }

    /// <summary>
    /// Update visual life icons (hearts)
    /// </summary>
    void UpdateLifeIcons()
    {
        if (lifeIcons == null || lifeIcons.Length == 0) return;
        if (GameManager.Instance == null) return;

        int currentLives = GameManager.Instance.currentLives;

        for (int i = 0; i < lifeIcons.Length; i++)
        {
            if (lifeIcons[i] == null) continue;

            // Show active sprite if life is available, inactive sprite if lost
            if (i < currentLives)
            {
                lifeIcons[i].sprite = lifeActiveSprite;
                lifeIcons[i].enabled = true;
            }
            else
            {
                lifeIcons[i].sprite = lifeInactiveSprite;
                lifeIcons[i].enabled = true;
            }
        }
    }

    /// <summary>
    /// Toggle pause state
    /// </summary>
    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    /// <summary>
    /// Pause the game
    /// </summary>
    void Pause()
    {
        Time.timeScale = 0f; // Freeze game time
        if (pauseMenuPanel != null)
        {
            pauseMenuPanel.SetActive(true);
        }
        Debug.Log("Game paused");
    }

    /// <summary>
    /// Resume the game
    /// </summary>
    public void Resume()
    {
        Time.timeScale = 1f; // Resume game time
        isPaused = false;
        if (pauseMenuPanel != null)
        {
            pauseMenuPanel.SetActive(false);
        }
        Debug.Log("Game resumed");
    }

    /// <summary>
    /// Restart current level (called from pause menu)
    /// </summary>
    public void RestartLevel()
    {
        Resume(); // Unpause first
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }

    /// <summary>
    /// Return to level select (called from pause menu)
    /// </summary>
    public void ReturnToLevelSelect()
    {
        Resume(); // Unpause first
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelSelectScene");
    }
}
