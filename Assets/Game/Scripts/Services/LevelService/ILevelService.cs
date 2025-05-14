using Game.Scripts.Models;
using UniRx;

namespace Game.Scripts.Services.LevelService
{
    public interface ILevelService
    {
        IReactiveProperty<int> Level { get; }
        LevelModel GenerateLevel();
        void UpdateLevel();
    }
}