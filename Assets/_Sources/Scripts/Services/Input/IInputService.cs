using UnityEngine;

namespace _Sources.Scripts.Services.Input
{
    public interface IInputService : IService
    {
        Vector2 Axis { get; }

        bool IsAttackButtonUp();
    }
}