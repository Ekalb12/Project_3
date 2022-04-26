using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player") // checks if collided game object has name player
        {
            Destroy(gameObject);
            Debug.Log("Teleport");
            collision.gameObject.transform.Rotate(0, 180, 0);
            collision.gameObject.GetComponent<PlayerMovement>().Backwards = true;
        }
    }
}
