using UnityEngine;

namespace Runtime.Services.AssetService
{
    public interface IAssetService
    {
        T LoadFromResources<T>(string path) where T : Object;
    }
}