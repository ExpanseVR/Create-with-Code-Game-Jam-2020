﻿using UnityEngine;

namespace CreateWithCodeGameJam2020.Utility
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    Debug.LogError(typeof(T).ToString() + " is NULL");
                }

                return _instance;
            }
        }

        private void Awake()
        {
            _instance = this as T;
        }
    }
}