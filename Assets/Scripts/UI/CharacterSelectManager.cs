using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// Manages the Character Selection scene.
/// Controls character slots, displays total coins, and handles scene transitions.
/// Attach to a manager GameObject in CharacterSelectScene.
/// </summary>
public class CharacterSelectManager : MonoBehaviour
{
    [Header("UI References")]
    [Tooltip("Parent container holding all character slot prefabs")]
    public Transform characterSlotsContainer;

    [Tooltip("Button to confirm selection and go to level select")]
    public Button confirmButton;

    [Tooltip("Button to go back to start menu")]
    public Button backButton;

    [Tooltip("Text displaying player's total coins")]
    public TextMeshProUGUI totalCoinsText;

    [Tooltip("Text showing currently selected character name")]
    public TextMeshProUGUI selectedCharacterText;

    [Header("Character Data")]
    [Tooltip("Array of all character data assets (13 animals + cart if selectable)")]
    public CharacterData[] allCharacters;

    [Header("Scene Settings")]
    [Tooltip("Name of level select scene to load after confirmation")]
    public string levelSelectSceneName = "LevelSelectScene";

    [Tooltip("Name of start scene to load if back button pressed")]
    public string startSceneName = "StartScene";

    private CharacterSlot[] characterSlots;
    private CharacterSlot currentlySelectedSlot;

    void Start()
    {
        // Get all character slots from container
        if (characterSlotsContainer != null)
        {
            characterSlots = characterSlotsContainer.GetComponentsInChildren<CharacterSlot>();
        }

        // Setup button listeners
        if (confirmButton != null)
        {
            confirmButton.onClick.AddListener(OnConfirmButtonClicked);
        }

        if (backButton != null)
        {
            backButton.onClick.AddListener(OnBackButtonClicked);
        }

        // Initialize UI
        UpdateCoinsDisplay();
        UpdateAllSlots();
        UpdateSelectedCharacterDisplay();

        // Pre-select character if one was already chosen
        if (GameManager.Instance != null && GameManager.Instance.selectedCharacter != null)
        {
            SelectSlotByCharacter(GameManager.Instance.selectedCharacter);
        }
    }

    /// <summary>
    /// Update coin display text
    /// </summary>
    void UpdateCoinsDisplay()
    {
        if (totalCoinsText != null && GameManager.Instance != null)
        {
            totalCoinsText.text = $"Coins: {GameManager.Instance.totalCoins}";
        }
    }

    /// <summary>
    /// Update all character slots (called when coins change or character unlocked)
    /// </summary>
    public void UpdateAllSlots()
    {
        if (characterSlots == null) return;

        foreach (CharacterSlot slot in characterSlots)
        {
            if (slot != null)
            {
                slot.UpdateSlotUI();
            }
        }

        UpdateCoinsDisplay();
    }

    /// <summary>
    /// Called when a character slot is clicked
    /// </summary>
    public void OnCharacterSelected(CharacterSlot slot)
    {
        // Deselect previous slot
        if (currentlySelectedSlot != null)
        {
            currentlySelectedSlot.SetSelected(false);
        }

        // Select new slot
        currentlySelectedSlot = slot;
        currentlySelectedSlot.SetSelected(true);

        // Update selected character display
        UpdateSelectedCharacterDisplay();

        // Enable confirm button
        if (confirmButton != null)
        {
            confirmButton.interactable = true;
        }
    }

    /// <summary>
    /// Update the selected character name display
    /// </summary>
    void UpdateSelectedCharacterDisplay()
    {
        if (selectedCharacterText != null)
        {
            if (GameManager.Instance != null && GameManager.Instance.selectedCharacter != null)
            {
                selectedCharacterText.text = $"Selected: {GameManager.Instance.selectedCharacter.characterName}";
            }
            else
            {
                selectedCharacterText.text = "Select a character";
            }
        }
    }

    /// <summary>
    /// Find and select slot matching given character
    /// </summary>
    void SelectSlotByCharacter(CharacterData character)
    {
        if (characterSlots == null) return;

        foreach (CharacterSlot slot in characterSlots)
        {
            if (slot != null && slot.character == character)
            {
                OnCharacterSelected(slot);
                break;
            }
        }
    }

    /// <summary>
    /// Confirm button - proceed to level select
    /// </summary>
    void OnConfirmButtonClicked()
    {
        if (GameManager.Instance == null || GameManager.Instance.selectedCharacter == null)
        {
            Debug.LogWarning("No character selected!");
            return;
        }

        Debug.Log($"Proceeding to level select with {GameManager.Instance.selectedCharacter.characterName}");
        SceneManager.LoadScene(levelSelectSceneName);
    }

    /// <summary>
    /// Back button - return to start menu
    /// </summary>
    void OnBackButtonClicked()
    {
        Debug.Log("Returning to start menu");
        SceneManager.LoadScene(startSceneName);
    }
}
