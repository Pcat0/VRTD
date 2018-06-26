using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPicker : MonoBehaviour {

	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1f,  9)) {
            print("hit");
        }
	}
}
