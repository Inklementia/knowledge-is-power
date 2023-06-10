using System;
using System.Collections;
using _Sources._Scripts.Infrastructure;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Sources._Scripts.Scene
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;
        
        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }
        
        public void Load(String name, Action onLoaded = null)
        {
            _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));
        }
        
        private IEnumerator LoadScene(string nextScene, Action onLoaded = null)
        {
            if(SceneManager.GetActiveScene().name == nextScene)
            {
                onLoaded?.Invoke(); 
                yield break;
            }
            
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

            while(!waitNextScene.isDone)
            {
                yield return new WaitForSeconds(1);
            }
            
            onLoaded?.Invoke();
        }
    }
    
    
}