using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class BulletSpawner : MonoBehaviour
{
    public GameObject prefabs;
    public Bullet bullet;
    public Transform follow;
    public List<GameObject> newthings;
    // Start is called before the first frame update
    void Start()
    {
        newthings = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && bullet ==null)
        {
            fire();
        }
    }

    void fire()
    {
        Vector3 pos = follow.position;
        GameObject spawnbullet = Instantiate(prefabs, pos, Quaternion.identity);
        newthings.Add(spawnbullet);
        bullet = spawnbullet.GetComponent<Bullet>();
        bullet.hasBeenFired = true;
        bullet = null;
        Destroy(spawnbullet, 1);
    }
}
