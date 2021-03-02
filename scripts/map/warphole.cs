using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warphole : MonoBehaviour
{
    public float x,y;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Player")
        {
            player.transform.position = new Vector3(x, y, player.transform.position.z);
        }
    }
}
