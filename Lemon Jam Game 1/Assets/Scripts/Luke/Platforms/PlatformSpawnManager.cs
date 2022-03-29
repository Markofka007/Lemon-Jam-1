using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnManager : MonoBehaviour
{
    private bool shouldSpawn = false;
    private float timeSinceLastSpawn = 0;

    public float timeToSpawn;
    public GameObject[] platforms;
    public Transform spawnSpot;
    public bool doSpawn = true;

    private void Start()
    {
        Instantiate(platforms[Random.Range(0, platforms.Length)], spawnSpot.position, Quaternion.identity);
    }

    /*
    // Update is called once per frame
    void //Update()
    {
       if(doSpawn)
        {
            timeSinceLastSpawn += Time.deltaTime;//Increment the timer after the last spawn

            if (timeSinceLastSpawn > timeToSpawn)//True after timeToSpawn seconds since last spawn
            {
                StartCoroutine("WaitSpawn");//Begin delayed spawn
                timeSinceLastSpawn = 0;//Reset clock
            }
        }
    }
    */


    IEnumerator WaitSpawn()//Begin the SpawnRand() function after a random delay
    {
        yield return new WaitForSeconds(0);
        GameObject platformSegment = platforms[Random.Range(0, platforms.Length)];
        SpawnPlatform(platformSegment);//Spawn a random platform from the array
    }

    public void SpawnPlatform(GameObject platformSegment)
    {
        Instantiate(platformSegment, spawnSpot.position, Quaternion.identity);
    }
}
