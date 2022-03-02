using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnManager : MonoBehaviour
{
    private bool shouldSpawn = false;
    private float timeSinceLastSpawn = 0;
    
    public float timeToSpawn;
    public GameObject platform;
    public Transform spawnSpot;

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;//Increment the timer after the last spawn

        if (timeSinceLastSpawn > timeToSpawn)//True after timeToSpawn seconds since last spawn
        {
            StartCoroutine("WaitSpawn");//Begin delayed spawn
            timeSinceLastSpawn = 0;//Reset clock
        }
    }

    IEnumerator WaitSpawn()//Begin the SpawnRand() function after a random delay
    {
        yield return new WaitForSeconds(timeToSpawn);
        SpawnPlatform(platform);
    }

    void SpawnPlatform(GameObject platform)
    {
        Instantiate(platform, spawnSpot.position, Quaternion.identity);
    }
}
