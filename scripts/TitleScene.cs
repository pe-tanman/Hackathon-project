﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

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

    public void OnNew()
    {
        File.Delete("Assets/savedata.json");
        SceneManager.LoadScene(1);
    }
    public void OnLoad()
    {
        SceneManager.LoadScene(1);
    }
}
