using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public GameObject pausePanel, GameoverPanel, Player;
    public Slider slider;
    bool pause = false;
    float hp;
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        HPBar();

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!pause)
            {
                OutPanel(pausePanel); 
            }
            else{
                reset_panel(pausePanel);
            }
           
        }
        
    }
    public void Restart()
    {
        reset_panel(pausePanel);
        SceneManager.LoadScene(1);
        Player.transform.position = new Vector3(-5, 0, -1);
    }
    public void Stage()
    {
        reset_panel(pausePanel);
    }
    public void Title()
    {
        reset_panel(pausePanel);
        SceneManager.LoadScene("TitleScene");
    }
    public void OutPanel(GameObject panel)
    {

        Time.timeScale = 0f;
        panel.SetActive(true);
        pause = true;

    }

    public void reset_panel (GameObject panel)
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
        pause = false;
    }
    void HPBar()
    {
        hp = player.hp;
        hp /= 6;
　　　　　slider.value = hp;
    }
    public void OnContinue()
    {
       reset_panel(GameoverPanel);
       SceneManager.LoadScene(1);
    }
    
}
public class Data
{
    public int point;
    public int stage;
}
public class Save : MonoBehaviour
{
    public static void save1(int savepoint)
    {
        Data data = new Data();
        data.stage = savepoint;
        save2(data);
    }
    public static void save2(Data data)
    {
        StreamWriter writer;//独自変数の宣言
        string jsonstr = JsonUtility.ToJson(data);//dataはアトリビュート(クラス内変数), dataをjsonに変換
        writer = new StreamWriter(Application.dataPath + "/savedata.json",false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }
    public static int load1 ()
    {
        Data data = Load2();
        return data.stage;
    }
    public static Data Load2()
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
    
