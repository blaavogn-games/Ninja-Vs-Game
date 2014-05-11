using UnityEngine;
using System.Collections;

public class FreezeArea : MonoBehaviour, AlarmListener {
	public Sprite slowFrame1, slowFrame2, slowFrame3, slowFrame4;
    SpriteRenderer spriteRenderer;
    float meltTime = 0;
	bool aniDir = true;

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

		spriteRenderer.sprite
        meltTime += Time.deltaTime;
        float trans = (meltTime < 4) ? 1 : 5 - meltTime;

        spriteRenderer.color = new Color(1, 1, 1, trans);
       // if (meltTime >= 5)
       //     Destroy(gameObject);
    }

	public void onAlarm(int i){
		float aniSpeed = 0.3;
		if (i == 1) {
			spriteRenderer.sprite = slowFrame1;
			aniDir = true;
			Alarm(aniSpeed, 2, false)
				}
		else if (i == 2){
			spriteRenderer.sprite = slowFrame1;
			if (aniDir == true){
				Alarm(aniSpeed, 3, false)
			}
			else{
				Alarm(aniSpeed, 1, false)
			}
		}
		else if (i == 3){
			spriteRenderer.sprite = slowFrame3;
			if (aniDir == true){
				Alarm(aniSpeed, 4, false)
			}
			else{
				Alarm(aniSpeed, 2, false)
			}
		}
		else if (i == 4){
			spriteRenderer.sprite = slowFrame4;
			aniDir = false;
			Alarm(0.2, 3, false)
		}
	}
