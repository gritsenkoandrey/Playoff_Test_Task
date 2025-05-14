using Game.Scripts.Models;
using Game.Scripts.Services.StaticDataService;
using Game.Scripts.UI;
using Game.Scripts.Utils;
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
        
        MainUIController IScreenFactory.CreateMainUiController()
        {
            return _objectResolver.Instantiate(_staticDataService.GetUIData().MainUIControllerPrefab, _uiRoot.MainRoot);
        }

        LevelPopupController IScreenFactory.CreateLevelPopupController(LevelModel levelModel)
        {
            LevelPopupController popup = _objectResolver.Instantiate(_staticDataService.GetUIData().LevelPopupControllerPrefab, _uiRoot.PopupRoot);
            
            popup.Init(levelModel);

            return popup;
        }

        RewardItemView IScreenFactory.CreateRewardItemView(RewardModel rewardModel, Transform root)
        {
            RewardItemView rewardItemView = _objectResolver.Instantiate(_staticDataService.GetUIData().RewardItemViewPrefab, root);

            string reward = string.Format(Format.Reward, rewardModel.Type, rewardModel.Count.ToString());

            rewardItemView.Init(reward);

            return rewardItemView;
        }
    }
}