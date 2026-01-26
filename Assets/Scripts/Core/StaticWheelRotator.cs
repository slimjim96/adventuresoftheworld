using UnityEngine;

/// <summary>
/// Rotates a static wheel sprite based on cart movement and applies dynamic lighting effect.
/// </summary>
public class StaticWheelRotator : MonoBehaviour
{
    [Header("Rotation Settings")]
    [Tooltip("Reference to the cart's Rigidbody2D to read velocity")]
    public Rigidbody2D cartRigidbody;

    [Tooltip("Speed multiplier for rotation (higher = faster rotation)")]
    [Range(0.1f, 10f)]
    public float rotationSpeed = 3f;

    [Tooltip("Reverse the rotation direction")]
    public bool reverseRotation = false;

    [Header("Light Effect Settings")]
    [Tooltip("Animate the highlight on the material (requires WheelGlow shader)")]
    public bool animateHighlight = true;

    [Tooltip("Offset the highlight angle (0-360 degrees)")]
    [Range(0f, 360f)]
    public float highlightOffset = 0f;

    private SpriteRenderer spriteRenderer;
    private Material wheelMaterial;
    private float currentRotation = 0f;
    private static readonly int HighlightAngle = Shader.PropertyToID("_HighlightAngle");

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("StaticWheelRotator requires a SpriteRenderer component!");
            return;
        }

        if (cartRigidbody == null)
        {
            Debug.LogWarning("StaticWheelRotator: No cart rigidbody assigned. Trying to find in parent...");
            cartRigidbody = GetComponentInParent<Rigidbody2D>();
        }

        if (animateHighlight && spriteRenderer != null)
        {
            // Get instance of material (not shared) so each wheel can have independent highlight
            wheelMaterial = spriteRenderer.material;
        }
    }

    void Update()
    {
        // Get horizontal movement speed
        float speed = 0f;
        if (cartRigidbody != null)
        {
            speed = Mathf.Abs(cartRigidbody.velocity.x);
        }

        // Calculate rotation amount based on speed
        // Using wheel circumference logic: rotation per frame = (distance / circumference) * 360
        // Simplified: just rotate based on speed for visual effect
        float rotationAmount = speed * rotationSpeed * Time.deltaTime * 100f;

        if (reverseRotation)
        {
            currentRotation -= rotationAmount;
        }
        else
        {
            currentRotation += rotationAmount;
        }

        // Keep rotation in 0-360 range
        while (currentRotation >= 360f) currentRotation -= 360f;
        while (currentRotation < 0f) currentRotation += 360f;

        // Apply rotation to the wheel GameObject
        transform.localRotation = Quaternion.Euler(0f, 0f, currentRotation);

        // Animate the highlight on the material to follow rotation
        if (animateHighlight && wheelMaterial != null)
        {
            // Sync highlight with wheel rotation plus offset
            float highlightAngle = (currentRotation + highlightOffset) % 360f;
            wheelMaterial.SetFloat(HighlightAngle, highlightAngle);
        }
    }
}
