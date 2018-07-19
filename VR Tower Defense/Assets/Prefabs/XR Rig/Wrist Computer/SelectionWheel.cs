using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionWheel : MonoBehaviour {
    public GameObject testObject;
    [SerializeField]
    private Transform edge;

    private float angleOffset = 30;
    private GameObject[] wheel;
    
    private Vector3 PointOnCircle(Vector3 center, float radius, float angle) {
        return center + Quaternion.AngleAxis(angle, Vector3.forward) * (Vector3.right * radius);
    }
    private void Awake() {
        wheel = new GameObject[(int)(360 / angleOffset)];
        float radius = (transform.position - edge.position).magnitude;
        for (int i = 0; i < (int)(360 / angleOffset); i++) {
            Vector3 location = PointOnCircle(transform.position, radius, i * angleOffset);
            wheel[i] = Instantiate(testObject, location, new Quaternion(), transform);
        }
    }
    public void Rotate(float angle) {
        transform.RotateAround(transform.position, transform.up, angle);
    }
}
