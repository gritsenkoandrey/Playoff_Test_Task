using UnityEngine;

namespace Game.Scripts.Services.AssetService
{
    public sealed class AssetService : IAssetService
    {
        T IAssetService.LoadFromResources<T>(string path) => Resources.Load<T>(path);
    }
}