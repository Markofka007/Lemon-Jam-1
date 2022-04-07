using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float Velo = 7;

    // Update is called once per frame
    private void Update()
    {
        transform.position += Time.deltaTime * Velo * Vector3.left;
    }
}
