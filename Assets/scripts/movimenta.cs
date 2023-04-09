using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimenta : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(0.0f, 0.0f, moveHorizontal);
        rb.AddRelativeForce(movement * speed);

        //Vector3 rotation = new Vector3(0.0f, moveHorizontal, 0.0f);
        //rb.AddRelativeTorque(rotation * rotationSpeed);
    }
}
