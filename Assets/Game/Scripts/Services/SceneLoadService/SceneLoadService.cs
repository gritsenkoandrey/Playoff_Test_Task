using System;
using System.Collections;
using Runtime.Services.CoroutineService;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runtime.Services.SceneLoadService
{
    public sealed class SceneLoadService : ISceneLoadService
    {
        private readonly ICoroutineService _coroutineService;

        public SceneLoadService(ICoroutineService coroutineService)
        {
            _coroutineService = coroutineService;
        }
        
        void ISceneLoadService.Load(string name, Action onComplete)
        {
            _coroutineService.StartCoroutine(LoadScene(name, onComplete));
        }

        private static IEnumerator LoadScene(string name, Action onComplete)
        {
            if (SceneManager.GetActiveScene().name.Equals(name))
            {
                onComplete?.Invoke();
                
                yield break;
            }
            
            AsyncOperation handle = SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);

            while (handle.isDone == false)
            {
                yield return null;
            }
            
            onComplete?.Invoke();
        }
    }
}