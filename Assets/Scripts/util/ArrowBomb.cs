using UnityEngine;
using System.Collections;

public class ArrowBomb : MonoBehaviour, AlarmListener {
	float angle = 90;
	Alarm alarm;
	bool flashSwitch = false;
	public float blinktTime = .3f;
	float blinkCounter = 0;
	float shootCounter = 0;

	// Use this for initialization
	void Start () {
		alarm = GetComponent<Alarm> ();
		if (alarm == null) {
			alarm = gameObject.AddComponent<Alarm>();		
		}
		alarm.setListener (this);
		alarm.addTimer (0.3f, 0, false);

        
	    angle = 90;
	    flashSwitch = false;
	    blinktTime = .3f;
	    blinkCounter = 0;
	    shootCounter = 0;
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
		else if(i == 99){
            Start();

        } else{
			arrowBombExplode();

		}
	}


	public void arrowBombExplode(){
		if (shootCounter < 13) {
			Instantiate (Resources.Load ("ArrowBombShot"), transform.position + new Vector3 (0, 0), Quaternion.Euler (0, 0, angle));
			angle += 30f;
			shootCounter += 1f;
			alarm.addTimer (0.25f, 1, false);
		} else {
            alarm.addTimer(4, 99, false);
		}
	}
}

