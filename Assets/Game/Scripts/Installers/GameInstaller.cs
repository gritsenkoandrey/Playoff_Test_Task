using Runtime.Services.AssetService;
using Runtime.Services.CoroutineService;
using Runtime.Services.Factories.ScreenFactory;
using Runtime.Services.Factories.StateMachineFactory;
using Runtime.Services.LevelService;
using Runtime.Services.SceneLoadService;
using Runtime.Services.StaticDataService;
using Runtime.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Runtime.Installers
{
    public sealed class GameInstaller : LifetimeScope
    {
        [SerializeField] private UIRoot _uiRoot;
        [SerializeField] private CoroutineService _coroutineService;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            
            builder.RegisterComponentInNewPrefab(_uiRoot, Lifetime.Singleton).DontDestroyOnLoad();
            builder.RegisterComponentInNewPrefab(_coroutineService, Lifetime.Singleton).DontDestroyOnLoad().As<ICoroutineService>();
            
            builder.Register<IAssetService, AssetService>(Lifetime.Singleton);
            builder.Register<IStaticDataService, StaticDataService>(Lifetime.Singleton);
            builder.Register<ILevelService, LevelService>(Lifetime.Singleton);
            builder.Register<ISceneLoadService, SceneLoadService>(Lifetime.Singleton);
            builder.Register<IStateMachineFactory, StateMachineFactory>(Lifetime.Singleton);
            builder.Register<IScreenFactory, ScreenFactory>(Lifetime.Singleton);
        }
    }
}
