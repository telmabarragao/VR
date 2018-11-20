using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameScoreScript : MonoBehaviour
{

    string playerName;
    float score;


    // Use this for initialization
    void Start()
    {
        Debug.Log(PlayerPrefs.GetString("name"));

        playerName = PlayerPrefs.GetString("name");


    }



    // Use this for initialization
    void Awake()
    {

        Debug.Log(playerName);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerName);


    }


    void setNamePlayer(string name)
    {

        playerName = name;
        Debug.Log(playerName);
    }
}