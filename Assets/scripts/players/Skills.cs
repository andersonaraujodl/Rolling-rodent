using UnityEngine;
using System.Collections;

public class Skills : MonoBehaviour {
	public int coolDown = 10;
	public int duration = 10;
	public float timer;
	public bool isUsing = false;
	public bool isCooling = true;
	public bool isLoaded = false;
	public bool showSign = true;
	public float dispTime=0f;
	public LookAt lookat; 


	
	public virtual void revertePoder(){

		
	}
	public virtual void aplicaPoder(){

	}
	public void chargeDisplay(){
	

		if (dispTime > 0.5f || dispTime == 0f) {

			if (showSign)
				lookat.alteraTexto ("!");
			else
				lookat.alteraTexto (" ");
			dispTime = 0f;
			showSign = !showSign;
		}
		dispTime +=Time.deltaTime;



	}
}
