using UnityEngine;

namespace AdventuresOfTheWorld.Environment
{
    /// <summary>
    /// Universal parallax script with depth-based movement, atmospheric fade,
    /// and optional X/Y axis fading for smooth blending.
    /// Designed for both manual placement and dynamic procedural spawning.
    /// </summary>
    public class ParallaxLayer : MonoBehaviour
    {
        [Header("Camera Reference")]
        [SerializeField] private Transform cameraTransform;

        [Header("Depth Settings")]
        [Range(0f, 1f)]
        [SerializeField] private float depth = 0.5f;
        [Tooltip("0.0 = Foreground (near), 1.0 = Background (far)")]

        [Header("Parallax Speed")]
        [SerializeField] private AnimationCurve speedCurve = AnimationCurve.Linear(0f, 0.8f, 1f, 0.2f);
        [Tooltip("Maps depth (0-1) to parallax speed. Default: near=0.8x, far=0.2x")]

        [Header("Atmospheric Perspective")]
        [SerializeField] private bool enableAtmosphericFade = true;
        [SerializeField] private Color atmosphericColor = new Color(0.85f, 0.9f, 1f, 1f);
        [SerializeField] private AnimationCurve fadeCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 0.5f);
        [Tooltip("Maps depth (0-1) to atmospheric fade. Default: near=0%, far=50%")]

        [Header("Brightness Adjustment")]
        [SerializeField] private bool enableBrightnessAdjust = true;
        [SerializeField] private AnimationCurve brightnessCurve = AnimationCurve.Linear(0f, 1f, 1f, 1.3f);
        [Tooltip("Maps depth (0-1) to brightness. Default: near=1.0x, far=1.3x")]

