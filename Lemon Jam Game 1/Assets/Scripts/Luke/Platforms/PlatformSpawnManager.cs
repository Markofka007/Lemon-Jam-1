using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnManager : MonoBehaviour
{
    public float timeToSpawn;
    public GameObject[] platforms;
    public Transform spawnSpot;
    public bool doSpawn = true;

    private void Start()
    {
        //Instantiate(platforms[Random.Range(0, platforms.Length)], spawnSpot.position, Quaternion.identity);
    }

    public GameObject SpawnPlatform(GameObject platformSegment)
    {
        Debug.Log("Spawn ran");
        return (GameObject)Instantiate(platformSegment, spawnSpot.position, Quaternion.identity);
    }
}
