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
    public GameObject Ceiling;

    public float Velo = 7;
    private float FinalX = 95;

    public GameObject platformSegment;

    private bool oneSpawn;
    private int i = 0;

    public int StartingLives;

    public int Player1Lives;
    public int Player2Lives;
    public int Player3Lives;
    public int Player4Lives;

    private void Start()
    {
        Player1Lives = StartingLives;
        Player2Lives = StartingLives;
        Player3Lives = StartingLives;
        Player4Lives = StartingLives;

        Ceiling.gameObject.SetActive(false);
        this.Wait(5f, () =>
        {
            Ceiling.gameObject.SetActive(true);
        });
    }

    // Update is called once per frame
    void Update()
    {
        CheckLives();

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

    void CheckLives()
    {
        if(Player1Lives < 0) { Destroy(Player1); }
        if(Player2Lives < 0) { Destroy(Player2); }
        if(Player3Lives < 0) { Destroy(Player3); }
        if(Player4Lives < 0) { Destroy(Player4); }
    }

    public void PlayerDeath(GameObject Player)
    {
        if(Player == Player1) { Player1Lives--; }
        if(Player == Player2) { Player2Lives--; }
        if(Player == Player3) { Player3Lives--; }
        if(Player == Player4) { Player4Lives--; }

        Player
    }

    void SpawnPlayer()
}
