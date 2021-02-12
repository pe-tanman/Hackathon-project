using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : MonoBehaviour
{
    public Rigidbody2D rid_tomato;   
    int dir_tomato = 1;
    public static float hp;
    bool first = true;
    float speed;
    float posb, posa;

    Enemies tomato = new Enemies("tomato", 3,1);
    
    void move_Tomato()
    {
        transform.Rotate(new Vector3(0,0,-180 * Time.deltaTime));
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x + 3f * Time.deltaTime * dir_tomato, pos.y, pos.z);
    }
    void bound_tomato()
    {   
        
        transform.Rotate(new Vector3(0, 180, 0));
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, pos.y + 0.3f, pos.z);
        dir_tomato *= -1;
    
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.hp -= 1;
        }
    } 

    void Start()
    {
        hp = tomato.maxHP;

    }
    void Update()
    {
        posb = transform.position.x;
        move_Tomato();
        posa = transform.position.x;
        speed = posb - posa;
        Debug.Log(speed);
        if(speed == 0){
            bound_tomato();
        }
        
        if(hp <= 0 && first)
        {
            tomato.death(this.gameObject);
            
            first = false;
        }
        
        
    }
}
