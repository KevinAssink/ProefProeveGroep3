using System.Collections.Generic;

namespace Utilities
{
    public enum StateMachineState
    {
        MAIN_MENU,
        GAME,
        PAUSED,
        GAME_OVER
    }

    public static class UtilitiesClass
    {
        private static System.Random _rng = new System.Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = _rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
