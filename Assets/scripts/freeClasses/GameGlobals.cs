using UnityEngine;
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
		new PlayersData(GameGlobals.atrib.PLAYER_ONE, new Vector4(1f,0f,0f,0.05f), 4.0f, 1.0f, 10f, 0.5f, "bola4", "hamster", "power"),
		new PlayersData(GameGlobals.atrib.PLAYER_TWO, new Vector4(0.14f,0.19f,0.23f,1f), 4.0f, 3.0f, 50f, 0.8f, "bola2", "hamster", "power"),
		new PlayersData(GameGlobals.atrib.NPC, new Vector4(0f,0f,1f,1f), 3.0f, 2.0f, 10f, 0.1f, "bola1", "hamster", "power"),
		new PlayersData(GameGlobals.atrib.NPC, new Vector4(0f,1f,1f,1f), 3.5f, 0.5f, 07f, 0.3f, "bola1", "hamster", "power"),
		new PlayersData(GameGlobals.atrib.NPC, new Vector4(0.5f,0.35f,0.1f,1f), 3.5f, 0.2f, 20f, 0.8f, "bola3", "hamster", "power"),
		new PlayersData(GameGlobals.atrib.NPC, new Vector4(1f,1f,0f,1f), 2.7f, 0.9f, 10f, 0.2f, "bola2", "hamster", "power")
	};


	static public GameObject player = Resources.Load("player") as GameObject;

}
