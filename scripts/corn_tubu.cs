using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corn_tubu : MonoBehaviour
{
    GameObject Player;
    float dam = Corn.damage;
    void OnCollisionEnter2D(Collision2D col)
    {
        
        if(col.gameObject.tag == "Player")
        {
            Player.GetComponent<player>().RevDamage(dam);
            Debug.Log("on corn");
        }
        if (col.gameObject.tag == "ground")
        {
            this.gameObject.SetActive(false);
        }
    }
    void Start()
    {
        Player = GameObject.Find ("player");
    }
}
