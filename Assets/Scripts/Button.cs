using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreateWithCodeGameJam2020.Scripts
{
    public class Button : Interactable
    {
        public static event Action<GameObject> onButtonPressed;

        [SerializeField]
        private GameObject _interactWith;

        protected override void BeginInteraction()
        {
            base.BeginInteraction();
            _isTriggered = true;
            onButtonPressed?.Invoke(_interactWith);
        }
    }
}