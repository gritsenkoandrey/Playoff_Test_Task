using Game.Scripts.Models;
using UniRx;

namespace Game.Scripts.Services.LevelService
{
    public interface ILevelService
    {
        public ReactiveProperty<LevelModel> LevelModel { get; }
        void GenerateLevel();
        void UpdateLevel();
    }
}