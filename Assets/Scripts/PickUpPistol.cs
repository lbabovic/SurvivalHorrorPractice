using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpPistol : MonoBehaviour {
    public float theDistance;
    public GameObject actionDisplay;
    public GameObject actiontext;
    public GameObject fakePistol;
    public GameObject extraCrosshair;
    public GameObject realPistol;
    public GameObject guideArrow;
    public GameObject theJumpTrigger;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        theDistance = PlayerCasting.distanceFromTarget;

    }

    private void OnMouseOver() {
        if (theDistance <= 3) {
            actionDisplay.SetActive(true);
            actiontext.SetActive(true);
            actiontext.GetComponent<Text>().text = "Pick up pistol";
            extraCrosshair.SetActive(true);
        }
        if (Input.GetButtonDown("Action")) {
            if (theDistance <= 3) {
                this.GetComponent<BoxCollider>().enabled = false;
                actionDisplay.SetActive(false);
                actiontext.SetActive(false);
                extraCrosshair.SetActive(false);
                fakePistol.SetActive(false);
                realPistol.SetActive(true);
                guideArrow.SetActive(false);
                theJumpTrigger.SetActive(true);
            }
        }
    }

    private void OnMouseExit() {
        actionDisplay.SetActive(false);
        actiontext.SetActive(false);
        extraCrosshair.SetActive(false);
    }
}
