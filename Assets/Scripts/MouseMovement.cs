using UnityEngine;
using System.Collections;

public class MouseMovement : MonoBehaviour {
	EnergiBar energi;
	Vector3 mousePosition;
	float wobbleY = 0;
	float wobbleX = 0;
	public float wobblefactor = 0.2f;
	public GameObject arrowBomb;
	public GameObject bomb;
	public GameObject freezeBomb;
	public KeyCode keyFreezeBomb;
	float bulletTime = 0f;
	public float fireRate;
	GUILayer test;
	Vector3 deltaPos;
	Vector3 lastPos;
	Vector3 lastMousePos;
    

	// Use this for initialization
	void Start () {
		energi = GameObject.FindGameObjectWithTag ("Energy").GetComponent<EnergiBar> ();
	}
	
	// Update is called once per frame
	void Update () {
		mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		
		deltaPos =  mousePosition - lastMousePos;
		
		wobbleX = Mathf.Sin (Time.time) / 5 + 0.5f * deltaPos.x;//*deltaPos.x;
		wobbleY = Mathf.Cos (Time.time) / 5 + 0.5f * deltaPos.y;//*deltaPos.y;

		this.transform.position = new Vector3 (lastPos.x + wobbleX, lastPos.y + wobbleY, 0);
		
		
		//Debug.Log (deltaPos.x);


			if (Input.GetMouseButtonDown(0) && Time.time > bulletTime) {
				if(energi.useGameMasterEnergi(5)){
					bulletTime = Time.time +fireRate;
					Instantiate (arrowBomb, this.transform.position, Quaternion.identity);
                }
		} else if (Input.GetMouseButtonDown(1) && Time.time > bulletTime) {
				if(energi.useGameMasterEnergi(20)){
					bulletTime = Time.time +fireRate;
					Instantiate (bomb, this.transform.position, Quaternion.identity);
				}
			}else if (Input.GetKeyDown(keyFreezeBomb) && Time.time > bulletTime) {
			if(energi.useGameMasterEnergi(5)){
				bulletTime = Time.time +fireRate;
				Instantiate (freezeBomb, this.transform.position, Quaternion.identity);
            }
			}
			
		
		lastMousePos = mousePosition;
		lastPos = this.transform.position;

	}
}