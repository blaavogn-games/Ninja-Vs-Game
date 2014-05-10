using UnityEngine;
using System.Collections;

public class ArrowBomb : MonoBehaviour, AlarmListener {
	float angle = 0;
	Alarm alarm;

	// Use this for initialization
	void Start () {
		alarm = GetComponent<Alarm> ();
		alarm.setListener (this);
		//StartCoroutine(animationBFexplode());
	}
	
	// Update is called once per frame
	void Update () {
		alarm.addTimer (1, 2, false);
	}

	public void onAlarm(int i){
		alarm.addTimer (1, 2, false);
		Debug.Log (i);
	}

	/*public IEnumerator animationBFexplode(){

		bool flashSwitch = false;
		for (var j = 0; j < 4; j++) {
			if (flashSwitch){
				renderer.material.color = Color.blue;
				flashSwitch = true;
			}
			else{
				renderer.material.color = Color.white;
				flashSwitch = false;
			}
			yield return new WaitForSeconds(0.5f);

				}
			arrowBombExplode();
		}

	public void arrowBombExplode(){

		for (var i = 12; i > 0; i--) {
		Instantiate (Resources.Load ("ArrowBombShot"), transform.position + new Vector3(0, 0), Quaternion.Euler(0,0,angle));
			angle += 30f;
		}
	}*/
}
