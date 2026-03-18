using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollwer : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currenWaypointIndex = 0;

    [SerializeField] float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(waypoints[currenWaypointIndex].transform.position, transform.position) < .1f)
        {
            currenWaypointIndex++;
            if (currenWaypointIndex >= waypoints.Length)
            {
                currenWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position,
                             waypoints[currenWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
