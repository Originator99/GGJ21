using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemySpawnArea spawnArea;

    public GameObject enemyObject, playerObject;

    private float xPos, yPos, zPos;

    private void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    private IEnumerator EnemyDrop()
    {
        for(int i = 0; i < spawnArea.enemyCount; ++i)
        {
            xPos = Random.Range(spawnArea.minPos.x, spawnArea.maxPos.x);
            yPos = Random.Range(spawnArea.minPos.y, spawnArea.maxPos.y);
            zPos = Random.Range(spawnArea.minPos.z, spawnArea.maxPos.z);
            Instantiate(enemyObject, new Vector3(xPos, yPos, zPos), Quaternion.identity).GetComponent<EnemyBrain>().LookAt = playerObject.transform;
            yield return new WaitForSeconds(0.1f);
        }
    }
}

[System.Serializable]
public struct EnemySpawnArea
{
    public Vector3 minPos, maxPos;
    public int enemyCount;
}