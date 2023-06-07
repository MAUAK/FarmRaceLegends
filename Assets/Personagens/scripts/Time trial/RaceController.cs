using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaceController : MonoBehaviour
{
    public GameObject[] arcos;
    private barreira arco;
    public bool conectado;
    public float maisperto;
    public GameObject player;
    int i;
    public int volta;
    bool falta1;
    public TMP_Text ui_volta;
    private GameObject[] jogadores;
    private GameObject go;
    private multiplayer_online script_player;

    public 
    // Start is called before the first frame update
    void Start()
    {
        i = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        if (conectado)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            script_player = player.GetComponent<multiplayer_online>();
            if (i < arcos.Length)
            {
                arco = arcos[i].GetComponent<barreira>();
                go = arcos[i];
                maisperto = Vector3.Distance(go.transform.position, player.transform.position);

     
                if (arco.passou)
                {
                    i++;     
                }
            }
            if(i>=arcos.Length)
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
    }    
}


