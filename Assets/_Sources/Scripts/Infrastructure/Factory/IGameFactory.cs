using System.Collections.Generic;
using _Sources.Scripts.Services;
using _Sources.Scripts.Services.PersistentProgress;
using UnityEngine;

namespace _Sources.Scripts.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayer(GameObject at);
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
        void CleanUp();
    }
}