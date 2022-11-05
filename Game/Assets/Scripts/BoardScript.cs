using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;

public class BoardScript : MonoBehaviour
{

    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> transformList;
    public StreamReader reader;
    public Dictionary<string,float> rankins = new Dictionary<string, float>();
    

    private void Start()
    {
        
    }

    private void Awake()
    {
        ReadData();
        entryContainer = transform.Find("EntryContainer");
        entryTemplate = entryContainer.Find("DataTemplate");

        entryTemplate.gameObject.SetActive(false);
        var sortedDict = from entry in rankins orderby entry.Value ascending select entry;
        int i = 0;
        foreach (KeyValuePair<string, float> pair in sortedDict) {
            float t = pair.Value;
            string id = pair.Key;
            //float t = 20;
            //string id = "asd";
            float templateHeight = 30f;
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);
            int rank = i + 1;
            string rankString;
            switch (rank)
            {
                default: rankString = rank + "TH"; break;
                case 1: rankString = "1ST"; break;
                case 2: rankString = "2ND"; break;
                case 3: rankString = "3RD"; break;

            }
            entryTransform.Find("Ranktext").GetComponent<Text>().text = rankString;

            entryTransform.Find("IDtext").GetComponent<Text>().text = id;


            string minutes = ((int)t / 60).ToString();
            string seconds = ((t % 60)).ToString("f1");
            string time = minutes + ":" + seconds;
            entryTransform.Find("Timetext").GetComponent<Text>().text = time;
            i++;
        }

    }

    private void createTransform(float t,string id, Transform container, List<Transform> list)
    {
        //Dictionary<float, string> temp =  dic.OrderByDescending(i => i.Key);
        
        
    }

    public void ReadData()
    {
        reader = new StreamReader(Application.dataPath + "/Ranking.txt");

        int cnt = 0;
        string str;
        string line2;
        while ((str = reader.ReadLine()) != null)
        {
            line2 = reader.ReadLine();
            if (rankins.ContainsKey(line2))
            {
                if (float.Parse(str) < rankins[line2])
                {
                    rankins.Remove(line2);
                    rankins.Add(line2, float.Parse(str));
                }
            }
            else { 
            rankins.Add(line2, float.Parse(str));
            }
            
        }
        if (str == null)
        {
            Debug.Log("No data");
        }
        reader.Dispose();
        reader.Close();

    }

    public void menu()
    {
        SceneManager.LoadScene("Menu");
    }


}
