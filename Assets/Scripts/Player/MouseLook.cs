using CreateWithCodeGameJam2020.UI;
using CreateWithCodeGameJam2020.Utility;
using UnityEngine;

namespace CreateWithCodeGameJam2020.Player
{
    public class MouseLook : MonoSingleton<MouseLook>
    {
        [SerializeField]
        private float _mouseSensativity = 50f;

        [SerializeField]
        private Transform _player;

        private float _mouseSensitivityModifier;

        private bool _isEnabled = true;
        private float _xRotation = 0f;

        private void OnEnable()
        {
            FluteMenu.onMenuOpen += SetEnabled;
        }

        private void Start()
        {
            #if UNITY_EDITOR
            Debug.Log("Unity Editor");
            _mouseSensitivityModifier = 1f;

            #elif UNITY_WEBGL
            Debug.Log("Unity iPhone");
            _mouseSensitivityModifier = 0.22f;

            #endif
        }

        // Update is called once per frame
        void Update()
        {
            if (!_isEnabled)
                return;
            //Get mouse input
            float mouseX = Input.GetAxis("Mouse X") * _mouseSensativity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * _mouseSensativity * Time.deltaTime;

            
            //Convert Y direction to face up and down
            _xRotation -= mouseY;
            //clamp up and down
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

            //Convert X direction to rotate player
            _player.Rotate(Vector3.up, mouseX);
        }

        private void SetEnabled (bool isEnabled)
        {
            _isEnabled = isEnabled;
        }

        private void OnDisable()
        {
            FluteMenu.onMenuOpen -= SetEnabled;
        }
    }
}