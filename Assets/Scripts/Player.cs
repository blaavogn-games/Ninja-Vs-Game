﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float speed = 15.0f;
	public KeyCode up, down, left, right;
	private Vector2 position;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 movement = Vector2.zero;
		float frameSpeed = speed * Time.deltaTime;

		if(Input.GetKey(down)){
			movement.y -= frameSpeed;
		}
		
		
		if(Input.GetKey(up)){
			movement.y += frameSpeed;
		}
		
		
		if(Input.GetKey(right)){
			movement.x += frameSpeed;
		}
		
		if(Input.GetKey(left)){
			movement.x -= frameSpeed;
		}

		position += movement;
		transform.position = new Vector2 ((int)position.x, (int) position.y);
	}
}
