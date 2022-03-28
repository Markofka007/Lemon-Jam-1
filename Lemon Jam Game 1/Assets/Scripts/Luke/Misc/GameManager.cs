using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlatformSpawnManager PSM;
    public GoRight GR;

    public GameObject platformSegment;

    private bool oneSpawn;

    // Update is called once per frame
    void Update()
    {
        if(GR.transform.position.x <= GR.FinalX / 2)
        {
            oneSpawn = true;
        }

        if(GR.transform.position.x >= GR.FinalX - 1 && oneSpawn)
        {
            Debug.Log("Bub");
            PSM.SpawnPlatform();
            oneSpawn = false;
        }
    }
}
