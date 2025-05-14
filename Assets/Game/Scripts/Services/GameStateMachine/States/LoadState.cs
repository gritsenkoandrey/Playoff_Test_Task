using Game.Scripts.Services.SceneLoadService;
using Game.Scripts.Services.StaticDataService;
using VContainer;

namespace Game.Scripts.Services.GameStateMachine.States
{
    public sealed class LoadState : IEnterLoadState<string>
    {
        private readonly IGameStateMachine _gameStateMachine;
        
        private ISceneLoadService _sceneLoadService;
        private IStaticDataService _staticDataService;

        public LoadState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        [Inject]
        private void Construct(ISceneLoadService sceneLoadService, IStaticDataService staticDataService)
        {
            _sceneLoadService = sceneLoadService;
            _staticDataService = staticDataService;
        }

        void IEnterLoadState<string>.Enter(string sceneName)
        {
            _staticDataService.Load();
            
            _sceneLoadService.Load(sceneName, Next);
        }

        void IExitState.Exit()
        {
        }

        private void Next()
        {
            _gameStateMachine.Enter<GameState>();
        }
    }
}