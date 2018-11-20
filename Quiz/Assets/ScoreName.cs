using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreName : MonoBehaviour
{

    string playerName;
    float score;


    // Use this for initialization
    void Start()
    {

        playerName = PlayerPrefs.GetString("name");


    }

    // Use this for initialization
    void Awake()
    {

        playerName = PlayerPrefs.GetString("name");


    }

    public string GetPlayerName()
    {
        return playerName;
    }


    public void setNamePlayer(string name)
    {

        playerName = name;
        Debug.Log(playerName);
        Debug.Log(PlayerPrefs.GetString("name"));
    }

    public void DisplayName()
    {

        GameObject where = GameObject.Find("NameTitle").text;
        where = "Player " + GetPlayerName();
    }
}