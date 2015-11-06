using UnityEngine;
using System.Collections;

public class CharacterLoader : MonoBehaviour {





	public Transform[] spawners;
	
	private GameObject player;


	// Use this for initialization
	void Start () {

		player = GameGlobals.player;
		instanciarPlayers ();

		GameObject[] personagens = GameObject.FindGameObjectsWithTag ("Player");
		int x=0;
		foreach (GameObject personagem in personagens) {
			personagem.GetComponent<PlayerController>().customizaPlayer(Selecao.playersToLoad[x]);
			
			x++;
		}
		ScoreController.score = x;
			//customizarPlayers ();

	}
	
	void instanciarPlayers(){

		for(int x =0 ; x< spawners.Length;x++) {
			Instantiate(player, spawners[x].position, spawners[x].rotation);

		}
	}
	
}
