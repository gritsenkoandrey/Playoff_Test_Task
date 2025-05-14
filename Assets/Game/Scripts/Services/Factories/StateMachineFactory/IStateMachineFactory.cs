using Game.Scripts.Services.GameStateMachine;

namespace Game.Scripts.Services.Factories.StateMachineFactory
{
    public interface IStateMachineFactory
    {
        IGameStateMachine CreateGameStateMachine();
    }
}