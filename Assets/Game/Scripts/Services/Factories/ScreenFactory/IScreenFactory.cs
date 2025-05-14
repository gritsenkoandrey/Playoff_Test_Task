using Game.Scripts.Models;
using Game.Scripts.UI;
using UnityEngine;

namespace Game.Scripts.Services.Factories.ScreenFactory
{
    public interface IScreenFactory
    {
        MainUIController CreateMainUiController();
        LevelPopupController CreateLevelPopupController();
        RewardItemView CreateRewardItemView(RewardModel rewardModel, Transform root);
    }
}