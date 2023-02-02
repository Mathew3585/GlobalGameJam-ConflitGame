using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabs : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject[] spawnPoints;
    public GameObject[] unusedSpawnPoints;

    void Start()
    {
        List<GameObject> unusedSpawnPointsList = new List<GameObject>();
        List<GameObject> spawnedPrefabsList = new List<GameObject>();

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            unusedSpawnPointsList.Add(spawnPoints[i]);
        }

        for (int i = 0; i < prefabs.Length; i++)
        {
            int spawnPointIndex = Random.Range(0, unusedSpawnPointsList.Count);

            GameObject spawnPoint = unusedSpawnPointsList[spawnPointIndex];
            GameObject spawnedPrefab = Instantiate(prefabs[i], spawnPoint.transform.position, Quaternion.identity);
            spawnedPrefab.transform.parent = spawnPoint.transform;
            spawnedPrefabsList.Add(spawnedPrefab);

            unusedSpawnPointsList.RemoveAt(spawnPointIndex);
        }

        unusedSpawnPoints = unusedSpawnPointsList.ToArray();
        spawnedPrefabsList.ToArray();
    }
}
