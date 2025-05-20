using Runtime.Services.AssetService;
using Runtime.Services.StaticDataService.Data;
using Runtime.Utils;

namespace Runtime.Services.StaticDataService
{
    public sealed class StaticDataService : IStaticDataService
    {
        private readonly IAssetService _assetService;

        private UIData _uiData;
        private RewardData _rewardData;
        private LevelData _levelData;

        public StaticDataService(IAssetService assetService)
        {
            _assetService = assetService;
        }
        
        void IStaticDataService.Load()
        {
            _uiData = _assetService.LoadFromResources<UIData>(Constants.AssetAddress.UI_DATA_PATH);
            _rewardData = _assetService.LoadFromResources<RewardData>(Constants.AssetAddress.REWARD_DATA_PATH);
            _levelData = _assetService.LoadFromResources<LevelData>(Constants.AssetAddress.LEVEL_DATA_PATH);
        }

        UIData IStaticDataService.GetUIData() => _uiData;
        
        RewardData IStaticDataService.GetRewardData() => _rewardData;
        
        LevelData IStaticDataService.GetLevelData() => _levelData;
    }
}