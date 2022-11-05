using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public int damage = 5;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy e = collision.GetComponent<Enemy>();
        
        if(e != null)
        {
            e.TookDamage(damage);
        }
    }
    void Update()
    {
        
    }
}
