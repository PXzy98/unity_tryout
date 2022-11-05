using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Property))]
public class PropertyEditor : Editor
{
    [Header("Properties")]
    private int healthMax = 20;
    private float fireRateMin = 0.2f;
    private float fireRatemax = 0.7f;


    public override void OnInspectorGUI()
    {
        Property prop = (Property)target;
        EditorGUILayout.LabelField("Properties");
        EditorGUILayout.Space();
        
        GUILayout.BeginHorizontal();
        GUILayout.EndHorizontal();
        prop.weapon = (Property.WeaponType)EditorGUILayout.EnumPopup("Weapon", prop.weapon);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Health");
        string newHealth = EditorGUILayout.TextField(prop.health.ToString());
        if (int.Parse(newHealth) >= 20)
        {
            prop.health = 20;
        }
        else if (int.Parse(newHealth) <= 20)
        {
            prop.health = 0;
        }
        else
        {
            prop.health = int.Parse(newHealth);
        }
        EditorGUILayout.Space();
        prop.fireRate = EditorGUILayout.Slider("FireRate: ",prop.fireRate, fireRateMin, fireRatemax);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Coins:");
        //int coins = prop.GetCoin();
        EditorGUILayout.LabelField(prop.GetCoin().ToString());


    }
}
