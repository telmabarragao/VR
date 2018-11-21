using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class CheckAnswers : MonoBehaviour {

    AudioManager am;
    
    GameObject pressedButton;
    
    string nameClickedButton;

    string audioNameNow;

    ScoreName scoreName;

    // Use this for initialization
    void Start () {

        am = FindObjectOfType<AudioManager>();
        scoreName = FindObjectOfType<ScoreName>();

    }
	
	// Update is called once per frame
	void Update () {

        if (am.isPlaying())
        {
            //something is playing
            audioNameNow = FindObjectOfType<AudioManager>().GetNameMusicPlaying();

        }else{

            //something is playing
            audioNameNow = FindObjectOfType<AudioManager>().GetNameMusicPlaying();

            //there is no audio playing

            //audioSource.clip = otherClip;
            //audioSource.Play();

        }
    }

    public void OnClicked()
    {
        Debug.Log("entrei no onclick");
        pressedButton = gameObject;
        nameClickedButton = pressedButton.name;

        Debug.Log(nameClickedButton);


        checkIfMatch(nameClickedButton);
    }


    public void checkIfMatch(string btn)
    {
        string toCompareBtn = btn.Split('_')[1];

        if(string.Compare(toCompareBtn, audioNameNow)==0){
            Debug.Log("resposta certa");
            scoreName.setScorePlayer(10);


            am.PlaySound("right");

            //Changes the button's Normal color to the new color.
            ColorBlock cb = gameObject.GetComponent<UnityEngine.UI.Button>().colors;
            cb.normalColor = Color.green;
            cb.pressedColor = Color.green;
            cb.disabledColor = Color.green;
            cb.highlightedColor = Color.green;

            GetComponent<UnityEngine.UI.Button>().colors = cb;
            gameObject.GetComponent<Image>().color = Color.green;

            Invoke("GoToNext", 2);



        }
        else
        {
            Debug.Log("resposta erradah");
        

            scoreName.setScorePlayer(-10);

            am.PlaySound("wrong");

            //Changes the button's Normal color to the new color.
            ColorBlock cb = gameObject.GetComponent<UnityEngine.UI.Button>().colors;
            cb.normalColor = Color.red;
            cb.pressedColor = Color.red;
            cb.disabledColor = Color.red;
            cb.highlightedColor = Color.red;

            GetComponent<UnityEngine.UI.Button>().colors = cb;
            gameObject.GetComponent<Image>().color = Color.red;

            Invoke("GoToNext", 2);

        }

    }


    public void GoToNext(){
        //which question is active
        GameObject parent = transform.parent.gameObject;
        string ActiveTag = parent.tag;
        string[] taggg = ActiveTag.Split('_');
        int questNumber = int.Parse(ActiveTag.Split('_')[2]);


        if(questNumber == 9){

            Debug.Log("e a ultima");
            GameObject goOutQ = GameObject.FindWithTag("Q_" + ActiveTag[2] + "_" + questNumber);
            goOutQ.SetActive(false);
            parent.SetActive(false);

            am.Stop(audioNameNow);

            GameObject board = GameObject.Find("Board");
            Debug.Log(board);
            board.SetActive(false);


            GameObject endScreen = FindInActiveObjectByTag("End_cat_entertai");
            Debug.Log(endScreen);

            endScreen.SetActive(true);



        }
        else
        {
            int nextQuestion = questNumber + 1;


            GameObject goA = FindInActiveObjectByTag(ActiveTag[0] + "_" + ActiveTag[2] + "_" + nextQuestion);
            goA.SetActive(true);

            GameObject goQ = FindInActiveObjectByTag("Q_" + ActiveTag[2] + "_" + nextQuestion);
            goQ.SetActive(true);

            GameObject goOutQ = GameObject.FindWithTag("Q_" + ActiveTag[2] + "_" + questNumber);
            goOutQ.SetActive(false);
            parent.SetActive(false);


            int nextSong = am.GetIndMusicPlaying() + 1;
            am.Stop(audioNameNow);
            am.PlayInd(nextSong);

        }


    }


    GameObject FindInActiveObjectByTag(string tagg)
    {

        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].CompareTag(tagg))
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
}
