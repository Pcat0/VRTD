using UnityEngine;

public class TargetNearest : MonoBehaviour {
    public TurretController turretController;
    public float range;
    private GameObject currentTaget;
    //private float currentDistance;
    // Update is called once per frame
    private void Start() {
        InvokeRepeating("FindTarget", 0f, .5f);
    }
    private void FindTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearest = null;
        float closestDistance = Mathf.Infinity;
        foreach (GameObject enemy in enemies) {
            float distance = (transform.position - enemy.transform.position).magnitude;
            if (distance < closestDistance) {
                closestDistance = distance;
                nearest = enemy;
            }
        }
        if (nearest != null) {
            if (closestDistance <= range) {
                currentTaget = nearest;
            } else {
                currentTaget = null;
            }
            
        }
    }
    private void Update() {
        if (currentTaget != null) {
            Quaternion lookRot = Quaternion.LookRotation(currentTaget.transform.position - transform.position);
            turretController.yRot = lookRot.eulerAngles.y;
        }
        
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
