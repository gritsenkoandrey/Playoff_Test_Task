using Runtime.Services.LevelService;
using Runtime.Services.SceneLoadService;
using Runtime.Services.StaticDataService;
using VContainer;

namespace Runtime.Services.GameStateMachine.States
{
    public sealed class LoadState : IEnterLoadState<string>
    {
        private readonly IGameStateMachine _gameStateMachine;
        
        private ISceneLoadService _sceneLoadService;
        private IStaticDataService _staticDataService;
        private ILevelService _levelService;

        public LoadState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        [Inject]
        private void Construct(ISceneLoadService sceneLoadService, IStaticDataService staticDataService, ILevelService levelService)
        {
            _sceneLoadService = sceneLoadService;
            _staticDataService = staticDataService;
            _levelService = levelService;
        }

        void IEnterLoadState<string>.Enter(string sceneName)
        {
            _staticDataService.Load();
            _levelService.Init();
            
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