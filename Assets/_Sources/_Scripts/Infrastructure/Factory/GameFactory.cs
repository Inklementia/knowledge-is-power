using _Sources._Scripts.Infrastructure.AssetManagement;
using UnityEngine;

namespace _Sources._Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;

        public GameFactory(IAssets assets)
        {
            _assets = assets;
        }
        public GameObject CreatePlayer(GameObject at)
        {
            return _assets.Instantiate(AssetPath.Player, at: at.transform.position);
        }
 
    }
}