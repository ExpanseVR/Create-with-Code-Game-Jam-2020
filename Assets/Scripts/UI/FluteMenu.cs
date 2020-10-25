using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using CreateWithCodeGameJam2020.FlutePlayer;
using CreateWithCodeGameJam2020.Utility;
using System;

namespace CreateWithCodeGameJam2020.UI
{
    public class FluteMenu : MonoSingleton<FluteMenu>
    {
        public static event Action<bool> onMenuOpen;

        [SerializeField]
        private GameObject _fluteMenu;

        [SerializeField]
        private Flute _flute;

        [SerializeField]
        private TextMeshProUGUI[] _melodyNoteSelection;

        private string[] _melodyNotes = new string[14];
        private int _melodyNoteCount = 0;

        public void EnableMenu ()
        {
            //check if player has flute
            //if (PlayerManager.Instance.GetHasFlute())
            _fluteMenu.SetActive(true);
            //Enable mouse pointer and lock movement
            Cursor.lockState = CursorLockMode.None;
            onMenuOpen?.Invoke(false);
        }

        public void NoteSelected (string note)
        {
            //Check to see if melody is full
            if (_melodyNoteCount < 14)
            {
                //Add note to array
                _melodyNotes[_melodyNoteCount] = note;
                //Display note in Melody UI
                _melodyNoteSelection[_melodyNoteCount].text = note;
                _melodyNoteCount++;
            }
        }

        public void AcceptMelody()
        {
            //Pass Melody to Flute;
            _flute.SetMelody(_melodyNotes, _melodyNoteCount);
            ExitMenu(true);
        }

        public void ExitMenu(bool isAccepted)
        {
            if (!isAccepted)
                ResetMelody();
            //Lock mouse pointer and enable movement
            Cursor.lockState = CursorLockMode.Locked;
            onMenuOpen?.Invoke(true);
            //Close Menu
            _fluteMenu.SetActive(false);
        }

        public void ResetMelody()
        {
            //Reset Melody UI
            for (int i = 0; i < _melodyNoteCount; i++)
            {
                _melodyNoteSelection[i].text = " ";
            }
            //Reset Melody Array
            _melodyNoteCount = 0;
        }
    }
}