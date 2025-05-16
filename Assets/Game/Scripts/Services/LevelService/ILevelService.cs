using Game.Scripts.Models;
using UniRx;

namespace Game.Scripts.Services.LevelService
{
    public interface ILevelService
    {
        void Init();
        public ReactiveProperty<LevelModel> LevelModel { get; }
        void GenerateLevel();
        void UpdateLevel();
    }
}