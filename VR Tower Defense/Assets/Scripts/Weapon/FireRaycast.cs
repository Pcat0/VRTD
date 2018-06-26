using UnityEngine;
public class FireRaycast : MonoBehaviour {
    public Transform barrelLocation;
    public float damage;

    public void Shoot() {
        Ray ray = new Ray(barrelLocation.position, barrelLocation.rotation * Vector3.forward);
        RaycastHit raycastHit = new RaycastHit();
        Debug.DrawRay(ray.origin, ray.direction);
        if (Physics.Raycast(ray, out raycastHit)) {
            EnemyController enemyController = raycastHit.collider.GetComponent<EnemyController>();
            if (enemyController != null) {
                enemyController.Damage(damage);
            }
        }
    }
}