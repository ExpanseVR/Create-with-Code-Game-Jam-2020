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

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private AudioClip _unlockSound;

        [SerializeField]
        private string _notesCode;

        protected override void OnEnable()
        {
            base.OnEnable();
            Button.onButtonPressed += UnLockDoor;
            Flute.onPlayMelody += FluteNotePlayed;
        }

        protected override void BeginInteraction()
        {
            //check if door is locked
            if (!_isLocked && _doorType == DoorType.normal && !_isTriggered)
            {
                base.BeginInteraction();
                //begin open animation
                _animator.SetTrigger("OpenDoor");
                _isTriggered = true;
                _audioSource.Play();
                _audioSource.SetScheduledEndTime(AudioSettings.dspTime + 1.5f);
            }   
        }

        private void UnLockDoor (GameObject interactCheck)
        {
            //check if the the item being interacted with is this
            if (interactCheck == this.gameObject)
            {
                //set locked state to unlocked;
                _isLocked = false;
                //play unlock sound
                Invoke("PlayUnlockSound", 1f);
            }
        }

        private void PlayUnlockSound()
        {
            if (_doorType == DoorType.normal)
                _audioSource.PlayOneShot(_unlockSound, 0.8f);
        }

        private void FluteNotePlayed (string notes)
        {
            if (_notesCode != notes)
                return;

            if (!_isTriggered && _doorType == DoorType.magic && _canInteract == true)
                _animator.SetTrigger("OpenDoor");
        }

        protected override void OnDisable()
        {
            base.OnEnable();
            Button.onButtonPressed -= UnLockDoor;
            Flute.onPlayMelody -= FluteNotePlayed;
        }
    }
}