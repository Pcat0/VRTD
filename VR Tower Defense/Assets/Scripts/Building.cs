using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
    protected Node parentNode;
    [SerializeField]
    protected GameObject controller;
    public virtual void OnPlayerEnter() {}
    public virtual void OnPlayerExit() {}
    public virtual void OnDistroy() {

    }
    public virtual void OnCreate(Node node) {
        parentNode = node;
    }
    public void Enable() {
        controller.SetActive(true);
    }
    public void Disable() {
        controller.SetActive(false);
    }
}
