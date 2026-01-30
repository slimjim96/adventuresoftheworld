using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

/// <summary>
/// Draws a bright flashing warning overlay in the Game view during Play Mode.
/// This prevents you from forgetting you're in Play Mode and losing changes!
/// </summary>
[InitializeOnLoad]
public class PlayModeWarning
{
    private static GUIStyle warningStyle;
    private static double lastTime;
    private static bool blink;

    static PlayModeWarning()
    {
        // Subscribe to Scene GUI drawing
        SceneView.duringSceneGui += OnSceneGUI;
    }

    private static void OnSceneGUI(SceneView sceneView)
    {
        if (!EditorApplication.isPlaying) return;

        // Blink every 0.5 seconds
        if (EditorApplication.timeSinceStartup - lastTime > 0.5)
        {
            blink = !blink;
            lastTime = EditorApplication.timeSinceStartup;
        }

        if (!blink) return;

        // Create style if needed
        if (warningStyle == null)
        {
            warningStyle = new GUIStyle();
            warningStyle.normal.textColor = Color.red;
            warningStyle.fontSize = 24;
            warningStyle.fontStyle = FontStyle.Bold;
            warningStyle.alignment = TextAnchor.UpperLeft;
        }

        Handles.BeginGUI();

        // Draw flashing warning text in Scene view
        GUI.color = new Color(1, 0, 0, 0.9f);
        GUI.Box(new Rect(10, 10, 300, 40), "");

        GUI.color = Color.white;
        GUI.Label(new Rect(20, 15, 280, 30), "⚠ PLAY MODE - CHANGES LOST!", warningStyle);

        Handles.EndGUI();
    }
}
#endif
