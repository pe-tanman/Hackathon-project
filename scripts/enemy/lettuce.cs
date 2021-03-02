using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lettuve : MonoBehaviour
{
    // Start is called before the first frame update
    void RevDamage(float dam)
    {
        Debug.Log("revdamage");
        transform.parent.GetComponent<Cabbage>().cabbage.RevDamage(dam);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
