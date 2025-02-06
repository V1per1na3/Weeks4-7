using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burgerTrans : MonoBehaviour
{
    public float speed=2f;
    public SpriteRenderer sp;
    public challenge8S thingthatspawnme;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        Vector2 screenpos = Camera.main.WorldToScreenPoint(pos);
        if(screenpos.x < 0)
        {
            Vector2 fixedpos = new Vector2(0, 0);
            pos.x = Camera.main.ScreenToWorldPoint(fixedpos).x;
            speed *= -1;
        }
        if (screenpos.x > Screen.width)
        {
            Vector2 fixedpos = new Vector2(Screen.width, 0);
            pos.x = Camera.main.ScreenToWorldPoint(fixedpos).x;
            speed *= -1;

        }
        transform.position = pos;
       
    }
    
}
