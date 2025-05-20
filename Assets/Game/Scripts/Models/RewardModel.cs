using Runtime.Utils;

namespace Runtime.Models
{
    public sealed class RewardModel
    {
        public readonly string Type;
        public readonly int Count;

        public RewardModel(string type, int count)
        {
            Type = type;
            Count = count;
        }

        public override string ToString() => string.Format(Constants.Format.REWARD, Type, Count.ToString());
    }
}