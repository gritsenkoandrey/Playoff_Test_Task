using System;

namespace Runtime.Utils
{
    [Serializable]
    public struct MinMax
    {
        public int Min;
        public int Max;

        public MinMax(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }
}