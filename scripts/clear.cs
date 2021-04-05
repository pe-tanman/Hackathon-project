using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clear : MonoBehaviour
{
    public int stop;
    public int next_scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < stop){
            transform.Translate(new Vector3(0, 5 * Time.deltaTime, 0));
        }
        else
        {
            Invoke("skip", 3);
        }
    }
    public void skip()
    {
        SceneManager.LoadScene(next_scene);
    }
}
