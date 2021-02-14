using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : MonoBehaviour
{
    public Rigidbody2D rid_tomato;   
    int dir_tomato = 1;
    public static float hp;
    bool first = true;
    float dis_ray = 0.7f;
    int layermask = 1 << 29 | 1<<31;//Ground, Player

    Enemies tomato = new Enemies("tomato", 1.5f,1);
    
    void move_Tomato()
    {
        transform.Rotate(new Vector3(0,0,-180 * Time.deltaTime));
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x + 3f * Time.deltaTime * dir_tomato, pos.y, pos.z);
    }
    void bound_tomato()
    {   
        Ray2D ray = new　Ray2D(transform.position,new Vector2(dir_tomato, 0)); 
        RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, dis_ray, layermask);
        
        if(hit.collider != null)
        {
            transform.Rotate(new Vector3(0, 180, 0));
            Vector3 pos = transform.position;
            transform.position = new Vector3(pos.x, pos.y + 0.3f, pos.z);
            dir_tomato *= -1;
            
        }
        
    
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.hp -= tomato.attack;
        }
    } 

    void Start()
    {
        hp = tomato.maxHP;

    }
    void Update()
    {
        
        move_Tomato();
        bound_tomato();
        
        if(hp <= 0 && first)
        {
            tomato.death(this.gameObject);
            
            first = false;
        }
        
        
    }
}
