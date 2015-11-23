using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Selecao : MonoBehaviour
{

    public GameObject[] bola;
    public GameObject[] roedor;
    public GameObject[] bolaCena;
    public GameObject[] roedorCena;
    public GameObject personagemJogo;

    public GameObject[] playerPos;

    static public int[] nivel;
    public int indexNivel;

    private Rigidbody rb;

    public Text[] txtTela;
    static public string player1_cpu, player2_cpu, player3_cpu, player4_cpu, player5_cpu, player6_cpu;

    public AudioSource somTroca;

    static public PlayersData[] playersToLoad;


    // Use this for initialization
    void Start()
    {
       Object.DontDestroyOnLoad(this);

        somTroca = GetComponent<AudioSource>();

        indexNivel = 0;
        nivel = new int[18];
        bolaCena = new GameObject[6];
        roedorCena = new GameObject[6];

        
        player1_cpu = "Player 1";
        player2_cpu = "CPU";
        player3_cpu = "CPU";
        player4_cpu = "CPU";
        player5_cpu = "CPU";
        player6_cpu = "CPU";

        

    }

    // Update is called once per frame
    void Update()
    {

        if (Application.loadedLevelName == "selecao")
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.LoadLevel("MenuInicial");
                Application.UnloadLevel("selecao");
                Destroy(this);
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {

                for (int i=0; i < nivel.Length; i++)
                {
                    if (i % 3 == 1 && nivel[i] == 0)
                    {
                        nivel[i] = Random.Range(1, roedor.Length);
                    }
                    if (i % 3 == 2 && nivel[i] == 0)
                    {
                        nivel[i] = Random.Range(1, bola.Length);
                    }
                }

                playersToLoad = new PlayersData[]{
					new PlayersData(Selecao.player1_cpu, Chars.ballsGame[Selecao.nivel[2]].color, Chars.rodentsGame[Selecao.nivel[1]].scale, Chars.ballsGame[Selecao.nivel[2]].densidade, Chars.rodentsGame[Selecao.nivel[1]].forca, Chars.ballsGame[Selecao.nivel[2]].drag, Chars.ballsGame[Selecao.nivel[2]].path, Chars.rodentsGame[Selecao.nivel[1]].path, Chars.ballsGame[Selecao.nivel[2]].power),
					new PlayersData(Selecao.player2_cpu, Chars.ballsGame[Selecao.nivel[5]].color, Chars.rodentsGame[Selecao.nivel[4]].scale, Chars.ballsGame[Selecao.nivel[5]].densidade, Chars.rodentsGame[Selecao.nivel[4]].forca, Chars.ballsGame[Selecao.nivel[5]].drag, Chars.ballsGame[Selecao.nivel[5]].path, Chars.rodentsGame[Selecao.nivel[4]].path, Chars.ballsGame[Selecao.nivel[5]].power),
					new PlayersData(Selecao.player3_cpu, Chars.ballsGame[Selecao.nivel[8]].color, Chars.rodentsGame[Selecao.nivel[7]].scale, Chars.ballsGame[Selecao.nivel[8]].densidade, Chars.rodentsGame[Selecao.nivel[7]].forca, Chars.ballsGame[Selecao.nivel[8]].drag, Chars.ballsGame[Selecao.nivel[8]].path, Chars.rodentsGame[Selecao.nivel[7]].path, Chars.ballsGame[Selecao.nivel[8]].power),
					new PlayersData(Selecao.player4_cpu, Chars.ballsGame[Selecao.nivel[11]].color, Chars.rodentsGame[Selecao.nivel[10]].scale, Chars.ballsGame[Selecao.nivel[11]].densidade, Chars.rodentsGame[Selecao.nivel[10]].forca, Chars.ballsGame[Selecao.nivel[11]].drag, Chars.ballsGame[Selecao.nivel[11]].path, Chars.rodentsGame[Selecao.nivel[10]].path, Chars.ballsGame[Selecao.nivel[11]].power),
					new PlayersData(Selecao.player5_cpu, Chars.ballsGame[Selecao.nivel[14]].color, Chars.rodentsGame[Selecao.nivel[13]].scale, Chars.ballsGame[Selecao.nivel[14]].densidade, Chars.rodentsGame[Selecao.nivel[13]].forca, Chars.ballsGame[Selecao.nivel[14]].drag, Chars.ballsGame[Selecao.nivel[14]].path, Chars.rodentsGame[Selecao.nivel[13]].path, Chars.ballsGame[Selecao.nivel[14]].power),
					new PlayersData(Selecao.player6_cpu, Chars.ballsGame[Selecao.nivel[17]].color, Chars.rodentsGame[Selecao.nivel[16]].scale, Chars.ballsGame[Selecao.nivel[17]].densidade, Chars.rodentsGame[Selecao.nivel[16]].forca, Chars.ballsGame[Selecao.nivel[17]].drag, Chars.ballsGame[Selecao.nivel[17]].path, Chars.rodentsGame[Selecao.nivel[16]].path, Chars.ballsGame[Selecao.nivel[17]].power)
                };

                Application.LoadLevel("test_arena");
                Application.UnloadLevel("selecao");
                Destroy(this);




            }

            int k = 1;

            for(int i = 0; i< roedorCena.Length; i++)
            {
                if (!roedorCena[i])
                {
                    roedorCena[i] = (GameObject)Instantiate(roedor[nivel[k]], playerPos[i].transform.position, Quaternion.identity);
                    rb = roedorCena[i].GetComponent<Rigidbody>();
                    rb.useGravity = false;
                }
                else if (!bolaCena[i])
                {
                    bolaCena[i] = (GameObject)Instantiate(bola[nivel[k+1]], playerPos[i].transform.position, Quaternion.identity);
                    rb = bolaCena[i].GetComponent<Rigidbody>();
                    rb.useGravity = false;
                }
                else
                {
                    roedorCena[i].transform.Rotate(0, 90 * Time.deltaTime, 0);
                    bolaCena[i].transform.Rotate(0, 90 * Time.deltaTime, 0);
                }
                txtTela[k].text = Chars.rodentsGame[nivel[k]].nome;
                txtTela[k+1].text = Chars.ballsGame[nivel[k+1]].nome;
                k = k + 3;
            }

            

            txtTela[0].text = player1_cpu;
            txtTela[3].text = player2_cpu;
            txtTela[6].text = player3_cpu;
            txtTela[9].text = player4_cpu;
            txtTela[12].text = player5_cpu;
            txtTela[15].text = player6_cpu;

            corTexto(indexNivel);


            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (indexNivel == nivel.Length - 1) indexNivel = 0;
                else indexNivel++;

            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (indexNivel == 0) indexNivel = nivel.Length - 1;
                else indexNivel--;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (indexNivel % 3 == 1)
                {
                    if (nivel[indexNivel] == 0) nivel[indexNivel] = roedor.Length - 1;
                    else nivel[indexNivel]--;
                }
                else if (indexNivel % 3 == 2)
                {
                    if (nivel[indexNivel] == 0) nivel[indexNivel] = bola.Length - 1;
                    else nivel[indexNivel]--;
                }
                else
                {
                    playerCPU(indexNivel);
                }
                somTroca.Play();
                Destroy_Obj(indexNivel);

            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (indexNivel % 3 == 1)
                {
                    if (nivel[indexNivel] == roedor.Length - 1) nivel[indexNivel] = 0;
                    else nivel[indexNivel]++;
                }
                else if (indexNivel % 3 == 2)
                {
                    if (nivel[indexNivel] == bola.Length - 1) nivel[indexNivel] = 0;
                    else nivel[indexNivel]++;
                }
                else
                {
                    playerCPU(indexNivel);
                }
                somTroca.Play();
                Destroy_Obj(indexNivel);
            }

            
        }
        else
        {
            

        }
    }

    void Destroy_Obj(int obj)
    {
        switch (obj)
        {
            case 1:
                Destroy(roedorCena[0]);
                break;
            case 2:
                Destroy(bolaCena[0]);
                break;
            case 4:
                Destroy(roedorCena[1]);
                break;
            case 5:
                Destroy(bolaCena[1]);
                break;
            case 7:
                Destroy(roedorCena[2]);
                break;
            case 8:
                Destroy(bolaCena[2]);
                break;
            case 10:
                Destroy(roedorCena[3]);
                break;
            case 11:
                Destroy(bolaCena[3]);
                break;
            case 13:
                Destroy(roedorCena[4]);
                break;
            case 14:
                Destroy(bolaCena[4]);
                break;
            case 16:
                Destroy(roedorCena[5]);
                break;
            case 17:
                Destroy(bolaCena[5]);
                break;
            default:
                break;
        }
    }

    private void playerCPU(int nivel)
    {
        if (nivel == 0)
        {
            if (player1_cpu == "Player 1") player1_cpu = "CPU";
            else if (player1_cpu == "CPU") player1_cpu = "Player 1";
        }
        if (nivel == 3)
        {
            if (player2_cpu == "Player 2") player2_cpu = "CPU";
            else if (player2_cpu == "CPU") player2_cpu = "Player 2";
        }
        if (nivel == 6)
        {
            if (player3_cpu == "Player 3") player3_cpu = "CPU";
            else if (player3_cpu == "CPU") player3_cpu = "Player 3";
        }
        if (nivel == 9)
        {
            if (player4_cpu == "Player 4") player4_cpu = "CPU";
            else if (player4_cpu == "CPU") player4_cpu = "Player 4";
        }
        if (nivel == 12)
        {
            if (player5_cpu == "Player 5") player5_cpu = "CPU";
            else if (player5_cpu == "CPU") player5_cpu = "Player 5";
        }
        if (nivel == 15)
        {
            if (player6_cpu == "Player 6") player6_cpu = "CPU";
            else if (player6_cpu == "CPU") player6_cpu = "Player 6";
        }
        
    }

    private void corTexto(int nivel)
    {
        for(int j = 0; j < txtTela.Length; j++)
        {
            txtTela[j].color = Color.black;
        }
        txtTela[nivel].color = Color.red;
    }
       

}
