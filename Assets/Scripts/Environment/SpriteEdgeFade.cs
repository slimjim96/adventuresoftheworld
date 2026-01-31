using UnityEngine;

/// <summary>
/// Applies elliptical edge fade effect to a sprite, making edges transparent.
/// Attach to any GameObject with a SpriteRenderer.
/// Creates a material instance with the Custom/SpriteEdgeFade shader.
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
[ExecuteInEditMode]
public class SpriteEdgeFade : MonoBehaviour
{
    [Header("Edge Fade")]
    [Tooltip("Where the fade begins (0 = center, 1 = edge)")]
    [Range(0f, 1f)]
    public float fadeStart = 0.3f;

    [Tooltip("Where the fade ends (fully transparent)")]
    [Range(0f, 1f)]
    public float fadeEnd = 0.5f;

    [Header("Ellipse Shape")]
    [Tooltip("Horizontal stretch (>1 = wider, <1 = narrower)")]
    [Range(0.1f, 2f)]
    public float ellipseWidth = 1f;

    [Tooltip("Vertical stretch (>1 = taller, <1 = shorter)")]
    [Range(0.1f, 2f)]
    public float ellipseHeight = 1f;

    [Header("Center Offset")]
    [Tooltip("Shift fade center horizontally")]
    [Range(-0.5f, 0.5f)]
    public float centerOffsetX = 0f;

    [Tooltip("Shift fade center vertically")]
    [Range(-0.5f, 0.5f)]
    public float centerOffsetY = 0f;

    [Header("Atmospheric Haze")]
    [Tooltip("Color to blend toward for depth haze")]
    public Color hazeColor = new Color(0.7f, 0.8f, 0.9f, 1f);

    [Tooltip("Amount of haze to apply (0 = none, 1 = full haze color)")]
    [Range(0f, 1f)]
    public float hazeAmount = 0f;

    [Header("Options")]
    [Tooltip("Auto-calculate haze from ParallaxLayer parent")]
    public bool autoHazeFromParallax = true;

    [Tooltip("Max haze when auto-calculating from parallax")]
    [Range(0f, 1f)]
    public float maxAutoHaze = 0.5f;

    private SpriteRenderer spriteRenderer;
    private Material materialInstance;
    private static Shader edgeFadeShader;

    // Shader property IDs for performance
    private static readonly int FadeStartID = Shader.PropertyToID("_FadeStart");
    private static readonly int FadeEndID = Shader.PropertyToID("_FadeEnd");
    private static readonly int EllipseXID = Shader.PropertyToID("_EllipseX");
    private static readonly int EllipseYID = Shader.PropertyToID("_EllipseY");
    private static readonly int CenterXID = Shader.PropertyToID("_CenterX");
    private static readonly int CenterYID = Shader.PropertyToID("_CenterY");
    private static readonly int HazeColorID = Shader.PropertyToID("_HazeColor");
    private static readonly int HazeAmountID = Shader.PropertyToID("_HazeAmount");

    void OnEnable()
    {
        Initialize();
    }

    void Start()
    {
        if (autoHazeFromParallax)
        {
            CalculateAutoHaze();
        }
        UpdateMaterial();
    }

    void OnValidate()
    {
        // Ensure fadeEnd is always >= fadeStart
        if (fadeEnd < fadeStart)
        {
            fadeEnd = fadeStart;
        }

        if (materialInstance != null)
        {
            if (autoHazeFromParallax)
            {
                CalculateAutoHaze();
            }
            UpdateMaterial();
        }
    }

    void OnDestroy()
    {
        // Clean up material instance
        if (materialInstance != null)
        {
            if (Application.isPlaying)
            {
                Destroy(materialInstance);
            }
            else
            {
                DestroyImmediate(materialInstance);
            }
        }
    }

    /// <summary>
    /// Initialize the component and create material instance.
    /// </summary>
    private void Initialize()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Find shader
        if (edgeFadeShader == null)
        {
            edgeFadeShader = Shader.Find("Custom/SpriteEdgeFade");
        }

        if (edgeFadeShader == null)
        {
            Debug.LogError("SpriteEdgeFade: Could not find Custom/SpriteEdgeFade shader!");
            return;
        }

        // Create material instance
        materialInstance = new Material(edgeFadeShader);
        materialInstance.name = "SpriteEdgeFade (Instance)";

        // Copy sprite texture
        if (spriteRenderer.sprite != null)
        {
            materialInstance.mainTexture = spriteRenderer.sprite.texture;
        }

        spriteRenderer.material = materialInstance;
    }

    /// <summary>
    /// Calculate haze amount based on parent ParallaxLayer speed.
    /// </summary>
    private void CalculateAutoHaze()
    {
        ParallaxLayer parallaxLayer = GetComponentInParent<ParallaxLayer>();
        if (parallaxLayer != null)
        {
            // Lower parallax speed = farther = more haze
            float depth = 1f - parallaxLayer.parallaxSpeed;
            hazeAmount = depth * maxAutoHaze;
        }
    }

    /// <summary>
    /// Update material properties.
    /// </summary>
    public void UpdateMaterial()
    {
        if (materialInstance == null) return;

        materialInstance.SetFloat(FadeStartID, fadeStart);
        materialInstance.SetFloat(FadeEndID, fadeEnd);
        materialInstance.SetFloat(EllipseXID, ellipseWidth);
        materialInstance.SetFloat(EllipseYID, ellipseHeight);
        materialInstance.SetFloat(CenterXID, centerOffsetX);
        materialInstance.SetFloat(CenterYID, centerOffsetY);
        materialInstance.SetColor(HazeColorID, hazeColor);
        materialInstance.SetFloat(HazeAmountID, hazeAmount);
    }

    /// <summary>
    /// Set fade parameters at runtime.
    /// </summary>
    public void SetFade(float start, float end)
    {
        fadeStart = Mathf.Clamp01(start);
        fadeEnd = Mathf.Clamp01(Mathf.Max(end, start));
        UpdateMaterial();
    }

    /// <summary>
    /// Set ellipse shape at runtime.
    /// </summary>
    public void SetEllipse(float width, float height)
    {
        ellipseWidth = Mathf.Clamp(width, 0.1f, 2f);
        ellipseHeight = Mathf.Clamp(height, 0.1f, 2f);
        UpdateMaterial();
    }

    /// <summary>
    /// Set haze at runtime.
    /// </summary>
    public void SetHaze(Color color, float amount)
    {
        hazeColor = color;
        hazeAmount = Mathf.Clamp01(amount);
        UpdateMaterial();
    }

    /// <summary>
    /// Set center offset at runtime.
    /// </summary>
    public void SetCenterOffset(float x, float y)
    {
        centerOffsetX = Mathf.Clamp(x, -0.5f, 0.5f);
        centerOffsetY = Mathf.Clamp(y, -0.5f, 0.5f);
        UpdateMaterial();
    }
}
