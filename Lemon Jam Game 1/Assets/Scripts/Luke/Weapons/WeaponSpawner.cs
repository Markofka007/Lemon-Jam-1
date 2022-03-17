using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject[] weapons;
    public float spawnTime;
    public float spawnHeight;
    public bool doSpawn;

    private float timeSinceLastSpawn = 0;
    // Start is called before the first frame update
    void Update()
    {
        if (doSpawn)
        {
            timeSinceLastSpawn += Time.deltaTime;//Increment the timer after the last spawn

            if (timeSinceLastSpawn > spawnTime)//True after timeToSpawn seconds since last spawn
            {
                StartCoroutine("WaitSpawn");//Begin delayed spawn
                timeSinceLastSpawn = 0;//Reset clock
            }
        }
    }

    IEnumerator WaitSpawn()//Begin the SpawnRand() function after a random delay
    {
        yield return new WaitForSeconds(0);
        SpawnWeapon();
    }

    void SpawnWeapon()
    {
        Instantiate(weapons[Random.Range(0, weapons.Length - 1)], new Vector2(Random.Range(-30, 31), spawnHeight), Quaternion.identity);
    }
}
