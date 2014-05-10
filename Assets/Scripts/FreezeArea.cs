using UnityEngine;
using System.Collections;

public class FreezeArea : MonoBehaviour {
    SpriteRenderer spriteRenderer;
    float meltTime = 0;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

	// Update is called once per frame
	void Update () {
        meltTime += Time.deltaTime;
        float trans = (meltTime < 4) ? 1 : 5 - meltTime;

        spriteRenderer.color = new Color(1, 1, 1, trans);
       // if (meltTime >= 5)
       //     Destroy(gameObject);
    }
}
