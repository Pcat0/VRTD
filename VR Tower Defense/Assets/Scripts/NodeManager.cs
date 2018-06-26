using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour {
    public static GameObject[] nodes;
    //TODO: Add find Node method(s) 
    private void Awake() {
        nodes = GameObject.FindGameObjectsWithTag("node");
    }
}
