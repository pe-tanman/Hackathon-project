using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Enemies boss;
    public AudioClip defence;
    Rigidbody2D rb, rb_tubu;
    public GameObject tubu, tubu1, tubu2, player, hp_bar_obj;
    public Slider hp_bar;
    GameObject[] tubus;
    

    float player_pos, pos_dif;
    float dis_ray = 1;
    int dir;
    bool rot = false;

//main move
    void move()
    {
        transform.Translate(1f * Time.deltaTime, 0, 0);
    }
    void turn()
    {
        player_pos = boss.player.transform.position.x;
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

//banana
    void jump()
    {
        rb.AddForce(new Vector2(250 * dir, 400));
        Invoke("turn", 0.9f);
        Invoke("change_rotate", 4f);
        Invoke("change_rotate", 7f);
        Invoke("jump_up", 12f);
    }

//tomato
    void change_rotate()
    {
        rot = !rot;
        rb.freezeRotation = !rot;
        if(!rot)
        {
            turn();
        }
    }
    void rotate()
    {
        float speed = rb.velocity.x;
            if(speed * dir < 6f)
            {
                rb.AddForce(new Vector3(400 * dir * Time.deltaTime, 0, 0));
            }
    }
    void bound()
    {
        Ray2D ray = new　Ray2D(transform.position,new Vector2(dir, 0)); 
            foreach (RaycastHit2D hit in Physics2D.RaycastAll((Vector2)ray.origin, (Vector2)ray.direction, dis_ray)) {
            if (hit) 
            {
                if (hit.collider != this.gameObject.GetComponent<Collider2D>())
                {
                    transform.Rotate(new Vector3(0, 180, 0));
                    dir *= -1;  
                }
            }   
        }
    }
    
    //corn
    void jump_up()
    {
        turn();
        rb.AddForce(new Vector3(0, 400));
        Invoke("Throw", 0.7f);
    }
    void Throw()
    {   
        float power = 3;
        foreach(GameObject any_tubu in tubus)
        {
            rb_tubu = any_tubu.GetComponent<Rigidbody2D>();

            any_tubu.SetActive(true);
            
            Vector3 pos = transform.position;
            any_tubu.transform.position = new Vector3(pos.x + 0.5f*dir, pos.y + 0.5f, pos.z);
            rb_tubu.AddForce(new Vector2(150 * dir* power, 80 ));
            power /= 2;
        }
        
        turn();
    }

//system
    void RevDamage(float dam)
    {
        AudioSource AS = GetComponent<AudioSource>();
        AS.PlayOneShot(defence);
    }
    void attack()
    {
        boss.attack();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            boss.attack();
        }
    }
    
    void hp()
    {
        Vector3 pos = player.transform.position;
        if(pos.x >= 630 && pos.x <= 680)
        {
            hp_bar_obj.SetActive(true);
            hp_bar.value = boss.hp / 50f;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        tubus = new GameObject[3]{tubu, tubu1, tubu2};
        boss = new Enemies("boss", 50, 0.8f, this.gameObject);
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        
        InvokeRepeating("jump", 3f, 17f); 
        turn();
    }

    // Update is called once per frame
    void Update()
    {
        hp();
        if(rot)
        {
            rotate();
            bound();
        }
        else{
           move(); 
        }
    }
}
