using UnityEngine;
using System;

/// <summary>
/// Generates a programmatic gradient background that can transition between presets.
/// Useful for day/night cycles or area-based atmosphere changes.
/// Creates a mesh-based gradient - no sprite assets required.
/// Includes horizon line feature for aligning background assets in the editor.
/// </summary>
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[ExecuteInEditMode]
public class GradientBackground : MonoBehaviour
{
    [Serializable]
    public class GradientPreset
    {
        public string name = "New Preset";
        public Color topColor = Color.cyan;
        public Color horizonColor = Color.white;
        public Color bottomColor = Color.blue;

        public GradientPreset() { }

        public GradientPreset(string name, Color top, Color horizon, Color bottom)
        {
            this.name = name;
            this.topColor = top;
            this.horizonColor = horizon;
            this.bottomColor = bottom;
        }

        // Legacy constructor for backwards compatibility
        public GradientPreset(string name, Color top, Color bottom)
        {
            this.name = name;
            this.topColor = top;
            this.horizonColor = Color.Lerp(top, bottom, 0.5f);
            this.bottomColor = bottom;
        }
    }

    [Header("Gradient Settings")]
    [Tooltip("Current top color of the gradient (sky)")]
    public Color topColor = new Color(0.5f, 0.7f, 1f, 1f);

    [Tooltip("Current horizon color (where sky meets ground)")]
    public Color horizonColor = new Color(0.85f, 0.9f, 1f, 1f);

    [Tooltip("Current bottom color of the gradient (ground/below horizon)")]
    public Color bottomColor = new Color(0.2f, 0.4f, 0.7f, 1f);

    [Header("Horizon Settings")]
    [Tooltip("World Y position of the horizon line")]
    public float horizonY = 0f;

    [Tooltip("Position of horizon within the gradient (0 = bottom, 1 = top)")]
    [Range(0f, 1f)]
    public float horizonPosition = 0.4f;

    [Header("Size")]
    [Tooltip("Width of the gradient quad")]
    public float width = 50f;

    [Tooltip("Height of the gradient quad")]
    public float height = 30f;

    [Header("Camera Follow")]
    [Tooltip("Follow the camera position horizontally")]
    public bool followCamera = true;

    [Tooltip("Lock vertical position to keep horizon at horizonY")]
    public bool lockHorizonPosition = true;

    [Tooltip("Camera to follow (auto-finds Main Camera if null)")]
    public Transform cameraTransform;

    [Tooltip("Z position offset (should be behind everything)")]
    public float zOffset = 50f;

    [Header("Editor Gizmos")]
    [Tooltip("Show horizon line in Scene view")]
    public bool showHorizonLine = true;

    [Tooltip("Color of the horizon guide line")]
    public Color horizonLineColor = Color.yellow;

    [Tooltip("Length of the horizon line in the editor")]
    public float horizonLineLength = 100f;

    [Tooltip("Show additional guide lines above/below horizon")]
    public bool showGuideLines = true;

    [Tooltip("Spacing between guide lines")]
    public float guideLineSpacing = 5f;

    [Tooltip("Number of guide lines above and below horizon")]
    public int guideLineCount = 3;

    [Header("Presets")]
    [Tooltip("Define gradient presets for different times/areas")]
    public GradientPreset[] presets = new GradientPreset[]
    {
        new GradientPreset("Day", new Color(0.4f, 0.6f, 1f), new Color(0.85f, 0.92f, 1f), new Color(0.6f, 0.75f, 0.65f)),
        new GradientPreset("Dusk", new Color(0.2f, 0.1f, 0.3f), new Color(0.95f, 0.5f, 0.3f), new Color(0.3f, 0.25f, 0.35f)),
        new GradientPreset("Night", new Color(0.05f, 0.05f, 0.15f), new Color(0.1f, 0.1f, 0.2f), new Color(0.08f, 0.08f, 0.12f))
    };

    [Header("Transition")]
    [Tooltip("Duration of preset transitions in seconds")]
    public float transitionDuration = 2f;

    private Mesh mesh;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    private Color[] meshColors;

    // Transition state
    private bool isTransitioning = false;
    private float transitionProgress = 0f;
    private Color transitionStartTop;
    private Color transitionStartHorizon;
    private Color transitionStartBottom;
    private Color transitionEndTop;
    private Color transitionEndHorizon;
    private Color transitionEndBottom;
    private Action onTransitionComplete;

