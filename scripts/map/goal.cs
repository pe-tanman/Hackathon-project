using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    public GameObject gorl_pannel, GameMaster;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Save.save1(100);
            GameMaster.GetComponent<GM>().OutPanel(gorl_pannel);
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
