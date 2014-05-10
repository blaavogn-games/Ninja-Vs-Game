using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

	public GUIText bossWinsText;
	public GUIText ninjaWinsText;
	
	public GUIText restartTxt;

	public bool ninjaWins;
	public bool dragonWins;
	public bool restart;


	
	
	
	// Use this for initialization
	void Start () {
		 bossWinsText.text = "";
         ninjaWinsText.text = "";
         restartTxt.text = "";

		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
