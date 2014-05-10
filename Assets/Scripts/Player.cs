using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, AlarmListener {
	EnergiBar energi;
    BoxCollider2D boxCollider;
    private readonly Vector2 min = new Vector2(-116, -84),max = new Vector2(116, 75);
	public float speed = 15.0f;
	public KeyCode up, down, left, right, rollFall;
	private Vector2 position;
    Animator animator;
	public float speedBoost = 1.0f;
	private Alarm alarm;
    bool isMoving;
    bool isRolling = false;

	// Use this for initialization
	void Start () {
		energi = GameObject.FindGameObjectWithTag ("Energy").GetComponent<EnergiBar> ();
        boxCollider = GetComponent<BoxCollider2D>();
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


		if(Input.GetKeyDown(rollFall)){
			Debug.Log ("rollfall");
			if(energi.usePlayerEnergi(10)){
				Debug.Log ("use player energi");
				speedBoost = 2f;
				isRolling = true;
				boxCollider.center = new Vector2(0, -3);
				boxCollider.size = new Vector2(7, 7);
				alarm.clear();
				alarm.addTimer(.5f, 0, false);
			}
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

        if (position.x < min.x) {
            position.x = min.x;
        } else if (position.x > max.x) {
            position.x = max.x;
        }

        if (position.y < min.y) {
            position.y = min.y;
        } else if (position.y > max.y) {
            position.y = max.y;
        }
		transform.position = position;
        
		animator.SetFloat("xSpeed", movement.x);
        animator.SetFloat("ySpeed", movement.y);
        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isRolling", isRolling);
	}

	private void changeAbility(){
		alarm.clear (); //annuller evt. activeret alarm
		onAlarm (0); // kør alarmens afslutning
	}

	public void onAlarm(int i){
        boxCollider.center = new Vector2(0, 0);
        boxCollider.size = new Vector2(7, 13);
        speedBoost = 1.0f;
        isRolling = false;
	}

	void OnTriggerEnter2D(Collider2D col){
		Destroy (col.gameObject);
		Destroy (this.gameObject);
		audio.Play ();
	}


}
