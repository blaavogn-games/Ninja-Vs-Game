using UnityEngine;
using System.Collections;

public class EnergiBar : MonoBehaviour {
	int pointer; //pointer er også playerens energi
	private int size = 238;
	public float movePointerEveryXSec = 1.5f;
	public Transform adjust;
	private bool flash = false;
	private bool toFlash = true;
	private float flashtimer = 0.4f;
    bool gameStarted = false, gameEnded = false;
	public AudioClip laughatPunyHuman;
	public AudioClip iWillNeverDie;
	public AudioClip bossDie;
    

	// Use this for initialization
	void Start () {
		pointer = size / 2; //
        adjust.localScale = new Vector3(pointer / 4, 1, 0);
        Screen.showCursor = false;

	}

	// Update is called once per frame
	void Update () {
        if (!gameStarted || gameEnded)
            return;

		movePointerEveryXSec -= Time.deltaTime;
		//Debug.Log (movePointer);
		if (movePointerEveryXSec <= 0) {
			movePointerEveryXSec = 1.5f;
			if(pointer < size)
				pointer += 4;
		}
		if (pointer > size) {
            gameEnded = true;
            Instantiate(Resources.Load("sprites/gui/prePlayerWins"));
		}else if (pointer < 0){
            pointer = 0;
            Debug.Log("Player must die"); 
		}
		
		if(Input.GetKeyDown(KeyCode.R)){
			Application.LoadLevel(0);
		}
		
		adjust.localScale = new Vector3( pointer / 4 , 1 , 0);

		if(pointer >= size /4 * 3){
			flash = true;
		} else{
			flash = false;
			foreach(SpriteRenderer SR in GetComponentsInChildren<SpriteRenderer>())
				SR.color = Color.white;
		}

		flashing();

	}

    public void startGame() {
        gameStarted = true;
    }

    public void endGame() {
        gameEnded = true;
    }

	public bool usePlayerEnergi(int playerEnergi){
        if (!gameStarted || gameEnded) {
            return true;
        }
        
        if (playerEnergi <= pointer){
			pointer -= playerEnergi;
			return true;
		}
		return false;
	}

	public bool useGameMasterEnergi(int gameMasterEnergi){
		if(gameMasterEnergi <= (size - pointer)){
			pointer += gameMasterEnergi;
			return true;
		}
		return false;
	}

	private void flashing(){
		if (flash) {
			if(flashtimer >= 0.3f){
				flashtimer = 0.0f;
				toFlash = !toFlash;
			}
			else{
				flashtimer += Time.deltaTime;
			}
			
			if(toFlash){
				foreach(SpriteRenderer SR in GetComponentsInChildren<SpriteRenderer>())
					SR.color = Color.clear;
			} else {
				foreach(SpriteRenderer SR in GetComponentsInChildren<SpriteRenderer>())
					SR.color = Color.white;
			}
		}
	}
}
