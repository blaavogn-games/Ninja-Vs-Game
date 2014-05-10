using UnityEngine;
using System.Collections;

public class MouseMovement : MonoBehaviour {
	Vector3 mousePosition;
	float wobbleY = 0;
	float wobbleX = 0;
	public float wobblefactor = 0.2f;
	public GameObject spreadBomb;
	float bulletTime= 0;
	public float fireRate;
	GUILayer test;
	Vector3 deltaPos;
	Vector3 lastPos;



	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () {
		mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		
		deltaPos =  mousePosition - lastPos;
		
		wobbleX = Mathf.Sin(Time.time) + deltaPos.x;
		wobbleY = Mathf.Cos(Time.time ) + deltaPos.y;

		this.transform.position = new Vector3 (mousePosition.x + wobbleX, mousePosition.y + wobbleY, 0);
		
		
		Debug.Log (deltaPos.x);

			if (Input.GetMouseButton(0) && Time.time > bulletTime) {
			bulletTime = Time.time +fireRate;
			Instantiate (spreadBomb, this.transform.position, Quaternion.identity);
			
			
			Debug.Log (bulletTime+" = bulletTime");
		}

		lastPos = this.transform.position;

	
		//GUI.DrawTexture (Rect(Input.mousePosition.x, Input.mousePosition.y, 32, 32,myCursor);
		 //= Rect( Input.mousePosition.x - (crosshairTexture.width / 2), (Screen.height - Input.mousePosition.y) - (crosshairTexture.height / 2), crosshairTexture.width , crosshairTexture.height );




	}

	}
	