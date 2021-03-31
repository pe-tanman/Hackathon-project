using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public float stay_time = 3;
    public GameObject gate, gate1, gate2;
    Transform parent_obj;
    public bool on = false;  
    GameObject[] gates;
    // Start is called before the first frame updat
    void Start()
    {
        parent_obj = this.transform.parent;
        gates = new GameObject[3] {gate, gate1, gate2}; 
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if((other.tag == "Player" || other.tag == "spe_tomato")&& !on)
        {
            Debug.Log(on);
            On_B();
        }
    }
    void On_B()
    {
        foreach (var any_gate in gates)
        {
           if(any_gate != null)
            {   if(any_gate.GetComponent<whole>() != null)
                {
                    any_gate.GetComponent<whole>().change();
                }
                else{
                    any_gate.GetComponent<gate>().change();
                }
            }
        }
        on = true;
        parent_obj.GetComponent<SpriteRenderer>().color = new Color(100/255.0f, 100/255.0f, 100/255.0f, 256.0f/255.0f);
        parent_obj.Translate(new Vector3(0, -0.2f, 0));
        Invoke("Off_B", stay_time);
    }
    void Off_B()
    {
        on = false;
        foreach (var any_gate in gates)
        {
            if(any_gate != null)
            {   if(any_gate.GetComponent<whole>() != null)
                {
                    any_gate.GetComponent<whole>().change();
                }
                else{
                    any_gate.GetComponent<gate>().change();
                }
            }
           
        }
        parent_obj.GetComponent<SpriteRenderer>().color = new Color(255/255.0f, 255/255.0f, 255/255.0f, 256.0f/255.0f);
        parent_obj.Translate(new Vector3(0, 0.2f, 0));
    }
    void RevDamage()
    {
        On_B();
    }
}
