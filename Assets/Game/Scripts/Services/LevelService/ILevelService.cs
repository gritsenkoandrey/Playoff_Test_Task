﻿using Runtime.Models;
using UniRx;

namespace Runtime.Services.LevelService
{
    public interface ILevelService
    {
        void Init();
        ReactiveProperty<LevelModel> LevelModel { get; }
        void GenerateLevel();
        void UpdateLevel();
    }
}