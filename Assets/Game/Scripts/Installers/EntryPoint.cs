using Runtime.Services.Factories.StateMachineFactory;
using Runtime.Services.GameStateMachine.States;
using VContainer;
using VContainer.Unity;

namespace Runtime.Installers
{
    public sealed class EntryPoint : IInitializable
    {
        private readonly IObjectResolver _objectResolver;

        public EntryPoint(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }
        
        void IInitializable.Initialize() => 
            _objectResolver.Resolve<IStateMachineFactory>().CreateGameStateMachine().Enter<BootstrapState>();
    }
}