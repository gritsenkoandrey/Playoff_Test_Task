using Game.Scripts.UI;
using UnityEngine;

namespace Game.Scripts.Services.StaticDataService.Data
{
    [CreateAssetMenu(fileName = nameof(UIData), menuName = "Configs/Data/" + nameof(UIData))]
    public sealed class UIData : ScriptableObject
    {
        public MainUIController MainUIControllerPrefab;
        public LevelPopupController LevelPopupControllerPrefab;
        public RewardItemView RewardItemViewPrefab;
    }
}