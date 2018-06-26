using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoloMap : MonoBehaviour {
    public GameObject holoCube;
    private void Start() {
        foreach (GameObject node in NodeManager.nodes) {
            Vector3 targetPosition = node.transform.position;
            targetPosition.Scale(transform.localScale);
            GameObject newNode = Instantiate(holoCube, transform, false);
            newNode.transform.localPosition = node.transform.position;
            newNode.transform.rotation = node.transform.rotation;
        }
    }
}
