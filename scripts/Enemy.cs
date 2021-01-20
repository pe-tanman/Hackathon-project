using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies
{
    public string name;
    float maxHP;
    float attack;
    public Enemies(string name, float maxHP, 
    float attack)
    {
        this.name = name;
        this.maxHP = maxHP;
        this.attack = attack;
    }
       
}
public class Enemy : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Awake()
    {
        //Tomato = Instantiate(prefab_tomato) as GameObject;
        //Tomato = Instantiate(prefab_tomato) as GameObject;
    }
    
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}

