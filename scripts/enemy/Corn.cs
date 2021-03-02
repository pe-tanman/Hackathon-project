using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Corn : MonoBehaviour
{
    public GameObject corn_tubu;
    Rigidbody2D rb, rb_tubu;
    Enemies corn;
    
    float pos_dif, player_pos, corn_pos;
    int corn_dir;
    bool first = true;
    

    void move_Corn()
    {
        player_pos = corn.player.transform.position.x;
        corn_pos = transform.position.x;
        pos_dif = player_pos - corn_pos;
        if (pos_dif > 0)
        {
            corn_dir = 1;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            corn_dir = -1;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
            transform.Translate(-0.7f * Time.deltaTime, 0, 0);
        
    }
    void attack_Corn()
    {
        rb.AddForce(new Vector3(0, 300f));
        Invoke("push_tubu", 0.7f);
    }
    void push_tubu()
    {
        corn_tubu.SetActive(true);
        rb_tubu.AddForce(new Vector2(200f * corn_dir, 100f));
        corn_tubu.transform.position = transform.position;

    }

    void RevDamage(float dam)
    {
        corn.RevDamage(dam);
    }
    void attack()
    {
        corn.attack();
    }
    
    void Start()
    {
        corn = new Enemies("corn", 2f,0.5f, this.gameObject);
        rb = this.GetComponent<Rigidbody2D>();
        rb_tubu = corn_tubu.GetComponent<Rigidbody2D>();
        InvokeRepeating("attack_Corn", 4,3f);  
    }

    // Update is called once per frame
    void Update()
    {
        move_Corn();
    }
}
