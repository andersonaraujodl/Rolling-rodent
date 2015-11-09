using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverManager : MonoBehaviour {
	Animator anim;
	public float restartDelay = 9f;
	float restartTimer;
	public Text gameOver;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (ScoreController.score <= 1.0f || ScoreController.tempo <= 0.0f) {
			if (ScoreController.score == 1.0f) {
				gameOver.text = "Game Over";

			} else if (ScoreController.score < 1.0f) {
				gameOver.text = "All Dead";

			} else if (ScoreController.tempo <= 0.0f) {
				gameOver.text = "Time Over";

			}

			ScoreController.isOver = true;
			anim.SetTrigger ("GameOver");
			stop ();

		}
		if (ScoreController.isOver) {
			restartTimer += Time.deltaTime;
			
			// .. if it reaches the restart delay...
			if(restartTimer >= restartDelay)
			{
				// .. then reload the currently loaded level.
				Application.LoadLevel("selecao");
                Application.UnloadLevel("test_arena");
			}
		}
	}
	void stop(){
		GameObject[] jogadores;
		jogadores = GameObject.FindGameObjectsWithTag ("Player");

		foreach(GameObject jogador in jogadores){
			jogador.GetComponent<Rigidbody>().drag=3;
			//jogador.GetComponent<Rigidbody>().Sleep();
		}
	}
}
