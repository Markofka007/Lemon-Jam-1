using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] items;
    public GameObject parental;

    public float minSpawnTime;
    public float maxSpawnTime;

    public float Height = 21;
    public float Width = 10;

    private AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        
        this.Wait(3f, () =>
        {
            SpawnItem();
        });
    }

    public void SpawnItem()
    {
        GameObject newItem = Instantiate(items[Random.Range(0, items.Length)], new Vector3(Random.Range(-Width, Width) + transform.position.x, Height, 0), Quaternion.identity);
        newItem.transform.parent = parental.transform;

        newItem.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-4f, 4f), 0f);
        newItem.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-5, 5), ForceMode2D.Impulse);

        sound.Play();

        this.Wait(Random.Range(minSpawnTime, maxSpawnTime), () =>
        {
            SpawnItem(); //I KNOW THAT THIS IS A RECURSION BUT THIS IS THE MOST EFFECTIVE AND SIMPLE SOLUTION I COULD THINK OF PLEASE DONT FIRE ME
            //Mark has been fired.
        });
    }
}
