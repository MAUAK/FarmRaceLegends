using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    public Transform targetLocation; // O local para onde os jogadores serão redirecionados


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Verifica se o objeto que colidiu tem a tag "Player"
            other.gameObject.transform.position = targetLocation.position;
            // Define a posição do jogador para a posição do local alvo
        }
    }
}
