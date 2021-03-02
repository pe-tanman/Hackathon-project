using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{
    public Sprite lever_on, lever_off;
    public GameObject gate1, gate2, gate3;
    public bool on_lever= false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {   
            if(Input.GetMouseButtonDown(1))
            {
                change_gate(gate1);
                change_gate(gate2);
                change_gate(gate3);
                if(!on_lever)
                {
                   this.GetComponent<SpriteRenderer>().sprite = lever_on;
                    on_lever = !on_lever; 
                }
                else{
                    this.GetComponent<SpriteRenderer>().sprite = lever_off;
                    on_lever = !on_lever; 
                }
                
            }
        }
    }
    void change_gate(GameObject go)
    {
        if(go != null)
        {
            go.GetComponent<gate>().change();
        }
    }

}
