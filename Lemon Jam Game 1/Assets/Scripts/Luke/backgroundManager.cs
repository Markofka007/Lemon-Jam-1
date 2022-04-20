using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundManager : MonoBehaviour
{
    public Transform endingSpot;
    public BackgroundDeleter BackObj;
    public bool doFlip = true;
    public GameObject background;
    public Vector3 Offset;

    // Update is called once per frame
    void Update()
    {
        if(BackObj.didDel)
        {
            endingSpot = spawnNewBackground(endingSpot.position + Offset, background).transform.Find("EndingTranform");
            BackObj.didDel = false;
        }
    }

    public GameObject spawnNewBackground(Vector3 transf, GameObject BG)
    {
        return (GameObject)Instantiate(BG, transf, Quaternion.identity);
    }

}
