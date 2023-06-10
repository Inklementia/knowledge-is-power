using _Sources._Scripts.Infrastructure.Services;
using UnityEngine;

namespace _Sources._Scripts.Infrastructure.AssetManagement
{
    public interface IAssets : IService    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
    }
}