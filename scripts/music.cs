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
            bool out_panel = gm.GetComponent<GM>().pause;
            if(out_panel)
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

