using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public List<GameObject> things;
    public float interval;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = interval;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            GameObject thing = Instantiate(things[Random.Range(0, things.Count)]);
            thing.transform.position = new Vector3(transform.position.x, transform.position.y, Random.Range(2f, 10f));
            timer = interval;
        }
    }
}
