using _Sources._Scripts.Infrastructure.States;
using _Sources._Scripts.Interfaces;
using UnityEngine;

namespace _Sources._Scripts.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        public LoadingCurtain LoadingCurtain;
        private Game _game;

        private void Awake()
        {
            _game = new Game(this, LoadingCurtain);
            _game.GameStateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}