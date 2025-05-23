namespace Runtime.Services.GameStateMachine
{
    public interface IEnterLoadState<in TLoad> : IExitState
    {
        void Enter(TLoad load);
    }
}