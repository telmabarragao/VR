using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreName : MonoBehaviour
{

    string playerName;
    float playerScore=0;
    public TextMeshProUGUI nametitleObject;
    public TextMeshProUGUI scoretitleObject;



    // Use this for initialization
    void Start()
    {
        playerName = PlayerPrefs.GetString("name");
        DisplayName();
        playerScore = 0.0f;
        DisplayScore();
    }

    // Use this for initialization
    void Awake()
    {
        playerName = PlayerPrefs.GetString("name");

        //TextMeshProUGUI[] textMeshes = FindObjectsOfType<TextMeshProUGUI>();
        //foreach (TextMeshProUGUI t in textMeshes)
        //{}

        playerName = PlayerPrefs.GetString("name");
        //TextMesh t = (TextMesh)gameObject.GetComponent("NameTitle");
        //Debug.Log(t.text);
        DisplayName();


        playerScore = 0.0f;
        DisplayScore();
    }

    public string GetPlayerName()
    {
        return playerName;
    }


    public void setNamePlayer(string name)
    {
        playerName = name;
        //Debug.Log(PlayerPrefs.GetString("name"));
        DisplayName();
    }

    public void DisplayName()
    {
        nametitleObject.text = "Player : "+GetPlayerName();
    }


    public float GetPlayerScore()
    {
        return playerScore;
    }


    public void setScorePlayer(float score)
    {
        playerScore += score;
        //Debug.Log(PlayerPrefs.GetString("name"));
        DisplayScore();
    }

    public void DisplayScore()
    {
        scoretitleObject.text = "Score : " + GetPlayerScore();
    }
}