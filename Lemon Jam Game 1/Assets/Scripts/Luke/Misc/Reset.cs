using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public float velo;
    public GameObject background;
    public GameManager GoBack;
    public Transform point;

    private float maxDistance = 87.04f;

    private float distance;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * velo * Time.deltaTime;
        distance += 1 * velo * Time.deltaTime;

        if (distance > maxDistance)
        {
            Instantiate(background, new Vector3(transform.position.x + 173.5f, transform.position.y), Quaternion.identity);//GameObject.FindGameObjectWithTag("Go Back please").transform)
            distance = 0;
        }
    }


}
