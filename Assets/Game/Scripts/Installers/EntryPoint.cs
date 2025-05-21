using Runtime.Services.Factories.StateMachineFactory;
using Runtime.Services.GameStateMachine.States;
using VContainer.Unity;

namespace Runtime.Installers
{
    public sealed class EntryPoint : IInitializable
    {
        private readonly IStateMachineFactory _stateMachineFactory;

        public EntryPoint(IStateMachineFactory stateMachineFactory)
        {
            _stateMachineFactory = stateMachineFactory;
        }
        
        void IInitializable.Initialize() => _stateMachineFactory.CreateGameStateMachine().Enter<BootstrapState>();
    }
}