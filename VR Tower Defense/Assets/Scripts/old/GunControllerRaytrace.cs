using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunControllerRaytrace : MonoBehaviour {

    public float damage;
    public float fireCooldown;
    public Transform barrelLocation;
    public bool trigger;

    
    public UnityEvent onFire;

    protected bool canFire = true;
    protected float timeToNextShot;
    // Use this for initialization
    void Awake() {
        timeToNextShot = 0;

    }

    // Update is called once per frame
    void Update() {
        if (timeToNextShot <= 0) {
            if (!canFire) {
                canFire = true;
                timeToNextShot = fireCooldown;
            }
        } else {
            timeToNextShot -= Time.deltaTime;
        }
        if (canFire && trigger) {
            shoot();
            canFire = false;
        }


    }

    public void shoot() {
        Ray ray = new Ray(barrelLocation.position, barrelLocation.rotation * Vector3.forward);
        RaycastHit raycastHit = new RaycastHit();
        Debug.DrawRay(ray.origin, ray.direction);
        if (Physics.Raycast(ray, out raycastHit)) {
            EnemyController enemyController = raycastHit.collider.GetComponent<EnemyController>();
            if (enemyController != null) {
                print("hit");
                enemyController.Damage(damage);
            }
        }
        //
    }
}
