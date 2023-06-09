using _Sources.Scripts.Services;
using UnityEngine;

namespace _Sources.Scripts.Infrastructure.AssetManagement
{
    public interface IAssets : IService    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
    }
}