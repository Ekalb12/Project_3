using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    int Coins = 0;
    [SerializeField] Text CoinsText;
    bool Collected = false;

    

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.CompareTag ("Coin") && Collected != true) // checks if collided game object has name player
        {
            Collected = true;
            Destroy(Other.gameObject);
            Debug.Log("Collect xp");
            GetComponent<LevelUp>().XpGain = true;
            Invoke(nameof(CoinUI),0.01f);
        }
    }

    void CoinUI()
    {
        Coins = Coins + 1;
        CoinsText.text = "Coins: " + Coins;
        Collected = false;
    }
}
