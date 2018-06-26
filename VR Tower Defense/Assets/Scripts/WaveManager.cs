using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {
    public float timeBetweenWaves = 5f;
    public EnemyController[] enemyTypes;

    [Header("Readonly stuff")]
    public float timeToNextWave;
    public int waveNumber = 0;

    private static bool hasInit = false;
    private bool isMainWaveManager = false;

    // Use this for initialization
    void Awake () {
        if (hasInit) {
            Debug.LogError("There can be only one! (WaveManager)");
            return;
        } else {
            isMainWaveManager = true;
        }
        timeToNextWave = timeBetweenWaves;
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isMainWaveManager)
            return;
        
        if(timeToNextWave <= 0) {
            waveNumber++;
            timeToNextWave = timeBetweenWaves;
            StartCoroutine(SpawnWave());
        }
        timeToNextWave -= Time.deltaTime;
    }
    IEnumerator SpawnWave() {
        for (int i = 0; i < waveNumber; i++) {
            int ranIndex = Game.random.Next(WaypointManager.startPoints.Count);
            Waypoint startPoint = WaypointManager.startPoints[ranIndex];

            GameObject newEnemy = Instantiate(enemyTypes[0].gameObject, startPoint.transform.position, startPoint.transform.rotation);
            newEnemy.GetComponent<EnemyController>().startWaypoint = startPoint;

            yield return new WaitForSeconds(0.5f);
        }
    }
}
