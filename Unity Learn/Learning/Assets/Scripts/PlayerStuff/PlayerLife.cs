using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{


    static int lives = 3;
    bool dead = false; // sets dead to false
    int Deadest;
    bool GameLost = false;

    private void Start()
    {
        dead = false;
        Debug.Log("Respawn Lives " + lives);
        EventManager.OnDeathTriggered?.Invoke(lives);
    }

    private void Update()
    {
        if (Input.GetKeyDown("x") || transform.position.y < -2f && !dead) // checks if y position is less than -2 and dead = false
        {                                        // if not checking for dead, executes multiple times
            Die();
        }
        if (Input.GetKeyDown("r"))
        {
            ReloadLevel();
            lives = 3;

        }
    }
    void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.CompareTag("Enemy Body"))
        {

            Die();
        }
    }

    public void Die()
    {
        if (GameLost != true)
        {
            GetComponent<MeshRenderer>().enabled = false;// makes character invisible 
            GetComponent<Rigidbody>().isKinematic = true; // makes character not affected by environment
            GetComponent<PlayerMovement>().enabled = false; // makes character not affected by user input

            dead = true; // sets dead to true


            if (lives == 1)
            {
                Invoke(nameof(GameOver), 1f);
                GameLost = true;
            }
            else
            {
                Invoke(nameof(ReloadLevel), 1.3f); // reloads level after 1.3 seconds
            }
            lives -= 1;
            EventManager.OnDeathTriggered?.Invoke(lives);
        }
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("RELOAD");
        
    }

    void GameOver()
    {
        EventManager.OnGameOverTriggered?.Invoke(Deadest);
    }
}
