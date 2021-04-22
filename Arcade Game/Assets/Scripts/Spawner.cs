using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject zombie;
    public int spawnRate = 3;
    private float timer;
    // Update is called once per frame
    void Update()
    {
        if(timer >= spawnRate)
        {
            Instantiate(zombie, transform.position, Quaternion.identity);
            timer = 0;
        }else { timer += Time.deltaTime; }
    }
}
