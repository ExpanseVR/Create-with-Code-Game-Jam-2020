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

        [SerializeField]
        private AudioSource _audioSource;

        protected override void BeginInteraction()
        {
            base.BeginInteraction();
            onButtonPressed?.Invoke(_interactWith);
            _audioSource.Play();
        }
    }
}