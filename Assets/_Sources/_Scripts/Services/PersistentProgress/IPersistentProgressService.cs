using _Sources._Scripts.Data;
using _Sources._Scripts.Infrastructure.Services;

namespace _Sources._Scripts.Services.PersistentProgress
{
    public interface IPersistentProgressService : IService
    {
        PlayerProgress Progress { get; set; }
    }
}