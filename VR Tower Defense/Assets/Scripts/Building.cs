using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
    protected Node parentNode;

    public virtual void OnPlayerEnter() {}
    public virtual void OnPlayerExit() {}
    public virtual void OnDistroy() {

    }
    public virtual void OnCreate(Node node) {
        parentNode = node;
    }
}
