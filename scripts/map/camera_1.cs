using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_1 : MonoBehaviour
{
    Cam cam1;
    public GameObject GM, tutorial;
    static bool first = true;
    void Start()
    {
        cam1 = new Cam(this.gameObject);
        if(first){
            GM.GetComponent<GM>().OutPanel(tutorial);
            first = false;
        }
        
    }
    

    void Update()
    {
        
        Vector3 pos = cam1.player.transform.position;
        if(pos.x >= 163 && pos.x <= 190)
        {
            this.GetComponent<Camera>().orthographicSize = 8;
            transform.position = new Vector3(178, 5, -9);
        }
        else{
            cam1.main();
        }
    }
}
