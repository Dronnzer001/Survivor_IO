using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopContent : MonoBehaviour
{
  public ShopItem ActiveItem;
    public static bool isPurchased = false;
    private ManagerMecanique managerMecanique;
    public void Start()
    {
        managerMecanique = FindAnyObjectByType<ManagerMecanique>();
    }
    public void Purchased()
    {
        if (PlayerPrefs.GetInt(ActiveItem.exchangeType.ToString()) <= ActiveItem.Price)
        {
            isPurchased= false;
            return;
        }
      
        ActiveItem.ActiveObject.SetActive(true);
        ActiveItem.NonActiveObject.SetActive(false);
        isPurchased = true;
        managerMecanique.DecrementHandler(ActiveItem.exchangeType, ActiveItem.Price);
    }
}
[System.Serializable]
public class ShopItem
{
    public GameObject ActiveObject;
    public GameObject NonActiveObject;
    public int Price;
    public  ShopItemType exchangeType; // "Coins" or "Gems"
}