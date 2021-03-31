using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sp_level : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.Find("savepoints").gameObject.SetActive(SelectScene.easy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
