using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlatformSpawnManager PSM;
    public GameObject GoBack;
    
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;

    public List<GameObject> PlayerList = new List<GameObject>();

    public GameObject JamRespawnPlatform;
    public GameObject BubbaRespawnPlatform;
    public GameObject AddieRespawnPlatform;
    public GameObject BonnieRespawnPlatform;

    public Transform SpawnSpot1;
    public Transform SpawnSpot2;
    public Transform SpawnSpot3;
    public Transform SpawnSpot4;

    public float Velo = 7;
    private readonly float FinalX = 95;
    private Vector3 posOffset = new Vector3(0, 1.26f, 0);

    public GameObject platformSegment;

    private bool oneSpawn;
    public int numPlayersAlive = 4;
    public int StartingLives;

    public int Player1Lives;
    public int Player2Lives;
    public int Player3Lives;
    public int Player4Lives;

    private void Start()
    {
        PlayerList.Add(Player1);
        PlayerList.Add(Player2);
        PlayerList.Add(Player3);
        PlayerList.Add(Player4);

        Player1Lives = StartingLives;
        Player2Lives = StartingLives;
        Player3Lives = StartingLives;
        Player4Lives = StartingLives;
    }

    // Update is called once per frame
    void Update()
    {
        CheckLives();//Checks if any of the players need to be destroyed

        //Debug.Log(PlayerList.Count);
            
        //Keeps track of whether or not the GoBack setup has passed a checkpoint
        if (GoBack.transform.position.x > 10 && GoBack.transform.position.x < 20)
        {
            oneSpawn = true;
        }

        //Checks if the GoBack setup has gone past the screen limit and it has passed the checkpoint
        if(GoBack.transform.position.x >= FinalX - 0.1f && oneSpawn)
        {
            platformSegment.transform.parent = GoBack.transform;//Grabs the platform segment
            ParentPlayer();//Grabs all the players
            
            GoBack.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);//Moves all the grabbed objects

            platformSegment.transform.parent = null;//releases the platform segment
            DeParentPlayer();//releases all the players

            platformSegment = PSM.platforms[Random.Range(0, PSM.platforms.Length)];//Gets a random platform from a list
            platformSegment = PSM.SpawnPlatform(platformSegment);//Instantiates the selected segment
            
            oneSpawn = false;//updated the checkpoint flag for the GoBack object
        }

        GoBack.transform.position += Time.deltaTime * Velo * Vector3.right;//Move the GoBack object

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
        if(Player1Lives < 0 && Player1 != null) 
        {
            PlayerList.Remove(Player1);
            Destroy(Player1); 
        }
        
        if(Player2Lives < 0 && Player2 != null) 
        {
            PlayerList.Remove(Player2);
            Destroy(Player2); 
        }
        
        if(Player3Lives < 0 && Player3 != null) 
        {
            PlayerList.Remove(Player3);
            Destroy(Player3); 
        }
        
        if(Player4Lives < 0 && Player4 != null) 
        {
            PlayerList.Remove(Player4);
            Destroy(Player4); 
        }

        PlayerWin();
    }

    void PlayerScreen(GameObject player)
    {
        if (player.name == "Jam") { SceneManager.LoadScene("JamWinScreen"); return; }
        if (player.name == "Bubba") { SceneManager.LoadScene("BubbaWinScreen"); return; }
        if (player.name == "Addie") { SceneManager.LoadScene("AddieWinScreen"); return; }
        if (player.name == "Bonnie") { SceneManager.LoadScene("BonnieWinScreen"); return; }
    }

    void PlayerWin()
    {
        if(PlayerList.Count == 1)
        {
            PlayerScreen(PlayerList[0]);
            Debug.Log(PlayerList[0].name);
        }
    }

    //Removes a life and starts the respawn procedure for the player who died
    public void PlayerDeath(GameObject Player)
    {
        //Checking identity of the player who fell
        if(Player == Player1) 
        {
            Player1Lives--;

            if (Player1Lives < 0) { return; }//Exits the function if the player is dead

            GameObject spawnPlat = (GameObject)Instantiate(JamRespawnPlatform, SpawnSpot1.position, Quaternion.identity);//Gets a reference to a newly instantiated respawn platform
            spawnPlat.transform.parent = GoBack.transform;//Applies it to the GoBack object
            
            Player.transform.position = spawnPlat.transform.position + posOffset;//Puts the player on top of the respawn platform
            Player.transform.parent = spawnPlat.transform;//parents the player to the repsawn platform for the descent (doesn't work?) 
            Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;//Cancels any momentum the player had before dying

            SpawnPlayer(Player, spawnPlat);//spawn the player using the instantiated spawn platform
            Player.GetComponent<PlayerController3>().enabled = false;//Stop the player from moving around
            this.Wait(1.8f, () =>
            {
                Player.GetComponent<PlayerController3>().enabled = true;//allow the player to move around after a delay
            });
        }

        //Checking identity of the player who fell
        if (Player == Player2) 
        {
            Player2Lives--;

            if (Player2Lives < 0) { return; }

            GameObject spawnPlat = (GameObject)Instantiate(BubbaRespawnPlatform, SpawnSpot2.position, Quaternion.identity);
            spawnPlat.transform.parent = GoBack.transform;

            Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Player.transform.position = spawnPlat.transform.position + posOffset;
            Player.transform.parent = spawnPlat.transform;

            SpawnPlayer(Player, spawnPlat);
            Player.GetComponent<PlayerController2>().enabled = false;
            this.Wait(1.8f, () =>
            {
                Player.GetComponent<PlayerController2>().enabled = true;
            });
        }

        //Checking identity of the player who fell
        if (Player == Player3) 
        {
            Player3Lives--;

            if (Player3Lives < 0) { return; }

            GameObject spawnPlat = (GameObject)Instantiate(AddieRespawnPlatform, SpawnSpot3.position, Quaternion.identity);
            spawnPlat.transform.parent = GoBack.transform;

            Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Player.transform.position = spawnPlat.transform.position + posOffset;
            Player.transform.parent = spawnPlat.transform;

            SpawnPlayer(Player, spawnPlat);
            Player.GetComponent<PlayerController3>().enabled = false;
            this.Wait(1.8f, () =>
            {
                Player.GetComponent<PlayerController3>().enabled = true;
            });
        }

        //Checking identity of the player who fell
        if (Player == Player4) 
        {
            Player4Lives--;

            if (Player4Lives < 0) { return; }

            GameObject spawnPlat = (GameObject)Instantiate(BonnieRespawnPlatform, SpawnSpot4.position, Quaternion.identity);
            spawnPlat.transform.parent = GoBack.transform;

            Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Player.transform.position = spawnPlat.transform.position + posOffset;
            Player.transform.parent = spawnPlat.transform;

            SpawnPlayer(Player, spawnPlat);
            Player.GetComponent<PlayerController4>().enabled = false;
            this.Wait(1.8f, () =>
            {
                Player.GetComponent<PlayerController4>().enabled = true;
            });
        }
    }

    void SpawnPlayer(GameObject Player, GameObject platform)
    {
        platform.GetComponent<RespawnPlatform>().SpawnPlayer = true;//Start moving the platform
        this.Wait(2f, () =>
        {
            Player.transform.parent = null;//Set the player back into the game after a delay
        });
    }

}
