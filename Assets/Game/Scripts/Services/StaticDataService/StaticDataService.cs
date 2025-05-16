using Game.Scripts.Services.AssetService;
using Game.Scripts.Services.StaticDataService.Data;

namespace Game.Scripts.Services.StaticDataService
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
            _uiData = _assetService.LoadFromResources<UIData>(AssetAddress.UIDataPath);
            _rewardData = _assetService.LoadFromResources<RewardData>(AssetAddress.RewardDataPath);
            _levelData = _assetService.LoadFromResources<LevelData>(AssetAddress.LevelDataPath);
        }

        UIData IStaticDataService.GetUIData() => _uiData;
        
        RewardData IStaticDataService.GetRewardData() => _rewardData;
        
        LevelData IStaticDataService.GetLevelData() => _levelData;
    }
}