using _Sources._Scripts.Infrastructure.AssetManagement;
using _Sources._Scripts.Infrastructure.Factory;
using _Sources._Scripts.Infrastructure.Services;
using _Sources._Scripts.Scene;
using _Sources._Scripts.Services.Input;

namespace _Sources._Scripts.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices services )
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            // make it first thing to do
            RegisterServices();
        }

        public void Enter()
        {
      
          _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel()
        {
            _gameStateMachine.Enter<LoadLevelState, string>("Game");
        }

        public void Exit()
        {
        }

        private void RegisterServices()
        {
            
            _services.RegisterSingle<IInputService>(new InputService());
            _services.RegisterSingle<IAssets>(new AssetProvider());
            _services.RegisterSingle<IGameFactory>(
                new GameFactory(_services.Single<IAssets>()));
        }
    }
}