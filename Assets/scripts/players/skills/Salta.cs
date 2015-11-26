using UnityEngine;
using System.Collections;

public class Salta : Skills {

	float  forcaUp = 100f;
	PlayerController pc;
	Rigidbody rb;

	void Start () {
		timer = (float)coolDown;
		pc = GetComponent<PlayerController> ();
		rb = GetComponent<Rigidbody> ();
		lookat = GetComponentInChildren<LookAt> ();
		//print ("Script devidamente carregado");

		
	}

	// Update is called once per frame
	void Update () {
		if( isUsing || isCooling){
			timer-= Time.deltaTime;
			
			if(timer<=0){
				if (isUsing){ 
					revertePoder();
					timer = (float) coolDown;
					isCooling = true;
				}else if (isCooling){ 
					timer = (float) duration;
					isCooling = false;
					isLoaded = true;
					isUsing = false;
					//print (Time.time+" - Restaurado");
				}
			}
		}

		if (isUsing) {

			float h = Input.GetAxisRaw ("Horizontal_" + (int)pc.playerData.atrib);
			
			
			float v = Input.GetAxisRaw ("Vertical_" + (int)pc.playerData.atrib);

			if(h==0)
				h= 0.001f;

			if(v==0)
				v=0.001f;

			pc.move (0f, forcaUp/pc.speed, 0f);
			rb.transform.position += new Vector3(h/(pc.speed*-2f),0f, v/(pc.speed*-2f));
		}

		if (isLoaded) {
			chargeDisplay();
		}
	}


	public override void revertePoder(){
		//print("Reverteu poder");
		isUsing = false;
		rb.useGravity = true;


	}
	public override void aplicaPoder(){
		if (!isCooling && !isUsing ) {
			//print("Rolou o poder");
			isLoaded =  false;
			lookat.alteraTexto(" ");
			isUsing = true;
			rb.useGravity = false;


		}
	}
}
