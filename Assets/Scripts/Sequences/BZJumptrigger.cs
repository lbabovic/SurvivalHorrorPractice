using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BZJumptrigger : MonoBehaviour {
    public AudioSource doorBang;
    public AudioSource doorJumpMusic;
    public GameObject theZombie;
    public GameObject theDoor;

    public void OnTriggerEnter(Collider other) {
        this.GetComponent<BoxCollider>().enabled = false;
        theDoor.GetComponent<Animation>().Play("Door1HingeAnim");
        doorBang.Play();
        StartCoroutine(MakeZombieMove());
        StartCoroutine(PlayJumpMusic());
    }

    IEnumerator MakeZombieMove() {
        yield return new WaitForSeconds(0.25f);
        theZombie.SetActive(true);
    }

    IEnumerator PlayJumpMusic() {
        yield return new WaitForSeconds(0.5f);
        doorJumpMusic.Play();
    }
}
