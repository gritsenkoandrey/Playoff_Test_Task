using Game.Scripts.Services.StaticDataService.Data;

namespace Game.Scripts.Services.StaticDataService
{
    public interface IStaticDataService
    {
        void Load();
        UIData GetUIData();
    }
}