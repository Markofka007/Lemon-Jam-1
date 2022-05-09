using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlatform : MonoBehaviour
{
    public float speed;
    public Transform spot;
    public Transform origin;
    public bool SpawnPlayer = false;
    public GameObject platform;
    private Vector3 velo = Vector3.zero;


    // Update is called once per frame
    void Update()
    {
        if(SpawnPlayer)
        {
            platform.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            platform.transform.position = Vector3.SmoothDamp(platform.transform.position, spot.position, ref velo, Time.deltaTime * speed);
            StartCoroutine("DelayedBack");
        }

        if(!SpawnPlayer)
        {
            platform.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            platform.transform.position = Vector3.SmoothDamp(platform.transform.position, origin.position, ref velo, Time.deltaTime * speed * 2.5f);
            if(platform.transform.position == origin.position)
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator DelayedBack()
    {
        yield return new WaitForSeconds(3.2f);
        SpawnPlayer = false;
    }
}
