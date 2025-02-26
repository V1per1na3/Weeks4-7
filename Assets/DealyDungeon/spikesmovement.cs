using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikesmovement : MonoBehaviour
{
    SpriteRenderer sr;
    public float speed = 5f;
    public spikeSpawner spawner;//this is the spawner
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
        pos.y -= speed * Time.deltaTime;//falls down at y axis
        transform.position = pos;
    }

}
