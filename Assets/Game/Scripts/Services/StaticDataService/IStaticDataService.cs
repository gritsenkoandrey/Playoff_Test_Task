using Runtime.Services.StaticDataService.Data;

namespace Runtime.Services.StaticDataService
{
    public interface IStaticDataService
    {
        void Load();
        UIData GetUIData();
        RewardData GetRewardData();
        LevelData GetLevelData();
    }
}