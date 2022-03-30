using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlatformSpawnManager PSM;
    public GameObject GoBack;

    public float Velo = 7;
    public float FinalX = 95;

    public GameObject platformSegment;

    private bool oneSpawn;
    private bool oneParent;
    private int i = 0;

    // Update is called once per frame
    void Update()
    {
        if(GoBack.transform.position.x > 10 && GoBack.transform.position.x < 20)
        {
            oneSpawn = true;
        }

        if(GoBack.transform.position.x >= FinalX - 0.1f && oneSpawn)
        {
            platformSegment.transform.parent = GoBack.transform;
            GoBack.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
            platformSegment.transform.parent = null;

            platformSegment = PSM.platforms[Random.Range(0, PSM.platforms.Length)];
            platformSegment = PSM.SpawnPlatform(platformSegment);
            
            oneSpawn = false;
            
            Debug.Log(i);
            i++;
        }

        GoBack.transform.position += Vector3.right * Velo * Time.deltaTime;

    }
}
