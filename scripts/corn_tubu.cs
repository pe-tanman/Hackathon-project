using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corn_tubu : MonoBehaviour
{
    float dam = Corn.damage;
    void OnCollisionEnter2D(Collision2D col)
    {
        
        if(col.gameObject.tag == "Player")
        {
            player.RevDamage(dam);
        }
        if (col.gameObject.tag == "ground")
        {
            this.gameObject.SetActive(false);
        }
    }
}
