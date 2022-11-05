using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Key : MonoBehaviour
{

    public bool inTrigger;

    void OnTriggerEnter2D(Collider2D other)
    {
        inTrigger = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        inTrigger = false;
    }

    void Update()
    {
        if (inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                DoorScript.doorKey = true;
                Destroy(this.gameObject);
            }
        }
    }

    void OnGUI()
    {
        if (inTrigger)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), "Press E to take key");
        }
    }
}
