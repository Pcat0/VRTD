using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
    public Waypoint[] nextWaypoints;
    public bool isStart = false;
    public bool isEnd = false;
    public Vector3 position {
        get { return transform.position; }
        set { transform.position = value; }
    }
    public Quaternion rotation {
        get { return transform.rotation; }
        set { transform.rotation = value; }
    }
    private void Awake() {
        if (nextWaypoints.Length == 0)
            isEnd = true;
    }
}
