using UnityEngine;

namespace Game.Scripts.Services.AssetService
{
    public interface IAssetService
    {
        T LoadFromResources<T>(string path) where T : Object;
    }
}