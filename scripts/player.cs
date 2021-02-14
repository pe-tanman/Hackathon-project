using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public static float hp = 6f; 
    public GameObject out_line;
    Rigidbody2D rb;
    bool on_floor;

    int player_dir = 1;
    float damage = 1.5f;
    float dis_ray = 1.5f;
    int layermask = 1<<30;//Enemy
    
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
            }
            if(Input.GetKey(KeyCode.A))
            {
                move_player(-1);
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector2(0,400f));
            }
        }

        //ゲームオーバー
        if (hp <= 0)
        {
            Debug.Log("gameover");
        }

        //武器選択
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            set_weapon(1.5f, 1.5f, -102f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            set_weapon(3, 1, -3f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            set_weapon(6, 0.8f, 102f);
        }
        //攻撃
        if (Input.GetMouseButtonDown(0))
        {
            attack(dis_ray, damage);   
        }
    }


    
    void OnCollisionEnter2D(Collision2D col_enter)
    {
        if (col_enter.gameObject.tag == "ground"){
            on_floor = true;
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            on_floor = true;
        }
        
    }
    void OnCollisionExit2D(Collision2D col_exit)
    {
        if (col_exit.gameObject.tag == "ground")
        {
            on_floor = false;
        }
    }
    void move_player(int num)
        {
            player_dir= num;
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
        
        RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, dis_ray, layermask);
        
        if(hit.collider != null)
        {
            Tomato.hp -= damage;
        }
        
    }
    void set_weapon(float dis, float dam, float x)
    {
        dis_ray = dis;
        damage = dam;
        Vector3 pos = out_line.GetComponent<RectTransform>().anchoredPosition3D;
        pos.x = x;
        out_line.GetComponent<RectTransform>().anchoredPosition3D = pos;
    }
    void RevDamage(float dam)
    {
        hp -= dam;
    }
}
