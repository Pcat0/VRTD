using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
   
    private Color oldColor;
    public bool playerPresent;
    public new Renderer renderer;
    [SerializeField]
    private Transform buildingTrasform;


    private int buildingIndex = 0;
    public Building currentBuilding;
    private void Awake() {
        oldColor = renderer.material.color;
    }

    private void Start() {
        //HACK: Node needs a building (and destroying) function
        currentBuilding = Instantiate(Game.buildings[buildingIndex].gameObject, buildingTrasform).GetComponent<Building>();
        if (playerPresent) {
            //TODO: Fix the thing not poping up
            currentBuilding.OnPlayerEnter();
            print("do da thing");
        }
            
    }
    public void OnPlayerEnter() {
        playerPresent = true;
        if (currentBuilding != null)
            currentBuilding.OnPlayerEnter();
    }
    public void OnPlayerExit() {
        playerPresent = false;
        if (currentBuilding != null)
            currentBuilding.OnPlayerExit();
    }
}
