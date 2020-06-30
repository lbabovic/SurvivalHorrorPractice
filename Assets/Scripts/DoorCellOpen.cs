using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorCellOpen : MonoBehaviour {
    public float theDistance;
    public GameObject actionDisplay;
    public GameObject actiontext;
    public GameObject theDoor;
    public GameObject extraCrosshair;
    public AudioSource creakSound;


    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        theDistance = PlayerCasting.distanceFromTarget;

    }

    private void OnMouseOver() {
        if (theDistance <= 2) {
            actionDisplay.SetActive(true);
            actiontext.SetActive(true);
            extraCrosshair.SetActive(true);
        }
        if (Input.GetButtonDown("Action") && theDistance <= 2) {

            this.GetComponent<BoxCollider>().enabled = false;
            actionDisplay.SetActive(false);
            actiontext.SetActive(false);
            extraCrosshair.SetActive(false);
            theDoor.GetComponent<Animation>().Play("FirstDoorOpenAnim");
            creakSound.Play();
        }
    }

    private void OnMouseExit() {
        actionDisplay.SetActive(false);
        actiontext.SetActive(false);
        extraCrosshair.SetActive(false);
    }
}
