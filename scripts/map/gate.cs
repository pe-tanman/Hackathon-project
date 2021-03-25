using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate : MonoBehaviour
{
    public Sprite gate_open, gate_close;
    public AudioClip gate_a;

    public bool open_gate = false;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player")
        {
            if(player.have_key)
            {
                open();
            }      
        }
        
    }
    void Update()
    {
        
    }
    void open()
    {
        player.have_key = false;
        GetComponent<SpriteRenderer>().sprite = gate_open;
        GetComponent<BoxCollider2D>().enabled = false;
    }
    void close()
    {
        GetComponent<SpriteRenderer>().sprite = gate_close;
        GetComponent<BoxCollider2D>().enabled = true;
    }
    public void change()
    {
        AudioSource AS = GetComponent<AudioSource>();
        AS.PlayOneShot(gate_a);

        if(open_gate)
        {
            close();
            open_gate = !open_gate;
        }
        else
        {
            open();
            open_gate = !open_gate;
        }
    }
}
