using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoExecUserPrefs : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (UserPrefs.keys != null){
            foreach (var key in UserPrefs.keys) //Runs through the dictionary
            {
                PlayerPrefs.SetString(key.Key, key.Value.ToString()); //Saves the keybinds for each key
                Debug.Log(key.Key);
                Debug.Log(key.Value.ToString());

            }

            PlayerPrefs.Save();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(UserPrefs.keys["Up"]))
        {
            //Do a move action
            Debug.Log("Up");
        }
        if (Input.GetKeyDown(UserPrefs.keys["Down"]))
        {
            //Do a move action
            Debug.Log("Down");
        }
        if (Input.GetKeyDown(UserPrefs.keys["Left"]))
        {
            //Do a move action
            Debug.Log("Left");
        }
        if (Input.GetKeyDown(UserPrefs.keys["Right"]))
        {
            //Do a move action
            Debug.Log("Right");
        }
        if (Input.GetKeyDown(UserPrefs.keys["Jump"]))
        {
            //Do a move action
            Debug.Log("Jump");
        }
        if (Input.GetButtonDown("Fire1"))
        {
            //Do a move action
            Debug.Log("Fire1");
        }

        if (Input.GetButtonDown("Fire2"))
        {
            //Do a move action
            Debug.Log("Fire2");
        }

        if (Input.GetKeyDown(UserPrefs.keys["Fire1"]))
        {
            //Do a move action
            Debug.Log("Fire1b");
        }

        if (Input.GetKeyDown(UserPrefs.keys["Fire2"]))
        {
            //Do a move action
            Debug.Log("Fire2b");
        }
        if (Input.GetKeyDown(UserPrefs.keys["Reload"]))
        {
            //Do a move action
            Debug.Log("Reload");
        }
    }
}
