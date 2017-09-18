using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Consultar : MonoBehaviour {
    public string titulo;
    public UnityAction<Texture2D> photoCall;
    public Text TResultados;
    // Use this for initialization

    public void Fallo(string results)
    {
        Debug.Log("Fallo");
    }
    public void GooglePhotoTest()
    {
        ShowExplorer(Enviar);
    }

    public void Enviar(Texture2D imagen)
    {
        byte[] bytes = imagen.EncodeToJPG();
        RootGoogle Rg = new RootGoogle();
        Request Rq = new Request();
        Feature ft = new Feature();
        Feature ft2 = new Feature();
        Ima im = new Ima();
        ft.type = "SAFE_SEARCH_DETECTION";
        Rq.features = new Feature[1];
        Rq.features[0] = ft;
        Rq.image = im;
        Rq.image.content = System.Convert.ToBase64String(bytes);
        Rg.requests = new Request[1];
        Rg.requests[0] = Rq;
        string json = JsonUtility.ToJson(Rg);
        WSGoogle.instance.StartGoogleApi(json, resultados, Fallo);
    }

    public void PhotoValida(string results)
    {
        Debug.Log("Valida");
        Debug.Log(results);
    }

    public void ShowExplorer(UnityAction<Texture2D> Call)
    {

        string lcPath = EditorUtility.OpenFilePanel("Selecciona una imagen...", "", "png");
        if (lcPath.Length == 0)  return;

        Call.Invoke(LoadImage(lcPath));

    }

    public static Texture2D LoadImage(string lcFilePath)
    {
        if (!File.Exists(lcFilePath)) return null;
        Texture2D loTexture2D = new Texture2D(1, 1, TextureFormat.ARGB32, false, false);
        if (!loTexture2D.LoadImage(File.ReadAllBytes(lcFilePath))) return null;
        return loTexture2D;
    }

    public void resultados(string results)
    {
        Debug.Log("Correcto");

        Debug.Log(results);

        RootObjectRespons rop = new RootObjectRespons();
        rop = JsonUtility.FromJson<RootObjectRespons>(results);

        Debug.Log(rop.responses);
        TResultados.text ="Contenido Adulto "+ rop.responses[0].safeSearchAnnotation.adult
              + "\n" + "Contenido Medicina " + rop.responses[0].safeSearchAnnotation.medical
              + "\n" + "Contenido de Humor " + rop.responses[0].safeSearchAnnotation.spoof
              + "\n" + "Contenido Violento " + rop.responses[0].safeSearchAnnotation.violence;
       
    }
}
