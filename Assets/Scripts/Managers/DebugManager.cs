using UnityEngine;

/// <summary>
/// Manages global debug settings and keyboard shortcuts.
/// Attach to a GameObject in your first scene (or add to GameManager).
/// </summary>
public class DebugManager : MonoBehaviour
{
    public static DebugManager Instance { get; private set; }

    [Header("Keyboard Shortcuts")]
    [Tooltip("Key to toggle debug mode on/off")]
    public KeyCode toggleDebugKey = KeyCode.F12;

    [Tooltip("Key to toggle HUD visibility")]
    public KeyCode toggleHUDKey = KeyCode.F11;

    [Tooltip("Key to cycle through debug visualization modes")]
    public KeyCode cycleVisualsKey = KeyCode.F10;

    [Header("Settings")]
    [Tooltip("Reference to DevSettings asset (auto-loaded if null)")]
    public DevSettings devSettings;

    [Tooltip("Save debug mode state between sessions")]
    public bool persistDebugMode = true;

    private const string DEBUG_MODE_KEY = "DevDebugMode";

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Load DevSettings
        if (devSettings == null)
        {
            devSettings = DevSettings.Instance;
        }

        // Load saved debug mode state
        if (persistDebugMode && devSettings != null)
        {
            devSettings.debugMode = PlayerPrefs.GetInt(DEBUG_MODE_KEY, 0) == 1;
            Debug.Log($"[DebugManager] Debug mode loaded: {devSettings.debugMode}");
        }
    }

    void Update()
    {
        if (devSettings == null) return;

        // Toggle debug mode
        if (Input.GetKeyDown(toggleDebugKey))
        {
            devSettings.debugMode = !devSettings.debugMode;
            OnDebugModeToggled();
        }

        // Toggle HUD (only if debug mode is on)
        if (devSettings.debugMode && Input.GetKeyDown(toggleHUDKey))
        {
            devSettings.showHUD = !devSettings.showHUD;
            Debug.Log($"[DebugManager] HUD: {(devSettings.showHUD ? "ON" : "OFF")}");
        }

        // Cycle visualization modes
        if (devSettings.debugMode && Input.GetKeyDown(cycleVisualsKey))
        {
            CycleVisualizationMode();
        }
    }

    /// <summary>
    /// Called when debug mode is toggled on/off
    /// </summary>
    void OnDebugModeToggled()
    {
        Debug.Log($"[DebugManager] Debug Mode: {(devSettings.debugMode ? "ENABLED" : "DISABLED")} (Press {toggleDebugKey} to toggle)");

        // Save state
        if (persistDebugMode)
        {
            PlayerPrefs.SetInt(DEBUG_MODE_KEY, devSettings.debugMode ? 1 : 0);
            PlayerPrefs.Save();
        }

        // Show/hide cursor in editor (helpful for testing)
        #if UNITY_EDITOR
        Cursor.visible = true;
        #endif
    }

    /// <summary>
    /// Cycle through different visualization modes
    /// </summary>
    void CycleVisualizationMode()
    {
        // Cycle: All On → Trajectory Only → Reachable Only → All Off → All On
        if (devSettings.showJumpTrajectory && devSettings.showReachableArea)
        {
            devSettings.showReachableArea = false;
            Debug.Log("[DebugManager] Visualization: Trajectory Only");
        }
        else if (devSettings.showJumpTrajectory && !devSettings.showReachableArea)
        {
            devSettings.showJumpTrajectory = false;
            devSettings.showReachableArea = true;
            Debug.Log("[DebugManager] Visualization: Reachable Area Only");
        }
        else if (!devSettings.showJumpTrajectory && devSettings.showReachableArea)
        {
            devSettings.showJumpTrajectory = false;
            devSettings.showReachableArea = false;
            Debug.Log("[DebugManager] Visualization: OFF");
        }
        else
        {
            devSettings.showJumpTrajectory = true;
            devSettings.showReachableArea = true;
            Debug.Log("[DebugManager] Visualization: All On");
        }
    }

    /// <summary>
    /// Public API to enable debug mode from code
    /// </summary>
    public static void EnableDebugMode(bool enable)
    {
        if (Instance != null && Instance.devSettings != null)
        {
            Instance.devSettings.debugMode = enable;
            Instance.OnDebugModeToggled();
        }
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
