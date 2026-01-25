using UnityEngine;

/// <summary>
/// Controls the cart movement, jumping, and loads the selected character sprite.
/// This script is on the Cart prefab used in all 12 level scenes.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class CartController : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("Constant auto-scroll speed")]
    public float moveSpeed = 5f;

    [Tooltip("Jump force (higher = jump higher)")]
    public float jumpForce = 10f;

    [Header("Ground Detection")]
    [Tooltip("Check if cart is touching ground")]
    public Transform groundCheck;

    [Tooltip("Radius of ground check circle")]
    public float groundCheckRadius = 0.2f;

    [Tooltip("Layer(s) considered as ground")]
    public LayerMask groundLayer;

    [Header("Character References")]
    [Tooltip("SpriteRenderer that displays the selected animal")]
    public SpriteRenderer animalSpriteRenderer;

    [Header("Jump Settings")]
    [Tooltip("Cooldown time between jumps (prevents air jumps)")]
    public float jumpCooldown = 0.2f;

    [Header("Terrain Following (Experimental)")]
    [Tooltip("Enable cart rotation to follow terrain angles")]
    public bool followTerrainRotation = false;

    [Tooltip("Maximum rotation angle in degrees (prevents flipping)")]
    [Range(0f, 90f)]
    public float maxRotationAngle = 45f;

    [Tooltip("How quickly cart rotates to match terrain (higher = faster)")]
    [Range(1f, 20f)]
    public float rotationSpeed = 10f;

    [Tooltip("Distance ahead to raycast for terrain detection")]
    public float terrainCheckDistance = 1f;

    [Tooltip("Minimum angle change to trigger rotation (prevents jitter)")]
    [Range(0f, 5f)]
    public float rotationDeadzone = 1f;

    // Private variables
    private Rigidbody2D rb;
    public bool isGrounded { get; private set; } // Public read-only for debug visualizer
    private CharacterData currentCharacter;
    private float lastJumpTime;
    private float targetRotationAngle; // Smooth rotation target

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Debug.Log("Rigidbody2D JJV component found and assigned.");

        // Load selected character from GameManager
        LoadSelectedCharacter();
    }

    void Update()
    {
        // Check if on ground
        CheckGroundStatus();

        // Jump input
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        // Mobile jump (tap anywhere on screen)
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        // Auto-scroll using physics (maintains constant forward velocity)
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        // Terrain following rotation (if enabled)
        if (followTerrainRotation && isGrounded)
        {
            FollowTerrainRotation();
        }
        else if (!followTerrainRotation)
        {
            // Reset rotation to upright when terrain following is disabled
            float currentRotation = transform.rotation.eulerAngles.z;
            if (currentRotation > 180f) currentRotation -= 360f; // Convert to -180 to 180 range

            if (Mathf.Abs(currentRotation) > 0.1f)
            {
                float targetRotation = Mathf.MoveTowards(currentRotation, 0f, rotationSpeed * Time.fixedDeltaTime * 50f);
                transform.rotation = Quaternion.Euler(0f, 0f, targetRotation);
            }
        }
    }

    /// <summary>
    /// Load the character selected in GameManager and apply sprite
    /// </summary>
    void LoadSelectedCharacter()
    {
        if (GameManager.Instance != null && GameManager.Instance.selectedCharacter != null)
        {
            currentCharacter = GameManager.Instance.selectedCharacter;
            animalSpriteRenderer.sprite = currentCharacter.characterSprite;

            // Apply character-specific stats (if using)
            jumpForce *= currentCharacter.jumpBoostMultiplier;
            moveSpeed *= currentCharacter.speedMultiplier;

            Debug.Log($"Loaded character: {currentCharacter.characterName}");
        }
        else
        {
            Debug.LogWarning("No character selected! Using default sprite.");
        }
    }

    /// <summary>
    /// Check if cart is touching the ground
    /// </summary>
    public void CheckGroundStatus()
    {
        if (groundCheck != null)
        {
            // Only set grounded to true if we're moving downward or stationary (prevents air jumps)
            bool touchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

            if (touchingGround && rb.velocity.y <= 0.1f)
            {
                isGrounded = true;
            }
            else if (!touchingGround)
            {
                isGrounded = false;
            }
        }
    }

    /// <summary>
    /// Rotate cart to follow terrain angle (experimental feature)
    /// </summary>
    void FollowTerrainRotation()
    {
        // Raycast downward from cart position to detect terrain
        Vector2 rayOrigin = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, terrainCheckDistance, groundLayer);

        if (hit.collider != null)
        {
            // Calculate angle from terrain surface normal
            Vector2 surfaceNormal = hit.normal;
            float terrainAngle = Mathf.Atan2(surfaceNormal.y, surfaceNormal.x) * Mathf.Rad2Deg - 90f;

            // Clamp angle to prevent flipping (±maxRotationAngle)
            terrainAngle = Mathf.Clamp(terrainAngle, -maxRotationAngle, maxRotationAngle);

            // Apply deadzone to prevent jitter from small angle changes
            float angleDifference = Mathf.Abs(terrainAngle - targetRotationAngle);
            if (angleDifference > rotationDeadzone)
            {
                targetRotationAngle = terrainAngle;
            }
        }
        else
        {
            // No ground detected, gradually return to upright
            targetRotationAngle = 0f;
        }

        // Smoothly interpolate to target angle (prevents sudden snaps and jitter)
        float currentAngle = transform.rotation.eulerAngles.z;
        if (currentAngle > 180f) currentAngle -= 360f; // Convert to -180 to 180 range

        float newAngle = Mathf.LerpAngle(currentAngle, targetRotationAngle, rotationSpeed * Time.fixedDeltaTime);
        transform.rotation = Quaternion.Euler(0f, 0f, newAngle);
    }

    /// <summary>
    /// Make the cart jump
    /// </summary>
    public void Jump()
    {
        // Check if enough time has passed since last jump (prevents air jumps)
        if (Time.time - lastJumpTime < jumpCooldown || !isGrounded)
        {
            return; // Too soon to jump again
        }

        //debug log
        Debug.Log("Attempting to jump");

        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false;
        lastJumpTime = Time.time; // Record jump time
        Debug.Log("Jump!");

        // Play jump sound (if AudioManager exists)
        // AudioManager.Instance.PlaySFX("Jump");
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if hit ground
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = true;
        }

        // Check if hit obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            OnHitObstacle();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Collect coins
        if (other.CompareTag("Coin"))
        {
            CollectCoin(other.gameObject);
        }
    }

    /// <summary>
    /// Handle hitting an obstacle
    /// </summary>
    void OnHitObstacle()
    {
        Debug.Log("Hit obstacle!");

        // Lose a life
        if (GameManager.Instance != null)
        {
            GameManager.Instance.LoseLife();
        }

        // Play death sound
        // AudioManager.Instance.PlaySFX("Death");

        // Restart level or game over (handled by GameManager)
        if (GameManager.Instance.currentLives > 0)
        {
            RestartLevel();
        }
    }

    /// <summary>
    /// Collect a coin
    /// </summary>
    void CollectCoin(GameObject coin)
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddCoins(1);
        }

        // Play coin sound
        // AudioManager.Instance.PlaySFX("CoinCollect");

        Destroy(coin);
    }

    /// <summary>
    /// Restart the current level
    /// </summary>
    void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }

    // Draw ground check gizmo in editor
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }

        // Draw terrain detection raycast (when terrain following is enabled)
        if (followTerrainRotation)
        {
            Gizmos.color = Color.yellow;
            Vector3 rayStart = transform.position;
            Vector3 rayEnd = rayStart + Vector3.down * terrainCheckDistance;
            Gizmos.DrawLine(rayStart, rayEnd);
        }
    }
}
