using _Sources._Scripts.Infrastructure.Services;
using _Sources._Scripts.Scene;
using _Sources._Scripts.Services.Input;

namespace _Sources._Scripts.Infrastructure
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