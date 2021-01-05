using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies
{
    public string image_main;
    public string image_left;
    public string name;
    float maxHP;
    float attack;
    

    public Enemies(string name, float maxHP, 
    float attack, string image_main, string image_left)
    {
        this.name = name;
        this.maxHP = maxHP;
        this.image_main = image_main;
        this.image_left = image_left;
        this.attack = attack;
    }
    
     
}
public class Enemy : MonoBehaviour
{
    public GameObject prefab_tomato;
    GameObject Tomato;

    int Tomato_dir = 1;
    Enemies tomato = new Enemies("tomato", 15, 1, 
    "image/tomato.png", "image/tomato_left.png"); 
    
    // Start is called before the first frame update
    void Awake()
    {
        Tomato = Instantiate(prefab_tomato) as GameObject;
    }
    
    void move_Tomato()
    {
        Tomato.transform.Rotate(new Vector3(0,0,-150 * Time.deltaTime * Tomato_dir));
        Vector3 pos = Tomato.transform.position;
        Tomato.transform.position = new Vector3(pos.x + 3f * Time.deltaTime * Tomato_dir, pos.y, pos.z);
    }
    void Tomato_onWall(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            Tomato.transform.Rotate(new Vector3(0, 180, 0));
            Tomato_dir = -1;
            Debug.Log("onWall");
        }
    }   
void Start()
    {
        
    }
    void Update()
    {
        move_Tomato();
    }
}

