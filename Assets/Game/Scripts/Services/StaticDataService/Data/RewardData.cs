using Game.Scripts.Utils;
using UnityEngine;

namespace Game.Scripts.Services.StaticDataService.Data
{
    [CreateAssetMenu(fileName = nameof(RewardData), menuName = "Configs/Data/" + nameof(RewardData))]
    public sealed class RewardData : ScriptableObject
    {
        public string[] Rewards;
        public MinMax MinMaxCurrency;
    }
}