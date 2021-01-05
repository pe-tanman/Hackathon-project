using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test
{
    string name;
    public Test(string name)
    {
        this.name = name;
    }
    public void avg(int math, int English)
    {
        Debug.Log(name + ":" + (math + English)/ 2);
    }

}
public class learn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Test a01 = new Test("Sato");
        a01.avg(50, 60);
        Test a02 = new Test("Tanaka");
        a02.avg(10, 90);
        Enemies tomato = new Enemies("tomato", 15, 1, 
        "image/tomato.png", "image/tomato_left.png"); 
        Debug.Log(tomato.name);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
