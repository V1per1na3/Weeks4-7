using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playermovmeent : MonoBehaviour
{
    public spikeSpawner sk;
    SpriteRenderer sr;
    public float speed =2f;
    public bool gothit = false;
    public float health;
    public Slider hpvisual;
    public float max = 5;
    public float min = 0f;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        hpvisual.minValue = 0;
        hpvisual.maxValue = 5;
        hpvisual.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            health = 5;
            hpvisual.value = health;
        }
        //this is for player movement and ctrl
        //plyaer goes left and right with input keycode A & D
        Vector2 pos = transform.position;
        Vector2 screenpos = Camera.main.WorldToScreenPoint(pos);
        ///////////////////////////////
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += Time.deltaTime * speed;
        }
        /////check boundary//////
        float halfwidth = sr.bounds.extents.x;
        if (screenpos.x <= 0)
        {
            pos.x = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x + halfwidth;

        }
        if (screenpos.x >= Screen.width)
        {
            pos.x = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x - halfwidth;
        }
        transform.position = pos;
        ouch();
        takedamage(1);

    }

    public void ouch()
    {
        if (!gothit)
        {
            //check if player overlap with spikes
            for (int i = sk.spikes.Count - 1; i >= 0; i--)//loop throught the spawned list of spikes
            {
                GameObject sp = sk.spikes[i];
                if (sr.bounds.Contains(sp.transform.position))
                {
                    gothit = true;
                    Destroy(sk.spikes[i]);
                    sk.spikes.Remove(sk.spikes[i]);
                }
            }
        }
        else
        {
            gothit = false;
        }

    }

    public void takedamage(float damage)
    {
        //function for hp slider
        if (gothit)//if player got hit...
        {
            health -= damage;//takes the damage 
            hpvisual.value = health;//update healh
            if (health <= hpvisual.minValue)
            {
                health = min;//prevent it goes to negative health
            }
            gothit = false;
        }
    }

}
