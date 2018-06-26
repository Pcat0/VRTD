using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour {
    public static Waypoint[] waypoints;
    public static List<Waypoint> startPoints = new List<Waypoint>();
    private void Awake() {
        GameObject[] foundWaypoints = GameObject.FindGameObjectsWithTag("waypoint");
        waypoints = new Waypoint[foundWaypoints.Length];
        for (int i = 0; i < foundWaypoints.Length; i++) {
            Waypoint waypoint = foundWaypoints[i].GetComponent<Waypoint>();
            waypoints[i] = waypoint;
            if (waypoint.isStart) {
                startPoints.Add(waypoint);
            }
        }
    }
}
  