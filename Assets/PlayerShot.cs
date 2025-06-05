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
    public PlayerHealth playerHealth;
    public string playerName;
    public TextMeshProUGUI playerNameUI;
    private int shotType;
    public GameManager gameManager;
    public LeaderBoard leaderBoard;
    public TypeYourName typeYourName;
    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += ChangeShotButton;
        PlayerHealth.OnPlayerDeath += SaveScore;

        GameManager.OnGameStart += UpdateName;
        GameManager.OnGameStart += ChangeShotButton;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= ChangeShotButton;
        PlayerHealth.OnPlayerDeath -= SaveScore;
        GameManager.OnGameStart -= UpdateName;
        GameManager.OnGameStart -= ChangeShotButton;
    }
    // Start is called before the first frame update
    void Start()
    {
        shotType = 2;
        playerActions = new PlayerActions();
        playerActions.Actions.Shot.Enable();
        playerActions.Actions.Shot.started += Shot2;
    }

    public void Shot(InputAction.CallbackContext context)
    {
        
        GameObject bullet = Instantiate(gun[currentGun]);
        bullet.transform.position = bulletExit.position;
        shake.StartShake(shakeDuration, shakeStrenght, false);
    }

    public void Shot2(InputAction.CallbackContext context)
    {
        
        leaderBoard.Hide();
        playerHealth.HideGameOverScreen();
        typeYourName.ShowTypeNameUI();
        typeYourName.ClearPlayerName();
        ResetScore();
    }
    public void IncreaseScore(int amount)
    {

        score += amount + Mathf.FloorToInt(Time.time);
        scoreUI.text = score.ToString();
    }
    public void ResetScore()
    {
        score = 0;
        scoreUI.text = score.ToString();
    }
    public void SaveScore()
    {
        GameObject.Find("GameManager").GetComponent<LeaderBoard>().AddScore(new Score(score, playerName));

    }
    public void DisableShooting()
    {
        playerActions.Actions.Shot.Disable();
    }
    public void EnableShooting()
    {
        playerActions.Actions.Shot.Enable();
    }
    public void ChangeShotButton()
    {
        if(shotType == 1)
        {
            shotType = 2;
            playerActions.Actions.Shot.started -= Shot;
            playerActions.Actions.Shot.started += Shot2;
        } else
        {
            shotType = 1;
            playerActions.Actions.Shot.started -= Shot2;
            playerActions.Actions.Shot.started += Shot;
            
        }
    }
    public void UpdateName()
    {
        this.playerName = GameObject.Find("GameManager").GetComponent<TypeYourName>().GetPlayerName();
        playerNameUI.text = this.playerName;

    }
    
}
