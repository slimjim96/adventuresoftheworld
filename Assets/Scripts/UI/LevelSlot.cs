using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// UI slot for level selection screen.
/// Shows level number, locked/unlocked status, and handles level loading.
/// Attach to each level slot prefab in LevelSelectScene.
/// </summary>
public class LevelSlot : MonoBehaviour
{
    [Header("UI References")]
    [Tooltip("Button component on this slot")]
    public Button slotButton;

    [Tooltip("Text displaying level number")]
    public TextMeshProUGUI levelNumberText;

    [Tooltip("Lock icon image (hide if unlocked)")]
    public GameObject lockIcon;

    [Tooltip("Background image (can tint based on world theme)")]
    public Image backgroundImage;

    [Header("Level Settings")]
    [Tooltip("Level number (1-12)")]
    public int levelNumber;

    [Tooltip("Scene name to load (e.g., 'Level01_Forest')")]
    public string levelSceneName;

    [Header("Theme Colors (Optional)")]
    [Tooltip("Background tint color for this level's theme")]
    public Color themeColor = Color.white;

    void Start()
    {
        // Setup button click listener
        if (slotButton != null)
        {
            slotButton.onClick.AddListener(OnLevelClicked);
        }

        // Initialize slot appearance
        UpdateSlotUI();
    }

    /// <summary>
    /// Update slot appearance based on unlock status
    /// </summary>
    public void UpdateSlotUI()
    {
        // Set level number text
        if (levelNumberText != null)
        {
            levelNumberText.text = levelNumber.ToString();
        }

        // Apply theme color
        if (backgroundImage != null)
        {
            backgroundImage.color = themeColor;
        }

        // Check if level is unlocked
        bool isUnlocked = IsLevelUnlocked();

        // Show/hide lock icon
        if (lockIcon != null)
        {
            lockIcon.SetActive(!isUnlocked);
        }

        // Enable/disable button
        if (slotButton != null)
        {
            slotButton.interactable = isUnlocked;
        }

        // Dim background if locked
        if (backgroundImage != null && !isUnlocked)
        {
            Color dimColor = themeColor * 0.5f;
            dimColor.a = themeColor.a;
            backgroundImage.color = dimColor;
        }
    }

    /// <summary>
    /// Check if this level is unlocked
    /// </summary>
    bool IsLevelUnlocked()
    {
        if (GameManager.Instance == null) return false;
        return levelNumber <= GameManager.Instance.highestUnlockedLevel;
    }

    /// <summary>
    /// Handle level slot click - load this level
    /// </summary>
    void OnLevelClicked()
    {
        if (!IsLevelUnlocked())
        {
            Debug.Log("Level is locked!");
            return;
        }

        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager not found!");
            return;
        }

        // Check if character is selected
        if (GameManager.Instance.selectedCharacter == null)
        {
            Debug.LogWarning("No character selected! Returning to character select.");
            UnityEngine.SceneManagement.SceneManager.LoadScene("CharacterSelectScene");
            return;
        }

        // Reset lives before starting level
        GameManager.Instance.ResetLives();

        // Load the level
        Debug.Log($"Loading Level {levelNumber}: {levelSceneName}");
        GameManager.Instance.LoadLevel(levelNumber);
    }
}
