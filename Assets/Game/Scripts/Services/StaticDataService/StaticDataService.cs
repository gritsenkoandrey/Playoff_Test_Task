using Game.Scripts.Services.AssetService;
using Game.Scripts.Services.StaticDataService.Data;

namespace Game.Scripts.Services.StaticDataService
{
    public sealed class StaticDataService : IStaticDataService
    {
        private readonly IAssetService _assetService;

        private UIData _uiData;

        public StaticDataService(IAssetService assetService)
        {
            _assetService = assetService;
        }
        
        void IStaticDataService.Load()
        {
            _uiData = _assetService.LoadFromResources<UIData>(AssetAddress.UIDataPath);
        }

        UIData IStaticDataService.GetUIData() => _uiData;
    }
}