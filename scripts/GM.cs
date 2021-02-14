using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public GameObject pausePanel;
    bool pause = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!pause)
            {
                Time.timeScale = 0f;
                pausePanel.SetActive(true);
                pause = true;
            }
            else
            {
                Time.timeScale = 1f;
                pausePanel.SetActive(false);
                pause = false;
            }
        }
        
    }
    public void Restart()
    {
        Debug.Log("restart");
    }
    public void Stage()
    {
        Debug.Log("stage select");
    }
    public void Title()
    {
        Debug.Log("title");
    }
}
