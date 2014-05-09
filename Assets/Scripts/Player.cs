using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float speed = 3.5f;
	public KeyCode up, down, left, right;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 movement = Vector2.zero;

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

	}
}
