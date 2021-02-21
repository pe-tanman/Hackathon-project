﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public string name_en;
    public float hp, damage;
    public GameObject GO;
    public GameObject player;

    //static GameObject anime;

    public Enemies(string name, float maxHP, 
    float damage, GameObject go)
    {
        this.name_en = name;
        this.hp = maxHP;
        this.damage = damage;
        this.GO = go;
        player = GameObject.Find("player");
    }
    public void death()
    {
        Debug.Log(GO);
        //var prefab  = Resources.Load<GameObject>("death_anime");
        //anime = Instantiate(prefab, obj.transform.position, Quaternion.identity);
        Destroy(GO);
    }
    public void attack()
    {
        player.GetComponent<player>().RevDamage(damage);
    }
    public void RevDamage(float dam)
    {
        hp -= dam;
        if(hp <= 0)
        {
            death();
        }
    }

}

