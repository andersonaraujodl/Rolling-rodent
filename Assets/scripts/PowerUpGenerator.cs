using UnityEngine;
using System.Collections;

public class PowerUpGenerator : MonoBehaviour {
	public GameObject[] powerUps;
	GameObject[] spawners;
	public int delay = 20;
	float counter;
	// Use this for initialization
	void Start () {
		spawners = GameObject.FindGameObjectsWithTag ("PowerUpSpawner");
		counter = ((float)delay)*1.5f;
		//InvokeRepeating ("instanciarPUp", delay+5, delay);
	}
	void Update(){
		if (counter <= 0) {
			instanciarPUp ();
			counter = (float)delay;
		} else {
			counter -= Time.deltaTime;
		}


	}
	
	void instanciarPUp(){
		int x = Random.Range(0, spawners.Length);
		//int upselector = Random.Range (0, powerUps.Length);
		int upselector = 3;
			Instantiate(powerUps[upselector], spawners[x].transform.position, spawners[x].transform.rotation);

	}
}
