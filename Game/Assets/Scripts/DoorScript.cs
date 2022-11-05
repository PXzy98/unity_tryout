using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public static bool doorKey;
    public bool open;
    public bool close;
    public bool inTrigger;
    public string nextLevel;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            inTrigger = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            inTrigger = false;
    }

    void Update()
    {
        if (inTrigger)
        {
            if (close)
            {
                if (doorKey)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        open = true;
                        close = false;
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    close = true;
                    open = false;
                }
            }
        }

        if (open)
        {
            GameObject.Find("timer").SendMessage("FinalFinish");
            SceneManager.LoadScene(nextLevel);
        }
        else
        {
            //GUI.Label(new Rect(0, 0, 200, 25), "NOT OPENED");
        }
    }

    void OnGUI()
    {
        if (inTrigger)
        {
            if (open)
            {
                GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), "Press E to close");
            }
            else
            {
                if (doorKey)
                {
                    GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), "Press E to open");
                }
                else
                {
                    GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), "Need a key!");
                }
            }
        }
    }
}
