using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class GM : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject player;
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
                reset_pause();
            }
        }
        
    }
    public void Restart()
    {
        Debug.Log("restart");
        reset_pause();
        Debug.Log(Save.load1());
        player.transform.position = new Vector3(-5, 0, -1);
    }
    public void Stage()
    {
        reset_pause();
        Debug.Log("stage select");
    }
    public void Title()
    {
        reset_pause();
        SceneManager.LoadScene("TitleScene");
    }
    void reset_pause ()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        pause = false;
    }
}
public class Data
{
    public int point;
}
public class Save : MonoBehaviour
{
    public static void save1(int savepoint)
    {
        Data data = new Data();
        data.point = savepoint;
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
        return data.point;
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
            data.point = 400;
            return data;
        }
    }
}
    
