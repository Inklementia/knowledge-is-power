using UnityEngine;

namespace _Sources._Scripts.Infrastructure
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}