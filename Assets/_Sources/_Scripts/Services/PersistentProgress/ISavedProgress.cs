using _Sources._Scripts.Data;

namespace _Sources._Scripts.Player
{
    public interface ISavedProgress : ISavedProgressReader
    {
         void UpdateProgress(PlayerProgress progress);
    }
}