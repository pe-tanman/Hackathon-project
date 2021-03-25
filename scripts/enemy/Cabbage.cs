using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabbage : MonoBehaviour
{
    public Enemies cabbage;
    public AudioClip defence;
    Rigidbody2D rb;

    float player_pos, pos_dif;
    int dir;

    void move()
    {
        transform.Translate(-1f * Time.deltaTime, 0, 0);
    }
    void turn()
    {
        player_pos = cabbage.player.transform.position.x;
        pos_dif = player_pos - transform.position.x;
        if (pos_dif > 0)
        {
            dir = 1;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            dir = -1;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    void RevDamage(float dam)
    {
        AudioSource AS = GetComponent<AudioSource>();
        AS.PlayOneShot(defence);
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            cabbage.attack();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        cabbage = new Enemies("cabbage", 4f, 2f, this.gameObject);
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        InvokeRepeating("turn", 4,5f); 
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
}
