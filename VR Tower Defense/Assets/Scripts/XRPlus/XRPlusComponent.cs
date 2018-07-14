using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using XRPlus_;
//TODO: clean up
namespace XRPlus_ {
    public enum XRControllerHand { Left, Right };
    public enum XRControllerType { Vive, Oculus };
    public enum XRButton { Grip, Trigger, Trackpad, Menu };
    public enum XRAxis { TrackpadX, TrackpadY, Trigger};

   

    public class XRController {

        public static Dictionary<XRControllerHand, XRController> XRControllers = new Dictionary<XRControllerHand, XRController>();
        
        //hand prefix
        private readonly string h;
        public readonly XRControllerHand hand;
        public Dictionary<XRButton, bool> Buttons = new Dictionary<XRButton, bool>();
        public Dictionary<XRAxis, float> Axes = new Dictionary<XRAxis, float>();

        public XRController(XRControllerHand hand) {

            this.hand = hand;
            h = hand == XRControllerHand.Left ? "L" : "R";

            XRControllers.Add(hand, this);
            foreach (XRButton item in Enum.GetValues(typeof(XRButton))) {
                Buttons.Add(item, false);
            }
        }
        private void UpdateButton(XRButton button, bool value) {
            if (Buttons[button] != value) {
                if (value) {
                    XRInputEventHandler.OnButtonDown(this, new XRInputEventArgs(this, XRInputEventArgs.XREventType.Button));
                } else {
                    XRInputEventHandler.OnButtonUp(this, new XRInputEventArgs(this, XRInputEventArgs.XREventType.Button));
                }
            } else if (value) {
                XRInputEventHandler.OnButtonStay(this, new XRInputEventArgs(this, XRInputEventArgs.XREventType.Button));
            }
        }
        public void Update() {
            float triggerValue = Input.GetAxisRaw(h + "Trigger");
            Axes[XRAxis.Trigger] = triggerValue;
            //UpdateButton(XRButton.Trigger, triggerValue == 1f);
        }
    }

    public class XRInputEventArgs : EventArgs {
        public enum XREventType { Button }
        public readonly XRController controller;
        public readonly XREventType eventType; 
        public XRInputEventArgs(XRController controller, XREventType eventType) {
            this.controller = controller;
            this.eventType = eventType;
        }
    }

    //Change: change to Component.SendMessage maybe
    public static class XRInputEventHandler {
        public delegate void XRInputEvent(XRController controller, XRInputEventArgs eventArgs);

        public static XRInputEvent OnButtonDown;
        public static XRInputEvent OnButtonStay;
        public static XRInputEvent OnButtonUp;

        private static XRInputEvent CreateDelegate(MethodInfo method) {
            return (XRInputEvent)Delegate.CreateDelegate(typeof(XRInputEvent), method);
        }
        private static void CreateXRGameObject() {
            new GameObject("[XRPlus]", typeof(XRPlusComponent));
        }
        //[RuntimeInitializeOnLoadMethod]
        static void OnLoadMethod() {
            Debug.Log("loading VRInput Events");
            MonoBehaviour _monoBehaviour = (new MonoBehaviour());
            Type monoBehaviour = typeof(MonoBehaviour);
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in types) {
                if (type.IsSubclassOf(monoBehaviour)) {
                    MethodInfo[] methods = type.GetMethods();
                    foreach (var method in methods) {
                        switch (method.Name) {
                            case "OnXRControllerButtonDown":
                                Debug.Log(type.ToString() + "." + method.ToString());
                                OnButtonDown += CreateDelegate(method);
                                break;

                            case "OnXRControllerButtonStay":
                                Debug.Log(type.ToString() + "." + method.ToString());
                                OnButtonStay += CreateDelegate(method);
                                break;

                            case "OnXRControllerButtonUp":
                                Debug.Log(type.ToString() + "." + method.ToString());
                                OnButtonUp += CreateDelegate(method);
                                break;
                            
                        }
                    }
                }
            }
            //CreateXRGameObject();
            //High: I Dont Like how this looks
        }
    }
}
[DisallowMultipleComponent]
public class XRPlusComponent : MonoBehaviour {
    private void Update() {
        //XRController.XRControllers[XRControllerHand.Left].Update();
        //XRController.XRControllers[XRControllerHand.Right].Update();
    }
}
