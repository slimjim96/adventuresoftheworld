using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(WheelAnimator))]
public class WheelAnimatorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        WheelAnimator wheelAnimator = (WheelAnimator)target;

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Quick Setup", EditorStyles.boldLabel);

        if (GUILayout.Button("Auto-Load CartWheelSheet Sprites"))
        {
            LoadCartWheelSprites(wheelAnimator);
        }

        EditorGUILayout.HelpBox("Click the button above to automatically load all 36 wheel sprites from CartWheelSheet.png", MessageType.Info);
    }

    private void LoadCartWheelSprites(WheelAnimator wheelAnimator)
    {
        // Find the CartWheelSheet asset
        string[] guids = AssetDatabase.FindAssets("CartWheelSheet t:Texture2D");

        if (guids.Length == 0)
        {
            Debug.LogError("CartWheelSheet.png not found in project!");
            return;
        }

        string path = AssetDatabase.GUIDToAssetPath(guids[0]);

        // Load all sprites from the sprite sheet
        Sprite[] sprites = AssetDatabase.LoadAllAssetsAtPath(path)
            .OfType<Sprite>()
            .OrderBy(s => s.name)
            .ToArray();

        if (sprites.Length == 0)
        {
            Debug.LogError("No sprites found in CartWheelSheet! Make sure the sprite sheet is sliced (Sprite Mode: Multiple).");
            return;
        }

        // Assign to the wheel animator
        SerializedObject so = new SerializedObject(wheelAnimator);
        SerializedProperty spritesProperty = so.FindProperty("wheelSprites");

        spritesProperty.arraySize = sprites.Length;
        for (int i = 0; i < sprites.Length; i++)
        {
            spritesProperty.GetArrayElementAtIndex(i).objectReferenceValue = sprites[i];
        }

        so.ApplyModifiedProperties();

        Debug.Log($"Successfully loaded {sprites.Length} wheel sprites!");
    }
}
