using CreateWithCodeGameJam2020.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreateWithCodeGameJam2020.Scripts
{
    public class Door : Interactable
    {
        [SerializeField]
        private bool _isLocked = false;

        [SerializeField]
        private Animator _animator;

        protected override void OnEnable()
        {
            base.OnEnable();
            Button.onButtonPressed += UnLockDoor;
        }

        protected override void BeginInteraction()
        {
            //check if door is locked
            if (!_isLocked)
            {
                base.BeginInteraction();
                //begin open animation
                _animator.SetTrigger("OpenDoor");
                _isTriggered = true;
            }   
        }

        private void UnLockDoor (GameObject interactCheck)
        {
            //check if the the item being interacted with is this
            if (interactCheck == this.gameObject)
            {
                //set locked state to unlocked;
                _isLocked = false;
                //TODO: play unlock sound
                print("Unlocked");
            }
        }

        protected override void OnDisable()
        {
            base.OnEnable();
            Button.onButtonPressed -= UnLockDoor;
        }
    }
}