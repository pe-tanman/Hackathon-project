using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corn_tubu : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        
        if(col.gameObject.tag == "Player")
        {
            Corn.corn.attack();
        }
        if (col.gameObject.tag == "ground")
        {
            this.gameObject.SetActive(false);
        }
    }
}
