using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Vuforia;


public class finishCategoryScript : MonoBehaviour {

    private ScoreName sn;
    public TextMeshProUGUI nametitleObjectFinal;
    public TextMeshProUGUI scoretitleObjectFinal;

    public GameObject EndGameUI;
    public GameObject CategorySelectionText;
    public GameObject AnatomyImageTarget;
    public GameObject EntertainmentImageTarget;

    private void Start() {

        Debug.Log("Start");

        sn = FindObjectOfType<ScoreName>();
        string playerName = sn.GetPlayerName();
        float playerScore = sn.GetPlayerScore();

        nametitleObjectFinal.text = "Player : " + playerName;
        scoretitleObjectFinal.text = "Final Score : " + playerScore;
  
    }

    private void Update()
    {
        sn = FindObjectOfType<ScoreName>();
        float playerScore = sn.GetPlayerScore();
        scoretitleObjectFinal.text = "Final Score : " + playerScore;
    }

    //private void Awake() {
    //    Debug.Log("Awake");

    //    sn = FindObjectOfType<ScoreName>();
    //    string playerName = sn.GetPlayerName();
    //    float playerScore = sn.GetPlayerScore();

    //    nametitleObjectFinal.text = "Player : " + playerName;
    //    scoretitleObjectFinal.text = "Final Score : " + playerScore;

    //}


    public void CloseCategory() {

        Application.Quit();
    }


    public void Restart() {
        sn.setScorePlayer(sn.GetPlayerScore());                                      //reset da pontuacao

        CategorySelectionText.SetActive(true);                                       //liga o texto de selecao de categoria
        AnatomyImageTarget.SetActive(true);                                          //volta a activar os objects de image target
        AnatomyImageTarget.GetComponent<ImageTargetBehaviour>().enabled = true;      //e as respectivas funcionalidades
        EntertainmentImageTarget.SetActive(true);                                    //same para o do entertainment
        EntertainmentImageTarget.GetComponent<ImageTargetBehaviour>().enabled = true;//basicamente é voltar ao inicio sem ter q por o nome outra vez
        EndGameUI.SetActive(false);                                                  //desliga endGameUI

    }


}
