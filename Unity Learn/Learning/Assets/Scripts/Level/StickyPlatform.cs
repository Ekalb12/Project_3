using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player") // checks if collided game object has name player
        {
            collision.gameObject.transform.SetParent(transform); // sets the player to be a child of platform
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        { 
            collision.gameObject.transform.SetParent(null); // makes the player no longer child of the platformz
        }
    }
}
