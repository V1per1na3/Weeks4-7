using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimmingmouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        //get mouse position
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //aim to mouse
        transform.right = pos - mouse;
    }
}
