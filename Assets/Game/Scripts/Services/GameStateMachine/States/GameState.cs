using Game.Scripts.Services.Factories.ScreenFactory;
using VContainer;

namespace Game.Scripts.Services.GameStateMachine.States
{
    public sealed class GameState : IEnterState
    {
        private readonly IGameStateMachine _gameStateMachine;
        
        private IScreenFactory _screenFactory;

        public GameState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        [Inject]
        private void Construct(IScreenFactory screenFactory)
        {
            _screenFactory = screenFactory;
        }

        void IEnterState.Enter()
        {
            _screenFactory.CreateMainUiController();
        }

        void IExitState.Exit()
        {
        }
    }
}