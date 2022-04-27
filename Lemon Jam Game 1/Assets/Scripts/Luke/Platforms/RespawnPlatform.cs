using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlatform : MonoBehaviour
{
    public float speed;
    public Transform spot;
    public Transform origin;
    public bool SpawnPlayer = false;

    // Update is called once per frame
    void Update()
    {
        if(SpawnPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, spot.position, Time.deltaTime * speed);
            StartCoroutine("DelayedBack");
        }

        if(!SpawnPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, origin.position, Time.deltaTime * speed * 2);
        }
    }

    IEnumerator DelayedBack()
    {
        yield return new WaitForSeconds(3.2f);
        SpawnPlayer = false;
    }
}
