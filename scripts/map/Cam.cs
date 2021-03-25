using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public GameObject player;
    public Vector3 pos;
    GameObject go;
    public Cam(GameObject GO)
    {
        go = GO;
        player = GameObject.Find("player");
    }
    public void main()
    {
        pos = player.transform.position;
        if(pos.y < 0)
        {
            go.GetComponent<Camera>().orthographicSize = 5;
            go.transform.position = new Vector3(pos.x, 0, -9);
        }
        else
        {
            go.GetComponent<Camera>().orthographicSize = 5;
            go.transform.position = new Vector3(pos.x, pos.y, -9);
        }
    }
}
