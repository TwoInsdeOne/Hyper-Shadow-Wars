using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shake : MonoBehaviour
{
    public float timer;
    public float str;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            
            transform.position = new Vector3(Random.Range(-str, str), Random.Range(-str, str), 0);
            timer -= Time.deltaTime;
        } else
        {
            Gamepad.current.SetMotorSpeeds(0, 0);
            transform.position = new Vector3(0, 0, 0);
        }
    }
    public void StartShake(float duration, float strenght)
    {
        Gamepad.current.SetMotorSpeeds(0.3f, 0.3f);
        timer = duration;
        str = strenght;
    }
}
