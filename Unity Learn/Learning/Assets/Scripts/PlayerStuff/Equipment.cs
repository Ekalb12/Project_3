using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Equipment : MonoBehaviour
{

    private void Update()
    {
        if (GetComponentInParent<Rigidbody>().isKinematic == true) // checks to see if parent is kinematic
        {
            Die();
        }
    }
    void Die()
    {

        GetComponent<MeshRenderer>().enabled = false;// makes objects invisible
    }

}
