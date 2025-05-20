using Runtime.Services.GameStateMachine;

namespace Runtime.Services.Factories.StateMachineFactory
{
    public interface IStateMachineFactory
    {
        IGameStateMachine CreateGameStateMachine();
    }
}