using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlatformSpawnManager PSM;
    public GoRight GR;

    public GameObject platformSegment;

    private bool oneSpawn;
    private bool oneParent;

    // Update is called once per frame
    void Update()
    {
        if(GR.transform.position.x > 10 && GR.transform.position.x < 20)
        {
            oneSpawn = true;
        }

        if(GR.transform.position.x >= GR.FinalX - 0.1f && oneSpawn)
        {
            Debug.Log("Bub");
            platformSegment = PSM.platforms[Random.Range(0, PSM.platforms.Length)];
            PSM.SpawnPlatform(platformSegment);
            platformSegment.transform = Vector3.zero;
            oneSpawn = false;
        }
        /*
        if(GR.transform.position.x >= 0.1f && oneParent)
        {
            platformSegment.transform.parent = null;
            oneParent = false;
        }
        */
    }
}
