using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public GameObject gm;
    AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();                         
    }

    // Update is called once per frame
    void Update()
    {
        if(gm != null)
        {
            if(player.hp <= 0 || gm.GetComponent<GM>().pause)
            {
                audioSource.enabled = false;
            }
            else
            {
                audioSource.enabled = true;
            }
        }
       
    }
}

