using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text timerText;
    private float startTime;
    private bool finished;
    private float t;
    public StreamWriter writer;
    public StreamReader reader;
    public List<string> allData;
    
    // Start is called before the first frame update
    void Start()
    {
        
        startTime = Time.time;
        finished = false;

    }


    // Update is called once per frame
    void Update()
    {
        if (finished){
            return;
        }
        t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = ((t % 60)).ToString("f1");

        timerText.text = minutes + ":" + seconds; 


    }

    public void Finish()
    {
        finished = true;
        timerText.color = Color.yellow;
        TotalTime.totalTime += t;
        //SavaProcess(t.ToString());
        //WriteData(t.ToString()+" ");
    }

    public void FinalFinish()
    {
        finished = true;
        timerText.color = Color.yellow;
        TotalTime.totalTime += t;
        //SavaProcess(t.ToString());

        WriteData(TotalTime.totalTime.ToString() + " ");
        TotalTime.totalTime = 0;
    }
    public void WriteData(string message)
    {
        FileInfo file = new FileInfo(Application.dataPath + "/Ranking.txt");
        if (!file.Exists)
        {
            writer = file.CreateText();
        }
        else
        {
            writer = file.AppendText();
        }
        writer.WriteLine(message);
        writer.Flush();
        writer.Dispose();
        writer.Close();
    }

    public void ReadData()
    {
        reader = new StreamReader(Application.dataPath + "/Ranking.txt");

        string str;
        while ((str = reader.ReadLine()) != null)
        {
            allData.Add(str);
        }
        if (allData == null)
        {
            Debug.Log("No data");
        }
        reader.Dispose();
        reader.Close();
        
    }



}
