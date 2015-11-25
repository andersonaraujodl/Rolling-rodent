using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {
	static public int score =10;
	static public float tempo;
	static public bool isOver;
	float initialTime;

	public GameObject[] jogadores;
	public Text placar;
	public Text timer;

	// Use this for initialization
	void Awake () {

	
		tempo = 300f;
		initialTime = Time.time;
		isOver = false;
	}

	// Update is called once per frame
	void Update () {
		float timedif = Time.time - initialTime;



		
		if (!isOver){
			placar.text = ScoreController.score + " jogadores";

			tempo = 300 - timedif;
			int min = (int)tempo / 60;
			int segs = (int)tempo % 60;
			string separador = ":";

			if (segs < 10)
				separador = ":0";

			timer.text = min + separador + segs;

		}


	}
	void FixedUpdate(){
		temporizador ();
	}
	IEnumerator temporizador(){
		yield return new WaitForSeconds(1);


	}

}
