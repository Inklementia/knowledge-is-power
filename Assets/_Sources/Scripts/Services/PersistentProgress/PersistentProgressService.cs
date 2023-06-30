using _Sources.Scripts.Data;

namespace _Sources.Scripts.Services.PersistentProgress
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}