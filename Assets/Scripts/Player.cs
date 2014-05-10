using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, AlarmListener {
	public float speed = 15.0f;
	public KeyCode up, down, left, right, boost;
	private Vector2 position;
    Animator animator;
	public float speedBoost = 1.0f;
	private Alarm alarm;

	// Use this for initialization
	void Start () {
		position = transform.position;
        animator = GetComponent<Animator>();
		alarm = GetComponent<Alarm>();
		alarm.setListener (this);
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 movement = Vector2.zero;
		float frameSpeed = speed * speedBoost * Time.deltaTime;
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

		if(Input.GetKey(boost)){
			speedBoost = 1.5f;
			alarm.addTimer(1, 0, false);
		} 

		if (movement.x != x && movement.y != y) {
			movement.x = (movement.x * Mathf.Sqrt(2))/2;
			movement.y = (movement.y * Mathf.Sqrt(2))/2;
			position += movement;
			transform.position = position;
		} else if(movement.x != x ^ movement.y != y){
			position += movement;
			transform.position = position;
        } else{
			position += movement;
			transform.position = new Vector2 (Mathf.Round(position.x), Mathf.Round( position.y));
		}
		
			
        Debug.Log(transform.position);
        animator.SetFloat("xSpeed", movement.x);
        animator.SetFloat("ySpeed", movement.y);
	}

	public void onAlarm(int i){
		speedBoost = 1.0f;
		Debug.Log ("alarm!!");
	}

	void OnTriggerEnter2D(Collider2D col){
		Destroy (col.gameObject);
		Destroy (this.gameObject);
	}
}
