using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorBuilding : Building {
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private Transform projectionTF;
    [SerializeField]
    private GameObject projectionGB;
    [SerializeField]
    private Animator projectorAnimator;

    private void Start() {
        //TODO: add holo code
        Instantiate(projectionGB, projectionTF);
    }
    private void Update() {
        projectionTF.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
    public void StartProjecting() {
        Debug.Log("Started Projecting");
        projectionTF.gameObject.SetActive(true);
    }
    public void StopProjecting() {
        Debug.Log("Stoped Projecting");
        projectionTF.gameObject.SetActive(false);
    }
    public override void OnPlayerEnter() {
        base.OnPlayerEnter();
        projectorAnimator.SetBool("Up", true);
    }
    public override void OnPlayerExit() {
        base.OnPlayerExit();
        projectorAnimator.SetBool("Up", false);
    }
}
