using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    public static AdsManager Ads;
    private UIManager uIManager;
    private ManagerMecanique managerMecanique;
    private void Start()
    {
        uIManager = FindAnyObjectByType<UIManager>();
        managerMecanique = FindAnyObjectByType<ManagerMecanique>();
    }
    public void Showintertitial()
    {
        Advertisements.Instance.ShowInterstitial();
    }
    public void ShowrewardVideo()
    {
        Advertisements.Instance.ShowRewardedVideo(CompleteMethod);
        void CompleteMethod(bool completed, string advertiser)
        {
            Debug.Log("Closed rewarded from: " + advertiser + " -> Completed " + completed);
            if (completed == true)
            {
                //give the reward
            }
            else
            {
                //no reward
            }
        }
    }
    public void AddGems(int gems)
    {
        int gemsValue = PlayerPrefs.GetInt("gems") + gems;
        managerMecanique.GemsInt = gemsValue;
        PlayerPrefs.SetInt("gems", managerMecanique.GemsInt);
    }
    public void AddCoins(int coins)
    {
        int coinsValue = PlayerPrefs.GetInt("coins") + coins;
        managerMecanique.CoinsInt = coinsValue;
        PlayerPrefs.SetInt("coins", managerMecanique.CoinsInt);
    }
    public void AddFlash(int flash)
    {  
        if(PlayerPrefs.GetInt("flash") >= 100)
        {
            return;
        }
        int flashValue = PlayerPrefs.GetInt("flash") + flash;
        managerMecanique.FlashInt = flashValue;
        PlayerPrefs.SetInt("flash", managerMecanique.FlashInt);
    }
}
