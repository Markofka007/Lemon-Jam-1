using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlatformSpawnManager PSM;
    public GameObject GoBack;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;

    public float Velo = 7;
    public float FinalX = 95;

    public GameObject platformSegment;

    private bool oneSpawn;
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
            ParentPlayer();
            GoBack.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
            platformSegment.transform.parent = null;
            DeParentPlayer();

            platformSegment = PSM.platforms[Random.Range(0, PSM.platforms.Length)];
            platformSegment = PSM.SpawnPlatform(platformSegment);
            
            oneSpawn = false;
            
            Debug.Log(i);
            i++;
        }

        GoBack.transform.position += Vector3.right * Velo * Time.deltaTime;

    }

    void ParentPlayer()
    {
        if(Player1 != null) { Player1.transform.parent = GoBack.transform; }
        if(Player2 != null) { Player2.transform.parent = GoBack.transform; }
        if(Player3 != null) { Player3.transform.parent = GoBack.transform; }
        if(Player4 != null) { Player4.transform.parent = GoBack.transform; }
    }

    void DeParentPlayer()
    {
        if (Player1 != null) { Player1.transform.parent = null; }
        if (Player2 != null) { Player2.transform.parent = null; }
        if (Player3 != null) { Player3.transform.parent = null; }
        if (Player4 != null) { Player4.transform.parent = null; }
    }
}
