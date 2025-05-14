using Game.Scripts.Services.AssetService;
using Game.Scripts.Services.Factories.ScreenFactory;
using Game.Scripts.Services.Factories.StateMachineFactory;
using Game.Scripts.Services.GameStateMachine.States;
using Game.Scripts.Services.LevelService;
using Game.Scripts.Services.SceneLoadService;
using Game.Scripts.Services.StaticDataService;
using Game.Scripts.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Installers
{
    public sealed class GameInstaller : LifetimeScope
    {
        [SerializeField] private UIRoot _uiRoot;
        [SerializeField] private int _level = 1;

        protected override void Awake()
        {
            base.Awake();
            
            DontDestroyOnLoad(this);
        }

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.RegisterComponentInNewPrefab(_uiRoot, Lifetime.Singleton).DontDestroyOnLoad();
            
            builder.Register<IAssetService, AssetService>(Lifetime.Singleton);
            builder.Register<IStaticDataService, StaticDataService>(Lifetime.Singleton);
            builder.Register<ILevelService, LevelService>(Lifetime.Singleton).WithParameter(_level);
            builder.Register<ISceneLoadService, SceneLoadService>(Lifetime.Singleton);
            builder.Register<IStateMachineFactory, StateMachineFactory>(Lifetime.Singleton);
            builder.Register<IScreenFactory, ScreenFactory>(Lifetime.Singleton);

            builder.RegisterBuildCallback(CreateGameStateMachine);
        }
        
        private static void CreateGameStateMachine(IObjectResolver container)
        {
            container.Resolve<IStateMachineFactory>().CreateGameStateMachine().Enter<BootstrapState>();
        }
    }
}
