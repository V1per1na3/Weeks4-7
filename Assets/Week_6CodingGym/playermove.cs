using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public float speed = 5f;
    public int dir = 1;
    SpriteRenderer sp;
    public carspawner carp;
    public bool gothit = false;
    public GameObject win;
    AudioSource audio;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        movement();
        collision();
        Debug.Log(gothit);
        victory();
    }

    void movement()
    {
        //move around the screen
        Vector2 pos = transform.position;
        Vector2 face = transform.localScale;//change sprite direction
        Vector2 sprite = sp.transform.position;
        //goleft
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= Time.deltaTime * speed;
            face.x = dir;
        }
        //goright
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += Time.deltaTime * speed;
            face.x = -dir;
        }
        //go up
        if (Input.GetKey(KeyCode.W))
        {
            pos.y += Time.deltaTime * speed;
            face.x = dir;
        }
        //go down
        if (Input.GetKey(KeyCode.S))
        {
            pos.y -= Time.deltaTime * speed;
            face.x = dir;
        }
        transform.position = pos;
        transform.localScale = face;
    }

    public void collision()
    {
        if (!gothit)
        {
            for (int i = 0; i < carp.cars.Count; i++)
            {
                GameObject newcar = carp.cars[i];
                if (sp.bounds.Contains(newcar.transform.position))
                {
                    gothit = true;
                }
            }
        }
        else
        {
            gothit = false;
        }
        

        if (gothit)
        {
            Vector2 pos = transform.position;
            pos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width/2, 0));
            transform.position = pos;
        }
    }

    public void victory()
    {
        Vector2 pos = transform.position;

        if(pos.y >= Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y)
        {
            win.SetActive(true);
            if (!audio.isPlaying)
            {
                audio.PlayOneShot(clip);
            }
        }
    }
    
    
}
