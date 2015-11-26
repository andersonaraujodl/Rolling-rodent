using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pausa : MonoBehaviour {

    private bool controlePause;

    private AudioSource bgm;

    public AudioSource efeito;

	public Image pauseImg;
	public Text pauseTxt;


    // Use this for initialization
    void Start () {
        bgm = GetComponentInChildren<AudioSource>();

        controlePause = true;
        Time.timeScale = 1; // voltar ao jogo
		pauseImg.enabled = false;
		pauseTxt.enabled = false;

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
				pauseImg.enabled = true;
				pauseTxt.enabled = true;
            }
            else
            {
                Time.timeScale = 1; // voltar ao jogo
                controlePause = true;

                bgm.volume = 0.65f;

                efeito.Play();
				pauseImg.enabled = false;
				pauseTxt.enabled = false;
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
