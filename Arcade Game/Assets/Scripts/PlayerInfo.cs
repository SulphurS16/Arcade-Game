using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static Vector3 playerPos;
    // Update is called once per frame
    void Update()
    {
        playerPos = transform.position;
    }
}
