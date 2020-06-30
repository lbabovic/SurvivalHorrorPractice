using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour {
    public static float distanceFromTarget;
    public float toTarget;
    public static Transform currentTransform;

    // Start is called before the first frame update
    void Start() {
        currentTransform = this.transform;
    }

    // Update is called once per frame
    void Update() {
        currentTransform = this.transform;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit)) {
            toTarget = hit.distance;
            distanceFromTarget = toTarget;
        }
    }
}
