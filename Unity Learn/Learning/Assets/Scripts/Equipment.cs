using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Equipment : MonoBehaviour
{

    private void Update()
    {
        if (GetComponentInParent<Rigidbody>().isKinematic == true) // checks if y position is less than -2 and dead = false
        {                                        // if not checking for dead, executes multiple times
            Die();
        }
    }
    void Die()
    {

        GetComponent<MeshRenderer>().enabled = false;// makes character invisible
    }

}
