using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class TypeYourName : MonoBehaviour
{
    public TextMeshProUGUI gameTitle;
    public TextMeshProUGUI typeYourName;
    public TextMeshProUGUI nameUI;
    public int maxLength = 8;

    private string playerName = "";

    public static event System.Action OnNameConfirmed;
    public GameManager gameManager;
    public bool activated;
    // Start is called before the first frame update
    void Start()
    {
        activated = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            foreach (var c in Keyboard.current.allKeys)
            {
                if (c.wasPressedThisFrame)
                {
                    if (c.keyCode >= Key.A && c.keyCode <= Key.Z)
                    {
                        AddChar(c.keyCode.ToString());
                    } else if (c.keyCode >= Key.Digit0 && c.keyCode <= Key.Digit9)
                    {
                        AddChar(((char)('0' + (c.keyCode - Key.Digit0))).ToString());
                    } else if (c.keyCode == Key.Space)
                    {
                        AddChar(" ");
                    } else if (c.keyCode == Key.Backspace)
                    {
                        RemoveChar();
                    } else if (c.keyCode == Key.Enter)
                    {
                        ConfirmName();
                    }
                }
            }

            nameUI.text = playerName;
        }
        
    }
    public void ShowTypeNameUI()
    {
        typeYourName.enabled = true;
        nameUI.enabled = true;
        gameTitle.enabled = true;
        activated = true;
    }
    public void ConfirmName()
    {
        typeYourName.enabled = false;
        nameUI.enabled = false;
        gameTitle.enabled = false;
        activated = false;
        OnNameConfirmed?.Invoke();
        gameManager.StartGame();
    }
    void AddChar(string c)
    {
        if (playerName.Length < maxLength)
        {
            playerName += c.ToLower(); // Deixa em minúsculo, igual sua UI linda!
        }
    }

    void RemoveChar()
    {
        if (playerName.Length > 0)
        {
            playerName = playerName.Substring(0, playerName.Length - 1);
        }
    }
    public string GetPlayerName()
    {
        return this.playerName;
    }
    public void ClearPlayerName()
    {
        playerName = "";
        nameUI.text = "";
    }
}
