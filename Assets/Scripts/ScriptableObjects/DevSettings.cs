using UnityEngine;

/// <summary>
/// Global developer settings for the entire project.
/// Create via: Assets → Create → Game → Dev Settings
/// </summary>
[CreateAssetMenu(fileName = "DevSettings", menuName = "Game/Dev Settings", order = 0)]
public class DevSettings : ScriptableObject
{
    [Header("Master Toggle")]
    [Tooltip("Enable all developer/debug features")]
    public bool debugMode = false;

    [Header("Visual Debug Options")]
    [Tooltip("Show on-screen HUD with cart stats")]
    public bool showHUD = true;

    [Tooltip("Draw jump trajectory arc in Scene/Game view")]
    public bool showJumpTrajectory = true;

    [Tooltip("Show reachable area from current position")]
    public bool showReachableArea = true;

    [Tooltip("Display numerical values as text in scene")]
    public bool showTextLabels = true;

    [Header("Performance")]
    [Tooltip("Show FPS counter")]
    public bool showFPS = true;

    [Tooltip("Show physics values (velocity, grounded, etc.)")]
    public bool showPhysicsInfo = true;

    [Header("Level Design")]
    [Tooltip("Show grid overlay for platform placement")]
    public bool showGrid = false;

    [Tooltip("Grid cell size (in units)")]
    public float gridCellSize = 1f;

    [Header("Color Scheme")]
    public Color trajectoryColor = new Color(1f, 1f, 0f, 0.8f); // Yellow
    public Color reachableAreaColor = new Color(0f, 1f, 0f, 0.3f); // Green transparent
    public Color hudTextColor = Color.white;

    /// <summary>
    /// Singleton instance (loaded from Resources)
    /// </summary>
    private static DevSettings _instance;
    public static DevSettings Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<DevSettings>("DevSettings");
                if (_instance == null)
                {
                    Debug.LogWarning("DevSettings not found in Resources folder. Creating default instance.");
                    _instance = CreateInstance<DevSettings>();
                }
            }
            return _instance;
        }
    }

    /// <summary>
    /// Quick check if debug mode is enabled
    /// </summary>
    public static bool IsDebugEnabled => Instance != null && Instance.debugMode;
}
