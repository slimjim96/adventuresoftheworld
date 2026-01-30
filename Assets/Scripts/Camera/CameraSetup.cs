using UnityEngine;
using Cinemachine;

/// <summary>
/// Auto-configures Cinemachine camera to follow the player cart.
/// Place this on the Virtual Camera GameObject.
/// Automatically finds the Cart with "Player" tag on scene start.
/// </summary>
public class CameraSetup : MonoBehaviour
{
    [Header("Auto-Setup")]
    [Tooltip("Automatically find and follow the Player on Start")]
    public bool autoFindPlayer = true;

    [Tooltip("Tag to search for (default: Player)")]
    public string playerTag = "Player";

    [Header("Camera Settings")]
    [Tooltip("Orthographic size (how zoomed out the camera is)")]
    public float orthographicSize = 6f;

    [Tooltip("Offset from player (x=ahead, y=above)")]
    public Vector3 followOffset = new Vector3(3f, 0f, -10f);

    private CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();

        if (virtualCamera == null)
        {
            Debug.LogError("[CameraSetup] No CinemachineVirtualCamera found on this GameObject!");
            return;
        }

        // Set orthographic size
        virtualCamera.m_Lens.OrthographicSize = orthographicSize;

        // Auto-find player if enabled
        if (autoFindPlayer)
        {
            FindAndFollowPlayer();
        }
    }

    /// <summary>
    /// Find the player cart and set it as follow target
    /// </summary>
    public void FindAndFollowPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);

        if (player != null)
        {
            virtualCamera.Follow = player.transform;
            Debug.Log($"[CameraSetup] Now following: {player.name}");

            // Configure follow settings
            ConfigureFollowSettings();
        }
        else
        {
            Debug.LogWarning($"[CameraSetup] No GameObject with tag '{playerTag}' found!");
        }
    }

    /// <summary>
    /// Configure the transposer component for smooth following
    /// </summary>
    void ConfigureFollowSettings()
    {
        var transposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();

        if (transposer != null)
        {
            // Position camera ahead of player
            transposer.m_TrackedObjectOffset = followOffset;

            // Smooth damping
            transposer.m_XDamping = 0.5f;
            transposer.m_YDamping = 0.5f;
            transposer.m_ZDamping = 0.5f;

            Debug.Log("[CameraSetup] Transposer configured");
        }
        else
        {
            Debug.LogWarning("[CameraSetup] No FramingTransposer found. Add Body → Framing Transposer in Inspector.");
        }
    }

    /// <summary>
    /// Call this to update the follow target at runtime
    /// </summary>
    public void SetFollowTarget(Transform target)
    {
        if (virtualCamera != null)
        {
            virtualCamera.Follow = target;
            Debug.Log($"[CameraSetup] Follow target set to: {target.name}");
        }
    }
}
