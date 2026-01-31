using UnityEngine;
using UnityEditor;

/// <summary>
/// Custom editor for the Platform component.
/// </summary>
[CustomEditor(typeof(Platform))]
public class PlatformSetupEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Platform platform = (Platform)target;

        DrawDefaultInspector();

        // Check layer
        if (platform.gameObject.layer != 7)
        {
            EditorGUILayout.Space(5);
            EditorGUILayout.HelpBox(
                "This platform is NOT on the Ground layer!\nThe cart won't be able to land on it.",
                MessageType.Error);

            if (GUILayout.Button("Fix: Set to Ground Layer"))
            {
                Undo.RecordObject(platform.gameObject, "Set Ground Layer");
                platform.gameObject.layer = 7;
                EditorUtility.SetDirty(platform.gameObject);
            }
        }

        EditorGUILayout.Space(5);
        EditorGUILayout.HelpBox(
            "Edit the BoxCollider2D directly above.\n" +
            "- Adjust 'Offset' to position where the cart lands\n" +
            "- Adjust 'Size' for collision area\n" +
            "- Green gizmo in Scene view shows collision area",
            MessageType.Info);
    }
}

/// <summary>
/// Menu items for quickly creating platform GameObjects
/// </summary>
public static class PlatformMenuItems
{
    [MenuItem("GameObject/2D Object/Platform (Forest)", false, 10)]
    static void CreateForestPlatform(MenuCommand menuCommand)
    {
        CreatePlatform("ForestPlatform", menuCommand);
    }

    [MenuItem("GameObject/2D Object/Platform (Generic)", false, 10)]
    static void CreateGenericPlatform(MenuCommand menuCommand)
    {
        CreatePlatform("Platform", menuCommand);
    }

    static void CreatePlatform(string name, MenuCommand menuCommand)
    {
        // Create the platform GameObject
        GameObject platform = new GameObject(name);

        // Add required components
        SpriteRenderer sr = platform.AddComponent<SpriteRenderer>();
        BoxCollider2D col = platform.AddComponent<BoxCollider2D>();
        PlatformEffector2D effector = platform.AddComponent<PlatformEffector2D>();
        Platform platformScript = platform.AddComponent<Platform>();

        // Set to Ground layer (layer 7)
        platform.layer = 7;

        // Configure collider to use effector (one-way platform)
        col.usedByEffector = true;

        // Configure effector: only collide from above
        effector.useOneWay = true;
        effector.surfaceArc = 180f;

        // Apply physics material if it exists
        PhysicsMaterial2D physicsMat = AssetDatabase.LoadAssetAtPath<PhysicsMaterial2D>(
            "Assets/PlatformPhysicsMaterial.physicsMaterial2D");
        if (physicsMat != null)
        {
            col.sharedMaterial = physicsMat;
        }

        // Set default collider size
        col.size = new Vector2(5f, 0.5f);

        // Register undo
        Undo.RegisterCreatedObjectUndo(platform, "Create Platform");

        // Parent to context if applicable
        GameObjectUtility.SetParentAndAlign(platform, menuCommand.context as GameObject);

        // Select the new object
        Selection.activeObject = platform;

        Debug.Log($"Created {name}. Assign a sprite and adjust the collider offset/size as needed.");
    }
}
