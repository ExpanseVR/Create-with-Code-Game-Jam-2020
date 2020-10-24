using CreateWithCodeGameJam2020.FlutePlayer;
using CreateWithCodeGameJam2020.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace CreateWithCodeGameJam2020.Manager
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public enum Worlds
        {
            Real,
            Red
        }

        [SerializeField]
        private Volume _volume;

        [SerializeField]
        private AudioClip[] _worldsMusic;

        [SerializeField]
        private AudioSource _audioSource;
        
        private ColorAdjustments _colorAdjustments;
        private Worlds _currentWorld = Worlds.Real;

        private void OnEnable()
        {
            Flute.onChangeWorld += ChangeWorld;
        }

        void Start()
        {
            ColorAdjustments tmp;
            if (_volume.profile.TryGet(out tmp))
            {
                _colorAdjustments = tmp;
            }
        }

        public Worlds GetCurrentWorld ()
        {
            return _currentWorld;
        }

        public void ChangeWorld (Worlds world)
        {
            //stop music
            _audioSource.Stop();

            //check for world and set the world;
            if (world == Worlds.Red)
            {
                _colorAdjustments.active = true;
                _currentWorld = Worlds.Red;
                _audioSource.clip = _worldsMusic[1];
            }
            else
            {
                _colorAdjustments.active = false;
                _currentWorld = Worlds.Real;
                _audioSource.clip = _worldsMusic[0];
            }

            //play new music
            _audioSource.Play();
        }

        private void OnDisable()
        {
            Flute.onChangeWorld -= ChangeWorld;
        }
    }
}