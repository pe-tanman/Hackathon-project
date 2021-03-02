using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;
    

    void Update()
    {
        

        Vector3 pos = player.transform.position;

        

        if(pos.x >= 163 && pos.x <= 192)
        {
            this.GetComponent<Camera>().orthographicSize = 8;
            transform.position = new Vector3(178, 5, -9);

        }
        else if(pos.y < 0)
        {
            this.GetComponent<Camera>().orthographicSize = 5;
            transform.position = new Vector3(pos.x, 0, -9);
        }
        else{
            this.GetComponent<Camera>().orthographicSize = 5;
            transform.position = new Vector3(pos.x, pos.y, -9);
        }


        
    }
}
