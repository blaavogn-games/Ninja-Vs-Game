using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {
    float time = 1.5f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time < 0) {
            GetComponent<Animator>().speed = 0;

        }
	}
}
