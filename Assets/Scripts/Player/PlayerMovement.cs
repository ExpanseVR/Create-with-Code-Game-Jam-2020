using CreateWithCodeGameJam2020.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController _characterController;

    [SerializeField]
    private float _movementSpeed;

    [SerializeField]
    private AudioSource _audioSource;

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

        //get player input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        if (move != Vector3.zero)
        {
            //move player based on input
            _characterController.Move(move * _movementSpeed * Time.deltaTime);
            //check if audio isnt already playing
            if (!_audioSource.isPlaying)
                _audioSource.Play();
        }
        else
            _audioSource.Stop();
    }

    private void SetEnabled(bool isEnabled)
    {
        if (!isEnabled)
            _audioSource.Stop();

        _isEnabled = isEnabled;
    }

    private void OnDisable()
    {
        FluteMenu.onMenuOpen -= SetEnabled;
    }
}
