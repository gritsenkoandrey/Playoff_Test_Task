using Runtime.Services.AssetService;
using Runtime.Services.StaticDataService.Data;

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
            _uiData = _assetService.LoadFromResources<UIData>(AssetAddress.UI_DATA_PATH);
            _rewardData = _assetService.LoadFromResources<RewardData>(AssetAddress.REWARD_DATA_PATH);
            _levelData = _assetService.LoadFromResources<LevelData>(AssetAddress.LEVEL_DATA_PATH);
        }

        UIData IStaticDataService.GetUIData() => _uiData;
        
        RewardData IStaticDataService.GetRewardData() => _rewardData;
        
        LevelData IStaticDataService.GetLevelData() => _levelData;
    }
}