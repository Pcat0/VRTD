﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
    public Transform XRRig;
    public Node currentNode { get; private set; }
    public float flops;

    public Player(Node startingNode, Transform _XRRig) {
        XRRig = _XRRig;
        if (startingNode != null)
            Teleport(startingNode);
    } 
    public void Teleport(Node tpNode) {
        if (currentNode != null)
            currentNode.OnPlayerExit();
        currentNode = tpNode;
        XRRig.position = currentNode.transform.position;
        currentNode.OnPlayerEnter();
    }
}
