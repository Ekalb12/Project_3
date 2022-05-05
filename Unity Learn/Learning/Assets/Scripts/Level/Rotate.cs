using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float SpeedX;
    public float SpeedY;
    public float SpeedZ;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(360 * SpeedX * Time.deltaTime, 360 * SpeedY * Time.deltaTime, 360 * SpeedZ * Time.deltaTime);
    }
}
