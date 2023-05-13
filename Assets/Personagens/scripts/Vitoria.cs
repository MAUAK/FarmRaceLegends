using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Vitoria : MonoBehaviour
{
    public GameObject vitoria;
    public TMP_Text nomevencedor;

    private void OnTriggerEnter(Collider other)
    {
        nomevencedor.text = other.gameObject.name;
        vitoria.SetActive(true);
       
    }

    // Start is called before the first frame update
    void Start()
    {
        vitoria.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
