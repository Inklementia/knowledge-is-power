
using _Sources._Scripts.Infrastructure.Services;
using UnityEngine;

namespace _Sources._Scripts.Services.Input
{
    public interface IInputService : IService
    {
        Vector2 Axis { get; }

        bool IsAttackButtonUp();
    }
}