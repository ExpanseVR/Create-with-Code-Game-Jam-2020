using CreateWithCodeGameJam2020.FlutePlayer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreateWithCodeGameJam2020.Scripts
{
    public class Door : Interactable
    {
        public enum DoorType
        {
            normal,
            magic
        }

        [SerializeField]
        private DoorType _doorType;

        [SerializeField]
        private bool _isLocked = false;

        [SerializeField]
        private Animator _animator;

        protected override void OnEnable()
        {
            base.OnEnable();
            Button.onButtonPressed += UnLockDoor;
            Flute.onPlayNote += FluteNotePlayed;
        }

        protected override void BeginInteraction()
        {
            //check if door is locked
            if (!_isLocked && _doorType == DoorType.normal)
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

        private void FluteNotePlayed ()
        {
            if (!_isTriggered && _doorType == DoorType.magic && _canInteract == true)
                _animator.SetTrigger("OpenDoor");
        }

        protected override void OnDisable()
        {
            base.OnEnable();
            Button.onButtonPressed -= UnLockDoor;
            Flute.onPlayNote -= FluteNotePlayed;
        }
    }
}