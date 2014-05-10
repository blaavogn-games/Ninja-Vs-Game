using UnityEngine;
using System.Collections;

public class MouseScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		

		this.transform.position.Set (Input.mousePosition.x, Input.mousePosition.y, 0);

	
	}
}
