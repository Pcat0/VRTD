using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    public static readonly System.Random random = new System.Random();

    public static Building[] buildings;
    [SerializeField]
    private Building[] buildingsTypes;

    public static Player player;
    [SerializeField]
    private Node startNode;
    [SerializeField]
    private Transform XRRig;

    private void Awake() {
        buildings = buildingsTypes;
        player = new Player(startNode, XRRig);
    }
}
