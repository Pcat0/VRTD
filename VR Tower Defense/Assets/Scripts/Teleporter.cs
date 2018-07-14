using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XRPlus;


//TODO: Move laser pointer and UI code to dif file
public class Teleporter : MonoBehaviour {
    private bool firstFrameUp = false;
    private Node _hoverNode = null;
    [SerializeField]
    private Color hoverColor;
    private Color oldColor;
    //public Transform XRRig;
    public GameObject laserPrefab;
    
    private Transform laser;
    private Node hoverNode {
        get { return _hoverNode; }
        set {
            if (value != _hoverNode) {
                if (_hoverNode != null)
                    HoverExit(hoverNode);
                if (value != null)
                    HoverEnter(value);
                _hoverNode = value;
            }
        }
    }
    public void HoverEnter(Node node) {
        oldColor = node.renderer.material.color;
        node.renderer.material.color = hoverColor;
    }
    public void HoverExit(Node node) {
        node.renderer.material.color = oldColor;
    }
    private void Awake() {
        laser = Instantiate(laserPrefab, transform).transform;
    }
    // Update is called once per frame
    void Update() {
        if (XRPlusHandler.Left.Trigger >= .9f) {
            //Debug.Log("triggerDown");
            firstFrameUp = true;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 20f, 1 << 8)) {
                Node newNode = hit.collider.GetComponent<Node>();
                ShowLaser(hit);
                if (newNode != null) {
                    hoverNode = newNode;
                }
            } else {
                ShowLaser(transform.TransformDirection(Vector3.forward), 40f);
                hoverNode = null;
            }
        } else if (firstFrameUp) {
            HideLaser();
            if (hoverNode != null) {
                firstFrameUp = false;
                Game.player.Teleport(hoverNode);
                hoverNode = null;
            }
        }
    }
    private void ShowLaser(RaycastHit hit) {
        Vector3 hitPoint = hit.point;
        laser.gameObject.SetActive(true);
        laser.position = Vector3.Lerp(transform.position, hitPoint, .5f);
        laser.LookAt(hitPoint);
        laser.localScale = new Vector3(laser.localScale.x, laser.localScale.y,
            hit.distance);
    }
    private void ShowLaser(Vector3 dir, float distance) {
        Vector3 hitPoint = dir.normalized * distance + transform.position;
        laser.gameObject.SetActive(true);
        laser.position = Vector3.Lerp(transform.position, hitPoint, .5f);
        laser.LookAt(hitPoint);
        laser.localScale = new Vector3(laser.localScale.x, laser.localScale.y,
            distance);
    }
    private void HideLaser() {
        laser.gameObject.SetActive(false);
    }
}