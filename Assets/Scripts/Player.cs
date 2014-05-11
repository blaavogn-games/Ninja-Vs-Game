using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, AlarmListener {
	EnergiBar energi;
    BoxCollider2D boxCollider;
    private readonly Vector2 min = new Vector2(-116, -84),max = new Vector2(116, 75);
	private float speed = 40.0f, slow = 1;
	public float invisibilityTime = 2f;
	public KeyCode up, down, left, right, rollFall, invisibility;
	private Vector2 position;
    Animator animator;
	public float speedBoost = 1.0f, dashSlow = 0.8f;
	public GameObject deadAnimation;
	private Alarm alarm;
    int slowNum = 0;
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
        if (Input.GetKey(down) || Input.GetAxis("Vertical") < -.25f) {
			movement.y -= frameSpeed;
		}


        if (Input.GetKey(up) || Input.GetAxis("Vertical") >.25f) {
			movement.y += frameSpeed;
		}


        if (Input.GetKey(right) || Input.GetAxis("Horizontal") > .25f) {
			movement.x += frameSpeed;
		}

        if (Input.GetKey(left) || Input.GetAxis("Horizontal") < -.25f) {
			movement.x -= frameSpeed;
		}


        if (Input.GetKeyDown(rollFall) || Input.GetButtonDown("Roll")) {
			if(energi.usePlayerEnergi(22)){
				Debug.Log ("use player energi");
				speedBoost = 3f;
				isRolling = true;
				boxCollider.center = new Vector2(0, -3);
				boxCollider.size = new Vector2(7, 7);
				alarm.removeType((int) Ability.RollFall);
				alarm.addTimer(.5f, (int)Ability.RollFall, false);
				audio.Play();
			}
		}

        if (Input.GetKeyDown(invisibility) || Input.GetButtonDown("Inv")) {
			if(energi.usePlayerEnergi(30)){
				SpriteRenderer SR = (SpriteRenderer) GetComponent<SpriteRenderer>();
				SR.color = Color.clear;
				alarm.removeType((int) Ability.Invisibility);
				alarm.addTimer(invisibilityTime, (int) Ability.Invisibility, false);
			}
		}

        float actualSlow = (isRolling) ? dashSlow : slow; 

		if (movement.x != x && movement.y != y) {
			movement.x = (movement.x * Mathf.Sqrt(2))/2;
			movement.y = (movement.y * Mathf.Sqrt(2))/2;
            position += movement * actualSlow;
			transform.position = position;
		} else if(movement.x != x ^ movement.y != y){
            position += movement * actualSlow;
			transform.position = position;
        } else{
            position += movement * actualSlow;
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

	public void onAlarm(int i){
		if(i ==(int) Ability.RollFall){
	        boxCollider.center = new Vector2(0, 0);
	        boxCollider.size = new Vector2(7, 13);
	        speedBoost = 1.0f;
	        isRolling = false;
		} else if (i == (int) Ability.Invisibility){
			SpriteRenderer SR = (SpriteRenderer) GetComponent<SpriteRenderer>();
			SR.color = Color.white;
		}
	}

	void OnTriggerEnter2D(Collider2D col){

        if ("Slow".CompareTo(col.tag) == 0) {
            slow = 0.6f;
            dashSlow = 0.9f;
            slowNum++;
        } else {
            Instantiate(deadAnimation, this.position, Quaternion.identity);
            Instantiate(Resources.Load("sprites/gui/preGameWins"));
			if(!col.gameObject.tag.Equals("Explosions"))
            	Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
	}
    void OnTriggerExit2D(Collider2D col) {
        Debug.Log(slowNum);
        if ("Slow".CompareTo(col.tag) == 0) {
            slowNum--;
            Debug.Log(slowNum);
            if (slowNum == 0) {
                dashSlow = 1f;
                slow = 1f;
                Debug.Log("sdfsdfsdf");
            }
        }
    }

	private enum Ability{
		RollFall = 0, Invisibility =1
	}

}
