namespace Game.Scripts.Models
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
    }
}