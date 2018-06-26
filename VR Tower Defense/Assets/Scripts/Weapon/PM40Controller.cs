using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM40Controller : MonoBehaviour {
    public Transform trigger;
    public float rotAmount = 25f;

    // Update is called once per frame
    void Update () {
        float axis = Input.GetAxis("RTrigger");
        trigger.localRotation = Quaternion.Euler(-axis * rotAmount, 0, 0);
    }   
}
