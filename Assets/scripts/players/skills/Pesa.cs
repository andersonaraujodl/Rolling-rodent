using UnityEngine;
using System.Collections;

public class Pesa : Skills {

	float  forcaUp = 100f;

	Rigidbody rb;

	void Start () {
		timer = (float)coolDown;

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
					isCooling = true;
				}else if (isCooling){ 
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

		rb.mass = rb.mass/10000;

	}
	public override void aplicaPoder(){
		if (!isCooling && !isUsing ) {
			print("Rolou o poder");

			isUsing = true;
			rb.mass = rb.mass*10000;


		}
	}
}
