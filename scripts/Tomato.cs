using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : MonoBehaviour
{
    GameObject object_tomato;
        
    int dir_tomato = 1;

    Enemies tomato = new Enemies("tomato", 15,1);

    void move_Tomato()
    {
        transform.Rotate(new Vector3(0,0,-180 * Time.deltaTime));
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x + 3f * Time.deltaTime * dir_tomato, pos.y, pos.z);
    }
    void bound_tomato()
    {
        transform.Rotate(new Vector3(0, 180, 0));
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, pos.y + 0.3f, pos.z);
        dir_tomato *= -1;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            bound_tomato();
        }
        if(collision.gameObject.tag == "Player")
        {
            bound_tomato();
            player.hp -= 1;
            Debug.Log(player.hp);
        }
    } 

    void Start()
    {
        
    }
    void Update()
    {
        move_Tomato();
    }
}
