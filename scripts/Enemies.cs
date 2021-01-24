using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public string name_en;
    public float maxHP;
    float attack;

    //static GameObject anime;

    public Enemies(string name, float maxHP, 
    float attack)
    {
        this.name_en = name;
        this.maxHP = maxHP;
        this.attack = attack;
    }
    public void death(GameObject obj)
    {
        var prefab  = Resources.Load<GameObject>("death_anime");
        //anime = Instantiate(prefab, obj.transform.position, Quaternion.identity);
        Destroy(obj);
    }

}

