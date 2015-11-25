using UnityEngine;
using System.Collections;

public class PowerUp {
	private float forca;
	private float massa;
	private float duracao;
	public Vector4 cor;

	public PowerUp (float forca, float massa, float duracao, Vector4 cor){
		this.forca = forca;
		this.massa = massa;
		this.duracao = duracao;
		this.cor = cor;

	}

	public float applyForca(float forcaObj){
		return forcaObj * this.forca;
	}
	public float applyMassa(float massaObj){
		return massaObj * this.massa;
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



}
