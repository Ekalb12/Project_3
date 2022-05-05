using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    public bool XpGain;
    int XpToLevel = 5;
    public int CurrentXpToLevel;
    int Level = 0;
    public int CurrentLevel;
   // int XPVariation;

    // Start is called before the first frame update
    void Start()
    {
        CurrentXpToLevel = XpToLevel;
        CurrentLevel = Level;
    }

    // Update is called once per frame
    void Update()
    {
        if (XpGain == true || Input.GetKeyDown("x"))
        {
            XpGain = false;
            CurrentXpToLevel -= 1; 
                        
        }
        if (CurrentXpToLevel == 0)
        {

            CurrentLevel += 1;
            XpToLevel += CurrentLevel;

            if (CurrentLevel > 3)
                 
            {
             //   XPVariation = Random.Range(-1, -3);
               // XpToLevel -= (CurrentLevel + XPVariation);
            }


            CurrentXpToLevel = XpToLevel;

            gameObject.GetComponent<PlayerMovement>().LevelUp = true;

            
        }

       

    }

}
