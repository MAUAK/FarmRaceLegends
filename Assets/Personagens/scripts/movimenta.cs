using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimenta : MonoBehaviour
{
    public float Speed = 2.0f;
    public float JumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float rotateSpeed = 3.0f;
    private Vector3 moveDirection = Vector3.zero;
    private Animator animator;
    //public bool Ani;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= Speed;

            /*if (Input.GetButton("Jump"))
                moveDirection.y = JumpSpeed;*/
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
    }
}
