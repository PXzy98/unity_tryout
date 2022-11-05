using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;


public class reportingHolder : MonoBehaviour


{
    public StreamWriter writer;
    public Button btnClick;
    public InputField inputUser;
    // Start is called before the first frame update
    void Start()
    {
        btnClick.onClick.AddListener(GetInputOnClickHandler);
    }
    public void menu()
    {
        WriteData("***");
        SceneManager.LoadScene("Menu");
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
    public void GetInputOnClickHandler()
    {
        Debug.Log("log input" + inputUser.text);
        if (inputUser.text.Equals(""))
        {
            WriteData("***");
        }else if (inputUser.text.Equals("Ur ID"))
        {
            WriteData("***");
        }
        else
        {
            WriteData(inputUser.text);
        }
        SceneManager.LoadScene("Menu");

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
