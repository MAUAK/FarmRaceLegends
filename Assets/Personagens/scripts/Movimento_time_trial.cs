using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Movimento_time_trial : MonoBehaviour
{
    public float Speed;
    public float acelerar;
    public float rotateSpeed;
    private Vector3 moveDirection = Vector3.zero;
    private Rigidbody rb;
    public TMP_Text tempotxt;
    float temposec;
    float tempomin;
    public Scrollbar velocidadeatual;
    float tempodrift;
    bool turbo;
    float tempoturbo;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        velocidadeatual.size = acelerar;
        temposec = temposec + Time.deltaTime;
        if (temposec < 60)
        {
            if (temposec > 10)
            {
                tempotxt.text = "Tempo: " + tempomin + ":" + temposec.ToString("0.00").Replace(',', ':'); 
            }
            else 
            {
                tempotxt.text = "Tempo: " + tempomin + ":0" + temposec.ToString("0.00").Replace(',', ':');
            }
        }
        else {
            tempomin++;
            temposec = 0;
        }
        
        CharacterController controller = GetComponent<CharacterController>();

        if (Input.GetAxis("Fire1") == 1 && acelerar<1) 
        {
            acelerar = acelerar + 0.05f;
        }
        if (Input.GetAxis("Fire1") == 0 && acelerar > 0)
        {
            acelerar = acelerar - 0.01f;
        }
        if (acelerar < 0)
        {
            acelerar = 0;
        }
        moveDirection = new Vector3(rb.velocity.x, rb.velocity.y, acelerar*-1);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= Speed;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rotateSpeed *= 1.5f;
            Speed *= 0.8f;
        }
        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            print(tempodrift+"tempodrift");
            tempodrift = tempodrift + Time.deltaTime;
            if (tempodrift > 4) 
            {
                turbo = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            tempodrift = 0;
            rotateSpeed *= 0.66667f;
            Speed *= 1.25f;
        }
        if (tempodrift == 0 && turbo && tempoturbo<3)
        {
            tempoturbo = tempoturbo+Time.deltaTime;
            print(tempoturbo+"tempoturbo");
        }

        controller.Move(moveDirection * Time.deltaTime);
     
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
    }
}
