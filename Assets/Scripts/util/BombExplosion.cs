using UnityEngine;
using System.Collections;

public class BombExplosion : MonoBehaviour, AlarmListener {
	Alarm alarm;
	SpriteRenderer spriteRenderer;
	bool endExplosion = false;

	public Sprite explodeFrame1, explodeFrame2;

	// Use this for initialization
	void Start () {
		alarm = GetComponent<Alarm> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		if (alarm == null) {
			alarm = gameObject.AddComponent<Alarm>();		
		}
		alarm.setListener (this);
		alarm.addTimer (0.04f, 5, false);
	}

	public void onAlarm(int i){
		if (i == 5) {
			spriteRenderer.sprite = explodeFrame1;
			alarm.addTimer (0.04f, 6, false);
			if (endExplosion){
				alarm.addTimer (0.04f, 7, false);	
			}
		} else if (i == 6) {
			spriteRenderer.sprite = explodeFrame2;
			alarm.addTimer (0.2f, 5, false);
			endExplosion = true;
		} else if (i == 7){
			Destroy (gameObject);
		}
	}
}
