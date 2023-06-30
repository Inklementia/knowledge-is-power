using _Sources.Scripts.Data;

namespace _Sources.Scripts.Services.PersistentProgress
{
    public interface ISavedProgress : ISavedProgressReader
    {
         void UpdateProgress(PlayerProgress progress);
    }
}