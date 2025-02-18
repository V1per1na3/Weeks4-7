using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class whitePoopSpawner : MonoBehaviour
{
    public GameObject prefab;
    public List<GameObject> whitepoop;
    public Transform bird;//need a transofrm to pass the transform of bird so it can spawn at bird position
    // Start is called before the first frame update
    void Start()
    {
        whitepoop = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnthepoop()
    {
        Vector3 pos = bird.position;
        pos.z = 0;
        GameObject newpoop = Instantiate(prefab, pos, Quaternion.identity);
        whitepoop.Add(newpoop);
        whitepoopMovement wm = newpoop.GetComponent<whitepoopMovement>();
        wm.spawner = this;
        wm.poop = true;
        Destroy(newpoop, 2);
    }
}
