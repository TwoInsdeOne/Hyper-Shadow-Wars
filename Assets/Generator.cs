using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public List<GameObject> things;
    public float interval;
    private float timer;
    public float start;
    private float timer2;
    public float randomY;
    public float randomZmin;
    public float randomZmax;
    public bool generating;
    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += StopGenerating;
        GameManager.OnGameStart += StartGenerating;
    }
    private void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= StopGenerating;
        GameManager.OnGameStart -= StartGenerating;
    }
    // Start is called before the first frame update
    void Start()
    {
        timer = interval;
        generating = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (generating)
        {
            timer2 += Time.deltaTime;
            timer -= Time.deltaTime;
            if (timer <= 0 && timer2 > start)
            {
                GameObject thing = Instantiate(things[Random.Range(0, things.Count)]);
                thing.transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(-randomY, randomY), Random.Range(-randomZmin, randomZmax));
                timer = interval;
            }
        }
        
    }
    public void StopGenerating()
    {
        generating = false;
    }
    public void StartGenerating()
    {
        generating = true;
    }
}
