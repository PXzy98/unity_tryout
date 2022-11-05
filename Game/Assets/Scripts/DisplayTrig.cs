using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTrig : MonoBehaviour
{
    public GameObject shopPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if(player != null)
        {
            player.canFire = false;
            shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.canFire = true;
            shopPanel.SetActive(false);
        }
    }
}
