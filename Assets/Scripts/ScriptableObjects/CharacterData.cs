using UnityEngine;

/// <summary>
/// ScriptableObject that stores data for each playable character.
/// Create assets via: Right-click → Create → Game → Character Data
/// </summary>
[CreateAssetMenu(fileName = "CharacterData", menuName = "Game/Character Data")]
public class CharacterData : ScriptableObject
{
    [Header("Character Info")]
    public string characterName;           // Display name (e.g., "Cat", "Dog")
    public Sprite characterSprite;         // Riding pose sprite (sits in cart)
    public Sprite iconSprite;              // Selection screen icon (portrait)

    [Header("Unlock Requirements")]
    public int unlockCost;                 // Cost in coins to unlock
    public bool isUnlocked = false;        // Whether player has unlocked this character

    [Header("Character Stats (Optional)")]
    [Tooltip("Jump boost multiplier (1.0 = normal, 1.2 = 20% higher jumps)")]
    public float jumpBoostMultiplier = 1f;

    [Tooltip("Speed multiplier (1.0 = normal, 1.1 = 10% faster)")]
    public float speedMultiplier = 1f;

    [Header("Character Description")]
    [TextArea(3, 5)]
    public string description;             // Personality description

    /// <summary>
    /// Unlock this character
    /// </summary>
    public void Unlock()
    {
        isUnlocked = true;
        Debug.Log($"{characterName} has been unlocked!");
    }
}
