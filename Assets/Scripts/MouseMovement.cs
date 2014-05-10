using UnityEngine;
using System.Collections;

public class MouseMovement : MonoBehaviour {
	EnergiBar energi;
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
	Vector3 lastMousePos;
	private Ability activeAbility;



	// Use this for initialization
	void Start () {
		energi = GameObject.FindGameObjectWithTag ("Energy").GetComponent<EnergiBar> ();
		Screen.showCursor = false;
		activeAbility = Ability.SpreadBomb;
	}
	
	// Update is called once per frame
	void Update () {
		mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		
		deltaPos =  mousePosition - lastMousePos;
		
		wobbleX = Mathf.Sin (Time.time) / 5 + 0.5f * deltaPos.x;//*deltaPos.x;
		wobbleY = Mathf.Cos (Time.time) / 5 + 0.5f * deltaPos.y;//*deltaPos.y;

		this.transform.position = new Vector3 (lastPos.x + wobbleX, lastPos.y + wobbleY, 0);
		
		
		Debug.Log (deltaPos.x);

			if (Input.GetMouseButton(0) && Time.time > bulletTime) {
				activateAbility();
			
			
			Debug.Log (bulletTime+" = bulletTime");
		}

		lastMousePos = mousePosition;
		lastPos = this.transform.position;

	
		//GUI.DrawTexture (Rect(Input.mousePosition.x, Input.mousePosition.y, 32, 32,myCursor);
		 //= Rect( Input.mousePosition.x - (crosshairTexture.width / 2), (Screen.height - Input.mousePosition.y) - (crosshairTexture.height / 2), crosshairTexture.width , crosshairTexture.height );




	}

	private void activateAbility(){
		switch (activeAbility) {
		case Ability.SpreadBomb : 
			if(energi.useGameMasterEnergi(10)){
				bulletTime = Time.time +fireRate;
				Instantiate (spreadBomb, this.transform.position, Quaternion.identity);
			}
			break;
		}
	}

	private enum Ability{
		SpreadBomb
	}

}
	