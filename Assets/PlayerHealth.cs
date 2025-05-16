using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int HP;
    public int HPMax;
    public Shake shake;
    public float shakeDuration;
    public float shakeStrenght;
    public Slider hpBar;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "EnemyBullet")
        {
            HP = HP - collision.gameObject.GetComponent<bullet>().damage;
            if(HP >= 0) {
                hpBar.value = (HP + 0f) / HPMax;
            }
            
            shake.StartShake(shakeDuration, shakeStrenght, true);
        }
    }
}
