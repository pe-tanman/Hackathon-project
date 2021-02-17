using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;


    void Update()
    {
        
        float pos = player.transform.position.x;
        if(pos > 0)
        {
            transform.position = new Vector3(pos, 0, -10);
        }
        
    }
}
