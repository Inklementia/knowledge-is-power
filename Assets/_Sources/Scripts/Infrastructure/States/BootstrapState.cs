using _Sources.Scripts.Infrastructure.AssetManagement;
using _Sources.Scripts.Infrastructure.Factory;
using _Sources.Scripts.Scene;
using _Sources.Scripts.Services;
using _Sources.Scripts.Services.Input;
using _Sources.Scripts.Services.PersistentProgress;
using _Sources.Scripts.Services.SaveLoad;

namespace _Sources.Scripts.Infrastructure.States
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
            _gameStateMachine.Enter<LoadProgressState>();
        }

        public void Exit()
        {
        }

        private void RegisterServices()
        {
            
            _services.RegisterSingle<IInputService>(new InputService());
            _services.RegisterSingle<IAssets>(new AssetProvider());
            _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());  
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssets>()));
            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(_services.Single<IPersistentProgressService>(), _services.Single<IGameFactory>()));
         
        }
    }
    
}