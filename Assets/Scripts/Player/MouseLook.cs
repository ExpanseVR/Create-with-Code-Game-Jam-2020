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

        private float _xRotation = 0f;

        private void Start()
        {
            //make sure cursor is not visible in game
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
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
    }
}