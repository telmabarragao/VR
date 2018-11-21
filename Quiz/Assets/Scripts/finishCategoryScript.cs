using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class finishCategoryScript : MonoBehaviour {

    ScoreName sn;
    public TextMeshProUGUI nametitleObjectFinal;
    public TextMeshProUGUI scoretitleObjectFinal;

    private void Start()
    {
        sn = FindObjectOfType<ScoreName>();

        string playerName = sn.GetPlayerName();
        float playerScore = sn.GetPlayerScore();

        nametitleObjectFinal.text = "Player : " + playerName;
        scoretitleObjectFinal.text = "Final Score : " + playerScore;



    }

    private void Awake()
    {
        sn = FindObjectOfType<ScoreName>();

        string playerName = sn.GetPlayerName();
        float playerScore = sn.GetPlayerScore();

        nametitleObjectFinal.text = "Player : " + playerName;
        scoretitleObjectFinal.text = "Final Score : " + playerScore;


    }


    public void CloseCategory()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

   
}
