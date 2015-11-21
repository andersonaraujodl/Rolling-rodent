using UnityEngine;
using System.Collections;

// Classe Menu Inicial (Menu inicial do jogo)
public class MenuInicial : MonoBehaviour {

	public GUISkin customSkin; // Para customizar estilo botoes menu
	public Texture TexturaMenuInicial,TexturaNomeJogo; // Para definir textura de fundo menu e colocar o nome do jogo
	public int selGradeBotoes = 0; // Selecao grade botoes igual a zero, para "cursor" comecar no primeiro botao descrito no array
	public string[] selBotoes;// Array botoes (elemento 0,elemento 1, elemento 2, para matriz com tres botoes)
	private int maxBotoes; // Numero total de botoes em nossa grade
	public int varInt; // Para converter strings em inteiros

	// Para um menu responsivo (que se adapta ao tamanho da tela)
	float posX = 0.4f*Screen.width; // posicao que ficara os botoes eixo x
	float posY = 0.6f*Screen.height; // posicao que ficara os botoes eixo y
	float larg = 0.3f*Screen.width; //largura botao
	float alt = 0.3f*Screen.height; //altura botao

	void Start(){
		maxBotoes = selBotoes.Length; // maxBotoes recebe a quantidade de botoes do array selBotoes
	}

	void Update(){

		// Selecao de botoes
		// Se entrada de teclado (GetKeyUp) com utilizacao de setas para cima (KeyCode.UpArrow) esta "ligada" (input)
		if ((Input.GetKeyUp (KeyCode.UpArrow))) {
			// Criar efeito redefinindo a selGradeBotoes se exceder o numero de botoes para tecla para cima
			if (selGradeBotoes > 0) { // Se botao selecionado eh maior que elemento zero (primeiro botao do menu)
				selGradeBotoes--; // Subtrai 1 do elemento atual, indo para botao de acima (elemento anterior) deste, botao anterior passa a ser o botao selecionado
			} else {
				selGradeBotoes = maxBotoes - 1; // Chega no primeiro botao, vai para o ultimo (elemento 2 da matriz, para matriz de tres botoes)
			}
		}
			
		// Selecao de botoes
		// Obter entrada de teclado (GetKeyUp) com utilizacao de setas para baixo (KeyCode.DownArrow) esta "ligada" (input)
		if ((Input.GetKeyUp (KeyCode.DownArrow))) {

			// Mesmo efeito que acima, mas para tecla para baixo
			if (selGradeBotoes < (maxBotoes - 1)) { // Se botao selecionado eh menor que o ultimo botao - 1
				selGradeBotoes++; // Soma 1 no elemento atual, indo para botao abaixo (proximo elemento) deste, proximo botao passa a ser o botao selecionado

			} else {
				selGradeBotoes = 0; // Chega no ultimo botao, vai para o primeiro (elemento zero da matriz)
			}

		}

		//Funcionamento botoes

		// GetKeyUp(KeyCode.Return), ativa tecla return
		if ((Input.GetKeyUp (KeyCode.Return))) { // Se pressionar Return (Enter)
			switch (selGradeBotoes) { // Se estiver no
			// botao jogar (elemento zero do array) e aperta-lo
			case 0:
				Application.LoadLevel ("selecao");// vai para selecao personagens -("nome da cena de selecao de personagens")
				break; //sai laco caso 0
			
			// botao creditos (elemento zero do array) e aperta-lo	
			case 1:
				Application.LoadLevel ("MenuCreditos"); // vai para o Menu Creditos -("nome da cena do so menu creditos")
				break; //sai laco caso 1
			
			// botao sair (elemento zero do array) e aperta-lo	
			case 2:
                Application.Quit();// sai do jogo
				break; //sai laco caso 2
			}
		}
	}

	void OnGUI(){
			GUI.skin = customSkin; //Aplica Gui Skin criado no Unity para customizacao botoes 
	
		// Fundo do Menu Inicial
		// Rect(posicao horizontal inicial, vertical inicial,largura,altura), parametro);
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), TexturaMenuInicial); //local textura de fundo do menu, textura de fundo que recebera textura externa no Unity

		// Nome do Jogo
		// Rect(posicao horizontal inicial, vertical inicial,largura,altura), parametro);
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height / 1.5f), TexturaNomeJogo); //local textura de fundo do menu, textura de fundo que recebera textura externa no Unity

		// Botoes
		// Necessario um menu responsivo (que se adapta ao tamanho da tela)
		posX = 0.4f*Screen.width; // posicao que ficara os botoes eixo x
		posY = 0.6f*Screen.height; // posicao que ficara os botoes eixo y
		larg = 0.3f*Screen.width; //largura botao
		alt = 0.3f*Screen.height; //altura botao

		//GUI.SelectionGrid cria uma grade de selecao (new Rect(posicao x, posicao y,espacamento largura botao, espacamento altura botao), array botoes, qtde colunas)
		selGradeBotoes = GUI.SelectionGrid (new Rect (posX, posY, larg, alt), selGradeBotoes, selBotoes, 1);
	}
}


