using Runtime.UI;
using UnityEngine;

namespace Runtime.Services.StaticDataService.Data
{
    [CreateAssetMenu(fileName = nameof(UIData), menuName = "Configs/Data/" + nameof(UIData))]
    public sealed class UIData : ScriptableObject
    {
        public MainUIController MainUIControllerPrefab;
        public LevelPopupController LevelPopupControllerPrefab;
        public RewardItemView RewardItemViewPrefab;
    }
}