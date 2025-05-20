namespace Runtime.Services.GameStateMachine
{
    public interface IEnterState : IExitState
    {
        void Enter();
    }
}