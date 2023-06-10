using _Sources._Scripts.Infrastructure.Services;
using UnityEngine;

namespace _Sources._Scripts.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayer(GameObject at);
    }
}