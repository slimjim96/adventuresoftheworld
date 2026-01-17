using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Simple script for the Start button in the main menu.
/// Attach to the Start button GameObject in StartScene.
/// </summary>
[RequireComponent(typeof(Button))]
public class StartButton : MonoBehaviour
{
    [Header("Scene Settings")]
    [Tooltip("Name of the scene to load when Start is clicked")]
    public string nextSceneName = "CharacterSelectScene";

    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnStartClicked);
    }

    /// <summary>
    /// Load the next scene (Character Select)
    /// </summary>
    void OnStartClicked()
    {
        Debug.Log($"Start button clicked. Loading {nextSceneName}");
        SceneManager.LoadScene(nextSceneName);
    }
}
