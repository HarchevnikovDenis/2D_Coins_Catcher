using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnapScrolling : MonoBehaviour
{
    [SerializeField] private GameObject productPanelPrefab;
    public List<SkinsSettings> skins = new List<SkinsSettings>();

    private List<InteractionWithSkins> panels = new List<InteractionWithSkins>();

    private void Awake()
    {
        CheckPurchasedProducts();
    }

    private void Start()
    {
        InitContent();
    }

    private void CheckPurchasedProducts()
    {
        // Выполняем проверку в реестре какие скины уже были куплены
        for (int i = 0; i < skins.Count; i++)
        {
            if (skins[i].Price == 0)
            {
                PlayerPrefs.SetInt(skins[i].Identifier, 1);
                skins[i].IsItBought = true;
            }
            else
            {
                if (PlayerPrefs.GetInt(skins[i].Identifier, 0) != 0)
                {
                    skins[i].IsItBought = true;
                }
            }
        }
    }

    private void InitContent()
    {
        // Генерируем контент на основании заполненного списка Скинов в объекте Content
        foreach (SkinsSettings skin in skins)
        {
            GameObject panel = Instantiate(productPanelPrefab, transform);
            panel.GetComponent<Image>().sprite = skin.Skin.GetComponent<SpriteRenderer>().sprite;
            panel.GetComponent<Image>().color = skin.Skin.GetComponent<SpriteRenderer>().color;

            InteractionWithSkins interactionWithSkins = panel.GetComponent<InteractionWithSkins>();

            if(skin.IsItBought)
            {
                interactionWithSkins.ActivateSelectButton(skin);
            }
            else
            {
                interactionWithSkins.ActivateBuyButton(skin);
            }

            panels.Add(interactionWithSkins);
        }
    }

    public void UpdateShopUI()
    {
        for (int i = 0; i < skins.Count; i++)
        {
            if (skins[i].IsItBought)
            {
                panels[i].ActivateSelectButton(skins[i]);
            }
            else
            {
                panels[i].ActivateBuyButton(skins[i]);
            }
        }
    }
}
