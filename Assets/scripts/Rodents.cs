using UnityEngine;
using System.Collections;

public class Rodents {
    public string nome;
    public string path;
    public float scale;
    public float forca;
    public string descricao;
	
    public Rodents(string nome, string roedorPath, float scale, float forca, string descricao)
    {
        this.nome = nome;
        this.path = roedorPath;
        this.scale = scale;
        this.forca = forca;
        this.descricao = descricao;
    }
}
