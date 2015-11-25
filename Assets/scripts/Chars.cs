using UnityEngine;
using System.Collections;

public class Chars{

    static public Rodents[] rodentsGame = new Rodents[]
    {
        new Rodents("Random", "random", 0f, 0.0f, "Roedor Aleatório"),
        new Rodents("Ginbal", "hamster", 2f, 5.0f, "Hamster ágil e esperto"),
        new Rodents("Ninky", "ratazana", 2.5f, 7.0f, "Ratazana nervosa"),
		new Rodents("Caps", "capivara", 3.5f, 14.0f, "Capivara confusa")
    };

    static public Balls[] ballsGame = new Balls[]
    {
		new Balls("Random", "random", new Vector4(0f,0f,0f,1f), 0.0f, 0.0f, "random", "Bola Aleatória"),
		new Balls("Plastico", "bola1", new Vector4(1f,1f,1f,1f), 1.0f, 0.5f, "Esmaga", "Bola de plástico comum"),
		new Balls("Aço", "bola2", new Vector4(0f,0f,1f,1f), 1.5f, 0.5f, "Pesa", "Bola de aço forte e resistente"),
		new Balls("Madeira", "bola3", new Vector4(0.5f,0.7f,0.2f,1f), 1.2f, 0.5f, "Ataca", "Bola de madeira reciclada"),
		new Balls("Ar", "bola4", new Vector4(0.14f,0.19f,0.23f,1f), 0.5f, 0.5f, "Salta", "Bolha de ar leve como o vento")
    };

}
