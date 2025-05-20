using System.Collections.Generic;
using Runtime.Utils;

namespace Runtime.Models
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

        public override string ToString() => string.Format(Constants.Format.LEVEL, Number.ToString());
    }
}