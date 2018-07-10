using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XRPlus;
public class XRtest : MonoBehaviour { 
    void OnXRControllerButtonDown(XRController controller, XRInputEventArgs eventArgs) {
        Debug.Log("button Down");
    }
    void OnXRControllerButtonUp(XRController controller, XRInputEventArgs eventArgs) {
        Debug.Log("button up");
    }
    void OnXRControllerButtonStay(XRController controller, XRInputEventArgs eventArgs) {
        Debug.Log("button Stay");
    }
}
