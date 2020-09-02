using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class InteractionWithSkins : MonoBehaviour
{
    [SerializeField] private Button selectButton;
    [SerializeField] private Text selectText;
    [SerializeField] private Button buyButton;
    [SerializeField] private Text costToBuy;

    private SkinsSettings skin;

    public void ActivateSelectButton(SkinsSettings skin)
    {
        this.skin = skin;
        selectButton.gameObject.SetActive(true);
        if (isSeleceted(skin.Identifier))
        {
            selectButton.interactable = false;
            selectText.text = "SELECTED";
        }
        else
        {
            selectButton.interactable = true;
            selectText.text = "SELECT";
        }

    }

    private bool isSeleceted(string productID)
    {
        if(productID == PlayerStats.Instance.selectableSkin)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



    public void ActivateBuyButton(SkinsSettings skin)
    {
        this.skin = skin;
        buyButton.gameObject.SetActive(true);
        costToBuy.text = $"{skin.Price} COINS";

        buyButton.interactable = PlayerStats.Instance.Coins >= skin.Price;
    }

    public void SelectSkin()
    {
        PlayerStats.Instance.selectableSkin = skin.Identifier;
        selectButton.interactable = false;
        UpdateUI();
    }

    public void BuyProduct()
    {
        if(PlayerStats.Instance.Coins >= skin.Price)
        {
            skin.IsItBought = true;
            PlayerStats.Instance.Coins -= skin.Price;
            PlayerStats.Instance.selectableSkin = skin.Identifier;
            buyButton.gameObject.SetActive(false);
            selectButton.gameObject.SetActive(true);
            SelectSkin();
        }
    }

    private void UpdateUI()
    {
        FindObjectOfType<SnapScrolling>()?.UpdateShopUI();
    }
}
