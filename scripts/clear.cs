using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < 100){
            transform.Translate(new Vector3(0, 5 * Time.deltaTime, 0));
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
    public void skip()
    {
        SceneManager.LoadScene(0);
    }
}
