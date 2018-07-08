using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WristComputer : MonoBehaviour {
    public float rotSpeed;
    public TextController textController;
    [SerializeField]
    private Transform holoTrasform;
    
    

    [SerializeField]
    private Text nameField;
    [SerializeField]
    private Text descriptionField;
    [SerializeField]
    private Transform buildingPreview;

    public BuildingType[] buildingsInShop;

    private bool shopState = false;
    private int _ShopIndex = 0;
    public int ShopIndex {
        get {
            return _ShopIndex;
        }
        set {
            _ShopIndex = value % buildingsInShop.Length;
            RefreshShop();
        }
    }
    public BuildingType DisplayedBuilding {
        get {
            return buildingsInShop[ShopIndex];
        }
    }
    private void RefreshShop() {
        nameField.text = DisplayedBuilding.buildingName;
        descriptionField.text = DisplayedBuilding.description;
        if (buildingPreview.childCount != 0) {
            Destroy(buildingPreview.GetChild(0).gameObject);
        }
        Instantiate(DisplayedBuilding.preFab, buildingPreview);
    } 
    private void Awake() {
        textController.values.Add("wave", "0");
        textController.values.Add("health", "100");
        textController.values.Add("flops", "0");
        ShopIndex = 0;

    }
    private void Update() {
        textController.values["wave"] = Game.waveManager.waveNumber.ToString();
        textController.values["health"] = "100";
        textController.values["flops"] = Game.player.flops.ToString();
        buildingPreview.Rotate(Vector3.up * Time.deltaTime * rotSpeed);
    }
    private void ShowShop() {
        //TODO: Show holo
        shopState = true;
    }
    private void HideShop() {
        //TODO: Hide holo
        shopState = false;
    }
    
}
