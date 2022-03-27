using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClouds : MonoBehaviour
{
    [SerializeField] private GameObject[] cloudPrefabs;    
    [SerializeField] private float yMax;
    [SerializeField] private float yMin;
    [SerializeField] private float xSpawn;

    [SerializeField] private float cloudSpawnCooldown = 5;
    private float cloudSpawnCounter;

    void Start()
    {
        cloudSpawnCounter = 0.1f;
    }

    void Update()
    {
        if (cloudSpawnCounter > 0)
        {
            cloudSpawnCounter -= Time.deltaTime;

            if (cloudSpawnCounter <= 0)
            {
                Instantiate(cloudPrefabs[Random.Range(0,2)], new Vector3(xSpawn, Random.Range(yMin, yMax), 0), Quaternion.identity);
                cloudSpawnCounter = cloudSpawnCooldown;
            }
        }

    }
}
