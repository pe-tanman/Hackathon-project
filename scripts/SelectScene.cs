using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using UnityEngine.UI;

public class SelectScene : MonoBehaviour
{
    public Button b_1,b_2,b_3;
    
    int stage_num;
    // Start is called before the first frame update
    void Start()
    {
        manage_stage();
        savepoint.start = Vector3.zero;
    }

    // Update is called once per frame
    void manage_stage()
    {
        Load load = new Load();
        stage_num = load.load1();

        Button[] stages = {b_1, b_2, b_3};

        for(int i = 0;i < 3;i ++)
        {
            if(i == stage_num)
            {
                stages[i].GetComponentInChildren<Image>().color = new Color(174f/255.0f, 29f/255.0f, 2f/255.0f, 255.0f/255.0f);
                Debug.Log("red");
            } 
            else if(i > stage_num) 
            {
                stages[i].interactable = false;
            }
        }
    }
    void Update()
    {
        
    }
    public void On1()
    {
        SceneManager.LoadScene(2);
    }
    public void On2()
    {
        SceneManager.LoadScene(3);
    }
    public void On3()
    {
        SceneManager.LoadScene(4);
    }
    public void OnBack()
    {
        SceneManager.LoadScene(0);
    }
}
public class Load : MonoBehaviour
{
    public int load1 ()
    {
        Data data = Load2();
        return data.stage;
    }
    public Data Load2()
    {
        if(File.Exists(Application.dataPath + "/savedata.json"))
        {
            string datastr = "";
            StreamReader reader;//streamreaderのインスタンス
            reader = new StreamReader(Application.dataPath + "/savedata.json");
            datastr = reader.ReadToEnd();
            reader.Close();
            return JsonUtility.FromJson<Data>(datastr);
        }
        else//ファイルがなかったら
        {
            Data data = new Data();//データのインスタンス化
            data.stage = 0;
            return data;
        }
    }
}