using _Sources.Scripts.Infrastructure.Factory;
using _Sources.Scripts.Player;
using _Sources.Scripts.Scene;
using _Sources.Scripts.Services.PersistentProgress;
using UnityEngine;

namespace _Sources.Scripts.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
       
        private const string InitialPoint = "InitialPoint";
        
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain, IGameFactory gameFactory, IPersistentProgressService progressService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
            _progressService = progressService;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtain.Show();
            _gameFactory.CleanUp();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
          _loadingCurtain.Hide();
        }

        private void OnLoaded()
        {
            InitGameWorld();
            InitProgressReaders();
            
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void InitProgressReaders()
        {
            foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
            {
                progressReader.LoadProgress(_progressService.Progress);
            }
        }

        private void InitGameWorld()
        {
            // just a player for now
            var player = _gameFactory.CreatePlayer(at:  GameObject.FindWithTag(InitialPoint));
            CameraFollow(player);
        }

        private void CameraFollow(GameObject player)
        {
            if (Camera.main != null) Camera.main.GetComponent<CameraFollow>().Follow(player);
        }
    }
}