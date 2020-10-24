using CreateWithCodeGameJam2020.Scripts;
using UnityEngine;
using CreateWithCodeGameJam2020.Player;
using CreateWithCodeGameJam2020.Manager;
using System;

namespace CreateWithCodeGameJam2020.FlutePlayer
{
    public class Flute : Item
    {
        public static event Action onPlayNote;

        [SerializeField]
        private AudioClip[] _fluteNotes;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private GameObject _fluteModel;

        [SerializeField]
        Transform _player;

        private bool _isFluteReady = false;

        private void Update()
        {
            //Debug TOREMOVE
            if (Input.GetKeyDown(KeyCode.T))
                PlayNote();
        }

        protected override void BeginInteraction()
        {
            base.BeginInteraction();
            _fluteModel.SetActive(false);
            PlayerManager.SetHasFlute(true);
            this.transform.SetParent(_player);
            _canInteract = false;
            CallOnGetItem(GetItemType());
        }

        public void ReadyFlute ()
        {
            _isFluteReady = !_isFluteReady;
            _fluteModel.SetActive(_isFluteReady);
        }

        public bool GetFluteIsReady()
        {
            return _isFluteReady;
        }    

        public void PlayNote ()
        {
            print("playing note");
            _audioSource.Play();
            onPlayNote?.Invoke();
        }
    }
}
