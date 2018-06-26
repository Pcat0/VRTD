using System;
using UnityEngine;

[SelectionBase]
public class TurretController : MonoBehaviour {


    public float damage;
    [Range(0, 360)]
    public float zRot;

    [Range(0, 360)]
    public float yRot;
    [Tooltip("Lock Z")]
    public bool lockZ;
    [Tooltip("Lock Y")]
    public bool lockY;
   
    [Header("Transforms", order = 5)]
    public Transform zAxis;
    public Transform yAxis;
    public Transform barrelLocation;
    
    private void Update() {
        if (!lockZ) {
            Vector3 newZRot = zAxis.eulerAngles;
            newZRot.z = zRot;
            zAxis.eulerAngles = newZRot;
        }
        if (!lockY) {
            Vector3 newYRot = yAxis.eulerAngles;
            newYRot.y = yRot;
            yAxis.eulerAngles = newYRot;
        }
        
    }
    //TODO: Add turn speed limiting
    public virtual void Fire() {
        Ray ray = new Ray(barrelLocation.position, barrelLocation.rotation * Vector3.forward);
        RaycastHit raycastHit = new RaycastHit();
        if (Physics.Raycast(ray, out raycastHit)) {
            EnemyController enemyController = raycastHit.collider.GetComponent<EnemyController>();
            if (enemyController != null) {
                OnHit(enemyController);
            }
        }
    }
    protected virtual void OnHit(EnemyController enemyHit) {
        enemyHit.Damage(damage);
    }
}
