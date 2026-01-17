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

    // Private variables
    private Rigidbody2D rb;
    private bool isGrounded;
    private CharacterData currentCharacter;
    private float lastJumpTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

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
    /// Make the cart jump
    /// </summary>
    public void Jump()
    {
        // Check if enough time has passed since last jump (prevents air jumps)
        if (Time.time - lastJumpTime < jumpCooldown || !isGrounded)
        {
            return; // Too soon to jump again
        }

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
    }
}
