using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//HACK: do non-temp repeat fire
public class TempRepeatFire : MonoBehaviour {
    public TurretController turretController;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Fire", 0f, .1f);
	}
	
	private void Fire() {
        turretController.Fire();
    }
}
