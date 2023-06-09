using _Sources._Scripts.Services.Input;

namespace _Sources._Scripts.Infrastructure
{
    public class Game
    {
        public static IInputService InputService;
        public GameStateMachine GameStateMachine;

        public Game(ICoroutineRunner coroutineRunner)
        {
            GameStateMachine = new GameStateMachine(new SceneLoader(coroutineRunner));
        }
    }
}