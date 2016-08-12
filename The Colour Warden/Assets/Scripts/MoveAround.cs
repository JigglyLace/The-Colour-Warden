using UnityEngine;
using System.Collections;

public class MoveAround : MonoBehaviour
{
    public Transform Waypoint1, Waypoint2, Waypoint3;

    private int currentWaypointTarget = 1;

	// Update is called once per frame
	void Update ()
    {
	    if(currentWaypointTarget == 1)
        {
            if (Vector3.Distance(transform.position, Waypoint1.position) > 1)
                transform.position = Vector3.Slerp(transform.position, Waypoint1.position, Time.deltaTime); // Don't actually use delta time, not proper
            else
                currentWaypointTarget = 2;
        }
        else if(currentWaypointTarget == 2)
        {
            if (Vector3.Distance(transform.position, Waypoint2.position) > 1)
                transform.position = Vector3.Slerp(transform.position, Waypoint2.position, Time.deltaTime); // Don't actually use delta time, not proper
            else
                currentWaypointTarget = 3;
        }
        else
        {
            if (Vector3.Distance(transform.position, Waypoint3.position) > 1)
                transform.position = Vector3.Slerp(transform.position, Waypoint3.position, Time.deltaTime); // Don't actually use delta time, not proper
            else
                currentWaypointTarget = 1;
        }
	}
}
