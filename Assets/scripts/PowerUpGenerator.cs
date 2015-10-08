using UnityEngine;
using System.Collections;

public class PowerUpGenerator : MonoBehaviour {
	public GameObject powerUp;
	GameObject[] spawners;
	public int delay = 10;
	// Use this for initialization
	void Start () {
		spawners = GameObject.FindGameObjectsWithTag ("PowerUpSpawner");

		InvokeRepeating ("instanciarPUp", delay+5, delay);
	}
	
	void instanciarPUp(){
		int x = Random.Range(0, spawners.Length);
	
			Instantiate(powerUp, spawners[x].transform.position, spawners[x].transform.rotation);

	}
}
