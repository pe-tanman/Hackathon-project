using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savepoint : MonoBehaviour
{
    GameObject player_point;
    public AudioClip save;
    static public Vector3 start; 
    // Start is called before the first frame update
    void Awake()
    {
        if(start == Vector3.zero)
        {
            player_point = GameObject.Find("start");
            go_to_pos();
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            AudioSource AS = GetComponent<AudioSource>();
            AS.PlayOneShot(save);

            player_point = this.gameObject;
            go_to_pos();
        }
        
    }
    void go_to_pos()
    {
        Vector3 pos = player_point.transform.position;
        start = new Vector3(pos.x, pos.y, -1);
    }
}
