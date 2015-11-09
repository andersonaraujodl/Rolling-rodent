using UnityEngine;
using System.Collections;

public class Balls{

    public string nome;
    public string path;
    public Vector4 color;
    public float densidade;
    public float drag;
    public string descricao;
    public string power;

    public Balls(string nome, string bolaPath, Vector4 color, float densidade, float drag, string power, string descricao)
    {
        this.nome = nome;
        this.path = bolaPath;
        this.color = color;
        this.densidade = densidade;
        this.drag = drag;
        //this.power = power;
        this.descricao = descricao;
    }
}
