using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public TextMeshProUGUI gameover;
    public TextMeshProUGUI pressbutton;
    public GameManager gm;
    public CircleCollider2D circleCollider;
    public static event System.Action OnPlayerDeath;

    private void OnEnable()
    {
        GameManager.OnGameStart += StartOver;
    }
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
            if(HP > 0) {
                hpBar.value = (HP + 0f) / HPMax;
            } else
            {
                hpBar.value = 0;
                gameover.enabled = true;
                pressbutton.enabled = true;
                circleCollider.enabled = false;
                OnPlayerDeath?.Invoke();
                //gm.currentStage = GameManager.Stage.gameOver;
            }
            
            shake.StartShake(shakeDuration, shakeStrenght, true);
        }
    }
    public void StartOver()
    {
        HideGameOverScreen();
        circleCollider.enabled = true;
        HP = HPMax;
        hpBar.value = 1f;
        
    }
    public void HideGameOverScreen()
    {
        gameover.enabled = false;
        pressbutton.enabled = false;
    }
}
