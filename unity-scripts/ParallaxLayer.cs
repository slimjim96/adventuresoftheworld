using UnityEngine;

/// <summary>
/// Creates parallax scrolling effect for background layers.
/// Attach to background layer GameObjects (Far, Mid, Near).
/// Moves background at different speed than camera for depth illusion.
/// </summary>
public class ParallaxLayer : MonoBehaviour
{
    [Header("Parallax Settings")]
    [Tooltip("Speed multiplier (0.2 = slow/far, 0.5 = mid, 0.8 = fast/near)")]
    [Range(0f, 1f)]
    public float parallaxSpeed = 0.5f;

    [Tooltip("Enable vertical parallax (usually only horizontal needed)")]
    public bool verticalParallax = false;

    [Header("References")]
    [Tooltip("Camera to follow (leave null to auto-find Main Camera)")]
    public Transform cameraTransform;

    private Vector3 previousCameraPosition;

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
                Debug.LogWarning("No main camera found! Parallax will not work.");
            }
        }

        // Store initial camera position
        if (cameraTransform != null)
        {
            previousCameraPosition = cameraTransform.position;
        }
    }

    void LateUpdate()
    {
        if (cameraTransform == null) return;

        // Calculate camera movement since last frame
        Vector3 cameraDelta = cameraTransform.position - previousCameraPosition;

        // Apply parallax effect
        float parallaxX = cameraDelta.x * parallaxSpeed;
        float parallaxY = verticalParallax ? cameraDelta.y * parallaxSpeed : 0f;

        transform.position += new Vector3(parallaxX, parallaxY, 0f);

        // Update previous camera position
        previousCameraPosition = cameraTransform.position;
    }
}
