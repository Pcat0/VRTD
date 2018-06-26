using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;

public class VRInputHandler : MonoBehaviour {

    public XRNode controllerXRNode;

    [HideInInspector]
    public bool isAvalible;

    [SerializeField]
    private GameObject model;
    void Start() {
        CheckJoysticks();
    }

    void CheckJoysticks() {
        List<XRNodeState> nodeStates = new List<XRNodeState>();
        InputTracking.GetNodeStates(nodeStates);
        if (nodeStates.Find(item => item.nodeType == controllerXRNode).tracked) {
            isAvalible = true;
            model.SetActive(true);
            Invoke("CheckJoysticks", 5f);
        } else {
            isAvalible = false;
            model.SetActive(false);
            Invoke("CheckJoysticks", .5f);
        }
    }

    // Update is called once per frame
    void Update () {
        //UnityEngine.Input.GetAxis(0);
    }
}
