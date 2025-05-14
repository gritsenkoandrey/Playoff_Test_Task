namespace Game.Scripts.Services.GameStateMachine
{
    public interface IEnterState : IExitState
    {
        void Enter();
    }
}