using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoRight : MonoBehaviour
{
    // Start is called before the first frame update
    public float Velo = 7;

    // Update is called once per frame
    private void Update()
    {
        transform.position += Vector3.right * Velo * Time.deltaTime;
    }
}
