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
    GameObject[] towers;
    int towerIndex = 0;
    

	// Use this for initialization
	void Start () {
        towers = new GameObject[2];
		energi = GameObject.FindGameObjectWithTag ("Energy").GetComponent<EnergiBar> ();
	}
	
	// Update is called once per frame
	void Update () {
		mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		
		deltaPos =  mousePosition - lastMousePos;
		
		wobbleX = Mathf.Sin (Time.time)*3 ;//*deltaPos.x;
		wobbleY = Mathf.Cos (Time.time)*3 ;//*deltaPos.y;

        this.transform.position = new Vector3(mousePosition.x + wobbleX, mousePosition.y + wobbleY, 0);
		
		
		//Debug.Log (deltaPos.x);


			if (Input.GetMouseButtonDown(1) && Time.time > bulletTime) {
				if(energi.useGameMasterEnergi(5)){
					bulletTime = Time.time +fireRate;
                   /* if (towers[towerIndex] != null) {
                        Destroy(towers[towerIndex]);
                    }
					towers[towerIndex] = (GameObject) Instantiate (arrowBomb, this.transform.position, Quaternion.identity);
                    towerIndex = (towerIndex + 1) % 4;*/
                    if (towerIndex < 2) {
                        	towers[towerIndex] = (GameObject) Instantiate (arrowBomb, this.transform.position, Quaternion.identity);
                            towerIndex++;
                    }
                }
		} else if (Input.GetMouseButtonDown(0) && Time.time > bulletTime) {
				if(energi.useGameMasterEnergi(20)){
					bulletTime = Time.time +fireRate;
					Instantiate (bomb, this.transform.position, Quaternion.identity);
				}
            } else if (Input.GetMouseButtonDown(2) && Time.time > bulletTime) {
			if(energi.useGameMasterEnergi(5)){
				bulletTime = Time.time +fireRate;
				Instantiate (freezeBomb, this.transform.position, Quaternion.identity);
            }
			}
			
		
		lastMousePos = mousePosition;
		lastPos = this.transform.position;

	}
}