using Game.Scripts.Models;
using Game.Scripts.UI;
using UnityEngine;

namespace Game.Scripts.Services.Factories.ScreenFactory
{
    public interface IScreenFactory
    {
        MainUIController CreateMainUiController();
        LevelPopupController CreateLevelPopupController(LevelModel levelModel);
        RewardItemView CreateRewardItemView(RewardModel rewardModel, Transform root);
    }
}