using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the Level Selection scene.
/// Handles level button clicks and scene transitions.
/// </summary>
public class LevelSelectManager : MonoBehaviour
{
    [Header("UI References")]
    [Tooltip("Button to go back to character select")]
    public Button backButton;

    [Header("Scene Settings")]
    [Tooltip("Name of character select scene")]
    public string characterSelectSceneName = "CharacterSelectScene";

    void Start()
    {
        // Setup back button
        if (backButton != null)
        {
            backButton.onClick.AddListener(OnBackButtonClicked);
        }
    }

    /// <summary>
    /// Load a specific level by scene name.
    /// Public so it can be called by level buttons.
    /// </summary>
    public void LoadLevel(string levelSceneName)
    {
        Debug.Log($"Loading level: {levelSceneName}");
        SceneManager.LoadScene(levelSceneName);
    }

    /// <summary>
    /// Back button - return to character select.
    /// </summary>
    public void OnBackButtonClicked()
    {
        Debug.Log("Returning to character select");
        SceneManager.LoadScene(characterSelectSceneName);
    }
}
