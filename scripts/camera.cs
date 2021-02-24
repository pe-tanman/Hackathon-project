using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;


    void Update()
    {
        
        Vector3 pos = player.transform.position;
        if(pos.x > 0)
        {
            transform.position = new Vector3(pos.x, pos.y, -9);
        }
        
    }
}
