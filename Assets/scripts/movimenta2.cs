    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimenta2 : MonoBehaviour
{
    public float Speed = 2.0f;
    public float JumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float rotateSpeed = 3.0f;
    private Vector3 moveDirection = Vector3.zero;
    private Animator animator;
    //public bool Ani;

    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical2"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= Speed;

            if (Input.GetButton("Jump"))
                moveDirection.y = JumpSpeed;
        }

        //animator.SetBool("Andando", Ani);

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        /*if (Input.GetAxis("Vertical") != 0)
        {

            Ani = true;
        }
        else
        {
            Ani = false;
        }*/
        transform.Rotate(0, Input.GetAxis("Horizontal2"), 0);
    }
}
