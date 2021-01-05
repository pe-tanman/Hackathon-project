using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies
{
    string image_main;
    string image_left;
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
    
    Enemies tomato = new Enemies("tomato", 15, 1, 
    "image/tomato.png", "image/tomato_left.png"); 
    GameObject Tomato;
    // Start is called before the first frame update
    void Awake()
    {
        Tomato = Instantiate (prefab_tomato) as GameObject;
    }
    void Start()
    {
        
    }
    void move_Tomato()
    {
        Tomato.transform.Rotate(new Vector3(0,0,-150 * Time.deltaTime));
        Vector3 pos = Tomato.transform.position;
        Tomato.transform.position = new Vector3(pos.x + 3f * Time.deltaTime, pos.y, pos.z);
    }
    void Update()
    {
        move_Tomato();
    }
}

