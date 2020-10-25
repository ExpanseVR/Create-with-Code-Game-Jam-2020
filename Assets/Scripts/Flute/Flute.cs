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
        public static event Action<string> onPlayMelody;
        public static event Action<GameManager.Worlds> onChangeWorld;

        [SerializeField]
        private AudioClip[] _fluteNotes;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private GameObject _fluteModel;

        [SerializeField]
        private Transform _player;

        [SerializeField]
        private List<AudioClip> _melodyNotes = new List<AudioClip>();

        [SerializeField]
        private string _worldCode;
        
        private string[] _melody = new string[14];
        private int _melodyCount = 0;
        private bool _isFluteReady = false;
        private bool _playingMelody = false;
        
        protected override void BeginInteraction()
        {
            base.BeginInteraction();
            _fluteModel.SetActive(false);
            PlayerManager.Instance.SetHasFlute(true);
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
            StartCoroutine(PlayMelody());
        }

        public void SetMelody (string[] melody, int melodyCount)
        {
            _melody = melody;
            _melodyCount = melodyCount;
        }

        IEnumerator PlayMelody()
        {
            //check if playing mellody
            if (!_playingMelody && _isFluteReady)
            {
                string newMelody = "";
                //set playingmelody
                _playingMelody = true;

                //play through each note in melody
                int i = 0;
                while (i < _melodyCount)
                {
                    int note;
                    switch (_melody[i])
                    {
                        case "C":
                            note = 0;
                            break;
                        case "D":
                            note = 1;
                            break;
                        case "E":
                            note = 2;
                            break;
                        case "F":
                            note = 3;
                            break;
                        case "G":
                            note = 4;
                            break;
                        case "A":
                            note = 5;
                            break;
                        default:
                            note = 6;
                            break;
                    }
                    _audioSource.PlayOneShot(_melodyNotes[note], 0.6f);
                    yield return new WaitForSeconds(_melodyNotes[note].length - 1.4f);

                    //assemble melody to check
                    newMelody += _melody[i];
                    i++;
                }

                //Broadcast melody to listeners
                onPlayMelody?.Invoke(newMelody);
                //switch worlds
                if (_worldCode == newMelody)
                {
                    if (GameManager.Instance.GetCurrentWorld() != GameManager.Worlds.Red)
                        onChangeWorld?.Invoke(GameManager.Worlds.Red);
                    else
                        onChangeWorld?.Invoke(GameManager.Worlds.Real);
                }
            }
            _playingMelody = false;
        }
    }
}
