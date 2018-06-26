using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class FireEvent : UnityEvent<GameObject> {}

public class GunController : MonoBehaviour {
    public float fireCooldown;
    public Transform barrelLocation;
    public GameObject Bullet;
    public bool trigger;

    public FireEvent onFire;

    protected bool canFire = true;
    protected float timeToNextShot;
	// Use this for initialization
	void Awake () {
        timeToNextShot = 0;

    }
	
	// Update is called once per frame
	void Update () {
        if (timeToNextShot <= 0) {
            if (!canFire) {
                canFire = true;
                timeToNextShot = fireCooldown - Time.deltaTime;
            }
        } else {
            timeToNextShot -= Time.deltaTime;
        }
        if (canFire && trigger) {
            shoot();
            canFire = false;
        }
        

	}

    private void shoot() {
        GameObject newBullet = Instantiate(Bullet, barrelLocation.position, barrelLocation.rotation);
        onFire.Invoke(newBullet);
    }
}
