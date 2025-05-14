using System.Collections.Generic;
using Game.Scripts.Models;
using Game.Scripts.Utils.Extensions;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Services.LevelService
{
    public sealed class LevelService : ILevelService
    {
        private readonly string[] _rewardTypes;
        private readonly LevelModel _levelModel;

        public LevelService(int level)
        {
            Level = new ReactiveProperty<int>(level);
            
            _rewardTypes = new []
            {
                "Gold", "Gem", "Potion", "Key", "Scroll"
            };

            _levelModel = new LevelModel
            {
                Number = level,
                Rewards = new List<RewardModel>(_rewardTypes.Length)
            };
        }

        public IReactiveProperty<int> Level { get; }

        LevelModel ILevelService.GenerateLevel()
        {
            int count = GenerateRandom(1, _rewardTypes.Length + 1);

            _levelModel.Number++;
            _levelModel.Rewards.Clear();
            _rewardTypes.Shuffle();
            
            for (int i = 0; i < count; i++)
            {
                _levelModel.Rewards.Add(GenerateReward(i));
            }

            return _levelModel;
        }

        void ILevelService.UpdateLevel() => 
            Level.Value = _levelModel.Number;

        private RewardModel GenerateReward(int index) => 
            new(_rewardTypes[index], GenerateRandom(1, 100));

        private static int GenerateRandom(int min, int max) => 
            Random.Range(min, max);
    }
}