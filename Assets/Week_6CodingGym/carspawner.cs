using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carspawner : MonoBehaviour
{
    public GameObject prefabs;
    public List<GameObject> cars;
    public int maxcars = 20;
    // Start is called before the first frame update
    void Start()
    {
        cars = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //only spawn this among of cars
        if(cars.Count< maxcars)
        {
            spawnit();
        }
    }

    void spawnit()
    {
        float spawnx = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0,Screen.width), 0, 0)).x;
        float spawny = Camera.main.ScreenToWorldPoint(new Vector3(0, Random.Range(0,Screen.height), 0)).y;
        Vector2 pos = new Vector2(spawnx, spawny);
        //spawn at this position
        GameObject newcars = Instantiate(prefabs, pos, Quaternion.identity);
        cars.Add(newcars);
        movingcar mc = newcars.GetComponent<movingcar>();
        mc.sp = this;//this is the car spawner
    }
}
