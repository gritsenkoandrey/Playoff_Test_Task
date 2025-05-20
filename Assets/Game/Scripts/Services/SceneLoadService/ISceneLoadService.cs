using System;

namespace Runtime.Services.SceneLoadService
{
    public interface ISceneLoadService
    {
        void Load(string name, Action onLoaded);
    }
}