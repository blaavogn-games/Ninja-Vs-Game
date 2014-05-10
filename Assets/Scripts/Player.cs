using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float speed = 30.0f;
	public KeyCode up, down, left, right;
	private Vector2 position;
    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 movement = Vector2.zero;
		float frameSpeed = speed * Time.deltaTime;
		float y = movement.y;
		float x = movement.x;

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

		if (movement.x != x && movement.y != y) {
			//movement.x = (movement.x * Mathf.Sqrt(2))/2;
			//movement.y = (movement.y * Mathf.Sqrt(2))/2;
			position += movement;
		} else {
			position += movement;
        }
		transform.position = new Vector2 (Mathf.Round(position.x), Mathf.Round( position.y));
        Debug.Log(transform.position);
        animator.SetFloat("xSpeed", movement.x);
        animator.SetFloat("ySpeed", movement.y);
	}
}
