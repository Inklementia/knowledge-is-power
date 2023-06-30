namespace _Sources.Scripts.Infrastructure.States
{
    public interface IState : IExitableState
    {
        void Enter();

    }
}