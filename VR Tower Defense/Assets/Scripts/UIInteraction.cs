using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInteraction : MonoBehaviour {
    private LayerMask layerMask;
    void Update() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, layerMask)) {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("UI")) {

            }
        }
    }
}
