using _Sources.Scripts.Data;
using _Sources.Scripts.Infrastructure.States;
using _Sources.Scripts.Services.PersistentProgress;
using _Sources.Scripts.Services.SaveLoad;
using UnityEngine;

namespace _Sources.Scripts.Infrastructure
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;
        
        public LoadProgressState(GameStateMachine gameStateMachine, IPersistentProgressService progressService, ISaveLoadService saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }

        public void Exit()
        {
            //
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            _gameStateMachine.Enter<LoadLevelState, string>(_progressService.Progress.WorldData.PositionOnLevel.Level);
        }

        private void LoadProgressOrInitNew()
        {
            _progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();
        }
        private PlayerProgress NewProgress()
        {
            return new PlayerProgress("Game");
        }
        
    }
}