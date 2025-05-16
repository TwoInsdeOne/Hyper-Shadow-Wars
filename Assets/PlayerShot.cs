using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerShot : MonoBehaviour
{
    
    public List<GameObject> gun;
    public int currentGun;
    public PlayerActions playerActions;
    public Transform bulletExit;
    public Shake shake;
    public float shakeDuration;
    public float shakeStrenght;
    public int score;
    public TextMeshProUGUI scoreUI;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {

        playerActions = new PlayerActions();
        playerActions.Actions.Enable();
        playerActions.Actions.Shot.started += Shot;
    }

    public void Shot(InputAction.CallbackContext context)
    {
        
        GameObject bullet = Instantiate(gun[currentGun]);
        bullet.transform.position = bulletExit.position;
        shake.StartShake(shakeDuration, shakeStrenght, false);
    }
    public void IncreaseScore(int amount)
    {

        score += amount + Mathf.FloorToInt(Time.time);
        scoreUI.text = score.ToString();
    }
}
