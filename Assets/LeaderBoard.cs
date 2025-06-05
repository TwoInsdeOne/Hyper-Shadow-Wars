using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class Score
{
    public int score;
    public string name;

    public Score(int score, string name)
    {
        this.score = score;
        this.name = name;
    }
    public string Show()
    {
        return this.name + " - " + this.score.ToString();
    }
}

[System.Serializable]
public class LeaderboardData
{
    public List<Score> scores = new List<Score>();
}

public class LeaderBoard : MonoBehaviour
{
    public List<Score> scores = new List<Score>();
    public TextMeshProUGUI highscores;
    public TextMeshProUGUI scoresNames;
    public TextMeshProUGUI boardTitle;
    public int scoreBoardQtd;

    public LeaderboardData leaderboard = new LeaderboardData();
    private const string LEADERBOARD_KEY = "leaderboard";

    public bool clearLeaderBoardData;
    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += UpdateLeaderBoardUI;
        GameManager.OnGameStart += Hide;
    }
    private void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= UpdateLeaderBoardUI;
        GameManager.OnGameStart -= Hide;
    }
    private void Start()
    {
        if (clearLeaderBoardData)
        {
            ClearLeaderBoardData();
        }
    }
    public void AddScore(Score score)
    {
        scores.Add(score);
        UpdateLeaderBoardData();
        SaveLeaderboard();
    }

    public void UpdateLeaderBoardUI()
    {
        highscores.text = "";
        scoresNames.text = "";
        Show();
        Sort();
        for(int i = 0; i < scoreBoardQtd; i++)
        {
            highscores.text = highscores.text + scores[i].score + "\n";
            scoresNames.text = scoresNames.text + scores[i].name + "\n";
        }
    }
    public void Sort()
    {
        for (int i = 1; i < scores.Count; i++)
        {
            Score key = scores[i];
            int j = i - 1;

            while (j >= 0 && key.score > scores[j].score)  // MAIOR SCORE PRIMEIRO
            {
                scores[j + 1] = scores[j];
                j--;
            }
            scores[j + 1] = key;
        }
    }
    public void Show()
    {
        scoresNames.enabled = true;
        highscores.enabled = true;
        boardTitle.enabled = true;
    }
    public void Hide()
    {
        scoresNames.enabled = false;
        highscores.enabled = false;
        boardTitle.enabled = false;
    }
    public void UpdateLeaderBoardData()
    {
        leaderboard.scores = this.scores;
    }
    public void SaveLeaderboard()
    {
        string json = JsonUtility.ToJson(leaderboard);
        PlayerPrefs.SetString(LEADERBOARD_KEY, json);
        PlayerPrefs.Save();
        Debug.Log("Leaderboard salva: " + json);
    }

    public void LoadLeaderboard()
    {
        if (PlayerPrefs.HasKey(LEADERBOARD_KEY))
        {
            string json = PlayerPrefs.GetString(LEADERBOARD_KEY);
            leaderboard = JsonUtility.FromJson<LeaderboardData>(json);
            Debug.Log("Leaderboard carregada: " + json);
        } else
        {
            Debug.Log("Nenhuma leaderboard salva ainda.");
            leaderboard = new LeaderboardData(); // evita null
        }
    }

    public void ClearLeaderBoardData()
    {
        leaderboard = new LeaderboardData();
        leaderboard.scores.Add(new Score(100, "Robin"));
        leaderboard.scores.Add(new Score(80, "Kuchi"));
        leaderboard.scores.Add(new Score(60, "Claude"));
        leaderboard.scores.Add(new Score(40, "Oliver"));
        leaderboard.scores.Add(new Score(20, "Riblin"));
        SaveLeaderboard();
    }
}
