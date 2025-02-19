using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class whiteCarSpawner : MonoBehaviour
{
    public GameObject prefab;
    public List<GameObject> whitecars;
    float spawntimer;
    // Start is called before the first frame update
    void Start()
    {
        //a list to store spawned white car
        whitecars = new List<GameObject>();
        spawntimer = Random.Range(1, 3);//make a timer for spawner so car spawn at random time between 3,5s

    }

    // Update is called once per frame
    void Update()
    {

        spawntimer -= Time.deltaTime;//countdown timer

        if (spawntimer <= 0)//if timer countdown to 0 spawn a white car
        {
            spawnit();//call spawn function
            spawntimer = Random.Range(1, 3);//reset timer
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
        GameObject newcar = Instantiate(prefab, pos, Quaternion.identity);//spawn white car at set position
        whitecars.Add(newcar);//add to list
    }

    void goaway()
    {
        //loop through the list and see if any white car are ouside of screen
        for (int i = whitecars.Count - 1; i >= 0; i--)
        {
            //regirstration so i can get stuff from the white car script
            WhiteCarMovement wc = whitecars[i].GetComponent<WhiteCarMovement>();
            wc.spawner = this;
            if (wc.outside)//if car is outside of screen...
            {
                Destroy(whitecars[i]);//destory instainly
                whitecars.Remove(whitecars[i]);//remove it from list
            }
        }
    }
}

