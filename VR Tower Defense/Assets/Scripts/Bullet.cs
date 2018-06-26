using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed;
    public float lifeSpan;
    //TODO: change rot to -31.4
    private void OnEnable() {
        Invoke("kill", lifeSpan);
    }
    private void Update() {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    void OnTriggerEnter(Collider other) {
        print(other.GetComponent<EnemyController>());
        kill();
        if (other.GetComponent<EnemyController>() != null){
            Destroy(other.gameObject);
        }
    }
    void kill() {
        Destroy(gameObject);
    }
}
