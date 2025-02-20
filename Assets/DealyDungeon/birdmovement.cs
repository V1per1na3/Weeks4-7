using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class birdmovement : MonoBehaviour
{
    public playermovmeent player;
    SpriteRenderer sr;
    public float speed=1f;
    public bool runaway = false;
    float timer = 0;
    float timeCount = 3;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        Debug.Log(player.transform.position+"player");
        Debug.Log(sr.bounds+"bird");
        closeenough();
        transform.position=pos;
    }


    void closeenough()
    {
        Vector2 pos = transform.position;
        if (sr.bounds.Contains(player.transform.position))
        {
            Debug.Log(runaway);
            runaway = true;
        }
        
        if (runaway)
        {
            speed = Random.Range(-5, 5);
            pos.x += speed * Time.deltaTime;
            //timer = timeCount;
            //timer -= Time.deltaTime;
            //if (timer <= 0)
            //{
                //runaway = false;
                //timer = timeCount;
            //}
        }


        transform.position = pos;
    }
}
