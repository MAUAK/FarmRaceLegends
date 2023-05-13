    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimenta2 : MonoBehaviour
{
    public float Speed;
    public float gravity = 20.0f;
    public float rotateSpeed;
    private Vector3 moveDirection = Vector3.zero;
    private Animator animator;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical2"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= Speed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal2") * rotateSpeed, 0);
    }
}
