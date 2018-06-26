using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyController : MonoBehaviour {
    public float speed = 1f;
    public float maxHealth;
    public float health;

    public Waypoint startWaypoint;
    [SerializeField]
    private float stopingDistance = .2f;
    [SerializeField]
    private Image healthBar;


    private Waypoint waypoint;
    private void Awake() {
        health = maxHealth;
    }
    void Start () {
        if(!FindNextWaypoint(startWaypoint, out waypoint))
            Debug.LogError("Enemy start waypoint cant have isEnd flag");

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 distance = Vector3.Scale(waypoint.position - transform.position, new Vector3(1, 0, 1));
        if (distance.magnitude <= stopingDistance) {
            if(!FindNextWaypoint(waypoint, out waypoint)) {
                OnEndReached();
                return;
            }
        }
        Quaternion lookRot = Quaternion.LookRotation(distance.normalized);
        transform.rotation = lookRot;
        if (distance.magnitude < 0)
            Debug.LogError("distance magnitude < 0! (add that ABS)");
        Vector3 moveDist = transform.forward * Mathf.Min(speed * Time.deltaTime, distance.magnitude);
        transform.position += moveDist;
        
    }
    protected bool FindNextWaypoint(Waypoint lastWaypoint, out Waypoint nextWaypoint) {
        if (!lastWaypoint.isEnd) {
            Waypoint[] possibleWaypoints = lastWaypoint.nextWaypoints;
            int ranIndex = Game.random.Next(possibleWaypoints.Length);
            nextWaypoint = possibleWaypoints[ranIndex];
            return true;
        } else {
            nextWaypoint = null;
            return false;
        }
        
    }
    protected virtual void OnEndReached() {
        Kill();
    }
    public bool Damage(float amount) {
        health -= amount;
        if (health <= 0) {
            Kill();
            return true;
        } else {
            healthBar.fillAmount = health / maxHealth ;
            return false;
        }
        
    }
    public void Kill() {
        GameObject.Destroy(gameObject);
        return;
    }
}
