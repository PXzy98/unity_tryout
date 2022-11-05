using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Triger : MonoBehaviour
{
    public string nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        //GameObject.Find("timer").SendMessage("Finish");
        
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(nextLevel);
            GameObject timerOb = GameObject.Find("timer");
            timerOb.SendMessage("Finish");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
