using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace Runtime.Utils.Editor
{
    [InitializeOnLoad]
    public static class AutoLoadScene
    {
        private const string ScenePath = "Assets/Scenes/Bootstrap.unity";
        private const string Key = "auto_load_scene_key";

        static AutoLoadScene()
        {
            EditorApplication.update += OnLoadScene;
            EditorApplication.quitting += OnEditorQuit;
        }

        private static void OnLoadScene()
        {
            EditorApplication.update -= OnLoadScene;

            if (EditorPrefs.GetBool(Key))
            {
                return;
            }
            
            EditorPrefs.SetBool(Key, true);

            if (SceneManager.GetActiveScene().path != ScenePath)
            {
                if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                {
                    EditorSceneManager.OpenScene(ScenePath);
                }
            }
        }
        
        private static void OnEditorQuit()
        {
            EditorApplication.quitting -= OnEditorQuit;
            
            EditorPrefs.DeleteKey(Key);
        }
    }
}