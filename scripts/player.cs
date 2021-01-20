using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public static int hp = 6; 
    Rigidbody2D rb;
    bool on_floor;
    float dis_ray = 11;

        RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, dis_ray);


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (on_floor){
            if(Input.GetKey(KeyCode.D))
            {
                move_player(1);
            }
            if(Input.GetKey(KeyCode.A))
            {
                move_player(-1);
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector2(0,300f));
                Debug.Log("onspace");
            }
        }
        if (hp <= 0)
        {
            Debug.Log("gameover");
        }
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }


    void move_player(int num)
    {
        if(num == 1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        
            float speed = rb.velocity.x;
            if(speed*num < 8f)
            {
               rb.AddForce(new Vector2(800 *num * Time.deltaTime, 0)); 
            }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "floor" || col.gameObject.tag == "wall")
        {
            on_floor = true;
        }
        
    }
    void OnCollisionExit2D(Collision2D col_exit)
    {
        if (col_exit.gameObject.tag == "floor" || col_exit.gameObject.tag == "wall")
        {
            on_floor = false;
        }
    }

    void attack()
    {
        
    }
    
}
