using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text scoreText;
    [SerializeField] private SnapScrolling snapScrolling;

    private static PlayerStats instance;
    private Vector3 playerSpawnPosition = new Vector3(0.0f, -3.5f, 0.0f);
    private GameObject playerSkinPrefab;
    public static PlayerStats Instance
    {
        get
        {
            return instance;
        }
    }
    public int Coins
    {
        get
        {
            return PlayerPrefs.GetInt("Coins", 0);
        }
        set
        {
            PlayerPrefs.SetInt("Coins", value);
            scoreText.text = value.ToString();
        }
    }

    public string selectableSkin
    {
        get
        {
            return PlayerPrefs.GetString("Skin", "product_0");
        }
        set
        {
            PlayerPrefs.SetString("Skin", value);
        }
    }

    public float LengthOfSideways;

    public bool isGameStart { get; set; }
    public bool isGameOver { get; set; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        scoreText.text = Coins.ToString();
        CreateACharacterWithTheSelectedSkin();
    }

    private void CreateACharacterWithTheSelectedSkin()
    {
        foreach (SkinsSettings skin in snapScrolling.skins)
        {
            if(skin.Identifier == selectableSkin)
            {
                playerSkinPrefab = skin.Skin;
            }
        }
        
        Instantiate(playerSkinPrefab, playerSpawnPosition, Quaternion.identity);
    }

    public void ShowGameOverPanel()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
    }
}
