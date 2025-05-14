using System.Collections.Generic;
using Game.Scripts.Models;
using Game.Scripts.Utils;
using Game.Scripts.Utils.Extensions;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Services.LevelService
{
    public sealed class LevelService : ILevelService
    {
        private readonly string[] _rewardTypes;
        private readonly MinMax _minMaxReward;
        private readonly MinMax _minMaxCount;

        public LevelService(int level)
        {
            _rewardTypes = new []
            {
                "Gold", "Gem", "Potion", "Key", "Scroll"
            };
            
            LevelModel = new ReactiveProperty<LevelModel>(new LevelModel
            {
                Number = level,
                Rewards = new List<RewardModel>(_rewardTypes.Length)
            });

            _minMaxReward = new MinMax(1, _rewardTypes.Length + 1);
            _minMaxCount = new MinMax(1, 100);
        }

        public ReactiveProperty<LevelModel> LevelModel { get; }

        void ILevelService.GenerateLevel()
        {
            int count = Random.Range(_minMaxReward.Min, _minMaxReward.Max);

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
            new(_rewardTypes[index], Random.Range(_minMaxCount.Min, _minMaxCount.Max));
    }
}