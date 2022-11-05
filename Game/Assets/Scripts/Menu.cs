using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene("First_level");
    }

    public void menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LeaderBoard()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        SceneManager.LoadScene("PauseMenu");
    }

    public void OnTriggerEnter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void Setting()
    {
        SceneManager.LoadScene("Setting");
    }

}
