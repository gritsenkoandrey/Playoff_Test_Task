using Runtime.Services.GameStateMachine;
using VContainer;

namespace Runtime.Services.Factories.StateMachineFactory
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
            GameStateMachine.GameStateMachine gameStateMachine = new ();

            foreach (IExitState state in gameStateMachine.States.Values)
            {
                _objectResolver.Inject(state);
            }
            
            return gameStateMachine;
        }
    }
}