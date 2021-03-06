﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WristComputer : MonoBehaviour {
    public TextController textController;
    private void Awake() {
        textController.values.Add("wave", "0");
        textController.values.Add("health", "100");
        textController.values.Add("flops", "0");
    }
    private void Update() {
        textController.values["wave"] = Game.waveManager.waveNumber.ToString();
        textController.values["health"] = "100";
        textController.values["flops"] = Game.player.flops.ToString();
    }
}
