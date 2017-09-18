using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ValidarTexto : MonoBehaviour {

    public InputField Entrada;
    public Text Salida;
    public void mandar()
    {
        WSGoogle.instance.StartWebService(Entrada.text, resultados, Fallo);
    }

    private void Fallo(string response)
    {
        Salida.text = response;
    }

    private void resultados(string response)
    {
       
        RootObject rs = JsonUtility.FromJson<RootObject>(response);
        if (rs.rsp.found == "0")
        {
            Salida.text = "Bien";
        }
        else
        {
            Salida.text = "Mal";
        }
    }
    public void clear()
    {
        Salida.text = "";
    }
}
