using System;

namespace Game.Scripts.Services.SceneLoadService
{
    public interface ISceneLoadService
    {
        void Load(string name, Action onLoaded);
    }
}