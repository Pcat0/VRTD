using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace XRPlus {
    /// <summary>
    /// Button names 
    /// </summary>
    public enum XRButtonName {
        Menu,
        Grip,
        TriggerTouch,
        TrackpadPress,
        TrackpadTouch,
    }
    /// <summary>
    /// Axis names
    /// </summary>
    public enum XRAxisName {
        Trigger,
        Grip,
        Horizontal,
        Vertical,
    }
    /// <summary>
    /// left and right controller names;
    /// </summary>
    public enum XRControllerHand {
        Left,
        Right
    }
    //High: add axis value change
    /// <summary>
    /// Dont touch, (For internal use only).
    /// </summary>
    public static class XRInput {
        private static int frame = -1;
        private static bool[] gripValue = new bool[] { false, false };
        private static bool[] GripLastValue { get; set; }
        private static float[] lastAxisValue = new float[13];
        private static float[] thisAxisValue = new float[13];
        private static readonly int[] trackedAxis = { 9, 11, 1, 2, 10, 12, 4, 5 };
        private static bool[] GripValue {
            get {
                Update();
                return gripValue;
            }
            set { gripValue = value; }
        }
        
        [RuntimeInitializeOnLoadMethod]
        static void RuntimeInitialize() {
            Debug.Log("init");
            UnityMessageExtender.UpdateCall += Update;
        }
        static void Update() {
            //High: (cheack it run onces every frame and that it runs first)
            if (frame != Time.frameCount) {
                frame = Time.frameCount;
                GripLastValue = gripValue;
                gripValue = new bool[] {
                    Input.GetAxisRaw("joystick axis 12") == 1f,
                    Input.GetAxisRaw("joystick axis 11") == 1f
                };
                foreach (var index in trackedAxis) {
                    lastAxisValue[index] = thisAxisValue[index];
                    thisAxisValue[index] = GetAxis(index);
                }
            }
        }
        public static bool GetKey(int index) {
            if (index == 1) {
                return GripValue[0];
            } else if (index == 3) {
                return GripValue[1];
            } else {
                return Input.GetKey("joystick button " + index);
            }
        }
        public static bool GetKeyDown(int index) {
            if (index == 1) {
                return GripValue[0] && !GripLastValue[0];
            } else if (index == 3) {
                return GripValue[1] && !GripLastValue[1];
            } else {
                return Input.GetKeyDown("joystick button " + index);
            }
        }
        public static bool GetKeyUp(int index) {
            if (index == 1) {
                return !GripValue[0] && GripLastValue[0];
            } else if (index == 3) {
                return !GripValue[1] && GripLastValue[1];
            } else {
                return Input.GetKeyUp("joystick button " + index);
            }
        }
        public static float GetAxis(int index) {
            Update();
            return Input.GetAxisRaw("joystick axis " + index);
        }
        public static float GetAxisDelta(int index) {
            Update();
            return thisAxisValue[index] - lastAxisValue[index];
        }
    }

    /// <summary>
    /// Class containing state of a XR controller
    /// </summary>
    public class XRController {
        

        public readonly XRControllerHand hand;
        private readonly XRNode node;
        private readonly int[] buttonIndexes;
        private readonly int[] axisIndexes;

        public bool Menu { get { return GetButton(XRButtonName.Menu); } }
        public bool Grip { get { return GetButton(XRButtonName.Grip); } }
        public bool TriggerTouch { get { return GetButton(XRButtonName.TriggerTouch); } }
        public bool TrackpadPress { get { return GetButton(XRButtonName.TrackpadPress); } }
        public bool TrackpadTouch { get { return GetButton(XRButtonName.TrackpadTouch); } }

        public float Trigger { get { return GetAxis(XRAxisName.Trigger); } }
        public float GripAxis { get { return GetAxis(XRAxisName.Grip); } }
        public float Horizontal { get { return GetAxis(XRAxisName.Horizontal); } }
        public float Vertical { get { return GetAxis(XRAxisName.Vertical); } }

        public bool IsTracked {
            get {
                List<XRNodeState> nodeStates = new List<XRNodeState>();
                InputTracking.GetNodeStates(nodeStates);
                return nodeStates.Find(item => item.nodeType == node).tracked;
            }
        }

        public bool GetButton(XRButtonName buttonName) {
            return XRInput.GetKey(buttonIndexes[(int)buttonName]);
        }
        public bool GetButtonDown(XRButtonName buttonName) {
            return XRInput.GetKeyDown(buttonIndexes[(int)buttonName]);
        }
        public bool GetButtonUp(XRButtonName buttonName) {
            return XRInput.GetKeyUp(buttonIndexes[(int)buttonName]);
        }

        public float GetAxis(XRAxisName axisName) {
            return XRInput.GetAxis(axisIndexes[(int)axisName]);
        }
        /// <summary>
        /// Gets how mutch axisName axis value has changes since last frame.
        /// </summary>
        /// <param name="axisName">XRAxisName </param>
        /// <returns>float change in since last frame</returns>
        public float GetAxisDelta(XRAxisName axisName) {
            return XRInput.GetAxisDelta(axisIndexes[(int)axisName]);
        }
        /// <summary>
        /// Gets how mutch axisName axis value has changes since last frame,
        /// But will account for jump from 0,0 when a finger is set on the trackpad.
        /// </summary>
        /// <param name="axisName">XRAxisName </param>
        /// <returns>float change in since last frame</returns>
        public float GetTrueAxisDelta(XRAxisName axisName) {
            if (axisName == XRAxisName.Vertical || axisName == XRAxisName.Horizontal)
                if (GetButtonDown(XRButtonName.TrackpadTouch) || !GetButton(XRButtonName.TrackpadTouch))
                    return 0;
            return XRInput.GetAxisDelta(axisIndexes[(int)axisName]);
        }
        public XRController(XRControllerHand hand, int[] buttonIndexes, int[] axisIndexes) {
            this.hand = hand;
            this.buttonIndexes = buttonIndexes;
            this.axisIndexes = axisIndexes;
            node = (hand == XRControllerHand.Left) ? XRNode.LeftHand : XRNode.RightHand;
        }

    }
    /// <summary>
    /// TODO
    /// </summary>
    public static class XRPlusHandler {
        public static XRControllerHand mainHand = XRControllerHand.Right;
        public static XRControllerHand offHand = XRControllerHand.Left;

        public static XRController Left { get { return Controllers[XRControllerHand.Left]; } }
        public static XRController Right { get { return Controllers[XRControllerHand.Right]; } }
        public static XRController MainController { get { return Controllers[mainHand]; } }
        public static XRController OffController { get { return Controllers[offHand]; } }

        public static Dictionary<XRControllerHand, XRController> Controllers = new Dictionary<XRControllerHand, XRController>() {
            {XRControllerHand.Left, new XRController(XRControllerHand.Left, new int[] { 2, 3, 14, 8, 16}, new int[] { 9, 11, 1, 2}) },
            {XRControllerHand.Right, new XRController(XRControllerHand.Right, new int[] { 0, 1, 15, 9, 17}, new int[] { 10, 12, 4, 5}) }
        };

        public static void SetMainHand(XRControllerHand mainHand) {
            XRPlusHandler.mainHand = mainHand;
            offHand = (mainHand == XRControllerHand.Right) ? XRControllerHand.Left : XRControllerHand.Right;
        }
    }
}