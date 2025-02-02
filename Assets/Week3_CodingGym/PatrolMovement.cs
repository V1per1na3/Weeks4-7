using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMovement : MonoBehaviour
{
    public List<Transform>waypoints;
    [Range(0, 1)]
    public float t;
    public AnimationCurve curve;
    int currentwaypoint;
    int nextwaypoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        t += Time.deltaTime;
        if (t > 1)
        {
            t = 0;
            currentwaypoint = nextwaypoint;//goes to next way point
            nextwaypoint = (nextwaypoint + 1)%waypoints.Count;//loops from 0-3
 
        }
        pos = Vector2.Lerp(waypoints[currentwaypoint].position, waypoints[nextwaypoint].position, curve.Evaluate(t));
        transform.position = pos;
    }
}
