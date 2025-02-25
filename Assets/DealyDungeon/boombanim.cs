using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class boombanim : MonoBehaviour
{
    public float speed = 1f;
    public AnimationCurve curve;
    [Range(0, 1)]
    public float t;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 huhoh = transform.localScale;

        t += Time.deltaTime * speed;
        if (t > 1)//form a anim cycle
        {
            t = 0;
        }
        huhoh = Vector2.one * curve.Evaluate(t);//apply anim curve to scale base on duration of t
        transform.localScale = huhoh;
    }
}
