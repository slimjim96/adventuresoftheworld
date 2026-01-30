using UnityEngine;

/// <summary>
/// Shows a flashing "PLAY MODE" indicator in the top-left corner of the Game view.
/// Automatically added to every scene during Play Mode.
/// ONLY works in the Editor - removed in builds.
/// </summary>
public class PlayModeIndicator : MonoBehaviour
{
#if UNITY_EDITOR
    private float blinkTimer = 0f;
    private bool showWarning = true;
    private GUIStyle warningStyle;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void OnRuntimeMethodLoad()
    {
        // Automatically create this indicator when entering Play Mode
        GameObject indicator = new GameObject("PlayModeIndicator");
        indicator.AddComponent<PlayModeIndicator>();
        DontDestroyOnLoad(indicator);
    }

    void Update()
    {
        blinkTimer += Time.unscaledDeltaTime;

        if (blinkTimer >= 0.5f)
        {
            showWarning = !showWarning;
            blinkTimer = 0f;
        }
    }

    void OnGUI()
    {
        if (!showWarning) return;

        // Create style on first draw
        if (warningStyle == null)
        {
            warningStyle = new GUIStyle();
            warningStyle.fontSize = 28;
            warningStyle.fontStyle = FontStyle.Bold;
            warningStyle.normal.textColor = Color.red;
            warningStyle.alignment = TextAnchor.UpperLeft;
        }

        // Draw semi-transparent red background
        GUI.color = new Color(1, 0, 0, 0.8f);
        GUI.Box(new Rect(10, 10, 380, 50), "");

        // Draw warning text
        GUI.color = Color.white;
        GUI.Label(new Rect(20, 18, 360, 40), "⚠️ PLAY MODE - CHANGES WILL BE LOST!", warningStyle);

        // Reset color
        GUI.color = Color.white;
    }
#endif
}
