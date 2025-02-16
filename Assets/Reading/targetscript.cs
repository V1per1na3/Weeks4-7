using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetscript : MonoBehaviour
{
    public float speed = 1;
    public SpriteRenderer sr;
    public AnimationCurve dis;
    public Color c;
    float t;
    bool isDead;
    public TargetSpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        Vector2 screenpos = Camera.main.WorldToScreenPoint(pos);
        pos.x += speed * Time.deltaTime;

        if (screenpos.x < 0)
        {
            speed *= -1;
            pos.x = Camera.main.ScreenToWorldPoint(new Vector2(0,0)).x;
                
        }

        if(screenpos.x > Screen.width)
        {
            speed *= -1;
            pos.x = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
        }

        transform.position = pos;

        if (Input.GetMouseButton(0))
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (sr.bounds.Contains(mousepos))
            {
                sr.color = c;
                isDead = true;

                Destroy(gameObject, 1);
                spawner.targethit(gameObject);
            }
        }

        if (isDead)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.one * dis.Evaluate(t);
        }
    }
}
