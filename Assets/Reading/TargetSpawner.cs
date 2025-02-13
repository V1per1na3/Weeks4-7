using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public int howmanytarget = 5;
    public List<GameObject> targets;
    public SpriteRenderer vs;
    public GameObject victoryshowup;


    // Start is called before the first frame update
    void Start()

    {
        vs.enabled = false;//just the spriterenderer
        victoryshowup.SetActive(false);//turn off whole game objec

        targets = new List<GameObject>();

        for(int i =0; i < howmanytarget; i++)
        {
            GameObject newtarget = Instantiate(targetPrefab);
            newtarget.transform.position = Random.insideUnitCircle * 5;

            targetscript t = newtarget.GetComponent<targetscript>();
            t.spawner = this;
            targets.Add(newtarget);
        }
    }

    public void targethit(GameObject t)
    {
        targets.Remove(t);
    }

    // Update is called once per frame
    void Update()
    {
        if(targets.Count == 0)
        {
            vs.enabled = true;//just the spriterenderer
            victoryshowup.SetActive(true);//turn on whole game object
        }
    }
}
