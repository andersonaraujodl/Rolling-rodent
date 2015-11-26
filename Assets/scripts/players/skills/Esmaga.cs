using UnityEngine;
using System.Collections;

public class Esmaga : Skills {

	Vector3 escalaInicial;
	Vector3 escalaDestino;
	float pontoDoPercurso = 0f;
	float  transDur = 1f;
	bool isShrinking = false;
	bool isGrowing = false;
	public Rigidbody rb;

	void Start () {
		timer = (float)coolDown;
		rb = GetComponent<Rigidbody> ();
		lookat = GetComponentInChildren<LookAt> ();
		//print ("Script devidamente carregado");
		escalaInicial =  rb.transform.localScale;
		
	}

	// Update is called once per frame
	void Update () {
		if( isUsing || isCooling){
			timer-= Time.deltaTime;
			
			if(timer<=0){
				if (isUsing){ 
					revertePoder();
					timer = (float) coolDown;
				}else if (isCooling){ 
					timer = (float) duration;
					isCooling = false;
					isLoaded = true;
					isUsing = false;
				}
			}
		}


		if (isShrinking) {
			pontoDoPercurso += Time.deltaTime;


			if(pontoDoPercurso>transDur){
				isShrinking = false;
				pontoDoPercurso = 0f;
			}else{
				rb.transform.localScale = Vector3.Lerp(escalaInicial, escalaDestino, pontoDoPercurso/transDur);
			}
		}

		if (isGrowing) {
			pontoDoPercurso += Time.deltaTime;
			
			
			if(pontoDoPercurso>transDur){
				isGrowing = false;
				isCooling = true;
				pontoDoPercurso = 0f;
			}else{
				rb.transform.localScale = Vector3.Lerp(escalaDestino, escalaInicial, pontoDoPercurso/transDur);
			}
		}

		if (isLoaded) {
			chargeDisplay();
		}

	}

	public override void revertePoder(){
		isUsing = false;
		isGrowing = true;

	}
	public override void aplicaPoder(){
		if (!isCooling && !isUsing ) {
			//print("Rolou o poder");
			isLoaded =  false;
			lookat.alteraTexto(" ");
			escalaDestino = new Vector3(escalaInicial.x*1.2f, 0.1f, escalaInicial.z*1.2f);
			isShrinking = true;
			isUsing = true;
		}
	}
}
