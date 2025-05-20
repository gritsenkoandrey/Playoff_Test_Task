using UnityEngine;

namespace Runtime.Services.AssetService
{
    public sealed class AssetService : IAssetService
    {
        T IAssetService.LoadFromResources<T>(string path) => Resources.Load<T>(path);
    }
}