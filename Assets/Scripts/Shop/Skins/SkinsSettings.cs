using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkinsSettings
{
    [SerializeField] private GameObject skin;
    [SerializeField] private string identifier;
    [SerializeField] private int price;

    public GameObject Skin { get { return skin; } }
    public string Identifier { get { return identifier; } }
    public int Price { get { return price; } }
    public bool IsItBought
    {
        get
        {
            if(PlayerPrefs.GetInt(identifier, 0) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        set
        {
            if (value)
            {
                PlayerPrefs.SetInt(identifier, 1);
            }
            else
            {
                PlayerPrefs.SetInt(identifier, 0);
            }
        }
    }
}
