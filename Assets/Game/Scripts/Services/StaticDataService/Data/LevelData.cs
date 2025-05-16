using UnityEngine;

namespace Game.Scripts.Services.StaticDataService.Data
{
    [CreateAssetMenu(fileName = nameof(LevelData), menuName = "Configs/Data/" + nameof(LevelData))]
    public sealed class LevelData : ScriptableObject
    {
        public int StartLevel;
    }
}