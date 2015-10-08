using UnityEngine;
using System.Collections;

public class PlayersData {
	public GameGlobals.atrib atrib;  
	public Vector4 color ;
	public float scale ;
	public float densidade;
	public float forca;
	public float drag;
	public Material bola;
	public GameObject roedor;
	public Component power;

	public PlayersData(GameGlobals.atrib atrib, Vector4 color, float scale, float densidade, float forca, float drag, string bolaPath, string roedorPath, string power){
		this.atrib = atrib;
		this.color = color;
		this.scale = scale;
		this.densidade = densidade;
		this.forca = forca;
		this.drag = drag;
		this.bola = Resources.Load(bolaPath) as Material;
		//this.roedor = Resources.Load (roedorPath) as GameObject;
		//this.power = power;
	}
}
