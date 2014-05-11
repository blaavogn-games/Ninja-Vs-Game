using UnityEngine;
using System.Collections;

public class FreezeArea : MonoBehaviour, AlarmListener {
	public Sprite slowFrame1, slowFrame2, slowFrame3, slowFrame4;
    SpriteRenderer spriteRenderer;
    float meltTime = 0;
	bool aniDir = true;
    Alarm alarm;

    void Start() {
		alarm = GetComponent<Alarm> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		if (alarm == null) {
			alarm = gameObject.AddComponent<Alarm>();		
		}
		alarm.setListener (this);
		alarm.addTimer (0.003f, 1, false);
    }

	// Update is called once per frame
	void Update () {
        meltTime += Time.deltaTime;
        float trans = (meltTime < 4) ? 1 : 5 - meltTime;

        spriteRenderer.color = new Color(1, 1, 1, trans);
       // if (meltTime >= 5)
       //     Destroy(gameObject);
    }

	public void onAlarm(int i){
		float aniSpeed = 0.3f;
		if (i == 1) {
			spriteRenderer.sprite = slowFrame1;
			aniDir = true;
			alarm.addTimer(aniSpeed, 2, false);
				}
		else if (i == 2){
			spriteRenderer.sprite = slowFrame1;
			if (aniDir == true){
				alarm.addTimer(aniSpeed, 3, false);
			}
			else{
				alarm.addTimer(aniSpeed, 1, false);
			}
		}
		else if (i == 3){
			spriteRenderer.sprite = slowFrame3;
			if (aniDir == true){
				alarm.addTimer(aniSpeed, 4, false);
			}
			else{
				alarm.addTimer(aniSpeed, 2, false);
			}
		}
		else if (i == 4){
			spriteRenderer.sprite = slowFrame4;
			aniDir = false;;
			alarm.addTimer(aniSpeed, 3, false);
		}
	}
}