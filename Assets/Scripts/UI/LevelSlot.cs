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
        Debug.Log($"[LevelSlot] Level {levelNumber} Start() - Scene: {levelSceneName}");

        // Setup button click listener
        if (slotButton != null)
        {
            Debug.Log($"[LevelSlot] Level {levelNumber} button listener added successfully");
            slotButton.onClick.AddListener(OnLevelClicked);
        }
        else
        {
            Debug.LogError($"[LevelSlot] Level {levelNumber} ERROR: slotButton is NULL! Assign Button component in Inspector!");
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
    /// Handle level slot click - load this level.
    /// Public so it can be assigned to Button.onClick in the Unity Inspector.
    /// </summary>
    public void OnLevelClicked()
    {
        Debug.Log($"[LevelSlot] Level {levelNumber} button CLICKED!");

        if (!IsLevelUnlocked())
        {
            Debug.LogWarning($"[LevelSlot] Level {levelNumber} is LOCKED! (highestUnlocked={GameManager.Instance?.highestUnlockedLevel})");
            return;
        }

        if (GameManager.Instance == null)
        {
            Debug.LogError("[LevelSlot] GameManager not found!");
            return;
        }

        // Check if character is selected
        if (GameManager.Instance.selectedCharacter == null)
        {
            Debug.LogWarning("[LevelSlot] No character selected! Returning to character select.");
            UnityEngine.SceneManagement.SceneManager.LoadScene("CharacterSelectScene");
            return;
        }

        // Reset lives before starting level
        GameManager.Instance.ResetLives();

        // Update current level before loading
        GameManager.Instance.currentLevel = levelNumber;

        // Load the level using the scene name from this slot
        Debug.Log($"[LevelSlot] Loading Level {levelNumber}: {levelSceneName}");
        GameManager.Instance.LoadLevelByName(levelSceneName);
    }
}
