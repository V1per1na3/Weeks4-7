using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class challenge8S : MonoBehaviour
{
    public GameObject prefabs;
    public List<GameObject> burgers;
    public float offset = 0.5f;
    public bool ismouseoverB=false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newburger = Instantiate(prefabs, mouse, Quaternion.identity);
            burgers.Add(newburger);
            newburger.GetComponent<burgerTrans>().speed = Random.Range(1f, 5f);
            newburger.GetComponent<burgerTrans>().sp.color = Random.ColorHSV();
            newburger.transform.localScale = Vector3.one * Random.Range(0.5f, 1.5f);
        }

        if (Input.GetMouseButtonDown(1))
        {

            for (int i = 0; i < burgers.Count; i++)
            {
                Vector2 pos = burgers[i].transform.localPosition;
                if (mouse.x >= pos.x - offset && mouse.x <= pos.x + offset && mouse.y >= pos.y - offset && mouse.y <= pos.y + offset)
                {
                    
                    Destroy(burgers[i]);
                    burgers.Remove(burgers[i]);
                }

            }
            
        }

        
    }
}
