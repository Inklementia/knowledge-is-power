using _Sources.Scripts.Data;

namespace _Sources.Scripts.Services.PersistentProgress
{
    public interface IPersistentProgressService : IService
    {
        PlayerProgress Progress { get; set; }
    }
}