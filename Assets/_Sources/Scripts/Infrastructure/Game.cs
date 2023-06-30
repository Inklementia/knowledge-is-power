using _Sources.Scripts.Scene;
using _Sources.Scripts.Services;
using _Sources.Scripts.Services.Input;

namespace _Sources.Scripts.Infrastructure
{
    public class Game
    {
        public static IInputService InputService;
        public readonly GameStateMachine GameStateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain)
        {
            GameStateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), loadingCurtain, AllServices.Container);
        }
    }
}