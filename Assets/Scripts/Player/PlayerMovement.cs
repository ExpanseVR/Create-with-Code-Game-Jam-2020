using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController _characterController;

    [SerializeField]
    private float _movementSpeed;
    
    // Update is called once per frame
    void Update()
    {
        //get player input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;


        //move player based on input
        _characterController.Move(move * _movementSpeed * Time.deltaTime);
    }
}
