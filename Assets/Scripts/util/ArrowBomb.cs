﻿using UnityEngine;
using System.Collections;

public class ArrowBomb : MonoBehaviour, AlarmListener {
	float angle = 0;
	Alarm alarm;
	bool flashSwitch = false;
	float blinkCounter = 0;
	float shootCounter = 0;

	// Use this for initialization
	void Start () {
		alarm = GetComponent<Alarm> ();
		alarm.setListener (this);
		alarm.addTimer (0.3f, 0, false);
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void onAlarm(int i){
		if (i == 0 && blinkCounter < 6) {
			if (flashSwitch == false) {
				renderer.material.color = Color.clear;
				flashSwitch = true;
				alarm.addTimer (0.3f, 0, false);
				blinkCounter += 1;

			} else {
				renderer.material.color = Color.white;
				flashSwitch = false;
				alarm.addTimer (0.3f, 0, false);
				blinkCounter += 1;
			}
		}
		else{
			arrowBombExplode();
		}
	}


	public void arrowBombExplode(){
				for (var i = 12; i > 0; i--) {
						Instantiate (Resources.Load ("ArrowBombShot"), transform.position + new Vector3 (0, 0), Quaternion.Euler (0, 0, angle));
						angle += 30f;
				}
		Destroy (gameObject);
		}
}
