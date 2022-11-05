using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyBindScript : MonoBehaviour
{

    /// <summary>
    /// This is the dictionary, that contains all our keybinds
    /// </summary>
    //public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    /// <summary>
    /// References to the button objects, these are used for showing the current keybinds
    /// </summary>
    public Text up, left, down, right, jump, fire1, fire2, reload;

    /// <summary>
    /// The key, that we are binding atm.
    /// </summary>
    private GameObject currentKey;

    /// <summary>
    /// The normal color of the buttons
    /// </summary>
    private Color32 normal = new Color32(39, 171, 249, 255);

    /// <summary>
    /// The highlighted color of the buttons
    /// </summary>
    private Color32 slected = new Color32(239, 116, 36, 255);

    // Use this for initialization
    void Start()
    {
        
        
            //Adds the keys to the dictionary, by using the playerprefs       
            UserPrefs.keys.Add("Up", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W")));
            UserPrefs.keys.Add("Down", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Down", "S")));
            UserPrefs.keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A")));
            UserPrefs.keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));
            UserPrefs.keys.Add("Jump", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space")));
            UserPrefs.keys.Add("Fire1", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Fire1", "Mouse 0")));
            UserPrefs.keys.Add("Fire2", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Fire2", "Mouse 1")));
            UserPrefs.keys.Add("Reload", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Reload", "R")));

            

        
    }

    // Update is called once per frame
    void Update()
    {
        //Simulates movement and usage of the keys

        //Debug.Log(UserPrefs.GetString("Up", "W"));
        up.text = UserPrefs.keys["Up"].ToString();
        down.text = UserPrefs.keys["Down"].ToString();
        left.text = UserPrefs.keys["Left"].ToString();
        right.text = UserPrefs.keys["Right"].ToString();
        jump.text = UserPrefs.keys["Jump"].ToString();
        fire1.text = UserPrefs.keys["Fire1"].ToString();
        fire2.text = UserPrefs.keys["Fire2"].ToString();
        reload.text = UserPrefs.keys["Reload"].ToString();

    }



    void OnGUI()
    {
        if (currentKey != null) //If we have selected a key, that we want to edit
        {
            Event e = Event.current; //Stores the event

            if (e.isMouse)
            {
                switch (e.button)
                {
                    case 0:
                        UserPrefs.keys[currentKey.name] = KeyCode.Mouse0;
                        currentKey.transform.GetChild(0).GetComponent<Text>().text = "Mouse 0";
                        break;
                    case 1:
                        UserPrefs.keys[currentKey.name] = KeyCode.Mouse1;
                        currentKey.transform.GetChild(0).GetComponent<Text>().text = "Mouse 1";
                        break;

                }

                currentKey.GetComponent<Image>().color = normal; //Sets thecolor
                currentKey = null; //Deselects the key
            }

            if (e.isKey) //If we pressed a key on the keyboard, then we need to assign it to the selected key
            {
                UserPrefs.keys[currentKey.name] = e.keyCode; //Sets the current key
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString(); //Sets the text
                currentKey.GetComponent<Image>().color = normal; //Sets thecolor
                currentKey = null; //Deselects the key
            }
        }
    }

    /// <summary>
    /// Changes a keybind
    /// </summary>
    /// <param name="clicked">The clicked button</param>
    public void ChangeKey(GameObject clicked)
    {
        if (currentKey !=null) //If we have a selected key, then we need to deselect
        {
            currentKey.GetComponent<Image>().color = normal; //Sets the color to normal
        }

        currentKey = clicked; //Sets the new clicked key as the current key

        currentKey.GetComponent<Image>().color = slected; //Set the color as selected
    }

    /// <summary>
    /// Saves the new keybinds
    /// </summary>
    public void SaveKeys()
    {
        foreach (var key in UserPrefs.keys) //Runs through the dictionary
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString()); //Saves the keybinds for each key
        }

        PlayerPrefs.Save();
        
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
