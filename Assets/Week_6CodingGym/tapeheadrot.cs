using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class tapeheadrot : MonoBehaviour
{
    public float speed = 0f;
    public bool isrotating = false;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rot = transform.eulerAngles;
        isrotating = true;
        if (isrotating)
        {
            rot.z += speed * Time.deltaTime;
        }
        else
        {

        }

        transform.eulerAngles = rot;
    }

    public void rotationstart()
    {
        speed = 20f;
    }

    public void rotationend()
    {
        speed = 0f;
    }

}
