using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerState {
    public readonly bool grip;
    public readonly bool trackpad;
    public readonly bool menu;

    public readonly float trigger;

    public readonly Vector2 trackpadTouch;

    public ControllerState(float trigger) {
        this.trigger = trigger;
    }
}
