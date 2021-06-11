using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    [Serializable]
    public struct DropChanceSettings
    {
        [Range(0, 100)]
        public float percentage;

    }
    public static class RandomValues
    {
        public static bool CalculateDropChance(in DropChanceSettings settings)
        {
            if(settings.percentage == 100)
                return true;

            float drawnValue = UnityEngine.Random.Range(0, 100);

            return drawnValue < settings.percentage;

        }

        public static void Shuffle<T>(ref List<T> list)
        {
            int count = list.Count;

            while(count > 1)
            {
                count--;
                int k = UnityEngine.Random.Range(0, count + 1);
                T value = list[k];
                list[k] = list[count];
                list[count] = value;
            }
        }
    }
}
