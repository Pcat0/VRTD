using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XRPlus;
public class Shop : MonoBehaviour {
    public float rotAmp = 0;

    [SerializeField]
    private float rotSpeed;
    [SerializeField]
    private Text nameField;
    [SerializeField]
    private Text descriptionField;
    [SerializeField]
    private Transform buildingPreview;
    [SerializeField]
    private SelectionWheel wheel;
    [SerializeField]
    private GameObject testObject;

    public BuildingType[] avalibleBuildings;

    [SerializeField]
    private float AngleOffset;

    private bool isShown = true;
    private int _Index = 0;
    public int Index {
        get {
            return _Index;
        }
        set {
            _Index = value % avalibleBuildings.Length;
            RefreshShop();
        }
    }
    public BuildingType CurrentBuilding {
        get {
            return avalibleBuildings[Index];
        }
    }
    private void RefreshShop() {
        nameField.text = CurrentBuilding.buildingName;
        descriptionField.text = CurrentBuilding.description;
        if (buildingPreview.childCount != 0) {
            //Destroy(buildingPreview.GetChild(0).gameObject);
        }
        //Instantiate(CurrentBuilding.preFab, buildingPreview);
    }
    public void ShowShop() {
        //TODO: Show holo
        isShown = true;
    }
    public void HideShop() {
        //TODO: Hide holo
        isShown = false;
    }
    public void Next() {
        Index += 1;
    }
    public void Back() {
        Index -= 1;
    }
    // Use this for initialization
    void Awake() {
        //Index = 0;
    }
    // Update is called once per frame
    void Update() {
        float rot = XRPlusHandler.Left.GetTrueAxisDelta(XRAxisName.Horizontal) * rotAmp;
        wheel.Rotate(rot);
        return;
        buildingPreview.Rotate(Vector3.up * Time.deltaTime * rotSpeed);
        if (isShown) {
            float xAxis = XRPlusHandler.Left.Horizontal;
            float yAxis = XRPlusHandler.Left.Vertical;
            if (XRPlusHandler.OffController.GetButtonDown(XRButtonName.TrackpadPress)) {
                Debug.Log("down");
                Index += (int)xAxis;
            }

        }
    }
    
}
