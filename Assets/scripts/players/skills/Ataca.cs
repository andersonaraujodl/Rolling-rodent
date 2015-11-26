using UnityEngine;
using System.Collections;

public class Ataca : Skills {

	float  forcaBash = 500f;

	PlayerController pc;

	void Start () {
		timer = (float)coolDown;
		lookat = GetComponentInChildren<LookAt> ();
		pc = GetComponent<PlayerController> ();
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

		if (isLoaded) {
			chargeDisplay();
		}

	
	}


	public override void revertePoder(){
		//print("Reverteu poder");
		isUsing = false;

	}
	public override void aplicaPoder(){
		if (!isCooling && !isUsing ) {
			isLoaded =  false;
			lookat.alteraTexto(" ");

			float roty = pc.rotY;
			//print("Rolou o poder - "+roty);
			float h = forcaBash*Mathf.Sin(Mathf.Deg2Rad* roty );
			float v = forcaBash*Mathf.Cos(Mathf.Deg2Rad* roty );

			pc.move (h,0f,v);
			isUsing= true;

		}
	}
}
