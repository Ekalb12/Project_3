using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecificWall : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "SpecificWall")
        {
            Phase();
            Debug.Log("Phase");
            Invoke(nameof(unphase), .5f);
        }
    }
    
    private void Phase()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void unphase()
    {
        GetComponent<Collider>().isTrigger = false;
        Debug.Log("unphase");
    }
}
