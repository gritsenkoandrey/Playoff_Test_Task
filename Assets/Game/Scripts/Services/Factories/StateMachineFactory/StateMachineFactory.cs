using Game.Scripts.Services.GameStateMachine;
using Game.Scripts.Utils.Extensions;
using VContainer;

namespace Game.Scripts.Services.Factories.StateMachineFactory
{
    public sealed class StateMachineFactory : IStateMachineFactory
    {
        private readonly IObjectResolver _objectResolver;

        public StateMachineFactory(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }
        
        IGameStateMachine IStateMachineFactory.CreateGameStateMachine()
        {
            GameStateMachine.GameStateMachine gameStateMachine = new GameStateMachine.GameStateMachine();
            gameStateMachine.States.Values.Foreach(_objectResolver.Inject);
            return gameStateMachine;
        }
    }
}