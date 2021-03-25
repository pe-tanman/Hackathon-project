using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_back : MonoBehaviour
{
    public GameObject warp_hole, BG,  hp_bar_obj;
    public Sprite sunny;
    void RevDamage(float dam)
    {
        Enemies boss = transform.parent.GetComponent<Boss>().boss;
        if(boss.hp - dam <= 0)
        {
            GameObject obj = Instantiate(warp_hole, new Vector3(660, 13, 0), Quaternion.Euler(0, 0, 0));
            BG.GetComponent<SpriteRenderer>().sprite = sunny;
            hp_bar_obj.SetActive(false);
        }
        boss.RevDamage(dam);
    }
    
}
