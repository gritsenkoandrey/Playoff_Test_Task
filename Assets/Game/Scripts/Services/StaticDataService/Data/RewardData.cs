using Runtime.Utils;
using UnityEngine;

namespace Runtime.Services.StaticDataService.Data
{
    [CreateAssetMenu(fileName = nameof(RewardData), menuName = "Configs/Data/" + nameof(RewardData))]
    public sealed class RewardData : ScriptableObject
    {
        public string[] Rewards;
        public MinMax MinMaxCurrency;
    }
}