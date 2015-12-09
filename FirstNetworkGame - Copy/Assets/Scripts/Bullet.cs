﻿using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Bullet : NetworkBehaviour 
{
	[SyncVar]
	public Color color;
	
	public override void OnStartClient() 
	{
		gameObject.GetComponent<Renderer>().material.color = color;
	}	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}