        [Header("X-Axis Fade (Horizontal Blending)")]
        [SerializeField] private bool enableXAxisFade = false;
        [SerializeField] private float xFadeStart = 0f;
        [Tooltip("World X position where fade begins (left edge)")]
        [SerializeField] private float xFadeEnd = 10f;
        [Tooltip("World X position where fully transparent (right edge)")]
        [SerializeField] private AnimationCurve xFadeCurve = AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);
        [Tooltip("Fade transition curve: 0=start, 1=end")]

        [Header("Y-Axis Fade (Vertical Blending)")]
        [SerializeField] private bool enableYAxisFade = false;
        [SerializeField] private float yFadeStart = 5f;
        [Tooltip("World Y position where fade begins (top edge)")]
        [SerializeField] private float yFadeEnd = -5f;
        [Tooltip("World Y position where fully transparent (bottom edge)")]
        [SerializeField] private AnimationCurve yFadeCurve = AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);
        [Tooltip("Fade transition curve: 0=start, 1=end")]

        private Vector3 _lastCameraPosition;
        private SpriteRenderer[] _sprites;
        private Color[] _originalColors;

        #region Unity Lifecycle

        private void Start()
        {
            InitializeCamera();
            CacheSprites();
            ApplyAllEffects();
        }

        private void LateUpdate()
        {
            if (cameraTransform == null)
                return;

            UpdateParallaxMovement();

            // Update axis fades if enabled (for dynamic/moving objects)
            if (enableXAxisFade || enableYAxisFade)
            {
                ApplyAxisFades();
            }
        }

        private void OnValidate()
        {
            // Real-time preview in editor
            if (Application.isPlaying && _sprites != null)
            {
                ApplyAllEffects();
            }
        }

        #endregion

        #region Initialization

        private void InitializeCamera()
        {
            if (cameraTransform == null)
            {
                Camera mainCamera = Camera.main;
                if (mainCamera != null)
                {
                    cameraTransform = mainCamera.transform;
                }
                else
                {
                    Debug.LogError($"ParallaxLayer on {gameObject.name}: No camera found!");
                    enabled = false;
                    return;
                }
            }

            _lastCameraPosition = cameraTransform.position;
        }

        private void CacheSprites()
        {
            _sprites = GetComponentsInChildren<SpriteRenderer>();
            _originalColors = new Color[_sprites.Length];

            for (int i = 0; i < _sprites.Length; i++)
            {
                _originalColors[i] = _sprites[i].color;
            }
        }

        #endregion

        #region Parallax Movement

        private void UpdateParallaxMovement()
        {
            Vector3 deltaMovement = cameraTransform.position - _lastCameraPosition;
            float parallaxSpeed = speedCurve.Evaluate(depth);

            float parallaxX = deltaMovement.x * parallaxSpeed;
            transform.position += new Vector3(parallaxX, 0f, 0f);

            _lastCameraPosition = cameraTransform.position;
        }

        #endregion

        #region Visual Effects

        /// <summary>
        /// Apply all visual effects: atmospheric fade, brightness, and axis fades
        /// </summary>
        private void ApplyAllEffects()
        {
            if (_sprites == null || _sprites.Length == 0)
                return;

            // Calculate atmospheric effects from depth
            float atmosphericFade = enableAtmosphericFade ? fadeCurve.Evaluate(depth) : 0f;
            float brightnessMultiplier = enableBrightnessAdjust ? brightnessCurve.Evaluate(depth) : 1f;

            for (int i = 0; i < _sprites.Length; i++)
            {
                if (_sprites[i] == null)
                    continue;

                Color baseColor = _originalColors[i];

                // Apply brightness
                Color adjustedColor = baseColor * brightnessMultiplier;

                // Apply atmospheric fade
                Color blendedColor = Color.Lerp(adjustedColor, atmosphericColor, atmosphericFade);

                // Preserve original alpha for now (axis fades will modify it)
                blendedColor.a = baseColor.a;

                _sprites[i].color = blendedColor;
            }

            // Apply axis fades (modifies alpha)
            ApplyAxisFades();
        }

        /// <summary>
        /// Apply X and Y axis transparency fading for smooth blending
        /// </summary>
        private void ApplyAxisFades()
        {
            if (_sprites == null || _sprites.Length == 0)
                return;

            for (int i = 0; i < _sprites.Length; i++)
            {
                if (_sprites[i] == null)
                    continue;

                float alphaMultiplier = 1f;

                // Calculate X-axis fade
                if (enableXAxisFade)
                {
                    float xPos = _sprites[i].transform.position.x;
                    float xFadeAmount = CalculateFadeAmount(xPos, xFadeStart, xFadeEnd, xFadeCurve);
                    alphaMultiplier *= xFadeAmount;
                }

                // Calculate Y-axis fade
                if (enableYAxisFade)
                {
                    float yPos = _sprites[i].transform.position.y;
                    float yFadeAmount = CalculateFadeAmount(yPos, yFadeStart, yFadeEnd, yFadeCurve);
                    alphaMultiplier *= yFadeAmount;
                }

                // Apply combined alpha multiplier
                Color currentColor = _sprites[i].color;
                currentColor.a = _originalColors[i].a * alphaMultiplier;
                _sprites[i].color = currentColor;
            }
        }

        /// <summary>
        /// Calculate fade amount based on position along axis
        /// </summary>
        private float CalculateFadeAmount(float position, float fadeStart, float fadeEnd, AnimationCurve curve)
        {
            // Normalize position to 0-1 range
            float range = fadeEnd - fadeStart;

            if (Mathf.Abs(range) < 0.001f)
                return 1f; // Avoid division by zero

            float normalizedPos = Mathf.Clamp01((position - fadeStart) / range);

            // Evaluate curve to get fade amount (1.0 = opaque, 0.0 = transparent)
            return curve.Evaluate(normalizedPos);
        }

        #endregion

        #region Public API (For Procedural Spawning)

        /// <summary>
        /// Set depth and recalculate all effects
        /// </summary>
        public void SetDepth(float newDepth)
        {
            depth = Mathf.Clamp01(newDepth);
            ApplyAllEffects();
        }

        /// <summary>
        /// Configure X-axis fade for horizontal blending
        /// </summary>
        public void SetXAxisFade(bool enabled, float startX, float endX)
        {
            enableXAxisFade = enabled;
            xFadeStart = startX;
            xFadeEnd = endX;

            if (enabled && Application.isPlaying)
            {
                ApplyAxisFades();
            }
        }

        /// <summary>
        /// Configure Y-axis fade for vertical blending
        /// </summary>
        public void SetYAxisFade(bool enabled, float startY, float endY)
        {
            enableYAxisFade = enabled;
            yFadeStart = startY;
            yFadeEnd = endY;

            if (enabled && Application.isPlaying)
            {
                ApplyAxisFades();
            }
        }

        /// <summary>
        /// Set all parameters at once (useful for procedural spawning)
        /// </summary>
        public void ConfigureParallax(float depthValue, bool xFade = false, float xStart = 0f, float xEnd = 10f,
                                       bool yFade = false, float yStart = 5f, float yEnd = -5f)
        {
            depth = Mathf.Clamp01(depthValue);
            enableXAxisFade = xFade;
            xFadeStart = xStart;
            xFadeEnd = xEnd;
            enableYAxisFade = yFade;
            yFadeStart = yStart;
            yFadeEnd = yEnd;

            ApplyAllEffects();
        }

        /// <summary>
        /// Get current parallax speed (useful for debugging)
        /// </summary>
        public float GetCurrentSpeed()
        {
            return speedCurve.Evaluate(depth);
        }

        #endregion

        #region Debug Visualization

        private void OnDrawGizmosSelected()
        {
            // Show depth as colored sphere
            Gizmos.color = Color.Lerp(Color.green, Color.red, depth);
            Gizmos.DrawWireSphere(transform.position, 0.5f);

            // Show parallax speed
            float speed = speedCurve.Evaluate(depth);

            #if UNITY_EDITOR
            UnityEditor.Handles.Label(transform.position + Vector3.up * 2f,
                $"Depth: {depth:F2}\nSpeed: {speed:F2}x\nX Fade: {enableXAxisFade}\nY Fade: {enableYAxisFade}");

            // Visualize X-axis fade zone
            if (enableXAxisFade)
            {
                Gizmos.color = Color.cyan;
                Vector3 startPos = new Vector3(xFadeStart, transform.position.y, 0f);
                Vector3 endPos = new Vector3(xFadeEnd, transform.position.y, 0f);
                Gizmos.DrawLine(startPos + Vector3.up * 10f, startPos + Vector3.down * 10f);
                Gizmos.DrawLine(endPos + Vector3.up * 10f, endPos + Vector3.down * 10f);
                UnityEditor.Handles.Label(startPos + Vector3.up * 5f, "X Fade Start");
                UnityEditor.Handles.Label(endPos + Vector3.up * 5f, "X Fade End");
            }

            // Visualize Y-axis fade zone
            if (enableYAxisFade)
            {
                Gizmos.color = Color.magenta;
                Vector3 startPos = new Vector3(transform.position.x, yFadeStart, 0f);
                Vector3 endPos = new Vector3(transform.position.x, yFadeEnd, 0f);
                Gizmos.DrawLine(startPos + Vector3.left * 10f, startPos + Vector3.right * 10f);
                Gizmos.DrawLine(endPos + Vector3.left * 10f, endPos + Vector3.right * 10f);
                UnityEditor.Handles.Label(startPos + Vector3.right * 5f, "Y Fade Start");
                UnityEditor.Handles.Label(endPos + Vector3.right * 5f, "Y Fade End");
            }
            #endif
        }

        #endregion
    }
}
