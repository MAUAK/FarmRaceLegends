using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barreira : MonoBehaviour
{
    public bool passou;
    public float tempopassou;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            passou = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        passou = false;
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
            }
        }
    }
}
