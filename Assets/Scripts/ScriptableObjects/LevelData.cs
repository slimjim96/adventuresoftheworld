using UnityEngine;

/// <summary>
/// ScriptableObject that defines level configuration data.
/// Create instances via: Assets → Create → Game → Level Data
/// </summary>
[CreateAssetMenu(fileName = "LevelData", menuName = "Game/Level Data", order = 2)]
public class LevelData : ScriptableObject
{
    [Header("Level Info")]
    [Tooltip("Level number (1-12)")]
    public int levelNumber;

    [Tooltip("Level name (e.g., 'Forest Adventure')")]
    public string levelName;

    [Tooltip("Scene name to load (e.g., 'Level01_Forest')")]
    public string sceneName;

    [Header("Level Theme")]
    [Tooltip("World theme (Forest, Mountain, Desert, Underwater, Ocean)")]
    public string worldTheme;

    [Tooltip("Background color for this level")]
    public Color backgroundColor = new Color(0.53f, 0.81f, 0.92f); // Sky blue default

    [Header("Difficulty Settings")]
    [Tooltip("Obstacle density (obstacles per 10 units)")]
    [Range(0f, 5f)]
    public float obstacleDensity = 1.5f;

    [Tooltip("Coin density (coins per 10 units)")]
    [Range(0f, 10f)]
    public float coinDensity = 3f;

    [Tooltip("Cart movement speed for this level")]
    public float levelSpeed = 5f;

    [Header("Level Length")]
    [Tooltip("Distance to complete level (in units)")]
    public float completionDistance = 100f;

    [Header("Background Layers")]
    [Tooltip("Prefabs for far background layer")]
    public GameObject[] farLayerPrefabs;

    [Tooltip("Prefabs for mid background layer")]
    public GameObject[] midLayerPrefabs;

    [Tooltip("Prefabs for near background layer")]
    public GameObject[] nearLayerPrefabs;

    [Header("Platform Borders")]
    [Tooltip("Border sprites for platform decoration")]
    public Sprite[] platformBorderSprites;

    [Header("Obstacles & Collectibles")]
    [Tooltip("Obstacle prefabs for this level")]
    public GameObject[] obstaclePrefabs;

    [Tooltip("Collectible prefabs for this level")]
    public GameObject[] collectiblePrefabs;
}
