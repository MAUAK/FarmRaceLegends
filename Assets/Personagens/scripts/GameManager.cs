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
    public int target_FPS;
    // Start is called before the first frame update

    private void Awake()
    {
        Application.targetFrameRate = target_FPS;
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            ingame = true;
        }
        volumeee.value = AudioListener.volume;
        if (Time.timeScale == 0) 
        {
            Time.timeScale = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = volumeee.value;
        if (Input.GetKeyDown(KeyCode.Escape) && ingame) 
        {
            atvconfiguracoes();
          
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

        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
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


    public void iraomenu() 
    {
        SceneManager.LoadScene(0);
    }


}
