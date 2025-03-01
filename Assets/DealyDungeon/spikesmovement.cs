using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikesmovement : MonoBehaviour
{
    SpriteRenderer sr;
    public float speed = 5f;
    public spikeSpawner spawner;//this is the spawner
    public bool outside = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        dropspike();

    }

    public void dropspike()
    {
        Vector2 pos = transform.position;
        Vector2 screenpos = Camera.main.WorldToScreenPoint(pos);
        pos.y -= speed * Time.deltaTime;//falls down at y axis
        transform.position = pos;

        //check if spike run outside of screen
        if (screenpos.y < 0)
        {
            outside = true;
        }
        else
        {
            outside = false;
        }
    }
    

}
