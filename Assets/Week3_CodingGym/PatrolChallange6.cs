using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PatrolChallange6 : MonoBehaviour
{
    public Transform prefabs;
    public List<Transform> waylists;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//spawn prefabs if left click
        {
            Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Transform newwaylist = Instantiate(prefabs, mouse, Quaternion.identity);
            waylists.Add(newwaylist);
        }
        if (Input.GetMouseButton(1))//destroy if right click
        {


        }

    }
}
