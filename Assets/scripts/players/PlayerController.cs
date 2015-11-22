using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 5;
	private Rigidbody rb;
	public PowerUp powerup;
	public PlayersData playerData;
	bool usingPowerUp = false;
	bool isWalking = false;
	bool isGrounded = true;
	public Animator anim;

	private Vector3 fixo;
	private Transform giro;
	private float rotY;
	public bool hasHit = false;
	public int delayReturn = 100;
	private int delayCount;

	int contadordePrint;

   
    private float minSpeed = 0.2f;

    
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody> ();
		anim = GetComponentInChildren<Animator> ();
		giro = this.transform.FindChild("ginbal").transform;

		fixo = giro.eulerAngles;
		rotY = fixo.y;

		delayCount = delayReturn;

       
    }


	void FixedUpdate(){

        
        if (!hasHit) {
			fixo.y = Mathf.LerpAngle (fixo.y, rotY, 0.1f);
			giro.eulerAngles = fixo;

			if (rb.velocity.magnitude <= minSpeed && isWalking == true) {
				isWalking = false;			
				anim.SetBool ("isWalking", isWalking);
			}

		} else if(rb.velocity.magnitude <= minSpeed){
			hasHit = false;
		}


	}
	void Update(){

        if (powerup != null && usingPowerUp) {
			if(powerup.controlaDuracao()<=0f){
				this.GetComponent<Rigidbody>().mass = powerup.revertMassa(this.GetComponent<Rigidbody>().mass);
				this.speed = powerup.revertForca(this.speed);
				powerup = null;
				usingPowerUp = false;
			}
		}
//		Debug.Log (gameObject.GetInstanceID () + " status = " + isGrounded);

	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Finish"))
		{
			this.gameObject.SetActive(false);
			ScoreController.score--;

		}else 	if (other.gameObject.CompareTag ("Player")) {
			other.GetComponent<PlayerController>().hasHit = true;
			this.hasHit = true;
		}
	}
	void OnCollisionStay(Collision other){
		if (other.gameObject.CompareTag ("Ground")) {

			isGrounded = true;
			
		}
	}
	void OnCollisionExit(Collision other){
		if (other.gameObject.CompareTag ("Ground")) {

			isGrounded = false;
			
		}
	}
	
	public void move(float h, float u, float v){

		if (hasHit) {
			if(delayCount<=0){
				hasHit = false;
				delayCount = delayReturn;
			}else{
				delayCount--;
			}
		}

		//aplicando a força ao objeto

		if (isGrounded) {
			Vector3 movement = new Vector3 (-h, u, -v);
			rb.AddForce (movement * speed);
		}


		//rotacionando roedor
		if (h != 0 || v != 0) {


			rotY = Mathf.Rad2Deg*Mathf.Atan (h/ v+0.00001f);

			if(v<0){
				rotY = 180-rotY;

				if(h>0.0001f)
					rotY-=90;

				if(h<0)
					rotY +=90;
			}
		}

		//controlando animaçao do roedor
		if (h != 0.0f || v != 0.0f) {
			isWalking = true;
			anim.SetBool ("isWalking", isWalking);
		}
			




	}

	public void usePowerUp(){
		if (powerup != null && usingPowerUp == false) {
			usingPowerUp = true;
			this.GetComponent<Rigidbody>().mass = powerup.applyMassa(this.GetComponent<Rigidbody>().mass);
			this.speed = powerup.applyForca(this.speed);
		}

	}


	public void customizaPlayer(PlayersData pd){
		this.playerData = pd;
		this.transform.localScale = new Vector3(pd.scale,pd.scale,pd.scale);
		this.GetComponent<Renderer> ().material = pd.bola;
		this.GetComponent<Renderer>().material.SetColor("_Color", pd.color);
		this.GetComponent<Rigidbody>().mass = pd.densidade*pd.scale;
		this.GetComponent<Rigidbody>().drag = pd.drag;
		this.GetComponent<PlayerController>().speed = pd.forca;
		GameObject roedor = Instantiate(pd.roedor, this.GetComponentInChildren<Transform>().position, this.GetComponentInChildren<Transform>().rotation ) as GameObject;
		roedor.transform.localScale = this.transform.localScale;
		roedor.transform.parent = this.transform.FindChild("ginbal").transform;

			
			
	 if (pd.atrib == GameGlobals.atrib.NPC) {
			this.gameObject.AddComponent<AIController> ();
			this.gameObject.AddComponent<NavMeshAgent> ();
		} else if (pd.atrib != GameGlobals.atrib.NPC) {
			this.gameObject.AddComponent<PlayerInput> ();
		}

	}



}
