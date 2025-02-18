using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackCarSpawner : MonoBehaviour
{
    public GameObject prefab;
    public List<GameObject> blackcars;
    float spawntimer;
    // Start is called before the first frame update
    void Start()
    {
        //a list to store spawned black car
        blackcars = new List<GameObject>();
        spawntimer = Random.Range(3, 5);//make a timer for spawner so car spawn at random time between 3,5s
    }

    // Update is called once per frame
    void Update()
    {
        spawntimer -= Time.deltaTime;//countdown timer

        if (spawntimer <= 0)//if timer countdown to 0 spawn a black car
        {
            spawnit();//call spawn function
            spawntimer = Random.Range(3, 5);//reset timer
        }
        goaway();//call destroy function
    }

    void spawnit()
    {
        //x of spawn position is right of screen
        float spawnx = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        //y of spawn position is bottom of screen
        float spawny = Camera.main.ScreenToWorldPoint(new Vector3(0, 20, 0)).y;
        Vector2 pos = new Vector2(spawnx, spawny);//start from left with fixed height
        GameObject newcar = Instantiate(prefab, pos, Quaternion.identity);//spawn blackcar at set position
        blackcars.Add(newcar);//add to list
    }

    void goaway()
    {
        //loop through the list and see if any black car are ouside of screen
        for (int i = blackcars.Count - 1; i >= 0; i--)
        {
            //regirstration so i can get stuff from the black car script
            BlackCarMovement bc = blackcars[i].GetComponent<BlackCarMovement>();
            bc.spawner = this;
            if (bc.outside)//if car is outside of screen...
            {
                Destroy(blackcars[i]);//destory instainly
                blackcars.Remove(blackcars[i]);//remove it from list
            }
        }
    }
}
