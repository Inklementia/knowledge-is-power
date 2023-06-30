using _Sources.Scripts.Data;
using _Sources.Scripts.Infrastructure.Factory;
using _Sources.Scripts.Services.PersistentProgress;
using UnityEngine;

namespace _Sources.Scripts.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "Progress";
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;
        
        public SaveLoadService(IPersistentProgressService progressService, IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
            _progressService = progressService;
        }

        public void SaveProgress()
        {
            foreach (ISavedProgress progressWriter in _gameFactory.ProgressWriters)
            {
                progressWriter.UpdateProgress(_progressService.Progress); 
            }

            PlayerPrefs.SetString(ProgressKey, _progressService.Progress.ToJson());
        }

        public PlayerProgress LoadProgress() => PlayerPrefs.GetString(ProgressKey)?.FromJson<PlayerProgress>();
    }
}