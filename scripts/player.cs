using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public static int hp = 6; 
    Rigidbody2D rb;
    bool on_floor;

    int weapon = 1;

    int player_dir = 1;

    
    


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        GameObject tomato = this.gameObject;
        Debug.Log(Tomato.hp);
    }

    // Update is called once per frame
    void Update()
    {
        //移動
        if (on_floor){
            if(Input.GetKey(KeyCode.D))
            {
                move_player(1);
                player_dir = 1;
            }
            if(Input.GetKey(KeyCode.A))
            {
                move_player(-1);
                player_dir = -1;
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector2(0,300f));
            }
        }

        //ゲームオーバー
        if (hp <= 0)
        {
            Debug.Log("gameover");
        }

        //攻撃
        if (Input.GetMouseButtonDown(0))
        {
            if (weapon == 1){
                attack(1.5f, 1.5f);
            }
            if(weapon == 2){
                attack(3, 1f);
            }
            if(weapon == 3){
                attack(6, 0.5f);
            }
            
        }
    }


    

    void OnCollisionStay2D(Collision2D col)
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
    void move_player(int num)
        {
            float num2 = num * 0.5f;

            transform.rotation = Quaternion.Euler(0, 180 * (0.5f + num2), 0);
            
            float speed = rb.velocity.x;
            if(speed*num < 8f)
            {
                rb.AddForce(new Vector2(800 *num * Time.deltaTime, 0)); 
            }
        }
    void attack(float dis_ray, float damage)
    {
        Ray2D ray = new　Ray2D(transform.position,new Vector2(player_dir, 0)); 
        RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, dis_ray);
        
        if(hit.collider != null)
        {
            if(hit.collider.gameObject.tag == "enemy")
            {
                Debug.Log("Tomato.hp=" + Tomato.hp);
                Tomato.hp -= damage;
            }
        }
        
    }
}
