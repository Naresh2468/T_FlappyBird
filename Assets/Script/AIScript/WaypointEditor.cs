using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad()]
public class WaypointEditor 
{
    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
    public static  void OnDrawSceneGizmos(Waypoint waypoint,GizmoType gizmoType)
    {
        if ((gizmoType & GizmoType.Selected) != 0 )
        {
            Gizmos.color = Color.green;            
        }
        else
        {
            Gizmos.color = Color.green * 0.5f;
        }
        Gizmos.DrawSphere(waypoint.transform.position , 0.15f);

        Gizmos.color = Color.white; // draw a line previous to next waypoint 
        Gizmos.DrawLine(waypoint.transform.position + (waypoint.transform.right * waypoint.waypointWidth / 2f), waypoint.transform.position - (waypoint.transform.right * waypoint.waypointWidth / 2f));

        if (waypoint.previousWaypoint != null)
        {
            Gizmos.color = Color.red;
            Vector3 offset = waypoint.transform.right  * waypoint.waypointWidth / 2f;
            Vector3 offsetTo = waypoint.previousWaypoint.transform.right  * waypoint.previousWaypoint.waypointWidth / 2f;

            Gizmos.DrawLine(waypoint.transform.position + offset , waypoint.previousWaypoint.transform.position + offsetTo);

        }
        if (waypoint.previousWaypoint != null)
        {
            Gizmos.color = Color.green;
            Vector3 offset = waypoint.transform.right  * -waypoint.waypointWidth / 2f;
            Vector3 offsetTo = waypoint.previousWaypoint.transform.right * -waypoint.previousWaypoint.waypointWidth / 2f;

            Gizmos.DrawLine(waypoint.transform.position + offset , waypoint.previousWaypoint.transform.position + offsetTo);


        }
    }

}
