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
    public GameObject ParentalGuardian;

    public GameObject spawnNewBackground(Vector3 transf, GameObject BG)
    {
        GameObject backgroundamundo = (GameObject)Instantiate(BG, transf, Quaternion.identity);
        backgroundamundo.transform.parent = ParentalGuardian.transform;
        return backgroundamundo;
    }

    public void SummonBackground()
    {
        endingSpot = spawnNewBackground(endingSpot.position + Offset, background).transform.Find("EndingTranform");
    }

}
