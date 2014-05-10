using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour, AlarmListener {
	Alarm alarm;
	SpriteRenderer spriteRenderer;
	float blinkCounter = 0f;
	
	public Sprite bombFrame1, bombFrame2;
	// Use this for initialization
	void Start () {
		alarm = GetComponent<Alarm> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		if (alarm == null) {
			alarm = gameObject.AddComponent<Alarm>();		
		}
		alarm.setListener (this);
		alarm.addTimer (0.1f, 3, false);
	}
	
	public void onAlarm(int i){
		if (i == 3 && blinkCounter < 3) {
			spriteRenderer.sprite = bombFrame1;
			alarm.addTimer (0.1f, 4, false);
		} else if (i == 4 && blinkCounter < 3) {
			spriteRenderer.sprite = bombFrame2;
			alarm.addTimer (0.1f, 3, false);
			blinkCounter += 1;
		}else{
			Instantiate (Resources.Load ("BombExplosion"), transform.position + new Vector3 (0, 0), Quaternion.Euler (0, 0, 0));
			Destroy (gameObject);
		}
	}
}
