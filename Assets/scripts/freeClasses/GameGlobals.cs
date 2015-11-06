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


    /*static public PlayersData[] playersToLoad = new PlayersData[]{
        new PlayersData(Selecao.player1_cpu, Chars.ballsGame[Selecao.nivel[2]].color, Chars.rodentsGame[Selecao.nivel[1]].scale, Chars.ballsGame[Selecao.nivel[2]].densidade, Chars.rodentsGame[Selecao.nivel[1]].forca, Chars.ballsGame[Selecao.nivel[2]].drag, Chars.ballsGame[Selecao.nivel[2]].path, Chars.rodentsGame[Selecao.nivel[1]].path, "power"),
        new PlayersData(Selecao.player2_cpu, Chars.ballsGame[Selecao.nivel[5]].color, Chars.rodentsGame[Selecao.nivel[4]].scale, Chars.ballsGame[Selecao.nivel[5]].densidade, Chars.rodentsGame[Selecao.nivel[4]].forca, Chars.ballsGame[Selecao.nivel[5]].drag, Chars.ballsGame[Selecao.nivel[5]].path, Chars.rodentsGame[Selecao.nivel[4]].path, "power"),
        new PlayersData(Selecao.player3_cpu, Chars.ballsGame[Selecao.nivel[8]].color, Chars.rodentsGame[Selecao.nivel[7]].scale, Chars.ballsGame[Selecao.nivel[8]].densidade, Chars.rodentsGame[Selecao.nivel[7]].forca, Chars.ballsGame[Selecao.nivel[8]].drag, Chars.ballsGame[Selecao.nivel[8]].path, Chars.rodentsGame[Selecao.nivel[7]].path, "power"),
        new PlayersData(Selecao.player4_cpu, Chars.ballsGame[Selecao.nivel[11]].color, Chars.rodentsGame[Selecao.nivel[10]].scale, Chars.ballsGame[Selecao.nivel[11]].densidade, Chars.rodentsGame[Selecao.nivel[10]].forca, Chars.ballsGame[Selecao.nivel[11]].drag, Chars.ballsGame[Selecao.nivel[11]].path, Chars.rodentsGame[Selecao.nivel[10]].path, "power"),
        new PlayersData(Selecao.player5_cpu, Chars.ballsGame[Selecao.nivel[14]].color, Chars.rodentsGame[Selecao.nivel[13]].scale, Chars.ballsGame[Selecao.nivel[14]].densidade, Chars.rodentsGame[Selecao.nivel[13]].forca, Chars.ballsGame[Selecao.nivel[14]].drag, Chars.ballsGame[Selecao.nivel[14]].path, Chars.rodentsGame[Selecao.nivel[13]].path, "power"),
        new PlayersData(Selecao.player6_cpu, Chars.ballsGame[Selecao.nivel[17]].color, Chars.rodentsGame[Selecao.nivel[16]].scale, Chars.ballsGame[Selecao.nivel[17]].densidade, Chars.rodentsGame[Selecao.nivel[16]].forca, Chars.ballsGame[Selecao.nivel[17]].drag, Chars.ballsGame[Selecao.nivel[17]].path, Chars.rodentsGame[Selecao.nivel[16]].path, "power")
    };*/


    static public GameObject player = Resources.Load("player") as GameObject;

}
