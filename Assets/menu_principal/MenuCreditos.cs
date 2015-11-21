using UnityEngine;
using System.Collections;

public class MenuCreditos : MonoBehaviour {

	public GUISkin customSkin; // Para customizar estilo botao menu credito
	public Texture TexturaMenuCreditos; // Para definir textura de fundo menu credito
	public int selGradeBotoes = 0; // Selecao grade botoes igual a zero, para "cursor" comecar no primeiro botao descrito no array
	public string[]selBotoes;// Array botoes (elemento 0,elemento 1, elemento 2, para matriz com tres botoes)
	private int maxBotoes; // Numero total de botoes em nossa grade

	// Para um menu responsivo (que se adapta ao tamanho da tela)
	float posX = 0.7f*Screen.width; // posicao que ficara os botoes eixo x
	float posY = 0.6f*Screen.height; // posicao que ficara os botoes eixo y
	float larg = 0.3f*Screen.width; //largura botao
	float alt = 0.3f*Screen.height; //altura botao

	void Start(){
		maxBotoes = selBotoes.Length; // maxBotoes recebe a quantidade de botoes do array selBotoes
	}

	void Update(){
		// Se entrada de teclado (GetKeyUp) com utilizacao de setas para cima (KeyCode.UpArrow) ou (KeyCode.DownArrow) para baixo  esta "ligada" (input)
		if((Input.GetKeyUp(KeyCode.UpArrow))||(Input.GetKeyUp(KeyCode.DownArrow))){
			// Criar efeito redefinindo a selGradeBotoes se exceder o numero de botoes para tecla para cima
			if(selGradeBotoes == 0) // Se botao selecionado eh o elemento zero (unico botao do menu) 
			{
				selGradeBotoes = maxBotoes; // slecao de botoes eh igual a quantidade maxima de botoes
				Application.LoadLevel ("MenuInicial");// vai para o Menu Inicial caso aperte setas pra cima e para baixo -("nome da cena do so menu inicial")
			}
			
		}
		// Se pressionar Return (Enter) ou botao esquerdo do mouse em cima de um botao especifico e
		if ((Input.GetKeyUp (KeyCode.Return)) || (Input.GetMouseButtonDown (0))) {
			switch (selGradeBotoes) { // Se estiver no
			// botao jogar (elemento zero do array) e aperta-lo
			case 0:
				Application.LoadLevel ("MenuInicial");// vai para o Menu Inicial -("nome da cena do so menu inicial")
				break; //sai laco caso 0
			}

		}
	}
			
	void OnGUI(){
		GUI.skin = customSkin; // Aplica Gui Skin criado no Unity para customizacao botoes

		// Fundo do Menu Creditos
		// Rect(posicao horizontal inicial, vertical inicial,largura,altura), parametro);
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), TexturaMenuCreditos); //local textura de fundo do menu creditos, textura de fundo que recebera textura externa no Unity


		// Botao
		// Necessario um menu responsivo (que se adapta ao tamanho da tela)
		posX = 0.7f*Screen.width; // posicao que ficara os botoes eixo x
		posY = 0.6f*Screen.height; // posicao que ficara os botoes eixo y
		larg = 0.3f*Screen.width; //largura botao
		alt = 0.3f*Screen.height; //altura botao
		//GUI.SelectionGrid cria uma grade de selecao (new Rect(posicao x, posicao y,espacamento largura botao, espacamento altura botao), array botoes, qtde colunas)
		selGradeBotoes = GUI.SelectionGrid (new Rect (posX, posY, larg, alt), selGradeBotoes, selBotoes, 1);

		}
}

