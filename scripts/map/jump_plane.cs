using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump_plane : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip jump;
    Rigidbody2D rb;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            rb = other.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(15, 6), ForceMode2D.Impulse);
            AudioSource AS = GetComponent<AudioSource>();
            AS.PlayOneShot(jump);
        }
        
    }
    void Start()
    {

    }
}
