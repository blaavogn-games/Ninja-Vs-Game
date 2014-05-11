using UnityEngine;
using System.Collections;

public class FreezeArea : MonoBehaviour, AlarmListener {
	public Sprite slowFrame1, slowFrame2, slowFrame3, slowFrame4;
    SpriteRenderer spriteRenderer;
    float meltTime = 0;
	bool aniDir = true;
    Alarm alarm;
    GameObject player;

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
        float trans = (meltTime < 4) ? 0.9f : 5 - meltTime;
        transform.Translate(0, 0, 0.1f);
        spriteRenderer.color = new Color(1, 1, 1, trans);
        if (meltTime >= 5) {
            if(player != null)
                player.GetComponent<Player>().changeFreeze(-1);
            Destroy(gameObject);
        }
    }



	public void onAlarm(int i){
		float aniSpeed = 0.1f;
		if (i == 1) {
			spriteRenderer.sprite = slowFrame1;
			aniDir = true;
			alarm.addTimer(aniSpeed, Random.Range(0,5), false);
				}
		else if (i == 2){
			spriteRenderer.sprite = slowFrame1;
			if (aniDir == true){
				alarm.addTimer(aniSpeed, Random.Range(0,5), false);
			}
			else{
				alarm.addTimer(aniSpeed, Random.Range(0,5), false);
			}
		}
		else if (i == 3){
			spriteRenderer.sprite = slowFrame3;
			if (aniDir == true){
				alarm.addTimer(aniSpeed, Random.Range(0,5), false);
			}
			else{
				alarm.addTimer(aniSpeed, Random.Range(0,5), false);
			}
		}
		else if (i == 4){
			spriteRenderer.sprite = slowFrame4;
			aniDir = false;;
			alarm.addTimer(aniSpeed, Random.Range(0,5), false);
		}
	}

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            player = col.gameObject;
            player.GetComponent<Player>().changeFreeze(1);
        }
    }
    void OnTriggerExit2D(Collider2D col) {
        if (col.tag == "Player") {
            player.GetComponent<Player>().changeFreeze(-1);
            player = null;
        }
    }
}