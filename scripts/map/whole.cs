using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whole : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D info)
    {
        if(info.gameObject.tag == "Player")
        {
            change();
        }
    }
    void back()
    {
        this.gameObject.SetActive(true);
    }
    public void change()
    {
        this.gameObject.SetActive(false);
        Invoke("back", 3);
    }
}
