using System;
using System.Collections;
using System.Text;
using System.Xml;
using UnityEngine;
using UnityEngine.Networking;



public class WSGoogle : MonoBehaviour {

    public delegate void WSResponse(string response);
    public static WSGoogle instance;
    public const string WS_URL = "http://api1.webpurify.com/services/rest/?api_key=2a4003b580676e5e47da0283dd33e784&method=webpurify.live.check&text=";
    public const string Go_URL = "https://vision.googleapis.com/v1/images:annotate?key=AIzaSyCjUhw5n9XNnQvRO2VK0yI0Avj_0NNr9g4";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            GameObject.Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    public void StartWebService(string endpoint, WSResponse successCallback, WSResponse errorCallback = null)
    {

        StartCoroutine(GetText(endpoint, successCallback, errorCallback));
    }

    public void StartGoogleApi(string json, WSResponse successCallback, WSResponse errorCallback = null)
    {

        StartCoroutine(ConsumeWebService(json, successCallback, errorCallback));

    }


    IEnumerator GetText(string comentario, WSResponse successCallback = null, WSResponse errorCallback = null)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(WS_URL + WWW.EscapeURL(comentario) + "&lang=sp&format=json"))
        {
#if UNITY_5_5_4 || UNITY_5_6_OR_NEWER
            www.timeout = 20;
#endif
            UTF8Encoding encoder = new UTF8Encoding();
            www.uploadHandler = (UploadHandler)new UploadHandlerRaw(encoder.GetBytes(comentario));
            www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");
          
           
            yield return www.Send();
          
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                if (errorCallback != null) errorCallback(www.error);
            }
            else
            {
                // Show results as text
                Debug.Log(www.downloadHandler.text.Trim());
                // Or retrieve results as binary data
                byte[] results = www.downloadHandler.data;
                Debug.Log(results);

                    if(successCallback != null) successCallback(www.downloadHandler.text);
            }
        }
    }












    private IEnumerator ConsumeWebService(string json, WSResponse successCallback = null,
        WSResponse errorCallback = null)
    {
        string url = Go_URL ;

        Debug.Log("Sending JSON: " + json);
        Debug.Log("To URL: " + url);

        using (UnityWebRequest www = new UnityWebRequest(url, "POST"))
        {
#if UNITY_5_5_4 || UNITY_5_6_OR_NEWER
            www.timeout = 20;
#endif
            UTF8Encoding encoder = new UTF8Encoding();
            www.uploadHandler = (UploadHandler)new UploadHandlerRaw(encoder.GetBytes(json));
            www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.Send();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
                if (errorCallback != null) errorCallback(www.error);
               
            }
            else
            {
                string responseString = www.downloadHandler.text.Trim();
                Debug.Log("responseString " + responseString);

                if (www.downloadHandler.text == null)
                {
                    if (errorCallback != null) errorCallback("www.downloadHandler.text is " + www.downloadHandler.text);
                   
                }
                else
                {
                    if (successCallback != null) successCallback(www.downloadHandler.text.Trim());
                  

                }
            }
        }
    }

}
