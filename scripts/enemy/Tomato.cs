using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : MonoBehaviour
{ 
    Enemies tomato;
    Vector3 pos;
    Rigidbody2D rb;
    int dir_tomato = 1;
    float dis_ray = 0.7f;
    int layermask = 1<<29 | 1<<31;//Ground, Player
    
    
    void move_Tomato()
    {
        transform.Rotate(0,0,-100 * Time.deltaTime);
        float speed = rb.velocity.x;
            if(speed * dir_tomato < 2f)
            {
                rb.AddForce(new Vector3(400 * dir_tomato * Time.deltaTime, 0, 0));
            }
        
        //pos = transform.position;
        //ransform.position = new Vector3(pos.x + 2.5f * dir_tomato * Time.deltaTime, pos.y, pos.z);
    }
    void bound_tomato()
    {   
        Ray2D ray = new　Ray2D(transform.position,new Vector2(dir_tomato, 0)); 
            foreach (RaycastHit2D hit in Physics2D.RaycastAll((Vector2)ray.origin, (Vector2)ray.direction, dis_ray)) {
            if (hit) 
            {
                if (hit.collider != this.gameObject.GetComponent<Collider2D>())
                {
                    transform.Rotate(new Vector3(0, 180, 0));
                    dir_tomato *= -1;  
                    //rb.AddForce (new Vector3(5* dir_tomato, 0, 0), ForceMode2D.Impulse);
                }
            }   
        }
        
    }
    void RevDamage(float dam)
    {
        tomato.RevDamage(dam);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            tomato.attack();
        }
    } 

    void Start()
    {
        tomato = new Enemies("tomato", 2f,1, this.gameObject);
        rb = this.GetComponent<Rigidbody2D>();
    }
    void Update()
    {   
        move_Tomato();
        bound_tomato();
    }
}