    void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
        CreateGradientMesh();
        SetupMaterial();
    }

    void Start()
    {
        if (followCamera && cameraTransform == null)
        {
            Camera mainCamera = Camera.main;
            if (mainCamera != null)
            {
                cameraTransform = mainCamera.transform;
            }
        }

        UpdateMesh();
    }

    void Update()
    {
        // Handle transitions
        if (isTransitioning)
        {
            transitionProgress += Time.deltaTime / transitionDuration;

            if (transitionProgress >= 1f)
            {
                transitionProgress = 1f;
                isTransitioning = false;
                topColor = transitionEndTop;
                horizonColor = transitionEndHorizon;
                bottomColor = transitionEndBottom;
                onTransitionComplete?.Invoke();
                onTransitionComplete = null;
            }
            else
            {
                topColor = Color.Lerp(transitionStartTop, transitionEndTop, transitionProgress);
                horizonColor = Color.Lerp(transitionStartHorizon, transitionEndHorizon, transitionProgress);
                bottomColor = Color.Lerp(transitionStartBottom, transitionEndBottom, transitionProgress);
            }

            UpdateColors();
        }

        // Follow camera
        if (followCamera && cameraTransform != null)
        {
            float yPos;
            if (lockHorizonPosition)
            {
                // Position so that horizon line in mesh aligns with world horizonY
                float horizonOffsetInMesh = (-height / 2) + (height * horizonPosition);
                yPos = horizonY - horizonOffsetInMesh;
            }
            else
            {
                yPos = cameraTransform.position.y;
            }

            transform.position = new Vector3(
                cameraTransform.position.x,
                yPos,
                cameraTransform.position.z + zOffset
            );
        }
    }

    void OnValidate()
    {
        // Update in editor when values change
        if (meshFilter == null) meshFilter = GetComponent<MeshFilter>();
        if (meshRenderer == null) meshRenderer = GetComponent<MeshRenderer>();

        if (mesh != null)
        {
            UpdateMesh();
        }
    }

    void OnDrawGizmos()
    {
        if (!showHorizonLine) return;

        // Calculate horizon world position
        float horizonWorldY = horizonY;

        // Draw main horizon line
        Gizmos.color = horizonLineColor;
        Vector3 horizonLeft = new Vector3(transform.position.x - horizonLineLength / 2, horizonWorldY, 0);
        Vector3 horizonRight = new Vector3(transform.position.x + horizonLineLength / 2, horizonWorldY, 0);
        Gizmos.DrawLine(horizonLeft, horizonRight);

        // Draw horizon label indicator (small vertical ticks)
        float tickSize = 0.5f;
        Gizmos.DrawLine(
            new Vector3(transform.position.x, horizonWorldY - tickSize, 0),
            new Vector3(transform.position.x, horizonWorldY + tickSize, 0)
        );

        // Draw guide lines
        if (showGuideLines && guideLineCount > 0)
        {
            Color guideColor = new Color(horizonLineColor.r, horizonLineColor.g, horizonLineColor.b, 0.3f);
            Gizmos.color = guideColor;

            for (int i = 1; i <= guideLineCount; i++)
            {
                float offset = i * guideLineSpacing;

                // Above horizon
                Vector3 aboveLeft = new Vector3(transform.position.x - horizonLineLength / 2, horizonWorldY + offset, 0);
                Vector3 aboveRight = new Vector3(transform.position.x + horizonLineLength / 2, horizonWorldY + offset, 0);
                Gizmos.DrawLine(aboveLeft, aboveRight);

                // Below horizon
                Vector3 belowLeft = new Vector3(transform.position.x - horizonLineLength / 2, horizonWorldY - offset, 0);
                Vector3 belowRight = new Vector3(transform.position.x + horizonLineLength / 2, horizonWorldY - offset, 0);
                Gizmos.DrawLine(belowLeft, belowRight);
            }
        }
    }

    /// <summary>
    /// Creates the gradient mesh with 6 vertices for 3-color gradient.
    /// </summary>
    private void CreateGradientMesh()
    {
        mesh = new Mesh();
        mesh.name = "GradientMesh";

        UpdateMeshGeometry();
        UpdateColors();

        meshFilter.mesh = mesh;
    }

    /// <summary>
    /// Updates mesh geometry based on current size and horizon position.
    /// </summary>
    private void UpdateMeshGeometry()
    {
        if (mesh == null) return;

        float halfWidth = width / 2;
        float halfHeight = height / 2;
        float horizonLocalY = -halfHeight + (height * horizonPosition);

        // 6 vertices: bottom-left, bottom-right, horizon-left, horizon-right, top-left, top-right
        Vector3[] vertices = new Vector3[6]
        {
            new Vector3(-halfWidth, -halfHeight, 0),    // 0: Bottom-left
            new Vector3(halfWidth, -halfHeight, 0),     // 1: Bottom-right
            new Vector3(-halfWidth, horizonLocalY, 0),  // 2: Horizon-left
            new Vector3(halfWidth, horizonLocalY, 0),   // 3: Horizon-right
            new Vector3(-halfWidth, halfHeight, 0),     // 4: Top-left
            new Vector3(halfWidth, halfHeight, 0)       // 5: Top-right
        };

        // Two quads: bottom (0,1,2,3) and top (2,3,4,5)
        int[] triangles = new int[12]
        {
            0, 2, 1,  // Bottom-left triangle
            2, 3, 1,  // Bottom-right triangle
            2, 4, 3,  // Top-left triangle
            4, 5, 3   // Top-right triangle
        };

        Vector2[] uvs = new Vector2[6]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, horizonPosition),
            new Vector2(1, horizonPosition),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;

        // Initialize colors array if needed
        if (meshColors == null || meshColors.Length != 6)
        {
            meshColors = new Color[6];
        }
    }

    /// <summary>
    /// Sets up unlit vertex color material.
    /// </summary>
    private void SetupMaterial()
    {
        // Use unlit vertex color shader
        Shader shader = Shader.Find("Sprites/Default");
        if (shader == null)
        {
            shader = Shader.Find("Unlit/Color");
        }

        Material material = new Material(shader);
        meshRenderer.material = material;
        meshRenderer.sortingOrder = -1000; // Behind everything
    }

    /// <summary>
    /// Updates both geometry and colors.
    /// </summary>
    private void UpdateMesh()
    {
        UpdateMeshGeometry();
        UpdateColors();
    }

    /// <summary>
    /// Updates the mesh vertex colors.
    /// </summary>
    private void UpdateColors()
    {
        if (mesh == null) return;
        if (meshColors == null || meshColors.Length != 6)
        {
            meshColors = new Color[6];
        }

        meshColors[0] = bottomColor;  // Bottom-left
        meshColors[1] = bottomColor;  // Bottom-right
        meshColors[2] = horizonColor; // Horizon-left
        meshColors[3] = horizonColor; // Horizon-right
        meshColors[4] = topColor;     // Top-left
        meshColors[5] = topColor;     // Top-right

        mesh.colors = meshColors;
    }

    /// <summary>
    /// Get the world Y position of the horizon.
    /// </summary>
    public float GetHorizonWorldY()
    {
        return horizonY;
    }

    /// <summary>
    /// Set the horizon world Y position.
    /// </summary>
    public void SetHorizonY(float newHorizonY)
    {
        horizonY = newHorizonY;
    }

    /// <summary>
    /// Transition to a preset by index.
    /// </summary>
    public void TransitionToPreset(int presetIndex, Action onComplete = null)
    {
        if (presetIndex < 0 || presetIndex >= presets.Length)
        {
            Debug.LogWarning($"Invalid preset index: {presetIndex}");
            return;
        }

        TransitionToPreset(presets[presetIndex], onComplete);
    }

    /// <summary>
    /// Transition to a preset by name.
    /// </summary>
    public void TransitionToPreset(string presetName, Action onComplete = null)
    {
        GradientPreset preset = Array.Find(presets, p => p.name == presetName);
        if (preset == null)
        {
            Debug.LogWarning($"Preset not found: {presetName}");
            return;
        }

        TransitionToPreset(preset, onComplete);
    }

    /// <summary>
    /// Transition to a specific preset.
    /// </summary>
    public void TransitionToPreset(GradientPreset preset, Action onComplete = null)
    {
        transitionStartTop = topColor;
        transitionStartHorizon = horizonColor;
        transitionStartBottom = bottomColor;
        transitionEndTop = preset.topColor;
        transitionEndHorizon = preset.horizonColor;
        transitionEndBottom = preset.bottomColor;
        transitionProgress = 0f;
        isTransitioning = true;
        onTransitionComplete = onComplete;
    }

    /// <summary>
    /// Transition to custom colors.
    /// </summary>
    public void TransitionToColors(Color newTop, Color newHorizon, Color newBottom, Action onComplete = null)
    {
        transitionStartTop = topColor;
        transitionStartHorizon = horizonColor;
        transitionStartBottom = bottomColor;
        transitionEndTop = newTop;
        transitionEndHorizon = newHorizon;
        transitionEndBottom = newBottom;
        transitionProgress = 0f;
        isTransitioning = true;
        onTransitionComplete = onComplete;
    }

    /// <summary>
    /// Immediately set colors without transition.
    /// </summary>
    public void SetColors(Color newTop, Color newHorizon, Color newBottom)
    {
        isTransitioning = false;
        topColor = newTop;
        horizonColor = newHorizon;
        bottomColor = newBottom;
        UpdateColors();
    }

    /// <summary>
    /// Immediately set to a preset without transition.
    /// </summary>
    public void SetPreset(int presetIndex)
    {
        if (presetIndex < 0 || presetIndex >= presets.Length) return;
        SetPreset(presets[presetIndex]);
    }

    /// <summary>
    /// Immediately set to a preset by name without transition.
    /// </summary>
    public void SetPreset(string presetName)
    {
        GradientPreset preset = Array.Find(presets, p => p.name == presetName);
        if (preset != null) SetPreset(preset);
    }

    /// <summary>
    /// Immediately set to a preset without transition.
    /// </summary>
    public void SetPreset(GradientPreset preset)
    {
        isTransitioning = false;
        topColor = preset.topColor;
        horizonColor = preset.horizonColor;
        bottomColor = preset.bottomColor;
        UpdateColors();
    }

    /// <summary>
    /// Get current transition progress (0-1).
    /// </summary>
    public float GetTransitionProgress()
    {
        return transitionProgress;
    }

    /// <summary>
    /// Check if currently transitioning.
    /// </summary>
    public bool IsTransitioning()
    {
        return isTransitioning;
    }
}
