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
		print ("Script devidamente carregado");

		
	}

	// Update is called once per frame
	void Update () {
		if( isUsing || isCooling){
			timer-= Time.deltaTime;
			
			if(timer<=0){
				if (isUsing){ 
					revertePoder();
					timer = (float) coolDown;
				}
				if (isCooling){ 
					timer = (float) duration;
					isCooling = false;
					isUsing = false;
					print (Time.time+" - Restaurado");
				}
			}
		}


	}


	public override void revertePoder(){
		print("Reverteu poder");
		isUsing = false;


	}
	public override void aplicaPoder(){
		if (!isCooling && !isUsing ) {
			print("Rolou o poder");

			isUsing = true;

			float h = Input.GetAxisRaw ("Horizontal_"+(int)pc.playerData.atrib);
			
			
			float v = Input.GetAxisRaw ("Vertical_"+(int)pc.playerData.atrib);
			pc.move(h, forcaUp,v);
		}
	}
}
