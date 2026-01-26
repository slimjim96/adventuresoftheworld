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

    [Tooltip("Size of ground check capsule (width, height)")]
    public Vector2 groundCheckSize = new Vector2(0.8f, 0.2f);

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

    [Tooltip("Horizontal offset for front/back wheel raycasts")]
    public float wheelOffset = 0.4f;

    [Tooltip("Torque force to apply when cart exceeds max angle (prevents tipping)")]
    public float correctionTorque = 50f;

    [Tooltip("Gentle torque to return cart to upright when grounded")]
    public float stabilizationTorque = 10f;

    // Private variables
    private Rigidbody2D rb;
    public bool isGrounded { get; private set; }
    private CharacterData currentCharacter;
    private float lastJumpTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Ensure rotation is not frozen for natural cart leaning
        rb.constraints = RigidbodyConstraints2D.None;

        // Add angular drag to prevent infinite spinning
        rb.angularDrag = 2f;

        // Set ground layer to layer 8 if not set
        if (groundLayer.value == 0)
        {
            groundLayer = 1 << 8;
            Debug.Log("Ground layer auto-set to layer 8");
        }

        LoadSelectedCharacter();
    }

    void Update()
    {
        CheckGroundStatus();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        if (followTerrainRotation)
        {
            // Get current rotation
            float currentRotation = transform.rotation.eulerAngles.z;
            if (currentRotation > 180f) currentRotation -= 360f;

            // Apply gentle correction torque only if rotation exceeds max angle
            // This works both in air and on ground
            if (currentRotation > maxRotationAngle)
            {
                // Tilted too far clockwise, apply counter-clockwise torque
                float excessAngle = currentRotation - maxRotationAngle;
                rb.AddTorque(-correctionTorque * excessAngle * 0.5f, ForceMode2D.Force);
            }
            else if (currentRotation < -maxRotationAngle)
            {
                // Tilted too far counter-clockwise, apply clockwise torque
                float excessAngle = -maxRotationAngle - currentRotation;
                rb.AddTorque(correctionTorque * excessAngle * 0.5f, ForceMode2D.Force);
            }
            else if (Mathf.Abs(currentRotation) > 0.5f)
            {
                // Gently stabilize towards upright (works both in air and on ground)
                rb.AddTorque(-currentRotation * stabilizationTorque, ForceMode2D.Force);
            }
        }
        else
        {
            // If terrain following is disabled, return cart to upright
            float currentRotation = transform.rotation.eulerAngles.z;
            if (currentRotation > 180f) currentRotation -= 360f;

            if (Mathf.Abs(currentRotation) > 0.1f)
            {
                float targetRotation = Mathf.MoveTowards(currentRotation, 0f, 500f * Time.fixedDeltaTime);
                transform.rotation = Quaternion.Euler(0f, 0f, targetRotation);
            }
        }
    }

    void LoadSelectedCharacter()
    {
        if (GameManager.Instance != null && GameManager.Instance.selectedCharacter != null)
        {
            currentCharacter = GameManager.Instance.selectedCharacter;
            animalSpriteRenderer.sprite = currentCharacter.characterSprite;
            jumpForce *= currentCharacter.jumpBoostMultiplier;
            moveSpeed *= currentCharacter.speedMultiplier;
            Debug.Log($"Loaded character: {currentCharacter.characterName}");
        }
        else
        {
            Debug.LogWarning("No character selected! Using default sprite.");
        }
    }

    public void CheckGroundStatus()
    {
        if (groundCheck != null)
        {
            // Check ground at front and back wheel positions, accounting for cart rotation
            Vector2 frontWheelPos = (Vector2)groundCheck.position + (Vector2)(transform.right * wheelOffset);
            Vector2 backWheelPos = (Vector2)groundCheck.position - (Vector2)(transform.right * wheelOffset);

            // Use overlap circles at wheel positions for more forgiving detection
            bool frontTouching = Physics2D.OverlapCircle(frontWheelPos, groundCheckSize.y, groundLayer);
            bool backTouching = Physics2D.OverlapCircle(backWheelPos, groundCheckSize.y, groundLayer);

            // Grounded only if BOTH wheels are touching (allows natural settling on uneven terrain)
            bool touchingGround = frontTouching && backTouching;

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

    public void Jump()
    {
        if (Time.time - lastJumpTime < jumpCooldown || !isGrounded)
        {
            Debug.Log($"Jump blocked - grounded: {isGrounded}, cooldown: {Time.time - lastJumpTime < jumpCooldown}");
            return;
        }

        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false;
        lastJumpTime = Time.time;
        Debug.Log("Jump executed!");
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            OnHitObstacle();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            CollectCoin(other.gameObject);
        }
    }

    void OnHitObstacle()
    {
        Debug.Log("Hit obstacle!");

        if (GameManager.Instance != null)
        {
            GameManager.Instance.LoseLife();
        }

        if (GameManager.Instance.currentLives > 0)
        {
            RestartLevel();
        }
    }

    void CollectCoin(GameObject coin)
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddCoins(1);
        }

        Destroy(coin);
    }

    void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }

    void OnDrawGizmos()
    {
        Transform checkTransform = groundCheck != null ? groundCheck : transform;

        // Draw ground check circles at wheel positions (accounting for rotation)
        Vector3 frontWheelPos = checkTransform.position + transform.right * wheelOffset;
        Vector3 backWheelPos = checkTransform.position - transform.right * wheelOffset;

        // Check if each wheel is touching ground (only in play mode)
        if (Application.isPlaying && groundLayer.value != 0)
        {
            bool frontTouching = Physics2D.OverlapCircle(frontWheelPos, groundCheckSize.y, groundLayer);
            bool backTouching = Physics2D.OverlapCircle(backWheelPos, groundCheckSize.y, groundLayer);

            // Front wheel - Green when touching ground, red when not
            Gizmos.color = frontTouching ? Color.green : Color.red;
            Gizmos.DrawWireSphere(frontWheelPos, groundCheckSize.y);
            Gizmos.DrawSphere(frontWheelPos, groundCheckSize.y * 0.1f);

            // Back wheel - Green when touching ground, red when not
            Gizmos.color = backTouching ? Color.green : Color.red;
            Gizmos.DrawWireSphere(backWheelPos, groundCheckSize.y);
            Gizmos.DrawSphere(backWheelPos, groundCheckSize.y * 0.1f);
        }
        else
        {
            // Front wheel - Yellow in edit mode
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(frontWheelPos, groundCheckSize.y);
            Gizmos.DrawSphere(frontWheelPos, groundCheckSize.y * 0.1f);

            // Back wheel - Cyan in edit mode for differentiation
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(backWheelPos, groundCheckSize.y);
            Gizmos.DrawSphere(backWheelPos, groundCheckSize.y * 0.1f);
        }
    }

}