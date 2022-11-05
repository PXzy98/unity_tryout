using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Property : MonoBehaviour
{
    
    public enum WeaponType { Rifle, Pistol, missile, laser}
    public int health;
    public float fireRate;
    public WeaponType weapon;
    private int coins;
    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        fireRate = 0.5f;
        weapon = WeaponType.Pistol;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetCoin()
    {
        return coins;
    }
}
