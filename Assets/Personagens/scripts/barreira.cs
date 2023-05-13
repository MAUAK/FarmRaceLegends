using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barreira : MonoBehaviour
{
    private Movimento_time_trial jogador;
    private void OnTriggerEnter(Collider other)
    {
        print(jogador.tempotxt.text);
      //  jogador.contadortempo();
    }

    // Start is called before the first frame update
    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Movimento_time_trial>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
