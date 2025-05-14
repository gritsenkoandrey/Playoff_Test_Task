namespace Game.Scripts.Services.GameStateMachine
{
    public interface IEnterLoadState<in TLoad> : IExitState
    {
        void Enter(TLoad load);
    }
}