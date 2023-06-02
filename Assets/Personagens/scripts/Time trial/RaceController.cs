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
    int volta;
    bool falta1;
    public TMP_Text ui_volta;
    private GameObject go;

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

            if (i < arcos.Length)
            {
                arco = arcos[i].GetComponent<barreira>();
                go = arcos[i];
                maisperto = Vector3.Distance(go.transform.position, player.transform.position);
                if (arco.passou)
                {
                    i++;
                    print(arco.name);
                    
                }
            }
            if(i>=arcos.Length)
            {
                i = 0;
                falta1 = true;
            }

            if (falta1 == true && i == 1)
            {
                print("1 volta");
                falta1 = false;  
                volta++;
            }
            ui_volta.text = "" + volta;
        }
        

    }
    
}



/*
            if (volta >= 3)
            {
                print("vitoria");
            }
            */