using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
[Serializable]
public class Ima
{
    public string content;
}

[Serializable]
public class RootObjectRespons
{
    public List<Respons> responses;
}

[Serializable]
public class Respons
{
    public SafeSearchAnnotation safeSearchAnnotation;
}
[Serializable]
public class Feature
{
    public string type;
}


[Serializable]
public class Request
{
    public Ima image;
    public Feature[] features;
}


[Serializable]
public class RootGoogle
{
    public Request[] requests;
}


[Serializable]
public class SafeSearchAnnotation
{
    public string adult;
    public string spoof;
    public string medical;
    public string violence;
}

[Serializable]
public class Attributes
{
    public string stat;
}
[Serializable]
public class rsp
{
    public Attributes @attributes;
    public string method;
    public string lang;
    public string format;
    public string found;
    public string api_key;
}
[Serializable]
public class RootObject
{
    public rsp rsp;
}
[Serializable]
public class Movie
{
    public string show_id;

    public string show_titl;

    public int release_year;

    public string poster;

    public float rating;

    public string summary;
}