using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    
    public GameObject gorl_pannel;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Save.save1(100);
            gorl_pannel.SetActive(true);
            Time.timeScale = 0f;
        }
        
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
