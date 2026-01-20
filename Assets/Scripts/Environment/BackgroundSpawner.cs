using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Procedurally spawns background decoration elements as the cart moves.
/// Spawns decorations ahead of camera, destroys them behind camera.
/// Attach to a manager GameObject in level scene.
/// </summary>
public class BackgroundSpawner : MonoBehaviour
{
    [Header("Decoration Settings")]
    [Tooltip("Array of decoration prefabs to spawn randomly")]
    public GameObject[] decorationPrefabs;

    [Tooltip("Minimum distance between spawned decorations")]
    public float minSpacing = 5f;

    [Tooltip("Maximum distance between spawned decorations")]
    public float maxSpacing = 15f;

    [Tooltip("Parallax layer to spawn on (e.g., Mid layer)")]
    public Transform spawnLayer;

    [Header("Spawn Area")]
    [Tooltip("Y position range for random vertical placement")]
    public float minY = -2f;

    [Tooltip("Y position range for random vertical placement")]
    public float maxY = 2f;

    [Tooltip("Z position (depth) for spawned decorations")]
    public float spawnZ = 0f;

    [Header("Spawn Distance")]
    [Tooltip("Distance ahead of camera to spawn new decorations")]
    public float spawnDistanceAhead = 30f;

    [Tooltip("Distance behind camera to destroy old decorations")]
    public float destroyDistanceBehind = 20f;

    [Header("References")]
    [Tooltip("Camera to track (leave null to auto-find)")]
    public Transform cameraTransform;

    private float nextSpawnX;
    private List<GameObject> spawnedDecorations = new List<GameObject>();

    void Start()
    {
        // Auto-find main camera if not assigned
        if (cameraTransform == null)
        {
            Camera mainCamera = Camera.main;
            if (mainCamera != null)
            {
                cameraTransform = mainCamera.transform;
            }
            else
            {
                Debug.LogWarning("No main camera found!");
            }
        }

        // Use this spawner's transform as spawn layer if not assigned
        if (spawnLayer == null)
        {
            spawnLayer = transform;
        }

        // Set initial spawn position
        if (cameraTransform != null)
        {
            nextSpawnX = cameraTransform.position.x + spawnDistanceAhead;
        }
    }

    void Update()
    {
        if (cameraTransform == null || decorationPrefabs.Length == 0) return;

        // Spawn new decorations ahead
        while (nextSpawnX < cameraTransform.position.x + spawnDistanceAhead)
        {
            SpawnDecoration();
        }

        // Destroy decorations behind camera
        DestroyOldDecorations();
    }

    /// <summary>
    /// Spawn a random decoration at next spawn position
    /// </summary>
    void SpawnDecoration()
    {
        // Choose random decoration prefab
        GameObject prefab = decorationPrefabs[Random.Range(0, decorationPrefabs.Length)];

        // Calculate spawn position
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(nextSpawnX, randomY, spawnZ);

        // Spawn decoration as child of spawn layer
        GameObject decoration = Instantiate(prefab, spawnPosition, Quaternion.identity, spawnLayer);

        // Track spawned decoration
        spawnedDecorations.Add(decoration);

        // Update next spawn position
        nextSpawnX += Random.Range(minSpacing, maxSpacing);
    }

    /// <summary>
    /// Destroy decorations that are behind the camera
    /// </summary>
    void DestroyOldDecorations()
    {
        float destroyThreshold = cameraTransform.position.x - destroyDistanceBehind;

        // Iterate backwards to safely remove from list
        for (int i = spawnedDecorations.Count - 1; i >= 0; i--)
        {
            if (spawnedDecorations[i] == null)
            {
                spawnedDecorations.RemoveAt(i);
                continue;
            }

            if (spawnedDecorations[i].transform.position.x < destroyThreshold)
            {
                GameObject toDestroy = spawnedDecorations[i];
                spawnedDecorations.RemoveAt(i);
                Destroy(toDestroy);
            }
        }
    }

    // Draw spawn and destroy boundaries in editor
    void OnDrawGizmosSelected()
    {
        if (cameraTransform == null) return;

        Gizmos.color = Color.green;
        Vector3 spawnLine = new Vector3(cameraTransform.position.x + spawnDistanceAhead, 0f, 0f);
        Gizmos.DrawLine(spawnLine + Vector3.up * 10f, spawnLine + Vector3.down * 10f);

        Gizmos.color = Color.red;
        Vector3 destroyLine = new Vector3(cameraTransform.position.x - destroyDistanceBehind, 0f, 0f);
        Gizmos.DrawLine(destroyLine + Vector3.up * 10f, destroyLine + Vector3.down * 10f);
    }
}
