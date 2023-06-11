namespace _Sources._Scripts.Infrastructure.States
{
    public interface IPayloadedState<in TPayload> : IExitableState
    {
        void Enter(TPayload payload);

    }
}