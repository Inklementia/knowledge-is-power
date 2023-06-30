using _Sources.Scripts.Data;

namespace _Sources.Scripts.Services.PersistentProgress
{
    public interface ISavedProgressReader
    {
        void LoadProgress(PlayerProgress progress);
      
    }
}