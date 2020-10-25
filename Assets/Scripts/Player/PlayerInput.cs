using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreateWithCodeGameJam2020.Manager;
using CreateWithCodeGameJam2020.FlutePlayer;
using CreateWithCodeGameJam2020.UI;

namespace CreateWithCodeGameJam2020.Player
{
    public class PlayerInput : MonoBehaviour
    {
        public static event Action onInteract;

        [SerializeField]
        private Flute _flute;

        private bool _isEnabled = true;

        private void OnEnable()
        {
            FluteMenu.onMenuOpen += SetEnabled;
        }

        // Update is called once per frame
        void Update()
        {
            if (!_isEnabled)
                return;

            if (Input.GetMouseButtonDown(0))
                onInteract?.Invoke();

            if (Input.GetMouseButtonDown(1))
                FluteMenu.Instance.EnableMenu();

            if (Input.GetKeyDown(KeyCode.Space) && _flute.GetFluteIsReady())
                _flute.PlayNote();

            if (Input.GetKeyDown(KeyCode.Alpha1) && PlayerManager.Instance.GetHasFlute())
                _flute.ReadyFlute();    
        }

        private void SetEnabled(bool isEnabled)
        {
            _isEnabled = isEnabled;
        }

        private void OnDisable()
        {
            FluteMenu.onMenuOpen -= SetEnabled;
        }
    }
}