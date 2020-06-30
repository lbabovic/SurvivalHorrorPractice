using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameAnimations : MonoBehaviour {
    public int lightMode;
    public GameObject flameLight;

    // Update is called once per frame
    void Update() {
        if (lightMode == 0) {
            StartCoroutine(AnimateLight());
        }
    }

    IEnumerator AnimateLight() {
        lightMode = Random.Range(1, 4);
        flameLight.GetComponent<Animation>().Play("TorchAnim" + lightMode);
        yield return new WaitForSeconds(0.99f);
        lightMode = 0;
    }
}
