using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum Stage
    {
        title,
        game,
        gameOver
    }
    public Stage currentStage;
    public static event System.Action OnGameStart;
    // Start is called before the first frame update
    void Start()
    {
        //StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        OnGameStart?.Invoke();
    }
}
