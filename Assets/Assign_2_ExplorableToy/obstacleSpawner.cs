using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawner : MonoBehaviour
{
    //this script is to create a spawner to spawn the obstacles.
    //spawner will have a timer that spawn obstacle at random time countdown.
    //spawner will also destroy the obstacle that exceed left of screen.
    //since I have a bool that checks this condition in obstacle's script, I will need to register the script too.
    public GameObject prefab;
    public List<GameObject> obstacles;
    float spawntimer;
    // Start is called before the first frame update
    void Start()
    {
        //a list to store spawned obstacles
        obstacles = new List<GameObject>();
        spawntimer = Random.Range(1, 3);//make a timer for spawner so obstacle spawn at random time between 1,4s
        
    }

    // Update is called once per frame
    void Update()
    {

        spawntimer -= Time.deltaTime;//countdown timer
       
        if (spawntimer <= 0)//if timer countdown to 0 spawn an obstacle
        {
            spawnit();//call spawn function
            spawntimer = Random.Range(1, 4);//reset timer
        }
        goaway();//call destroy function
    }

    void spawnit()
    {
        //x of spawn position is right of screen
        float spawnx = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        //y of spawn position is random range in the upper half screen.
        float spawny = Camera.main.ScreenToWorldPoint(new Vector3 (0,Screen.height - Random.Range(0, Screen.height/2),0)).y;
        Vector2 pos = new Vector2(spawnx, spawny);//start from right with random height (upper half screen)
        GameObject newobs = Instantiate(prefab, pos, Quaternion.identity);//spawn obstacle at set position
        obstacles.Add(newobs);//add to list
    }

    void goaway()
    {
        //loop through the list and see if any obstacles are ouside of screen
        for (int i = obstacles.Count - 1; i >= 0; i--)
        {
            //regirstration so i can get stuff from the obstaclescript
            obstaclemovement ob = obstacles[i].GetComponent<obstaclemovement>();
            ob.spawner = this;
            if (ob.outside)//if obstacle is outside of screen...
            {
                Destroy(obstacles[i]);//destory instainly
                obstacles.Remove(obstacles[i]);//remove it from list
            }
        }
    }
}
