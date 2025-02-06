using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class trickshotmove : MonoBehaviour
{
    public float speed=1f;
    public float yspeed = 3f;
    public float rotspeed = 2f;
    public AnimationCurve curve;
    public AnimationCurve rotcurve;
    bool isjumping;
    [Range(0, 1)]
    public float e;
    [Range(0,1)]
    public float t;
    
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        
    }

    void movement()
    {
        Vector2 pos = transform.position;
        Vector3 rot = transform.eulerAngles;
        pos.x += Time.deltaTime * speed;
        Vector2 screenpos = Camera.main.WorldToScreenPoint(pos);
        if (screenpos.x < 0)
        {
            Vector2 fixpos = new Vector2(0, 0);
            speed *= -1;
        }
        if (screenpos.x > Screen.width)
        {
            Vector2 fixpos = new Vector2(Screen.width, 0);
            speed *= -1;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isjumping = true;
        }
        if (isjumping)
        {
            t += Time.deltaTime ;
            e += Time.deltaTime ;
            if (t > 1 && e >1)
            {
                t = 0;
                e = 0;
                isjumping = false;
            }
        }
        rot.z = rotspeed* rotcurve.Evaluate(e);
        pos.y = yspeed *curve.Evaluate(t);
        transform.eulerAngles = rot;
        transform.position = pos;
    }
}
