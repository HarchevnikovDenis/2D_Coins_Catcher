using UnityEngine;
using UnityEngine.Purchasing;

public class PurchaseSource : MonoBehaviour
{
    // Успешное совершение покупки
    public void OnPurchaseComplete(Product product)
    {
        switch (product.definition.id)
        {
            case "1000_coins": 
                PlayerStats.Instance.Coins += 1000;
                break;
            default:
                break;
        }
    }

    // Во время покупки произошла ошибка
    public void OnPurchaseFailure(Product product, PurchaseFailureReason reason)
    {
        Debug.Log($"Purchase of product {product.definition.id} failed because {reason}");
    }
}
