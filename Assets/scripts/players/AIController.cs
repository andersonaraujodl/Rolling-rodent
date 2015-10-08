using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {
	private NavMeshAgent agent;
	private NavMeshPath path = new NavMeshPath();
	PlayerController control;
	Vector3 finalDestination;

	bool powerUpTest = false;
	Vector3 direction;
		
	int contador=0;




	// Use this for initialization
	void Start () {
		control = GetComponent<PlayerController> ();
		agent = GetComponent<NavMeshAgent> ();

		agent.Stop ();
		agent.autoBraking = false;
		agent.autoRepath = false;
		agent.updateRotation = false;
		agent.updatePosition= false;


		finalDestination = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {


		string layer;


		contador++;



		if(control.powerup== null && !powerUpTest){
			layer = "PowerUps";
			powerUpTest = true;
		}else{
			layer = "Players";
			powerUpTest = false;
		}


		if(Mathf.Abs(Vector3.SqrMagnitude(finalDestination -this.transform.position)) <= 1 || powerUpTest == true){
			if(tracaRota(layer))
				finalDestination = path.corners[path.corners.Length-1];

		
		}	

	
	}

	void FixedUpdate(){



		if ( Mathf.Abs(Vector3.SqrMagnitude(finalDestination -this.transform.position)) > 1){

			if (control.powerup != null)
				control.usePowerUp ();

			int i =1;
			while (i < path.corners.Length) {
				if (Mathf.Abs(Vector3.SqrMagnitude(path.corners[i]-this.transform.position)) > 0.25f) {
					direction = path.corners [i] - this.transform.position;
					direction = direction.normalized;
					control.move (-direction.x, 0.0f, -direction.z);
					break;
				}
				i++;
			
			}
		}	

	}



	private bool tracaRota(string mask){

		agent.Warp (this.transform.position);
		RaycastHit hit;
		if (Physics.SphereCast (this.transform.position, 10, transform.forward, out hit, 0.1f, LayerMask.GetMask (mask))) {
			agent.CalculatePath (hit.point, path);
			
			print (contador + " - id_destination: " + (path.corners.Length - 1));
			print (contador + " - New Target!");

			return true;

		} 

		return false;
		
	}



}
