namespace Runtime.Utils
{
    public static class Constants
    {
        public static class Format
        {
            public const string REWARD = "{0} x{1}";
            public const string LEVEL = "Level {0}";
        }
        
        public static class AssetAddress
        {
            public const string UI_DATA_PATH = "StaticData/UIData";
            public const string REWARD_DATA_PATH = "StaticData/RewardData";
            public const string LEVEL_DATA_PATH = "StaticData/LevelData";
        }
        
        public static class SceneName
        {
            public const string BOOTSTRAP = "Bootstrap";
            public const string GAME = "Game";
        }
        
        public static class EditorAutoLoadScene
        {
            public const string SCENE_PATH = "Assets/Scenes/Bootstrap.unity";
            public const string KEY = "auto_load_scene_key";
        }
    }
}