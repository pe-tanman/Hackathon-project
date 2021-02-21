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
    public static int savepoint;
    bool pause = false;
    float hp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HPBar();

        if(Input.GetKeyDown(KeyCode.Escape))
        {
           OutPanel(pausePanel); 
        }
        
    }
    public void OutPanel(GameObject panel)
    {
        if(!pause)
        {
            Time.timeScale = 0f;
            panel.SetActive(true);
            pause = true;
        }
        else
        {
            reset_pause();
        }
    }
    public void Restart()
    {
        Debug.Log("restart");
        reset_pause();
        Debug.Log(Save.load1());
        SceneManager.LoadScene(1);
        Player.transform.position = new Vector3(-5, 0, -1);
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
    public void reset_pause ()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        pause = false;
    }
    void HPBar()
    {
        hp = player.hp;
        hp /= 6;
　　　　　slider.value = hp;
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
    
