using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public Text CoinCounttxt;

    private void OnEnable()
    {
        EventManager.OnCoinsCollected += OnCoinCountUpdated;
    }
    private void OnDisable()
    {
        EventManager.OnCoinsCollected -= OnCoinCountUpdated;
    }

    private void OnCoinCountUpdated(int CoinCount)
    {
        CoinCounttxt.text = "Coins: " + CoinCount.ToString();
        Debug.Log("Collect xp");
        
    }

}
