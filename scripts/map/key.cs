using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    public AudioClip key_a;
    Music music = new Music();
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player")
        {
            player.have_key = true;
            AudioSource AS = GetComponent<AudioSource>();
            AS.PlayOneShot(key_a);
            Destroy(this.gameObject);
        }
    }
}
