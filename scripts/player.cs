using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public GameObject out_line, GameMaster, GameoverPanel1, GameoverPanel2;
    public AudioClip sord, yari, bow, dam_audio;
    RectTransform trans;
    AudioClip[] clips;
    Music music;
    AudioSource AS;
    GameObject ya;
    Rigidbody2D rb;
    public static float hp; 
    float player_dir = 1;
    float damage = 1.5f;
    float dis_ray = 1.5f;
    bool can_jump = true;
    float speed;
    
    float num = 0.1f;

    public static bool have_key = false;
    bool move_On , hashigo_On;
    int layermask = 1<<30;//Enemy
    int weapon = 1;
    int num_m;    
    void Start()
    {
        hp = 6f;
        rb = this.GetComponent<Rigidbody2D>();

        transform.position = savepoint.start;
        ya = transform.Find("ya").gameObject;

        AS = GetComponent<AudioSource>();
        clips = new AudioClip[3]{sord, yari, bow};

        trans = GameoverPanel1.GetComponent<RectTransform>();
        trans.localScale = new Vector3(1, 1, 1);
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
            jump();      
        }
    
        //武器選択
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon = 1;
            set_weapon(1.5f, 1f, -102f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapon = 2;
            set_weapon(3, 0.8f, -3f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weapon = 3;
            set_weapon(6, 0.4f, 102f);
        }
        //攻撃
        if (Input.GetMouseButtonDown(0))
        {
            attack(dis_ray, damage);
            if(weapon == 3)
            {
                shot();
            }
        }

        fall();
        float speed = rb.velocity.x;
        if((speed < 1f && speed > -1f )||(num == 0.1f || num == -0.1f))
        {
            GetComponent<Animator>().SetBool("run", false);
        }
        else{
            GetComponent<Animator>().SetBool("run", true);
        }
        
        if(move_On)
        {
            move(num * num_m);
        }
        if (hp <= 0)
        {
            GameOver();
        }
        if(hp > 0){
            retry();
        }
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
            if(Input.GetKey(KeyCode.Space) || hashigo_On)
            {
                up_hashigo();        
            }
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
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            if(speed*num < 8f)
            {
                rb.AddForce(new Vector2(800 * player_dir * Time.deltaTime, 0)); 
            }
        }
    void attack(float dis_ray, float damage)
    {
        Ray2D ray = new　Ray2D(transform.position,new Vector2(player_dir, 0)); 
        
        RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, dis_ray, layermask);
        
        if(hit.collider != null)
        {
            hit.collider.gameObject.SendMessage("RevDamage", damage);
            AS.PlayOneShot(clips[weapon-1]);
        }
        
    }
    public void jump()
    {
        if(can_jump && (num == 1 || num == -1))
        {
            rb.AddForce(new Vector2(0,405f));
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
            AS.PlayOneShot(dam_audio);
            if (hp <= 0)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                GameObject death_anim = (GameObject)Resources.Load("prefabs/death_anime");
                Vector3 pos = transform.position;
                GameObject anime = Instantiate(death_anim, new Vector3 (pos.x, pos.y, pos.z -1),  Quaternion.identity);
                Destroy(anime, 0.27f);
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
            hp = 0;
        }
    
    }

    void shot()
    {
        ya.transform.position = transform.position;
        ya.SetActive(true);
        ya.GetComponent<Rigidbody2D>().AddForce(new Vector2(1500 * player_dir, 100));
        Invoke("rm_ya", 0.2f);
    }
    void up_hashigo()
    {
        float speed_y = rb.velocity.y;
                if(speed_y < 4f)
                {
                    rb.AddForce(new Vector2(0, 10)); 
                }
    }

    void rm_ya()
    {
        ya.SetActive(false);
    }
    void GameOver()
    {
        Invoke("GameOver2", 0.53f);

        GameoverPanel1.SetActive(true);
        RectTransform trans = GameoverPanel1.GetComponent<RectTransform>();

        
        if(trans.localScale.x > 1.6f)
        {
            trans.localScale -= new Vector3(200 * Time.deltaTime, 200* Time.deltaTime, 0);
        }
    }
    void GameOver2()
    {
        GameoverPanel2.SetActive(true);
        Scene nowScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(nowScene.name);
    }
    void retry()
    {

        GameoverPanel1.SetActive(true);
        
        if(trans.localScale.x <  120f)
        {
            trans.localScale += new Vector3(200 * Time.deltaTime, 200* Time.deltaTime, 0);
        }
        else{
            GameoverPanel1.SetActive(false);
        }
    }

    public void onDown(int i)
    {
        if(i == 3)
        {
            hashigo_On = true;
        }
        else{
            num_m = i;
            move_On = true;
        }
        
    }
    public void onUp()
    {
        hashigo_On = false;
        move_On = false;
    }
    public void on1()
    {
        weapon = 1;
        set_weapon(1.5f, 1.5f, -102f);
        attack(dis_ray, damage);
    }
    public void on2()
    {
        weapon = 2;
        set_weapon(3, 1, -3f);
        attack(dis_ray, damage);
    }
    public void on3()
    {
        weapon = 3;
        set_weapon(6, 0.7f, 102f);
        attack(dis_ray, damage);
    }
}
