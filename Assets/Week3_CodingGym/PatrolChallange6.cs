using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PatrolChallange6 : MonoBehaviour
{
    public Transform prefabs;
    public List<Transform> waylists;
    public Transform closets;//use to store closets way point
    float Closestdist;//use to store closest distance
    public AnimationCurve curve;
    int currentwaypoint;
    int nextwaypoint;
    [Range(0, 1)]
    public float t;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //get mouse pos
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))//spawn prefabs if left click
        {
            Transform newwaylist = Instantiate(prefabs, mouse, Quaternion.identity);
            waylists.Add(newwaylist);//add to list
        }

        if (waylists.Count > 0)//if there something in the list
        {
            closets = waylists[0];//the first one I just spawn is the closest
            Closestdist = Vector2.Distance(mouse, closets.position);//calculate dis
            //go thr all waypoints and update the closest way point
            for (int i = 0; i < waylists.Count; i++)
            {
                Transform currentwaypoint = waylists[i];
                float currentDis = Vector2.Distance(mouse, currentwaypoint.position);//calculate the current prefab/mouse dis
                if (currentDis < Closestdist)//compare
                {
                    closets = currentwaypoint;//now this is the closest way point
                    Closestdist = currentDis;//update closest dis
                }
            }
            movment();//start to move!
        }

        if (Input.GetMouseButtonDown(1))//destroy if right click
        {

            Destroy(closets.gameObject);//destroy closest way point
            waylists.Remove(closets);//delete closest way point from list
        }

    }
    void movment()
    {
        Vector2 pos = transform.position;
        t += Time.deltaTime;
        if (t > 1)
        {
            t = 0;
            currentwaypoint = nextwaypoint;//update currentpoint and next point
            nextwaypoint = (nextwaypoint + 1) % waylists.Count;//loop thr the list
        }
        if (currentwaypoint >= waylists.Count || nextwaypoint >= waylists.Count)//reset to 0 if current&nextwaypoint exceed length of list
        {
            currentwaypoint = 0;
            nextwaypoint = 0;

        }
        //lerp with animcurve
        pos = Vector2.Lerp(waylists[currentwaypoint].position, waylists[nextwaypoint].position, curve.Evaluate(t));
        transform.position = pos;
    }
}
