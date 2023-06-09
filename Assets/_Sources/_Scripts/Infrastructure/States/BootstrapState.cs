using _Sources._Scripts.Interfaces;
using _Sources._Scripts.Services.Input;

namespace _Sources._Scripts.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader )
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
          RegisterServices();
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
            Game.InputService = RegisterInputService();
        }
        
        private static IInputService RegisterInputService()
        {   
            return new InputService();
        }
    }
}