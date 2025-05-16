using Game.Scripts.Models;
using Game.Scripts.Services.StaticDataService;
using Game.Scripts.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Services.Factories.ScreenFactory
{
    public sealed class ScreenFactory : IScreenFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly IStaticDataService _staticDataService;
        private readonly UIRoot _uiRoot;

        public ScreenFactory(IObjectResolver objectResolver, IStaticDataService staticDataService, UIRoot uiRoot)
        {
            _objectResolver = objectResolver;
            _staticDataService = staticDataService;
            _uiRoot = uiRoot;
        }
        
        MainUIController IScreenFactory.CreateMainUiController() => 
            _objectResolver.Instantiate(_staticDataService.GetUIData().MainUIControllerPrefab, _uiRoot.MainRoot);

        LevelPopupController IScreenFactory.CreateLevelPopupController() => 
            _objectResolver.Instantiate(_staticDataService.GetUIData().LevelPopupControllerPrefab, _uiRoot.PopupRoot);

        RewardItemView IScreenFactory.CreateRewardItemView(RewardModel rewardModel, Transform root)
        {
            RewardItemView rewardItemView = _objectResolver.Instantiate(_staticDataService.GetUIData().RewardItemViewPrefab, root);
            rewardItemView.Init(rewardModel.ToString());
            return rewardItemView;
        }
    }
}