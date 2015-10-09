﻿using UnityEngine;
using System.Collections;

public class GameGlobals  {

	public enum atrib{
		PLAYER_ONE,
		PLAYER_TWO,
		PLAYER_THREE,
		PLAYER_FOUR,
		PLAYER_FIVE,
		PLAYER_SIX,
		NPC };
	

	static public PlayersData[] playersToLoad = new PlayersData[]{
		new PlayersData(GameGlobals.atrib.PLAYER_ONE, new Vector4(1f,0f,0f,1f), 2.0f, 1.0f, 10f, 0.5f, "bola1", "roedorPath", "power"),
		new PlayersData(GameGlobals.atrib.PLAYER_TWO, new Vector4(0f,1f,0f,1f), 1.0f, 2.0f, 10f, 0.8f, "bola2", "roedorPath", "power"),
		new PlayersData(GameGlobals.atrib.NPC, new Vector4(0f,0f,1f,1f), 2.0f, 2.0f, 10f, 0.1f, "bola1", "roedorPath", "power"),
		new PlayersData(GameGlobals.atrib.NPC, new Vector4(0f,1f,1f,1f), 0.9f, 0.5f, 07f, 0.3f, "bola2", "roedorPath", "power"),
		new PlayersData(GameGlobals.atrib.NPC, new Vector4(1f,0f,1f,1f), 4.0f, 3.0f, 50f, 0.8f, "bola2", "roedorPath", "power"),
		new PlayersData(GameGlobals.atrib.NPC, new Vector4(1f,1f,0f,1f), 1.0f, 0.9f, 10f, 0.2f, "bola2", "roedorPath", "power")
	};


	static public GameObject player = Resources.Load("player") as GameObject;
}