using UnityEngine;

/// <summary>
/// ScriptableObject that defines background decoration properties.
/// Create instances via: Assets → Create → Game → Decoration Data
/// </summary>
[CreateAssetMenu(fileName = "DecorationData", menuName = "Game/Decoration Data", order = 3)]
public class DecorationData : ScriptableObject
{
    [Header("Decoration Info")]
    [Tooltip("Decoration name (e.g., 'Forest Tree 01')")]
    public string decorationName;

    [Tooltip("Sprite for this decoration")]
    public Sprite decorationSprite;

    [Header("Spawn Settings")]
    [Tooltip("Parallax layer (Far, Mid, Near)")]
    public ParallaxLayerType layerType = ParallaxLayerType.Mid;

    [Tooltip("Minimum Y position for random spawning")]
    public float minY = -2f;

    [Tooltip("Maximum Y position for random spawning")]
    public float maxY = 2f;

    [Tooltip("Spawn probability weight (higher = more common)")]
    [Range(0f, 10f)]
    public float spawnWeight = 1f;

    [Header("Visual Settings")]
    [Tooltip("Sorting order offset (within parallax layer)")]
    public int sortingOrderOffset = 0;

    [Tooltip("Color tint (white = no tint)")]
    public Color tint = Color.white;

    [Header("World Theme")]
    [Tooltip("Which world this decoration belongs to")]
    public string worldTheme;
}

/// <summary>
/// Enum for parallax layer types
/// </summary>
public enum ParallaxLayerType
{
    Far,
    Mid,
    Near
}
