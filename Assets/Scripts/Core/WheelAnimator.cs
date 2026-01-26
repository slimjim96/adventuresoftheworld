using UnityEngine;

/// <summary>
/// Animates a mine cart wheel sprite based on movement speed.
/// Cycles through sprite frames to create a spinning wheel effect.
/// </summary>
public class WheelAnimator : MonoBehaviour
{
    [Header("Sprite Animation")]
    [Tooltip("Array of wheel sprites in rotation order")]
    public Sprite[] wheelSprites;

    [Tooltip("Reference to the cart's Rigidbody2D to read velocity")]
    public Rigidbody2D cartRigidbody;

    [Tooltip("Speed multiplier for animation (higher = faster rotation)")]
    [Range(0.1f, 10f)]
    public float animationSpeed = 3f;

    [Tooltip("Reverse the animation direction")]
    public bool reverseAnimation = true;

    [Tooltip("Also rotate the wheel GameObject to complete full 360° rotation")]
    public bool addRotation = true;

    [Tooltip("Degrees to rotate per sprite frame (360 / number of frames for full circle)")]
    public float degreesPerFrame = 10f;

    [Header("Lighting Effect (Optional)")]
    [Tooltip("Animate the highlight angle on the material (requires WheelGlow shader)")]
    public bool animateHighlight = false;

    private SpriteRenderer spriteRenderer;
    private float currentFrame = 0f;
    private float currentRotation = 0f;
    private Material wheelMaterial;
    private static readonly int HighlightAngle = Shader.PropertyToID("_HighlightAngle");

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("WheelAnimator requires a SpriteRenderer component!");
        }

        if (wheelSprites == null || wheelSprites.Length == 0)
        {
            Debug.LogWarning("WheelAnimator: No wheel sprites assigned!");
        }
        else if (addRotation)
        {
            // Auto-calculate degrees per frame for smooth full rotation
            // 360 degrees / number of frames = degrees each frame should rotate
            degreesPerFrame = 360f / wheelSprites.Length;
            Debug.Log($"WheelAnimator: Auto-calculated {degreesPerFrame}° per frame for {wheelSprites.Length} sprites");
        }

        if (cartRigidbody == null)
        {
            Debug.LogWarning("WheelAnimator: No cart rigidbody assigned. Trying to find it in parent...");
            cartRigidbody = GetComponentInParent<Rigidbody2D>();
        }

        if (animateHighlight && spriteRenderer != null)
        {
            // Get instance of material (not shared)
            wheelMaterial = spriteRenderer.material;
        }
    }

    void Update()
    {
        if (spriteRenderer == null || wheelSprites == null || wheelSprites.Length == 0)
            return;

        // Get horizontal movement speed
        float speed = 0f;
        if (cartRigidbody != null)
        {
            speed = Mathf.Abs(cartRigidbody.velocity.x);
        }

        // Advance frame based on speed
        float frameAdvance = speed * animationSpeed * Time.deltaTime;
        currentFrame += frameAdvance;

        // Wrap around to create looping animation
        while (currentFrame >= wheelSprites.Length)
        {
            currentFrame -= wheelSprites.Length;
        }

        // Update sprite
        int frameIndex = Mathf.FloorToInt(currentFrame) % wheelSprites.Length;

        // Reverse if needed (for backwards animations)
        if (reverseAnimation)
        {
            frameIndex = wheelSprites.Length - 1 - frameIndex;
        }

        spriteRenderer.sprite = wheelSprites[frameIndex];

        // Add rotation to complete the full circle effect
        if (addRotation)
        {
            // Rotate the wheel GameObject based on movement
            float rotationAmount = frameAdvance * degreesPerFrame;
            if (reverseAnimation)
            {
                currentRotation -= rotationAmount;
            }
            else
            {
                currentRotation += rotationAmount;
            }

            // Keep rotation in 0-360 range
            currentRotation = currentRotation % 360f;

            // Apply rotation (only on Z axis for 2D)
            transform.localRotation = Quaternion.Euler(0f, 0f, currentRotation);
        }

        // Animate the highlight on the material
        if (animateHighlight && wheelMaterial != null)
        {
            // Sync highlight rotation with wheel rotation
            float highlightAngle = addRotation ? currentRotation : (currentFrame / wheelSprites.Length) * 360f;
            wheelMaterial.SetFloat(HighlightAngle, highlightAngle);
        }
    }
}
