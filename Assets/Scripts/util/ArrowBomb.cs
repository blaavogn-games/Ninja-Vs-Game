using UnityEngine;
using System.Collections;

public class ArrowBomb : MonoBehaviour, AlarmListener {
	float angle;
	Alarm alarm;
	bool flashSwitch = false;
	public float blinktTime;
	float blinkCounter;
	float shootCounter;

	// Use this for initialization
	void Start () {
		blinktTime = 0.3f;
		angle = 90f;
		blinkCounter = 0f;
		shootCounter = 0f;


		alarm = GetComponent<Alarm> ();
		if (alarm == null) {
			alarm = gameObject.AddComponent<Alarm>();		
		}
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
				alarm.addTimer (blinktTime, 0, false);
				blinkCounter += 1; 	
				audio.Play ();

			} else {
				renderer.material.color = Color.white;
				flashSwitch = false;
				alarm.addTimer (blinktTime, 0, false);
				blinkCounter += 1;
			}
		}
		else{
			arrowBombExplode();

		}
	}


	public void arrowBombExplode(){
		if (shootCounter < 13) {
			Instantiate (Resources.Load ("ArrowBombShot"), transform.position + new Vector3 (0, 0), Quaternion.Euler (0, 0, angle));
			angle += 30f;
			shootCounter += 1f;
			alarm.addTimer (0.2f, 1, false);
		} else {
			Start();
		}
	}
}

