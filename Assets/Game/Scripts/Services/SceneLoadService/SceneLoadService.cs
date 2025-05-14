using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Services.SceneLoadService
{
    public sealed class SceneLoadService : ISceneLoadService
    {
        void ISceneLoadService.Load(string name, Action onLoaded)
        {
            _ = LoadScene(name, onLoaded);
        }
        
        private async Task LoadScene(string name, Action onLoaded)
        {
            if (SceneManager.GetActiveScene().name.Equals(name))
            {
                onLoaded?.Invoke();
                
                return;
            }

            AsyncOperation handle = SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);

            while (handle.isDone == false)
            {
                await Task.Yield();
            }
            
            onLoaded?.Invoke();
        }
    }
}