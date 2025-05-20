using Runtime.Models;
using Runtime.UI;
using UnityEngine;

namespace Runtime.Services.Factories.ScreenFactory
{
    public interface IScreenFactory
    {
        MainUIController CreateMainUiController();
        LevelPopupController CreateLevelPopupController();
        RewardItemView CreateRewardItemView(RewardModel rewardModel, Transform root);
    }
}