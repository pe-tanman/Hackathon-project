using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    Enemies banana;
    Rigidbody2D rb;

    float player_pos, pos_dif;
    int dir;

    void move()
    {
        transform.Translate(1f * Time.deltaTime, 0, 0);
    }
    void turn()
    {
        player_pos = banana.player.transform.position.x;
        pos_dif = player_pos - transform.position.x;
        if (pos_dif > 0)
        {
            dir = 1;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            dir = -1;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    void attack()
    {
        rb.AddForce(new Vector2(100 * dir, 230));
        Invoke("turn", 0.9f);
    }
    void RevDamage(float dam)
    {
        banana.RevDamage(dam);
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            banana.attack();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        banana = new Enemies("cabbage", 1.8f, 1f, this.gameObject);
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        InvokeRepeating("attack", 4,3f); 
        turn();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
}
