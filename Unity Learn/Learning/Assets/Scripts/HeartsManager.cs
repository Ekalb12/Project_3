using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsManager : MonoBehaviour
{
    public GameObject[] Hearts;
    public Text Deathtrackertxt;
    public Text RestartOption;
    
    void start()
    {
       
    }

    private void OnEnable()
    {
        EventManager.OnDeathTriggered += TakeDamage;
        EventManager.OnGameOverTriggered += Lose;
    }

    private void OnDisable()
    {
        EventManager.OnDeathTriggered -= TakeDamage;
        EventManager.OnGameOverTriggered -= Lose;
    }

    private void TakeDamage(int lives)
    {
        if(lives < 3)
        {
            Destroy(Hearts[lives].gameObject);
            if(lives == 1)
            { 
                Destroy(Hearts[lives + 1].gameObject);
            }
            Debug.Log("Lives left " + lives);
        }
        
    }

    private void Lose(int Deadest)
    {
        Deathtrackertxt.text = "DEAD";
        RestartOption.text = "Press " +"r" +" to Restart";
    }
}
