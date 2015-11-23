using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pausa : MonoBehaviour {

    private bool controlePause;

    private AudioSource bgm;

    public AudioSource efeito;

    public Text menuPause;


    // Use this for initialization
    void Start () {
        bgm = GetComponentInChildren<AudioSource>();

        controlePause = true;
        Time.timeScale = 1; // voltar ao jogo


    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        { // se apertar a tecla esc (escape)

            if (controlePause)
            {
                Time.timeScale = 0; // pausar o jogo
                controlePause = false;
                bgm.volume = 0.1f;
                efeito.Play();
                menuPause.text= "Aperte 'F4' para sair ou 'ESC' para voltar ao jogo";
            }
            else
            {
                Time.timeScale = 1; // voltar ao jogo
                controlePause = true;

                bgm.volume = 0.65f;

                efeito.Play();
                menuPause.text = "";
            }
        }

        if (Input.GetKeyDown(KeyCode.F4) && !controlePause)
        {

            controlePause = true;
            Time.timeScale = 1; // voltar ao jogo
            Application.LoadLevel("MenuInicial");
            Application.UnloadLevel("test_arena");
            Destroy(this);

        }



    }
}
