using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public Text bulletsText;
	public Text healthText;
	public Slider healthBar;
	public Text coinsText;
	public Text bombsText;

	// Use this for initialization
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void Awake()
	{

		UpdateHealthBar();
		UpdateCoins();

	}

	public void UpdateBulletsUI(int bullets)
	{
		bulletsText.text = bullets.ToString();
	}

	public void UpdateHealthUI(int health)
	{
		healthText.text = health.ToString();
		healthBar.value = health;
	}

	public void UpdateCoins()
	{
		coinsText.text = Manager.gameManager.coins.ToString();
	}

	public void UpdateBombs(int bombs)
	{
		bombsText.text = bombs.ToString();
	}

	public void UpdateHealthBar()
	{
		healthBar.maxValue = Manager.gameManager.health;
	}
}
