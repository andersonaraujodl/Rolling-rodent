using UnityEngine;
using System.Collections;

public class PowerUpPicker : MonoBehaviour {
	Animator anim;
	bool isPicked = false;
	float delay = 1f;
	PowerUp powerup;
	float timer = 5f;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		isPicked = false;
		powerup = new PowerUp (2f, 4f, 2f,10f);
	}
	void OnTriggerEnter(Collider other){
		if (other.GetComponent<PlayerController> ().powerup == null) {
			anim.SetTrigger ("pickedUp");
			isPicked = true;
			other.GetComponent<PlayerController> ().powerup = this.powerup;
		}
	}
	// Update is called once per frame
	void Update () {
		if (isPicked) {
			if(delay>=0){
				delay -= Time.deltaTime;

			}else{
				isPicked =false;
				GetComponentInParent<Transform>().gameObject.SetActive(false);
			}
		}

		if(timer >0f && !isPicked)
			timer-=Time.deltaTime;
		else if(timer <=0f && !isPicked)
			GetComponentInParent<Transform>().gameObject.SetActive(false);
		
	}
}
