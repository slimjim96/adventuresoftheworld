using UnityEngine;

/// <summary>
/// Global game manager that persists across all scenes.
/// Handles character selection, level unlocking, and game state.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Player Selection")]
    public CharacterData selectedCharacter; // Currently selected character

    [Header("Level Progress")]
    public int currentLevel = 1;
    public int highestUnlockedLevel = 1;

    [Header("Game Stats")]
    public int totalCoins = 0;
    public int currentLives = 3;
    public int maxLives = 3;

    void Awake()
    {
        // Singleton pattern - only one GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persists across scene loads
            Debug.Log("GameManager initialized");
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate
        }
    }

    /// <summary>
    /// Select a character for gameplay
    /// </summary>
    public void SelectCharacter(CharacterData character)
    {
        if (character != null && character.isUnlocked)
        {
            selectedCharacter = character;
            Debug.Log($"Character selected: {character.characterName}");
        }
        else
        {
            Debug.LogWarning("Character is locked or null!");
        }
    }

    /// <summary>
    /// Load a specific level by number
    /// </summary>
    public void LoadLevel(int levelNumber)
    {
        currentLevel = levelNumber;
        // Default naming convention for backwards compatibility
        string sceneName = $"Level{levelNumber:D3}_{GetThemeName(levelNumber)}";
        string fullPath = $"Levels/{sceneName}";

        Debug.Log($"Loading level: {fullPath}");
        UnityEngine.SceneManagement.SceneManager.LoadScene(fullPath);
    }

    /// <summary>
    /// Load a level by scene name (direct path)
    /// </summary>
    public void LoadLevelByName(string sceneName)
    {
        Debug.Log($"Loading level scene: {sceneName}");
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Get theme name based on level number
    /// </summary>
    private string GetThemeName(int levelNumber)
    {
        if (levelNumber <= 3) return "Forest";
        if (levelNumber <= 6) return "Mountain";
        if (levelNumber <= 9) return "Desert";
        if (levelNumber <= 11) return "Underwater";
        return "Ocean";
    }

    /// <summary>
    /// Unlock the next level
    /// </summary>
    public void UnlockNextLevel()
    {
        highestUnlockedLevel = Mathf.Max(highestUnlockedLevel, currentLevel + 1);
        Debug.Log($"Level {highestUnlockedLevel} unlocked!");
    }

    /// <summary>
    /// Add coins to player's total
    /// </summary>
    public void AddCoins(int amount)
    {
        totalCoins += amount;
        Debug.Log($"Coins collected: {amount}. Total: {totalCoins}");
    }

    /// <summary>
    /// Try to unlock a character (if player has enough coins)
    /// </summary>
    public bool TryUnlockCharacter(CharacterData character)
    {
        if (character.isUnlocked)
        {
            Debug.Log($"{character.characterName} already unlocked");
            return true;
        }

        if (totalCoins >= character.unlockCost)
        {
            totalCoins -= character.unlockCost;
            character.isUnlocked = true;
            Debug.Log($"{character.characterName} unlocked for {character.unlockCost} coins!");
            return true;
        }
        else
        {
            Debug.Log($"Not enough coins. Need {character.unlockCost}, have {totalCoins}");
            return false;
        }
    }

    /// <summary>
    /// Lose a life
    /// </summary>
    public void LoseLife()
    {
        currentLives--;
        Debug.Log($"Life lost. Lives remaining: {currentLives}");

        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    /// <summary>
    /// Reset lives to maximum
    /// </summary>
    public void ResetLives()
    {
        currentLives = maxLives;
    }

    /// <summary>
    /// Handle game over
    /// </summary>
    void GameOver()
    {
        Debug.Log("Game Over!");
        // Return to level select or show game over screen
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelSelectScene");
    }

    /// <summary>
    /// Save game data (TODO: Implement PlayerPrefs or JSON save)
    /// </summary>
    public void SaveGame()
    {
        // PlayerPrefs.SetInt("HighestUnlockedLevel", highestUnlockedLevel);
        // PlayerPrefs.SetInt("TotalCoins", totalCoins);
        // PlayerPrefs.Save();
        Debug.Log("Game saved (not yet implemented)");
    }

    /// <summary>
    /// Load game data (TODO: Implement PlayerPrefs or JSON load)
    /// </summary>
    public void LoadGame()
    {
        // highestUnlockedLevel = PlayerPrefs.GetInt("HighestUnlockedLevel", 1);
        // totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        Debug.Log("Game loaded (not yet implemented)");
    }
}
