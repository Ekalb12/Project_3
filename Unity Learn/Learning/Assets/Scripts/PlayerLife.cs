using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{

    [SerializeField] Text DeathTracker;
    static int lives = 3;
    bool dead = false; // sets dead to false
    bool deader = false;

    private void Start()
    {       
       
    }

    private void Update()
    {
        if (transform.position.y < -2f && !dead && !deader) // checks if y position is less than -2 and dead = false
        {                                        // if not checking for dead, executes multiple times
            Die();
        } 
    }
    void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.CompareTag("Enemy Body"))
        {
        
            Die();
        }
    }

    void Die()
    {

       GetComponent<MeshRenderer>().enabled = false;// makes character invisible 
       GetComponent<Rigidbody>().isKinematic = true; // makes character not affected by environment
       GetComponent<PlayerMovement>().enabled = false; // makes character not affected by user input

        dead = true; // sets dead to true
        
       

        if (lives == 1) // stops reloading level if lives go to 0
        {
            Invoke(nameof(Deadest), 0.5f);
            deader = true;
        }
        else
        {
            Invoke(nameof(ReloadLevel), 1.3f); // reloads level after 1.3 seconds
            lives -= 1;
            deader = false;
        }
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("RELOAD");
    }
    void Deadest()
    {
        DeathTracker.text = "Dead";
    }

}
