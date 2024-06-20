using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    bool onGround;

    Vector3 velocity;

    float jumpHeight;

    CharacterController characterController;

    [SerializeField] Vector3 offset;

    [SerializeField] float radius;

    [SerializeField] LayerMask groundMask;

    void Start()
    {
        
    }

    private void Update()
    {
        CheckGround();
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void CheckGround()
    {
        onGround = Physics.CheckSphere(transform.position + offset, radius, groundMask);

        if (onGround && velocity.y < 0)
        {
            velocity = Vector3.zero;
        }
        else
        {
            velocity += Physics.gravity * Time.deltaTime;
        }

        velocity += Physics.gravity;

        characterController.Move(velocity);
    }
    public void Jump()
    {
        if (onGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
        }
    }


    private void Movement()
    {

    }
}
