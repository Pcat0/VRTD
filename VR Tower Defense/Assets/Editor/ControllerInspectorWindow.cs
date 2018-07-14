using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using XRPlus;

public class ControllerInspectorWindow : EditorWindow {
    public XRControllerHand ActiveHand = XRControllerHand.Left;
    Texture trackpad;
    Texture crosshairs;
    public XRController ActiveController {
        get {
            return XRPlusHandler.Controllers[ActiveHand];
        }
    }
    [MenuItem("Tools/Controller Inspector/Open")]
    public static void ShowWindow() {
        ControllerInspectorWindow window = CreateInstance<ControllerInspectorWindow>();
        window.titleContent = new GUIContent("VR Controller");
        window.Show();
    }

    void Awake() {
        trackpad = EditorGUIUtility.LoadRequired("Trackpad.png") as Texture;
        crosshairs = EditorGUIUtility.LoadRequired("Crosshairs.png") as Texture;
        Debug.Log(trackpad);
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

        DrawTrackpad(200, 200, ActiveController.Horizontal, ActiveController.Vertical, ActiveController.TrackpadTouch);
    }
    void DrawTrackpad(float width, float height, float x, float y, bool showCrosshairs) {
        GUI.BeginGroup(new Rect(Screen.width / 2 - width / 2, Screen.height / 2 - height / 2, width, height));
        GUI.Box(new Rect(0, 0, width, height), trackpad);
        if (showCrosshairs)
            GUI.Box(new Rect(width * (x * .5f *.5f + .5f) - 10, height * (y * .5f * .5f + .5f) - 10, 20, 20), crosshairs);
        GUI.EndGroup();
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

