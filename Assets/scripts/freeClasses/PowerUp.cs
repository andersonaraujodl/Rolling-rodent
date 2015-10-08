using UnityEngine;
using System.Collections;

public class PowerUp {
	private float forca;
	private float massa;
	private float drag;
	private float duracao;

	public PowerUp (float forca, float massa, float drag, float duracao){
		this.forca = forca;
		this.massa = massa;
		this.drag = drag;
		this.duracao = duracao;

	}

	public float applyForca(float forcaObj){
		return forcaObj * this.forca;
	}
	public float applyMassa(float massaObj){
		return massaObj * this.massa;
	}
	public float applyDrag(float dragObj){
		return dragObj * this.drag;
	}
	public float controlaDuracao(){
		duracao -= Time.deltaTime;
		return duracao;
	}

	public float revertForca(float forcaObj){
		return forcaObj / this.forca;
	}
	public float revertMassa(float massaObj){
		return massaObj/ this.massa;
	}
	public float revertDrag(float dragObj){
		return dragObj / this.drag;
	}


}
