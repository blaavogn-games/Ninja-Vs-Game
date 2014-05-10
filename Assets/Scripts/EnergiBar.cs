using UnityEngine;
using System.Collections;

public class EnergiBar : MonoBehaviour {
	int pointer; //pointer er også playerens energi
	int size = 30;
	float movePointer = 3;

	// Use this for initialization
	void Start () {
		pointer = size / 2; //


	}
	
	// Update is called once per frame
	void Update () {
		movePointer -= Time.deltaTime;
		if (movePointer <= 0) {
			movePointer = 3;
			pointer++;
			Debug.Log("pointer is now" + pointer);
		}
		if (pointer > size) {
			Debug.Log("GameMaster must die");

		}else if (pointer < 0){
			Debug.Log("Player must die"); 
		}
		
		if(Input.GetKeyDown(KeyCode.R)){
			Application.LoadLevel(0);
		}
	}

	bool usePlayerEnergi(int playerEnergi){
		if (playerEnergi >= pointer){
			pointer -= playerEnergi;
			return true;
		}
		return false;
	}

	bool useGameMasterEnergi(int gameMasterEnergi){
		if(gameMasterEnergi >= (size - pointer)){
			pointer += gameMasterEnergi;
			return true;
		}
		return false;
	}


}
