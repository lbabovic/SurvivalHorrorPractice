using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class AOpening : MonoBehaviour {
    public GameObject thePlayer;
    public GameObject fadeScreenIn;
    public GameObject textBox;


    // Start is called before the first frame update
    void Start() {
        thePlayer.GetComponent<FirstPersonController>().enabled = false;
        fadeScreenIn.GetComponent<Animation>().Play("FadeScreenInAnim");
        StartCoroutine(ScenePlayer());
    }

    // Update is called once per frame
    void Update() {
        
    }

    IEnumerator ScenePlayer() {
        yield return new WaitForSeconds(1.5f);
        fadeScreenIn.SetActive(false);
        textBox.GetComponent<Text>().text = "I need to get out of here...";
        yield return new WaitForSeconds(1.5f);
        textBox.GetComponent<Text>().text = "";
        thePlayer.GetComponent<FirstPersonController>().enabled = true;
    }
}
