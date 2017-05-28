using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digimon
{
    public string Nombre;
    public Sprite Imagen;
    public string Descripcion;
    public string Tipo;
}


public class Listas : MonoBehaviour {
    public Sprite Agumon;
    public Sprite Guilmon;
    public Sprite Veemon;
    public GameObject PrefabDigimon;
    public Transform Contenedor;

	// Use this for initialization
	void Start () {
        List<Digimon> LDigi = new List<Digimon> {
            new Digimon{Nombre="Agumon", Descripcion="Agumon es un Digimon reptil. Ha crecido y puede caminar sobre dos piernas, " +
            "y tiene un aspecto como un pequeño dinosaurio", Tipo="Vacuna" , Imagen=Agumon },
            new Digimon{Nombre="Guilmon", Descripcion="Guilmon es un Digimon tipo Reptil. " +
            "Es un Digimon pacifico y tranquilo, y lleva el símbolo del Peligro Digital en el pecho", Tipo="Virus" , Imagen=Guilmon },
            new Digimon{Nombre="Veemon", Descripcion="Veemon es un digimon dragón pequeño. " +
            "Su nombre deriva de la letra V, que es el símbolo de la victoria.", Tipo="Vacuna" , Imagen=Veemon }

        };

        for (int i = 0; i < 3; i++)
        {
            foreach (var item in LDigi)
            {
                GameObject _digimon = Instantiate(PrefabDigimon, Contenedor);
                _digimon.GetComponent<DetallesDigimon>().Crear(item);
            }
        }
      
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
