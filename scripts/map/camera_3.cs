using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_3 : MonoBehaviour
{
    Cam cam3;
    public AudioSource audioSource;
    public AudioClip boss, sunny;
    bool first1 = true, first2 = true;
    void Start()
    {
        cam3 = new Cam(this.gameObject);
    }
    

    void Update()
    {
        Vector3 pos = cam3.player.transform.position;
        if(pos.x >= 345 && pos.x <= 350)
        {
            this.GetComponent<Camera>().orthographicSize = 9;
            transform.position = new Vector3(338, 13, -7);
        }
        else if(pos.x >= 630 && pos.x <= 690)
        {
            if(first1)
            {
                audioSource.clip = boss;
                audioSource.Play();
                first1 = false;
            }
            
            this.GetComponent<Camera>().orthographicSize = 9;
            transform.position = new Vector3(pos.x, pos.y, -7);
        }
        else if(pos.x > 680)
        {
            if(first2)
            {
                audioSource.clip = sunny;
                audioSource.Play();
                first2 = false;
            }
            cam3.main();
        }
        else
        {
            cam3.main();
        }
    }
}
