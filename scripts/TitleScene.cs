﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
    
    }   

    public void OnStart()
    {
        SceneManager.LoadScene(1);
    }
    public void OnLoad()
    {
        SceneManager.LoadScene(1);
    }
}
