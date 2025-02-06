using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication;
using UnityEngine;
using UnityEngine.UI;

public class hp : MonoBehaviour
{
    public float health = 10;
    public Slider bar;
    public float max = 10;
    public float min = 0f;
    // Start is called before the first frame update
    void Start()
    {
        bar.minValue = 0;
        bar.maxValue = 10;
        bar.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            takedamage(1);
        }
    }

    public void takedamage(float damage)
    {
        health -= damage;
        bar.value = health;
        if (health <= bar.minValue)
        {
            health = min;
        }
        if (health >= bar.maxValue)
        {
            health = max;
        }
    }
}
