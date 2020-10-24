using CreateWithCodeGameJam2020.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreateWithCodeGameJam2020.Scripts
{
    public abstract class Interactable : MonoBehaviour
    {
        [SerializeField]
        private Renderer _renderer;

        [SerializeField]
        private Material _interactMaterial; 

        private Material _startMaterial;
        private bool _canInteract = false;
        protected bool _isTriggered = false;

        protected virtual void OnEnable()
        {
            PlayerInput.onInteract += Interacted;
        }

        private void Start()
        {
            _startMaterial = _renderer.material;
        }


        private void OnTriggerEnter(Collider other)
        {
            if (_isTriggered)
                return;

            //detect if player is there
            if (other.tag == "Player")
            {
                //change state to interactable and highlight object
                _renderer.material = _interactMaterial;
                _canInteract = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (_isTriggered)
                return;

            //detect if player is there
            if (other.tag == "Player")
            {
                //change state to not interactable and highlight object
                _renderer.material = _startMaterial;
                _canInteract = false;
            }
        }

        private void Interacted ()
        {
            if (_canInteract)
                BeginInteraction();
        }

        protected virtual void BeginInteraction ()
        {
            _renderer.material = _startMaterial;
        }

        protected virtual void OnDisable()
        {
            PlayerInput.onInteract -= Interacted;
        }
    }
}
