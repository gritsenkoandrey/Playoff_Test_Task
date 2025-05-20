using Game.Scripts.Services.AssetService;
using Game.Scripts.Services.Factories.ScreenFactory;
using Game.Scripts.Services.Factories.StateMachineFactory;
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

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            
            builder.RegisterComponentInNewPrefab(_uiRoot, Lifetime.Singleton).DontDestroyOnLoad();
            
            builder.Register<IAssetService, AssetService>(Lifetime.Singleton);
            builder.Register<IStaticDataService, StaticDataService>(Lifetime.Singleton);
            builder.Register<ILevelService, LevelService>(Lifetime.Singleton);
            builder.Register<ISceneLoadService, SceneLoadService>(Lifetime.Singleton);
            builder.Register<IStateMachineFactory, StateMachineFactory>(Lifetime.Singleton);
            builder.Register<IScreenFactory, ScreenFactory>(Lifetime.Singleton);
        }
    }
}
