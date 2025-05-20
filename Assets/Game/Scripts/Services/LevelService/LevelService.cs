using System.Collections.Generic;
using System.Linq;
using Runtime.Models;
using Runtime.Services.StaticDataService;
using Runtime.Services.StaticDataService.Data;
using Runtime.Utils;
using Runtime.Utils.Extensions;
using UniRx;
using UnityEngine;

namespace Runtime.Services.LevelService
{
    public sealed class LevelService : ILevelService
    {
        private readonly IStaticDataService _staticDataService;
        
        private string[] _rewardTypes;
        private MinMax _minMaxReward;
        private MinMax _minMaxCurrency;

        public LevelService(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public ReactiveProperty<LevelModel> LevelModel { get; private set; }

        void ILevelService.Init()
        {
            RewardData rewardData = _staticDataService.GetRewardData();
            LevelData levelData = _staticDataService.GetLevelData();

            _rewardTypes = rewardData.Rewards.ToArray();
            _minMaxCurrency = rewardData.MinMaxCurrency;
            _minMaxReward = new MinMax(1, _rewardTypes.Length);
            
            LevelModel levelModel = new (levelData.StartLevel, 
                new List<RewardModel>(_rewardTypes.Length));
            
            LevelModel = new ReactiveProperty<LevelModel>(levelModel);
        }

        void ILevelService.GenerateLevel()
        {
            int count = RangeInclusive(_minMaxReward.Min, _minMaxReward.Max);

            _rewardTypes.Shuffle();

            LevelModel.Value.Number++;
            LevelModel.Value.Rewards.Clear();

            for (int i = 0; i < count; i++)
            {
                LevelModel.Value.Rewards.Add(GenerateReward(i));
            }
        }

        void ILevelService.UpdateLevel() => 
            LevelModel.SetValueAndForceNotify(LevelModel.Value);

        private RewardModel GenerateReward(int index) => 
            new(_rewardTypes[index], RangeInclusive(_minMaxCurrency.Min, _minMaxCurrency.Max));
        
        private static int RangeInclusive(int min, int max) => 
            Random.Range(min, max + 1);
    }
}