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

    // Private variables
    private Rigidbody2D rb;
    private bool isGrounded;
    private CharacterData currentCharacter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Load selected character from GameManager
        LoadSelectedCharacter();
    }

    void Update()
    {
        // Auto-scroll to the right
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

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
    void CheckGroundStatus()
    {
        if (groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }
    }

    /// <summary>
    /// Make the cart jump
    /// </summary>
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false;
        Debug.Log("Jump!");

        // Play jump sound (if AudioManager exists)
        // AudioManager.Instance.PlaySFX("Jump");
    }

    void OnCollisionEnter2D(Collision2D collision)
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
