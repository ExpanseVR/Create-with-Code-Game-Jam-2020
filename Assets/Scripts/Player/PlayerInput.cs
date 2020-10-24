using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreateWithCodeGameJam2020.Manager;
using CreateWithCodeGameJam2020.FlutePlayer;

namespace CreateWithCodeGameJam2020.Player
{
    public class PlayerInput : MonoBehaviour
    {
        public static event Action onInteract;

        [SerializeField]
        private Flute _flute;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                onInteract?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Space) && _flute.GetFluteIsReady())
            {
                _flute.PlayNote();
            }

            if (Input.GetKeyDown(KeyCode.Alpha1) && PlayerManager.GetHasFlute())
            {
                print("ready flute");
                _flute.ReadyFlute();
            }    
        }
    }
}