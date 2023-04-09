using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    float velo;
    float girar;


    #region Metodos da Unity
    void Start()
    {
        velo = 10;
        girar = 60;
    }
    void Update()
    {        


        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, (velo * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, (-velo * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, (-girar * Time.deltaTime), 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, (girar * Time.deltaTime), 0);
        }

    }
    #endregion
}
