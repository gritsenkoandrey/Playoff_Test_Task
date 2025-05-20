using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace Runtime.Utils.Editor
{
    [InitializeOnLoad]
    public static class AutoLoadScene
    {
        static AutoLoadScene()
        {
            EditorApplication.update += OnLoadScene;
            EditorApplication.quitting += OnEditorQuit;
        }

        private static void OnLoadScene()
        {
            EditorApplication.update -= OnLoadScene;

            if (EditorPrefs.GetBool(Constants.EditorAutoLoadScene.KEY))
            {
                return;
            }
            
            EditorPrefs.SetBool(Constants.EditorAutoLoadScene.KEY, true);

            if (SceneManager.GetActiveScene().path != Constants.EditorAutoLoadScene.SCENE_PATH)
            {
                if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                {
                    EditorSceneManager.OpenScene(Constants.EditorAutoLoadScene.SCENE_PATH);
                }
            }
        }
        
        private static void OnEditorQuit()
        {
            EditorApplication.quitting -= OnEditorQuit;
            
            EditorPrefs.DeleteKey(Constants.EditorAutoLoadScene.KEY);
        }
    }
}