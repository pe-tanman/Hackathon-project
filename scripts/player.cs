using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public GameObject out_line, GameMaster, GameoverPanel;
    Rigidbody2D rb;
    public static float hp; 
    float player_dir = 1;
    float damage = 1.5f;
    float dis_ray = 1.5f;
    bool can_jump = true;
    
    float num = 0.1f;

    public static bool have_key = false;
    int layermask = 1<<30;//Enemy
    
    void Start()
    {
        hp = 6f;
        rb = this.GetComponent<Rigidbody2D>();
        transform.position = savepoint.start;
    }

    // Update is called once per frame
    void Update()
    {
        //移動
        if(Input.GetKey(KeyCode.D))
        {
            move(num);
        }
        if(Input.GetKey(KeyCode.A))
        {
            move(num * -1);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(num == 1 || num == -1)
            {
                jump();
            }
                    
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

        fall();
    }


    //接地判定
    void OnTriggerEnter2D(Collider2D col_enter)
    {
        num = 1;
    }
    void OnTriggerStay2D(Collider2D col)
    {
        
        num = 1;
        if(col.tag == "hashigo")
        {
            if(Input.GetKey(KeyCode.Space))
            {
                Debug.Log(col.tag);
                rb.AddForce(new Vector2(0, 5));            }
        }
    }
    void OnTriggerExit2D(Collider2D col_exit)
    {
        num = 0.1f;
    }

    void move(float num2)
        {
            player_dir = num2;

            if(num2 > 0)
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
                rb.AddForce(new Vector2(800 * player_dir * Time.deltaTime, 0)); 
            }
        }
    void attack(float dis_ray, float damage)
    {
        Ray2D ray = new　Ray2D(transform.position,new Vector2(player_dir, 0)); 
        
        RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, dis_ray, layermask);
        
        if(hit.collider != null);
        {
            hit.collider.gameObject.SendMessage("RevDamage", damage);
        }
        
    }
    void jump()
    {
        if(can_jump)
        {
            rb.AddForce(new Vector2(0,400f));
            Invoke("get_jump", 0.6f);
            can_jump = false;
        }
    }  
    void get_jump()
    {
        can_jump = true;
    }
    public void RevDamage(float dam)
        {
            hp -= dam;

            if (hp <= 0)
            {
                GameMaster.GetComponent<GM>().OutPanel(GameoverPanel);
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
    void fall()
    {
        if(transform.position.y < -5)
        {
            transform.position = savepoint.start;
            RevDamage(hp);
        }
    
    }

}
