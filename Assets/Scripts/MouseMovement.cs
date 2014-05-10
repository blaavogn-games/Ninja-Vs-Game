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



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0) && Time.time > bulletTime) {
			bulletTime = Time.time +fireRate;
			Instantiate (spreadBomb, this.transform.position, Quaternion.identity);
			
			
			Debug.Log (bulletTime+" = bulletTime");
		}



		wobbleX = Mathf.Sin(Time.time *3);
		wobbleY = Mathf.Cos(Time.time * 2);
	
		//GUI.DrawTexture (Rect(Input.mousePosition.x, Input.mousePosition.y, 32, 32,myCursor);
	
		mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		this.transform.position = new Vector3(mousePosition.x + wobbleX, mousePosition.y + wobbleY, 0);

		 //= Rect( Input.mousePosition.x - (crosshairTexture.width / 2), (Screen.height - Input.mousePosition.y) - (crosshairTexture.height / 2), crosshairTexture.width , crosshairTexture.height );




	}
}
