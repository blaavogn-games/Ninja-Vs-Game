using UnityEngine;
using System.Collections;

public class EnergiBar : MonoBehaviour {
	int pointer; //pointer er også playerens energi
	public int size = 198;
	public float movePointerEveryXSec = 1;
	public Transform adjust;

	// Use this for initialization
	void Start () {
		pointer = size / 2; //
		adjust.localScale = new Vector3( pointer / 4 , 1 , 0);

	}
	
	// Update is called once per frame
	void Update () {
		movePointerEveryXSec -= Time.deltaTime;
		//Debug.Log (movePointer);
		if (movePointerEveryXSec <= 0) {
			movePointerEveryXSec = 3;
			pointer += 4;
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
		
		adjust.localScale = new Vector3( pointer / 4 , 1 , 0);
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
