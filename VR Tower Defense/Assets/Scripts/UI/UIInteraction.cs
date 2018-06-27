using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInteraction : MonoBehaviour {
    [SerializeField]
    private LayerMask layerMask;
    public Transform point;
    void Update() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5f, layerMask)) {
            point.position = hit.point;
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("UI")) {
                VRUI ui = hit.collider.GetComponent<VRUI>();
                if (ui != null) {
                    ui.OnHoverEnter(new Vector2(0, 0), new ControllerState(0f));
                }
            }
        }
    }
}
