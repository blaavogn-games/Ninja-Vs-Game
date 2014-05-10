using UnityEngine;
using System.Collections;

public class FreezeBomb : MonoBehaviour, AlarmListener {

    Alarm alarm;
    void Start () {
        alarm = GetComponent<Alarm>();
        alarm.setListener(this);
        alarm.addTimer(.1f, 0, true);
        alarm.addTimer(1.5f, 1, true);
	}

    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 80 * Time.deltaTime);
    }

    public void onAlarm(int i) {
        Vector2 spawnPos = new Vector2((int)transform.position.x , (int) transform.position.y);

        Instantiate(Resources.Load("FreezeArea"), spawnPos, Quaternion.identity);
        if (i == 1)
            Destroy(gameObject);
    }
	
}
