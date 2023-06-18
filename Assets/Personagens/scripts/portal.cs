using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    public Transform targetLocation; // O local para onde os jogadores ser�o redirecionados


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Verifica se o objeto que colidiu tem a tag "Player"
            other.gameObject.transform.position = targetLocation.position;
            // Define a posi��o do jogador para a posi��o do local alvo
        }
    }
}
