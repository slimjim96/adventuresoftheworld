using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// UI slot for character selection screen.
/// Shows character icon, name, unlock status, and handles click events.
/// Attach to each character slot prefab in CharacterSelectScene.
/// </summary>
public class CharacterSlot : MonoBehaviour
{
    [Header("UI References")]
    [Tooltip("Button component on this slot")]
    public Button slotButton;

    [Tooltip("Image component showing character icon")]
    public Image characterIcon;

    [Tooltip("Text displaying character name")]
    public TextMeshProUGUI characterNameText;

    [Tooltip("Text showing unlock cost (hide if unlocked)")]
    public TextMeshProUGUI unlockCostText;

    [Tooltip("Lock icon image (hide if unlocked)")]
    public GameObject lockIcon;

    [Tooltip("Visual indicator when selected")]
    public GameObject selectionHighlight;

    [Header("Character Data")]
    [Tooltip("The character this slot represents")]
    public CharacterData character;

    private CharacterSelectManager selectManager;

    void Start()
    {
        // Find the character select manager
        selectManager = FindObjectOfType<CharacterSelectManager>();

        // Setup button click listener
        if (slotButton != null)
        {
            slotButton.onClick.AddListener(OnSlotClicked);
        }

        // Initialize slot appearance
        UpdateSlotUI();
    }

    /// <summary>
    /// Update slot appearance based on character unlock status
    /// </summary>
    public void UpdateSlotUI()
    {
        if (character == null) return;

        // Set character name
        if (characterNameText != null)
        {
            characterNameText.text = character.characterName;
        }

        // Set character icon
        if (characterIcon != null && character.iconSprite != null)
        {
            characterIcon.sprite = character.iconSprite;
        }

        // Show/hide lock and cost based on unlock status
        if (character.isUnlocked)
        {
            // Character is unlocked
            if (lockIcon != null) lockIcon.SetActive(false);
            if (unlockCostText != null) unlockCostText.gameObject.SetActive(false);
            if (slotButton != null) slotButton.interactable = true;
        }
        else
        {
            // Character is locked
            if (lockIcon != null) lockIcon.SetActive(true);
            if (unlockCostText != null)
            {
                unlockCostText.gameObject.SetActive(true);
                unlockCostText.text = $"{character.unlockCost} coins";
            }

            // Make button interactable if player has enough coins
            if (slotButton != null && GameManager.Instance != null)
            {
                slotButton.interactable = GameManager.Instance.totalCoins >= character.unlockCost;
            }
        }
    }

    /// <summary>
    /// Handle slot click - select or unlock character.
    /// Public so it can be assigned to Button.onClick in the Unity Inspector.
    /// </summary>
    public void OnSlotClicked()
    {
        if (character == null) return;

        if (character.isUnlocked)
        {
            // Select this character
            SelectCharacter();
        }
        else
        {
            // Try to unlock this character
            TryUnlockCharacter();
        }
    }

    /// <summary>
    /// Select this character
    /// </summary>
    void SelectCharacter()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.SelectCharacter(character);
        }

        // Notify manager to update UI
        if (selectManager != null)
        {
            selectManager.OnCharacterSelected(this);
        }

        Debug.Log($"Selected character: {character.characterName}");
    }

    /// <summary>
    /// Attempt to unlock this character
    /// </summary>
    void TryUnlockCharacter()
    {
        if (GameManager.Instance != null)
        {
            bool unlocked = GameManager.Instance.TryUnlockCharacter(character);

            if (unlocked)
            {
                // Successfully unlocked
                UpdateSlotUI();

                // Auto-select newly unlocked character
                SelectCharacter();

                // Update all slots (coin count changed)
                if (selectManager != null)
                {
                    selectManager.UpdateAllSlots();
                }
            }
            else
            {
                // Not enough coins
                Debug.Log("Not enough coins to unlock this character!");
                // TODO: Show feedback to player (shake animation, sound effect, etc.)
            }
        }
    }

    /// <summary>
    /// Show/hide selection highlight
    /// </summary>
    public void SetSelected(bool selected)
    {
        if (selectionHighlight != null)
        {
            selectionHighlight.SetActive(selected);
        }
    }
}
