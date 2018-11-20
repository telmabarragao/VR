using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NameMenu : MonoBehaviour
{

    public InputField inputName;
    string playerName;
    ScoreName sn;
   
    public void PlayGame()
    {

        sn = FindObjectOfType<ScoreName>();

        playerName = inputName.text;
        PlayerPrefs.SetString("name", inputName.text);
        sn.setNamePlayer(playerName);
    }


    public void Back()
    {
        SceneManager.LoadScene("Menu");

    }
}