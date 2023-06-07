using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barreira : MonoBehaviour
{
    public bool passou;
    public float tempopassou;
    public bool primeiro_arco;
    public int quantas_passou;
    public bool ganhou;
    public string nome_vencedor;
    public multiplayer_online controleplayer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            controleplayer = other.GetComponent<multiplayer_online>();
            passou = true;
            controleplayer.ultimoarco = this.gameObject;
            if (ganhou)
            {
                nome_vencedor = other.gameObject.name;
                ganhou = false;
                quantas_passou = 0;
            }
        }

      
    }
    // Start is called before the first frame update
    void Start()
    {
        passou = false;
        ganhou = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (passou) 
        {
            tempopassou = tempopassou + Time.deltaTime;
            if (tempopassou > 0.5f)
            {
                passou = false;
                tempopassou = 0;
                quantas_passou++;
            }
        }

        if (primeiro_arco && quantas_passou>=4) 
        {
            ganhou = true;
        }


    }
}
