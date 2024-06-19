using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    PlayerGravity playerGravity ;
    Transform camTransform;
    Weapon weapon;
    GameObject grenade;
    Transform throwPoint;

    Vector3 direction;
    Vector2 camDirection;

    const float speed = 0;
    float verticalRotation, mouseSensitivity;
    bool shooting, crouching;
    

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
        camTransform = gameObject.transform.GetChild(0);
    }

    private void Update()
    {
        
    }

    private void Movement()
    {

    }

    private void Rotation()
    {

    }

    private void Fire()
    {

    }

    private void Jump()
    {

    }

    private void Crouch()
    {

    }

    private void ThrowGrenade()
    {

    }
}
