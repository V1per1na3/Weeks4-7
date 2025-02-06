using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public bool hasBeenFired = false;
    // Start is called before the first frame update
    void Start()
    {
        pointatmouse();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasBeenFired)
        {
            movment();
        }

    }

    void pointatmouse()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        Vector2 dir = mouse - transform.position;
        transform.up = dir;
    }

    void movment()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
