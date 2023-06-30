using _Sources.Scripts.Data;

namespace _Sources.Scripts.Services.SaveLoad
{
    public interface ISaveLoadService : IService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}