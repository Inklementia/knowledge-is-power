namespace _Sources._Scripts.Infrastructure.States
{
    public interface IPayloadedState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);

    }
}