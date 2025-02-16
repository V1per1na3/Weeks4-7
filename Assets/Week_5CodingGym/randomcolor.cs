using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomcolor : MonoBehaviour
{
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changecolor()
    {
        sr.color = Random.ColorHSV();
    }

    public void spinnnn()
    {
        Vector3 rot = transform.eulerAngles;
        rot.z +=60;
        transform.eulerAngles = rot;

    }
}
