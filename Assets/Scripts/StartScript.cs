using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void LateUpdate() {
        if (Input.GetMouseButtonDown(0)) {
            Instantiate(Resources.Load("MouseCursor"));
            GameObject.FindGameObjectWithTag("Energy").GetComponent<EnergiBar>().startGame();
            Destroy(gameObject);
        }
	}
}
