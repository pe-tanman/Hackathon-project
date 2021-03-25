using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_2 : MonoBehaviour
{
    Cam cam2;

    void Start()
    {
        cam2 = new Cam(this.gameObject);
    }
    

    void Update()
    {
        cam2.main();
    }
}
