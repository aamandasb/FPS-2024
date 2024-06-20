using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    const float speed = 5;
    const float throwForceUp = 5;
    const float throwForceForward = 10;

    CharacterController characterController;
    PlayerGravity playerGravity ;
    Transform camTransform;
    Weapon weapon;
    [SerializeField] GameObject grenadePrefab;
    [SerializeField] Transform throwPoint;
    [SerializeField] float mouseSensitivity;

    Vector3 direction;
    Vector2 camDirection;

    float verticalRotation;
    bool shooting, crounching;
    

    private void Awake()
    {
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
        camTransform = gameObject.transform.GetChild(0);
        playerGravity = GetComponent<PlayerGravity>();
    }

    private void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        camDirection.x = Input.GetAxis("Mouse X");
        camDirection.y = Input.GetAxis("Mouse Y");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            ThrowGrenade();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Crounch();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shooting = true;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            shooting = false;
        }

        Movement();
        Rotation();
        Fire();
    }



    private void Movement()
    {
        float newSpeed = crounching ? speed / 2 : speed;

        Vector3 velocity = (direction.x * transform.right + direction.z * transform.forward) * newSpeed * Time.deltaTime;

        characterController.Move(velocity);
    }

    private void Rotation()
    {
        camDirection *= mouseSensitivity * Time.deltaTime;

        verticalRotation -= camDirection.y;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);

        camTransform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        transform.Rotate(Vector3.up * camDirection.x);
    }

    private void Fire()
    {
        if (shooting)
        {
            weapon.Fire();
        }
    }

    private void Jump()
    {
        playerGravity.Jump();
    }

    private void Crounch()
    {
        crounching = !crounching;
    }

    private void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, throwPoint.position, throwPoint.rotation);

        Vector3 throwForce = transform.up * throwForceUp + camTransform.forward * throwForceForward;

        grenade.GetComponent<Rigidbody>().AddForce(throwForce, ForceMode.Impulse);

        Destroy(grenade, 10);
    }
}
