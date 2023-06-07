using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

public class multiplayer_online : MonoBehaviourPun
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
    public GameObject derrota;
    public string tempovolta;
    public TMP_Text tempodavolta;
    public float gravity = 50f;
    public PhotonView photonview;
    public Camera myCamera;
    public RaceController controledacorrida;
    public int minhavolta;
    public GameObject ultimoarco;
    public int volta;
    public float distanciaarco;
    public int PL_arco;
    public int i;
    public barreira arco;
    public GameObject go;
    public bool falta1;
    public float maisperto;
    public TMP_Text ui_volta;
    public GameObject[] arcos;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "caiu") 
        {
            transform.position = ultimoarco.transform.position;
            acelerar = 0;
        }
    }

    void Start()
    {
        arcos = GameObject.FindGameObjectsWithTag("arco");
        normalspeed = Speed;

        velocidadeatual = GameObject.FindGameObjectWithTag("BARRA_VELOCIDADE").GetComponent<Scrollbar>();
        drift = GameObject.FindGameObjectWithTag("BARRA_DRIFT").GetComponent<Scrollbar>();
        tempotxt = GameObject.FindGameObjectWithTag("TXT_TEMPO").GetComponent<TMP_Text>();
        vitoria = GameObject.FindGameObjectWithTag("tela_vitoria");
        derrota = GameObject.FindGameObjectWithTag("tela_derrota");


        photonview = GetComponent<PhotonView>();

        if (!photonView.IsMine)
        {
            myCamera.gameObject.SetActive(false);
        }

        Debug.LogWarning("Name: " + PhotonNetwork.NickName + " PhotonView: " + photonview.IsMine);

    }

    void Update()
    {
        photonView.RPC("qualposicao", RpcTarget.AllBuffered, volta);

        void qualposicao()
        {
           
        }



        if (photonview.IsMine)
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

            if (Input.GetAxis("Fire2_2") == 1 && acelerar < 1)
            {
                acelerar = acelerar + 0.05f;
            }
            if (Input.GetAxis("Fire2_2") == 0 && acelerar > 0)
            {
                acelerar = acelerar - 0.01f;
            }
            if (acelerar < 0)
            {
                acelerar = 0;
            }
            moveDirection = new Vector3(0, -gravity, acelerar * -1 * Speed);
            moveDirection = transform.TransformDirection(moveDirection);




            if (Input.GetButtonDown("Fire1_2"))
            {
                Speed = Speed * 0.8f;
                rotateSpeed *= 1.5f;
            }
            if (Input.GetButton("Fire1_2"))
            {
                tempodrift = tempodrift + Time.deltaTime;
                if (tempodrift > 4)
                {
                    turbo = true;
                }
            }
            if (Input.GetButtonUp("Fire1_2"))
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

            transform.Rotate(0, Input.GetAxis("Horizontal2") * rotateSpeed, 0);
        }
    }

    public void saberposicao() 
    {
        if (i < arcos.Length)
        {
            arco = arcos[i].GetComponent<barreira>();
            go = arcos[i];
            maisperto = Vector3.Distance(go.transform.position, this.transform.position);

            if (arco.passou)
            {
                i++;
            }
        }
        if (i >= arcos.Length)
        {
            i = 0;
            falta1 = true;
        }

        if (falta1 == true && i == 1)
        {
            falta1 = false;
            volta++;
        }
        ui_volta.text = "Volta " + volta + "/3";
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
