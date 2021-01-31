using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public EnemySpawnArea spawnArea;
    public GameObject enemyObject;
    public EnemyTriggerPoint triggerPoint;

    private bool hasSpawnedEnemies;
    
    private void Start() {
        triggerPoint.TriggerEnter += PlayerEnteredTrigger;
    }

    private void PlayerEnteredTrigger(GameObject obj) {
        if(obj != null && !hasSpawnedEnemies) {
            hasSpawnedEnemies = true;
            StartCoroutine(EnemyDrop(obj));
        }
    }

    private IEnumerator EnemyDrop(GameObject player) {
        for(int i = 0; i < spawnArea.enemyCount; ++i) {
            float xPos = UnityEngine.Random.Range(spawnArea.minT.position.x, spawnArea.maxT.position.x);
            float yPos = spawnArea.maxT.position.y;
            float zPos = UnityEngine.Random.Range(spawnArea.minT.position.z, spawnArea.maxT.position.z);
            Instantiate(enemyObject, new Vector3(xPos, yPos, zPos), Quaternion.identity).GetComponent<EnemyBrain>().LookAt = player.transform;
            yield return new WaitForSeconds(0.1f);
        }
    }
}

[System.Serializable]
public struct EnemySpawnArea {
    public Transform minT, maxT;
    public int enemyCount;
}