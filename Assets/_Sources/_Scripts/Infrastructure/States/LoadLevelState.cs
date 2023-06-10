using _Sources._Scripts.Infrastructure.Factory;
using _Sources._Scripts.Player;
using _Sources._Scripts.Scene;
using UnityEngine;

namespace _Sources._Scripts.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
       
        private const string InitialPoint = "InitialPoint";
        
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;

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
            var player = _gameFactory.CreatePlayer(at:  GameObject.FindWithTag(InitialPoint));
            
            CameraFollow(player);
            
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void CameraFollow(GameObject player)
        {
            if (Camera.main != null) Camera.main.GetComponent<CameraFollow>().Follow(player);
        }
    }
}