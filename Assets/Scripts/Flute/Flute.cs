using CreateWithCodeGameJam2020.Scripts;
using UnityEngine;
using CreateWithCodeGameJam2020.Manager;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CreateWithCodeGameJam2020.FlutePlayer
{
    public class Flute : Item
    {
        public static event Action onPlayNote;
        public static event Action<GameManager.Worlds> onChangeWorld;

        [SerializeField]
        private AudioClip[] _fluteNotes;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private GameObject _fluteModel;

        [SerializeField]
        Transform _player;

        [SerializeField]
        List<AudioClip> _melody = new List<AudioClip>();

        private bool _isFluteReady = false;
        private bool _playingMelody = false;
        

        private void Update()
        {
            //Debug TOREMOVE
            if (Input.GetKeyDown(KeyCode.T))
                StartCoroutine(PlayMelody());
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

        public void ReadyFlute()
        {
            _isFluteReady = !_isFluteReady;
            _fluteModel.SetActive(_isFluteReady);
        }

        public bool GetFluteIsReady()
        {
            return _isFluteReady;
        }    

        public void PlayNote()
        {
            _audioSource.PlayOneShot(_fluteNotes[0], 0.6f);
            onPlayNote?.Invoke();
        }

        IEnumerator PlayMelody()
        {
            //check if playing mellody
            if (!_playingMelody && _isFluteReady)
            {
                //set playingmelody
                _playingMelody = true;

                //play through each note in melody
                int i = 0;
                while (i < _melody.Count)
                {
                    _audioSource.PlayOneShot(_melody[i], 0.6f);
                    yield return new WaitForSeconds(_melody[i].length - 1.4f);
                    i++;
                }

                //switch worlds
                if (GameManager.Instance.GetCurrentWorld() != GameManager.Worlds.Red)
                    onChangeWorld?.Invoke(GameManager.Worlds.Red);
                else
                    onChangeWorld?.Invoke(GameManager.Worlds.Real);
            }
            _playingMelody = false;
        }
    }
}
