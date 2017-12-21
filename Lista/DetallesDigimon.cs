using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetallesDigimon : MonoBehaviour {
    public Text Nombre;
    public Image Imagen;
    public Text Descripcion;
    public Text Tipo;
    // Use this for initialization
    void Start () {
		
	}
	
	public void Crear(Digimon digimon)
    {
        Nombre.text = digimon.Nombre;
        Imagen.sprite = digimon.Imagen;
        Descripcion.text = digimon.Descripcion;
        Tipo.text = digimon.Tipo;
    }
}
