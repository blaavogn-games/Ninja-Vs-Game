using UnityEngine;
using System.Collections;

public class FreezeBomb : MonoBehaviour, AlarmListener {

    Alarm alarm;
    void Start () {
        alarm = GetComponent<Alarm>();
        alarm.setListener(this);
        alarm.addTimer(.1f, 0, true);
	}

    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 80 * Time.deltaTime);
    }

    public void onAlarm(int i) {
        Instantiate(Resources.Load("FreezeArea"), transform.position, Quaternion.identity);
    }
	
}
