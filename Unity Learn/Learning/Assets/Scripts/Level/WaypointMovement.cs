using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints; // Array of waypoints
    int currentWayPointIndex = 0; // What waypoint moving towards

    public float speed = 1f; // speed of platform

    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWayPointIndex].transform.position) < .1f) // checks when the platform is .1f away from the waypoints
        {
            currentWayPointIndex++; // increases waypoint index
            if (currentWayPointIndex >= waypoints.Length) // checks if at last waypoint
            {
                currentWayPointIndex = 0; // resets index to 0
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWayPointIndex].transform.position, speed * Time.deltaTime);
    }
}
