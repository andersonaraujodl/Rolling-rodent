using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	private PlayerController control;





	// Use this for initialization
	void Start () {
		control = GetComponent<PlayerController> ();


	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//move player
		float h = Input.GetAxisRaw ("Horizontal_"+(int)control.playerData.atrib);
		float v = Input.GetAxisRaw ("Vertical_"+(int)control.playerData.atrib);

		float u = 0f;
		control.move (h, u, v);


		if (control.powerup != null)
			control.usePowerUp ();
	}
}
