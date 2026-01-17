using UnityEngine;

/// <summary>
/// Visualizes cart physics debug information.
/// Attach to Cart GameObject alongside CartController.
/// Automatically shows/hides based on DevSettings.debugMode.
/// </summary>
[RequireComponent(typeof(CartController))]
public class CartDebugVisualizer : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Auto-assigned if null")]
    public CartController cartController;

    [Tooltip("Auto-assigned if null")]
    public Rigidbody2D rb;

    [Header("HUD Settings")]
    [Tooltip("HUD position on screen (0-1 normalized)")]
    public Vector2 hudPosition = new Vector2(0.02f, 0.02f);

    [Tooltip("Font size for HUD text")]
    public int fontSize = 14;

    [Header("Trajectory Settings")]
    [Tooltip("Number of points in trajectory arc (more = smoother)")]
    [Range(10, 100)]
    public int trajectoryPoints = 50;

    [Tooltip("Draw trajectory in Game view (uses Debug.DrawLine)")]
    public bool drawInGameView = true;

    // Cached values
    private DevSettings devSettings;
    private GUIStyle hudStyle;
    private float fps;
    private float fpsTimer;
    private int frameCount;

    void Start()
    {
        // Auto-assign components
        if (cartController == null)
            cartController = GetComponent<CartController>();

        if (rb == null)
            rb = GetComponent<Rigidbody2D>();

        // Load dev settings
        devSettings = DevSettings.Instance;

        // Setup GUI style
        SetupGUIStyle();
    }

    void Update()
    {
        if (!DevSettings.IsDebugEnabled) return;

        // Calculate FPS
        if (devSettings.showFPS)
        {
            frameCount++;
            fpsTimer += Time.unscaledDeltaTime;

            if (fpsTimer >= 0.5f)
            {
                fps = frameCount / fpsTimer;
                frameCount = 0;
                fpsTimer = 0f;
            }
        }

        // Draw trajectory in Game view
        if (devSettings.showJumpTrajectory && drawInGameView)
        {
            DrawTrajectoryInGameView();
        }
    }

    void OnGUI()
    {
        if (!DevSettings.IsDebugEnabled || !devSettings.showHUD) return;

        if (hudStyle == null)
            SetupGUIStyle();

        DrawHUD();
    }

    void OnDrawGizmos()
    {
        if (!DevSettings.IsDebugEnabled) return;
        if (cartController == null || rb == null) return;

        // Draw jump trajectory
        if (devSettings.showJumpTrajectory)
        {
            DrawJumpTrajectory();
        }

        // Draw reachable area
        if (devSettings.showReachableArea)
        {
            DrawReachableArea();
        }

        // Draw text labels
        if (devSettings.showTextLabels)
        {
            DrawSceneLabels();
        }
    }

    /// <summary>
    /// Draw HUD overlay with cart stats
    /// </summary>
    void DrawHUD()
    {
        float screenX = Screen.width * hudPosition.x;
        float screenY = Screen.height * hudPosition.y;

        Rect hudRect = new Rect(screenX, screenY, 400, 300);
        GUI.Box(hudRect, "", hudStyle);

        GUILayout.BeginArea(hudRect);
        GUILayout.Label("<b><color=#ffff00>DEVELOPER DEBUG MODE</color></b>", hudStyle);
        GUILayout.Label($"<color=#00ff00>F12:</color> Toggle Debug | <color=#00ff00>F11:</color> Toggle HUD | <color=#00ff00>F10:</color> Cycle Visuals", hudStyle);
        GUILayout.Space(10);

        // FPS
        if (devSettings.showFPS)
        {
            string fpsColor = fps >= 60 ? "#00ff00" : (fps >= 30 ? "#ffff00" : "#ff0000");
            GUILayout.Label($"<b>FPS:</b> <color={fpsColor}>{fps:F1}</color>", hudStyle);
        }

        // Physics info
        if (devSettings.showPhysicsInfo && cartController != null && rb != null)
        {
            GUILayout.Space(5);
            GUILayout.Label("<b><color=#ffff00>CART PHYSICS</color></b>", hudStyle);
            GUILayout.Label($"Position: ({transform.position.x:F2}, {transform.position.y:F2})", hudStyle);
            GUILayout.Label($"Velocity: ({rb.velocity.x:F2}, {rb.velocity.y:F2}) m/s", hudStyle);
            GUILayout.Label($"Speed: {cartController.moveSpeed:F2} m/s", hudStyle);
            GUILayout.Label($"Grounded: {(cartController.isGrounded ? "<color=#00ff00>YES</color>" : "<color=#ff0000>NO</color>")}", hudStyle);

            if (cartController.followTerrainRotation)
            {
                float angle = transform.rotation.eulerAngles.z;
                if (angle > 180f) angle -= 360f;
                GUILayout.Label($"Rotation: {angle:F1}°", hudStyle);
            }
        }

        // Jump stats
        GUILayout.Space(5);
        GUILayout.Label("<b><color=#ffff00>JUMP CAPABILITIES</color></b>", hudStyle);

        float gravity = rb != null ? rb.gravityScale : 1f;
        float maxDistance = JumpCalculator.CalculateMaxJumpDistance(cartController.moveSpeed, cartController.jumpForce, gravity);
        float maxHeight = JumpCalculator.CalculateMaxJumpHeight(cartController.jumpForce, gravity);
        float airTime = JumpCalculator.CalculateTotalAirTime(cartController.jumpForce, gravity);

        GUILayout.Label($"<b>Max Horizontal:</b> {maxDistance:F2} units ({maxDistance * 100:F0} pixels)", hudStyle);
        GUILayout.Label($"<b>Max Vertical:</b> {maxHeight:F2} units ({maxHeight * 100:F0} pixels)", hudStyle);
        GUILayout.Label($"<b>Air Time:</b> {airTime:F2} seconds", hudStyle);

        // Level design helper
        GUILayout.Space(5);
        GUILayout.Label("<b><color=#ffff00>LEVEL DESIGN GUIDE</color></b>", hudStyle);
        GUILayout.Label($"Max platform gap: <color=#00ff00>{maxDistance:F2}</color> units", hudStyle);
        GUILayout.Label($"Max platform height: <color=#00ff00>{maxHeight:F2}</color> units above cart", hudStyle);

        GUILayout.EndArea();
    }

    /// <summary>
    /// Draw jump trajectory arc in Scene view
    /// </summary>
    void DrawJumpTrajectory()
    {
        float gravity = rb != null ? rb.gravityScale : 1f;
        Vector3[] trajectory = JumpCalculator.CalculateJumpTrajectory(
            transform.position,
            cartController.moveSpeed,
            cartController.jumpForce,
            gravity,
            trajectoryPoints
        );

        Gizmos.color = devSettings.trajectoryColor;
        for (int i = 0; i < trajectory.Length - 1; i++)
        {
            Gizmos.DrawLine(trajectory[i], trajectory[i + 1]);
        }

        // Draw endpoint marker
        if (trajectory.Length > 0)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(trajectory[trajectory.Length - 1], 0.2f);
        }
    }

    /// <summary>
    /// Draw trajectory in Game view using Debug.DrawLine
    /// </summary>
    void DrawTrajectoryInGameView()
    {
        float gravity = rb != null ? rb.gravityScale : 1f;
        Vector3[] trajectory = JumpCalculator.CalculateJumpTrajectory(
            transform.position,
            cartController.moveSpeed,
            cartController.jumpForce,
            gravity,
            trajectoryPoints
        );

        for (int i = 0; i < trajectory.Length - 1; i++)
        {
            Debug.DrawLine(trajectory[i], trajectory[i + 1], devSettings.trajectoryColor);
        }
    }

    /// <summary>
    /// Draw reachable area box in Scene view
    /// </summary>
    void DrawReachableArea()
    {
        float gravity = rb != null ? rb.gravityScale : 1f;
        Bounds reachable = JumpCalculator.CalculateReachableBounds(
            transform.position,
            cartController.moveSpeed,
            cartController.jumpForce,
            gravity
        );

        Gizmos.color = devSettings.reachableAreaColor;
        Gizmos.DrawCube(reachable.center, reachable.size);

        // Draw outline
        Gizmos.color = new Color(0f, 1f, 0f, 0.8f);
        Gizmos.DrawWireCube(reachable.center, reachable.size);
    }

    /// <summary>
    /// Draw text labels in Scene view
    /// </summary>
    void DrawSceneLabels()
    {
        #if UNITY_EDITOR
        float gravity = rb != null ? rb.gravityScale : 1f;
        float maxDistance = JumpCalculator.CalculateMaxJumpDistance(cartController.moveSpeed, cartController.jumpForce, gravity);
        float maxHeight = JumpCalculator.CalculateMaxJumpHeight(cartController.jumpForce, gravity);

        // Label at max horizontal distance
        Vector3 maxDistancePos = new Vector3(transform.position.x + maxDistance, transform.position.y, 0f);
        UnityEditor.Handles.Label(maxDistancePos, $"Max Distance: {maxDistance:F2}u\n({maxDistance * 100:F0}px)", new GUIStyle()
        {
            normal = new GUIStyleState() { textColor = Color.yellow },
            fontSize = 12,
            fontStyle = FontStyle.Bold
        });

        // Label at max height
        Vector3 maxHeightPos = new Vector3(transform.position.x + maxDistance / 2f, transform.position.y + maxHeight, 0f);
        UnityEditor.Handles.Label(maxHeightPos, $"Max Height: {maxHeight:F2}u\n({maxHeight * 100:F0}px)", new GUIStyle()
        {
            normal = new GUIStyleState() { textColor = Color.cyan },
            fontSize = 12,
            fontStyle = FontStyle.Bold
        });
        #endif
    }

    /// <summary>
    /// Setup GUI style for HUD
    /// </summary>
    void SetupGUIStyle()
    {
        hudStyle = new GUIStyle();
        hudStyle.fontSize = fontSize;
        hudStyle.normal.textColor = devSettings.hudTextColor;
        hudStyle.richText = true;
        hudStyle.padding = new RectOffset(10, 10, 10, 10);
        hudStyle.normal.background = MakeTex(2, 2, new Color(0f, 0f, 0f, 0.7f));
    }

    /// <summary>
    /// Create a solid color texture for GUI backgrounds
    /// </summary>
    Texture2D MakeTex(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; i++)
            pix[i] = col;

        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }
}
