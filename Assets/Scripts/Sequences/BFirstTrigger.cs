﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class BFirstTrigger : MonoBehaviour {
    public GameObject thePlayer;
    public GameObject textBox;
    public GameObject theMarker;

    private void OnTriggerEnter(Collider other) {
        thePlayer.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(ScenePlayer());
    }

    IEnumerator ScenePlayer() {
        textBox.GetComponent<Text>().text = "Looks like a weapon on that table.";
        yield return new WaitForSeconds(2.5f);
        textBox.GetComponent<Text>().text = "";
        thePlayer.GetComponent<FirstPersonController>().enabled = true;
        theMarker.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
