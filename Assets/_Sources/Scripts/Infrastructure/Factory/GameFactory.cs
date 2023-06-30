using System.Collections.Generic;
using _Sources.Scripts.Infrastructure.AssetManagement;
using _Sources.Scripts.Services.PersistentProgress;
using UnityEngine;

namespace _Sources.Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;

        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();

        public GameFactory(IAssets assets)
        {
            _assets = assets;
        }
        
        // player
        public GameObject CreatePlayer(GameObject at) => InstantiateAndRegister(AssetPath.Player, at.transform.position);
        
        
        // helpers
        
        private GameObject InstantiateAndRegister(string prefabPath, Vector3 position)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath, at: position);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }
        
        private GameObject InstantiateAndRegister(string prefabPath)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }

        // progress watchers

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
            {
                Register(progressReader);
            }
        }

        private void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
                ProgressWriters.Add(progressWriter);
            
            ProgressReaders.Add(progressReader);
        }
        
        // others

        public void CleanUp()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }
    }
}