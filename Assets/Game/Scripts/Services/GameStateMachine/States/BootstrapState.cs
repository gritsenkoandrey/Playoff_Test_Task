using Runtime.Services.SceneLoadService;
using Runtime.Utils;
using VContainer;

namespace Runtime.Services.GameStateMachine.States
{
    public sealed class BootstrapState : IEnterState
    {
        private readonly IGameStateMachine _gameStateMachine;
        
        private ISceneLoadService _sceneLoadService;

        public BootstrapState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        [Inject]
        private void Construct(ISceneLoadService sceneLoadService)
        {
            _sceneLoadService = sceneLoadService;
        }

        void IEnterState.Enter()
        {
            _sceneLoadService.Load(Constants.SceneName.BOOTSTRAP, Next);
        }

        void IExitState.Exit()
        {
        }

        private void Next() => _gameStateMachine.Enter<LoadState, string>(Constants.SceneName.GAME);
    }
}