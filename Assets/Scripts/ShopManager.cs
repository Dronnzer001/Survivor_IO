using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public ManagerMecanique Mecanique;

    public Button btn0;
    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;
    public Button btn5;

    public void Geems()
    {
        Mecanique.GemsInt = Mecanique.GemsInt +10;
        btn0.interactable = false;
    }
    public void WeaponDesign()
    {
      
        if (ShopContent.isPurchased == true)
        {
            btn1.interactable = false;
            ShopContent.isPurchased = false;
        }
       /* if (Mecanique.CoinsInt > 400)
        {
            Mecanique.CoinsInt -= 400;
           btn1.interactable = false;
        }*/
    }
    public void BonePendant()
    {
       
        btn2.interactable = false;
        Mecanique.CoinsInt = Mecanique.CoinsInt + 30;
    }
    public void BoneM()
    {
        if (ShopContent.isPurchased == true)
        {
            btn3.interactable = false;
            ShopContent.isPurchased = false;
        }
      
    }
    public void ClothingDesign()
    {
        if (ShopContent.isPurchased == true)
        {
            btn4.interactable = false;
            ShopContent.isPurchased = false;
        }
     
    }
    public void ShoesDesign()
    {
        btn5.interactable = false;
    }
}
public enum ShopItemType
{
    coins,
    gems,
    flash
}
