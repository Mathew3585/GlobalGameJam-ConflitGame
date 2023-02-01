using UnityEngine;
using UnityEngine.SceneManagement;

namespace Poleaxe.Helper
{
    public static class SceneHelper
    {
        private static bool isLoadingScene = false;
        public static bool IsAdditive => SceneManager.sceneCount > 1;

        public static AsyncOperation ReloadScene()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            return LoadScene(currentScene.name);
        }

        public static AsyncOperation LoadScene(string sceneName)
        {
            if (isLoadingScene) return null;
            isLoadingScene = true;

            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
            operation.completed += ResetSettings;

            TimeHelper.SetPause(true);
            return operation;
        }

        public static AsyncOperation LoadSceneAdditive(string sceneName)
        {
            if (isLoadingScene) return null;
            return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }

        private static void ResetSettings(AsyncOperation _)
        {
            TimeHelper.SetSpeed(1f);
            isLoadingScene = false;
        }
    }
}