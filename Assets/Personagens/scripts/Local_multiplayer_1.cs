using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Local_multiplayer_1 : MonoBehaviour
{
    public float Speed;
    public float acelerar;
    public float rotateSpeed;
    private Vector3 moveDirection = Vector3.zero;
    public TMP_Text tempotxt;
    float temposec;
    float tempomin;
    public Scrollbar velocidadeatual;
    public Scrollbar drift;
    float tempodrift;
    bool turbo;
    float tempoturbo;
    float normalspeed;
    public int pontodecontrole;
    public TimerController controladortempo;
    public GameObject vitoria;
    public string tempovolta;
    public TMP_Text tempodavolta;
    public float gravity = 9.81f;

    void Start()
    {
        normalspeed = Speed;
    }

    void Update()
    {
        velocidadeatual.size = acelerar;
        drift.size = tempodrift / 4;

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
        else
        {
            tempomin++;
            temposec = 0;
        }


        CharacterController controller = GetComponent<CharacterController>();

        if (Input.GetAxis("Fire2") == 1 && acelerar < 1)
        {
            acelerar = acelerar + 0.05f;
        }
        if (Input.GetAxis("Fire2") == 0 && acelerar > 0)
        {
            acelerar = acelerar - 0.01f;
        }
        if (acelerar < 0)
        {
            acelerar = 0;
        }
        moveDirection = new Vector3(0, -gravity, acelerar * -1 * Speed);
        moveDirection = transform.TransformDirection(moveDirection);




        if (Input.GetButtonDown("Fire1"))
        {
            Speed = Speed * 0.8f;
            rotateSpeed *= 1.5f;
        }
        if (Input.GetButton("Fire1"))
        {
            tempodrift = tempodrift + Time.deltaTime;
            if (tempodrift > 4)
            {
                turbo = true;
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            tempodrift = 0;
            rotateSpeed *= 0.66667f;
            Speed = Speed * 1.25f;
        }
        if (tempodrift == 0 && turbo && tempoturbo < 3)
        {
            tempoturbo = tempoturbo + Time.deltaTime;
            Speed = normalspeed * 2;
        }
        else if (tempoturbo >= 3)
        {
            Speed = normalspeed;
            tempoturbo = 0;
            turbo = false;
        }

        controller.Move(moveDirection * Time.deltaTime);

        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
    }

    public void contadortempo()
    {
        pontodecontrole++;
        if (pontodecontrole == controladortempo.barreiras.Length)
        {
            vitoria.SetActive(true);
            tempovolta = tempotxt.text;
            tempodavolta.text = tempovolta;
        }
    }

}
