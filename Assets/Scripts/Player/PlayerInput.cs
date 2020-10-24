using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreateWithCodeGameJam2020.Player
{
    public class PlayerInput : MonoBehaviour
    {
        public static event Action onInteract;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                onInteract?.Invoke();
            }
        }
    }
}