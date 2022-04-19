using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundManager : MonoBehaviour
{
    public Transform endingSpot;
    public DeleteObject DelObj;
    public bool doFlip = true;
    public GameObject background;

    private Vector3 offset = new Vector3(14.69f, 0, 0);

    // Update is called once per frame
    void Update()
    {
        if(DelObj.didDel)
        {
            endingSpot = spawnNewBackground(endingSpot.position + offset, background).transform.Find("EndingTranform");
            DelObj.didDel = false;
        }
    }

    public GameObject spawnNewBackground(Vector3 transf, GameObject BG)
    {
        return (GameObject)Instantiate(BG, transf, Quaternion.identity);
    }

}
