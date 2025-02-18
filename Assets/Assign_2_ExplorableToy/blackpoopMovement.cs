using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackpoopMovement : MonoBehaviour
{
    public float speed = 8f;
    public bool poop = false;
    public blackPoopSpawner spawner;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (poop)
        {
            dropPoop();
        }
    }

    public void dropPoop()
    {
        Vector2 pos = transform.position;
        pos.y -= speed * Time.deltaTime;
        transform.position = pos;
    }
}
