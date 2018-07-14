using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using XRPlus;

public class ControllerInspectorWindow : EditorWindow {
    public XRControllerHand ActiveHand = XRControllerHand.Left;
    Image trackpad;
    Image crosshairs;
    public XRController ActiveController {
        get {
            return XRPlusHandler.Controllers[ActiveHand];
        }
    }
    [MenuItem("Tools/Controller Inspector/Open")]
    public static void ShowWindow() {
        ControllerInspectorWindow window = CreateInstance<ControllerInspectorWindow>();
        window.Load();
        window.titleContent = new GUIContent("VR Controller");
        window.Show();
    }

    public void Load() {

    }
    void OnGUI() {
        DrawToolBar();
        GUILayout.Toggle(ActiveController.Menu, "Menu");
        GUILayout.Toggle(ActiveController.Grip, "Grip");
        GUILayout.Toggle(ActiveController.TriggerTouch, "Trigger");
        GUILayout.Toggle(ActiveController.TrackpadPress, "Trackpad (press)");
        GUILayout.Toggle(ActiveController.TrackpadTouch, "Trackpad (touch)");

        GUILayout.Label(ActiveController.Trigger.ToString() + " Trigger");
        GUILayout.Label(ActiveController.GripAxis.ToString() + " Grip (Axis)");
        GUILayout.Label(ActiveController.Horizontal.ToString() + " Horizontal");
        GUILayout.Label(ActiveController.Vertical.ToString() + " Vertical");
    }
    void DrawTrackpad() {
        GUILayout.BeginArea(new Rect(0, 0, 100, 100), image);
        GUILayout.
    }
    void DrawToolBar() {
        GUILayout.BeginHorizontal(EditorStyles.toolbar);
        if (GUILayout.Button("Controller", EditorStyles.toolbarDropDown)) {
            GenericMenu controllerMenu = new GenericMenu();
            controllerMenu.AddMenuItem(new GUIContent("Left"), XRPlusHandler.Left.IsTracked || Application.isEditor, ActiveHand == XRControllerHand.Left, delegate () {
                ActiveHand = XRControllerHand.Left;
            });
            controllerMenu.AddMenuItem(new GUIContent("Right"), XRPlusHandler.Right.IsTracked || Application.isEditor, ActiveHand == XRControllerHand.Right, delegate () {
                ActiveHand = XRControllerHand.Right;
            });
            controllerMenu.DropDown(new Rect(0, 0, 0, 16));
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
    }
    private void Update() {
        if (Application.isPlaying) {
            Repaint();
        }
    }

}

