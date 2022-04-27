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

    public RespawnPlatform RespawnPlatform1;
    public RespawnPlatform RespawnPlatform2;
    public RespawnPlatform RespawnPlatform3;
    public RespawnPlatform RespawnPlatform4;

    public float Velo = 7;
    private float FinalX = 95;
    private Vector3 posOffset = new Vector3(0, 2, 0);

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

        //Ceiling.gameObject.SetActive(false);
        //this.Wait(5f, () =>
        //{
           // Ceiling.gameObject.SetActive(true);
        //});
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
        if(Player == Player1) 
        {
            if (Player1Lives < 0) { return; }

            Player1Lives--;
            Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Player.transform.position = RespawnPlatform1.transform.position + posOffset;
            Player.transform.parent = RespawnPlatform1.transform;
            
            SpawnPlayer(Player, RespawnPlatform1);
            Player.GetComponent<PlayerController>().enabled = false;
            this.Wait(1.8f, () =>
            {
                Player.GetComponent<PlayerController>().enabled = true;
            });
        }
        
        if(Player == Player2) 
        {
            if (Player2Lives < 0) { return; }

            Player2Lives--;
            Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Player.transform.position = RespawnPlatform2.transform.position + posOffset;
            Player.transform.parent = RespawnPlatform2.transform;
           
                SpawnPlayer(Player, RespawnPlatform2);
                Player.GetComponent<PlayerController2>().enabled = false;
                this.Wait(1.8f, () =>
                {
                    Player.GetComponent<PlayerController2>().enabled = true;
                });
        }
        
        if(Player == Player3) 
        {
            if (Player3Lives < 0) { return; }

            Player3Lives--;
            Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Player.transform.position = RespawnPlatform3.transform.position + posOffset;
            Player.transform.parent = RespawnPlatform3.transform;

       
                SpawnPlayer(Player, RespawnPlatform3);
                Player.GetComponent<PlayerController3>().enabled = false;
                this.Wait(1.8f, () =>
                {
                    Player.GetComponent<PlayerController3>().enabled = true;
                });
            
        }
        
        if(Player == Player4) 
        {
            if (Player4Lives < 0) { return; }

            Player4Lives--;
            Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Player.transform.position = RespawnPlatform4.transform.position + posOffset;
            Player.transform.parent = RespawnPlatform4.transform;

                SpawnPlayer(Player, RespawnPlatform4);
                Player.GetComponent<PlayerController4>().enabled = false;
                this.Wait(1.8f, () =>
                {
                    Player.GetComponent<PlayerController4>().enabled = true;
                });
        }
    }

    void SpawnPlayer(GameObject Player, RespawnPlatform platform)
    {
        platform.SpawnPlayer = true;
        this.Wait(2f, () =>
        {
            Player.transform.parent = null;
        });
    }
}
