using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WristComputer : MonoBehaviour {
    public TextController textController;
    [SerializeField]
    private Transform holoTrasform; 
    private bool holoState = false;

    public Text nameField;
    public Text descriptionField;

    public BuildingType[] buildingTypes;
private void Awake() {
        textController.values.Add("wave", "0");
        textController.values.Add("health", "100");
        textController.values.Add("flops", "0");
        nameField.text = buildingTypes[0].nameType;
        descriptionField.text = buildingTypes[0].description;
    }
    private void Update() {
        textController.values["wave"] = Game.waveManager.waveNumber.ToString();
        textController.values["health"] = "100";
        textController.values["flops"] = Game.player.flops.ToString();
    }
    private void ShowHolo() {
        //TODO: Show holo
        holoState = true;
    }
    private void HideHolo() {
        //TODO: Hide holo
        holoState = true;
    }
}
