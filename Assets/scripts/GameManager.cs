using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool ingame = false;
    public GameObject configuracoes;
    public GameObject creditos;
    public Slider volumeee;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            ingame = true;
        }
        volumeee.value = AudioListener.volume;
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = volumeee.value;
        if (Input.GetKeyDown(KeyCode.Escape) && ingame) 
        {
           if(Time.timeScale == 0) 
            {
                Time.timeScale = 1;
                atvconfiguracoes();
            }
           else if(Time.timeScale == 1) 
            {
                Time.timeScale = 0;
                atvconfiguracoes();
            }
        }
    }

    public void iniciar_jogo() 
    {
        SceneManager.LoadScene(1);
    }

    public void fechar_game() 
    {
        Application.Quit();
    }

    public void atvconfiguracoes()
    {
        if (configuracoes.active == true)
        {
            configuracoes.SetActive(false);
        }
        else if (configuracoes.active == false)
        {
            configuracoes.SetActive(true);
        }
    }

    public void atvcreditos()
    {
        if (creditos.active == true)
        {
            creditos.SetActive(false);
        }
        else if (creditos.active == false)
        {
            creditos.SetActive(true);
        }
    }

    public void voltaraojogo() 
    {
            Time.timeScale = 1;
            atvconfiguracoes();
    }

    public void iraomenu() 
    {
        SceneManager.LoadScene(0);
    }


}
