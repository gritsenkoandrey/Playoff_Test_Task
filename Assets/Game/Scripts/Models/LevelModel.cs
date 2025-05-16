using System.Collections.Generic;
using Game.Scripts.Utils;

namespace Game.Scripts.Models
{
    public sealed class LevelModel
    {
        public int Number;
        public readonly List<RewardModel> Rewards;

        public LevelModel(int number, List<RewardModel> rewards)
        {
            Number = number;
            Rewards = rewards;
        }

        public override string ToString() => string.Format(Format.Level, Number.ToString());
    }
}