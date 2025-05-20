using Game.Scripts.Services.Factories.StateMachineFactory;
using Game.Scripts.Services.GameStateMachine.States;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Installers
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