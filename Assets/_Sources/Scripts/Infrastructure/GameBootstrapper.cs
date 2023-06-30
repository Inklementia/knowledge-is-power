using _Sources.Scripts.Infrastructure.States;
using _Sources.Scripts.Scene;
using UnityEngine;

namespace _Sources.Scripts.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        public LoadingCurtain LoadingCurtainPrefab;
        private Game _game;

        private void Awake()
        {
            _game = new Game(this, Instantiate(LoadingCurtainPrefab));
            _game.GameStateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}