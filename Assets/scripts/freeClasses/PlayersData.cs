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
	public string poder;

	public PlayersData(string atrib, Vector4 color, float scale, float densidade, float forca, float drag, string bolaPath, string roedorPath, string poder){
		checkPlayer(atrib);
		this.color = color;
		this.scale = scale;
		this.densidade = densidade;
		this.forca = forca;
		this.drag = drag;
        this.bola = Resources.Load(bolaPath) as Material;
		this.roedor = Resources.Load(roedorPath) as GameObject;
		this.poder = poder;



	}

    private void checkPlayer(string player)
    {

        if (player == "CPU") this.atrib = GameGlobals.atrib.NPC;
        else if (player == "Player 1") this.atrib = GameGlobals.atrib.PLAYER_ONE;
        else if (player == "Player 2") this.atrib = GameGlobals.atrib.PLAYER_TWO;
        else if (player == "Player 3") this.atrib = GameGlobals.atrib.PLAYER_THREE;
        else if (player == "Player 4") this.atrib = GameGlobals.atrib.PLAYER_FOUR;
        else if (player == "Player 5") this.atrib = GameGlobals.atrib.PLAYER_FIVE;
        else if (player == "Player 6") this.atrib = GameGlobals.atrib.PLAYER_SIX;
    }
}
