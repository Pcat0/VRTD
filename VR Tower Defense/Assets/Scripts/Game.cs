using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XRPlus;
[DisallowMultipleComponent]
public class Game : MonoBehaviour {
    public static readonly System.Random random = new System.Random();

    public static Building[] buildings;
    [SerializeField]
    private Building[] buildingsTypes;

    public static Player player;
    public static WaveManager waveManager;

    [SerializeField]
    private float flops;

    [SerializeField]
    private Node startNode;

    [SerializeField]
    private Transform XRRig;



    private void Start() {
        
    }
    private void Awake() {
        waveManager = GetComponent<WaveManager>();
        buildings = buildingsTypes;
        player = new Player(startNode, XRRig);
    }
    private void Update() {
        player.flops = flops;
    }

}
