using UnityEngine;
using System.Collections;

public class ArrowBombShot : MonoBehaviour {
	private float speed = 1f;
	
	// Update is called once per frame
	void Update () {
		transform.Translate (speed * Time.deltaTime, 0, 0);
	}
}
