using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class CheckAnswersCollision : MonoBehaviour {

    AudioManager am;
    
    GameObject pressedButton;
    
    string nameClickedButton;

    string audioNameNow;

    ScoreName scoreName;

    public Material wrongMate;

    public Material rightMate;

    // Use this for initialization
    void Start () {

        am = FindObjectOfType<AudioManager>();
        scoreName = FindObjectOfType<ScoreName>();

    }
	

    void Update()
    {
            if (am.isPlaying())
            {
                //something is playing
                audioNameNow = FindObjectOfType<AudioManager>().GetNameMusicPlaying();

            }
            else
            {

                //something is playing
                audioNameNow = FindObjectOfType<AudioManager>().GetNameMusicPlaying();

                //there is no audio playing

                //audioSource.clip = otherClip;
                //audioSource.Play();

            }


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            ShootRay(ray);
        }
    }

    void ShootRay(Ray ray)
    {

        RaycastHit rhit;

        bool objectHit = false;
        GameObject gObjectHit = null;


        if (Physics.Raycast(ray, out rhit, 1000.0f))
        {
            Debug.Log("Ray Shot and hit!");
            objectHit = true;
            gObjectHit = rhit.collider.gameObject;
            OnCollision(gObjectHit);
        }

    }

    public void OnCollision(GameObject col)
    {
       
        pressedButton = col.gameObject;
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
            pressedButton.GetComponent<Renderer>().material = rightMate;
      
            Invoke("GoToNext", 2);



        }
        else
        {
            Debug.Log("resposta erradah");
        

            scoreName.setScorePlayer(-5);

            am.PlaySound("wrong");

            //Changes the button's Normal color to the new color.
            pressedButton.GetComponent<Renderer>().material = rightMate;

            Invoke("GoToNext", 2);

        }

    }


    public void GoToNext(){
        //which question is active
        GameObject parent = transform.parent.gameObject;
        string ActiveTag = parent.tag;
        string[] taggg = ActiveTag.Split('_');
        int questNumber = int.Parse(ActiveTag.Split('_')[2]);


        if(questNumber == 10){

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
