using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, AlarmListener {

    private readonly Vector2 gameSize = new Vector2(76, 54);
	public float speed = 15.0f;
	public KeyCode up, down, left, right, boost;
	private Vector2 position;
    Animator animator;
	public float speedBoost = 1.0f;
	private Alarm alarm;
    bool isMoving;
    bool isRolling = false;

	// Use this for initialization
	void Start () {
		position = transform.position;
        animator = GetComponent<Animator>();
		alarm = GetComponent<Alarm>();
        alarm.setListener(this);
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 movement = Vector2.zero;
		float frameSpeed = speed * speedBoost * Time.deltaTime;
		float y = movement.y;
		float x = movement.x;
        isMoving = true;
        

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

		if(Input.GetKeyDown(KeyCode.CapsLock)){
			speedBoost = 2f;
            isRolling = true;
			alarm.addTimer(.5f, 0, false);
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
            isMoving = false;
		}

        if (position.x < -gameSize.x) {
            position.x = -gameSize.x;
        } else if (position.x > gameSize.x) {
            position.x = gameSize.x;
        }

        if (position.y < -gameSize.y) {
            position.y = -gameSize.y;
        } else if (position.y > gameSize.y) {
            position.y = gameSize.y;
        }
		transform.position = position;
        
		animator.SetFloat("xSpeed", movement.x);
        animator.SetFloat("ySpeed", movement.y);
        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isRolling", isRolling);
	}

	public void onAlarm(int i){
        speedBoost = 1.0f;
        isRolling = false;
		Debug.Log ("alarm!!");
	}

	void OnTriggerEnter2D(Collider2D col){
		Destroy (col.gameObject);
		Destroy (this.gameObject);
	}
}
