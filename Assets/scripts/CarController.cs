using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody rb;
    public float velocidade;


    float horizontalaxis;
    float verticalaxis;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        horizontalaxis = Input.GetAxis("Horizontal");
        verticalaxis = Input.GetAxis("Vertical");

    }

    private void FixedUpdate()
    {
        Vector3 andar = new Vector3(horizontalaxis * -velocidade, rb.velocity.y, verticalaxis * velocidade);
        rb.velocity = andar;

    }
}


