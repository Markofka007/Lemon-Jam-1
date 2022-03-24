using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlatformSpawnManager PSM;
    public GoRight GR;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GR.transform.position.x > GR.FinalX)
        {
            Debug.Log("Bub");
            PSM.SpawnPlatform();
        }
    }
}
