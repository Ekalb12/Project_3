using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    int CoinCount = 0;
    bool Collected = false;




    private void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.CompareTag("Coin") && Collected != true) // checks if collided game object has name player
        {
            Collected = true;

            CoinCount++;
            EventManager.OnCoinsCollected?.Invoke(CoinCount);   // ? = checks if not null

            Destroy(Other.gameObject);
            GetComponent<LevelUp>().XpGain = true;

            Invoke(nameof(CoinDestroy), 0.01f);
        }
    }

    void CoinDestroy()
    {

        Collected = false;
    }
}
