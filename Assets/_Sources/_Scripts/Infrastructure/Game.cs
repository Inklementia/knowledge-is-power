using _Sources._Scripts.Services.Input;

namespace _Sources._Scripts.Infrastructure
{
    public class Game
    {
        public static IInputService InputService;

        public Game()
        {
            InputService = new InputService();
        }
    }
}