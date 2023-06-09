using _Sources._Scripts.Interfaces;
using _Sources._Scripts.Player;
using UnityEngine;

namespace _Sources._Scripts.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string PlayerPath = "Player/Player";
        private const string InitialPoint = "InitialPoint";
        
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
          _loadingCurtain.Hide();
        }

        private void OnLoaded()
        {
            var initialPoint = GameObject.FindWithTag(InitialPoint);
            
            GameObject player = Instantiate(PlayerPath, at: initialPoint.transform.position);
            CameraFollow(player);
            
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void CameraFollow(GameObject player)
        {
            if (Camera.main != null) Camera.main.GetComponent<CameraFollow>().Follow(player);
        }

        private GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }
        
        private GameObject Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }
    }
}