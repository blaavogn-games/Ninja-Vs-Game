﻿using UnityEngine;
using System.Collections;

public class DestroyWhenHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	void OnTriggerExit(Collider other)
	{
		Destroy(other.gameObject);
		Debug.Log ("Destroyed " + other.GetType ());
	}
}
