using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectToLevel : MonoBehaviour
{
    // Start is called before the first frame update
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player") // checks if collided game object has name player
        {
            Destroy(gameObject);
            Debug.Log("Collect xp");
            collision.gameObject.GetComponent<LevelUp>().XpGain = true;
        }
    }
}
