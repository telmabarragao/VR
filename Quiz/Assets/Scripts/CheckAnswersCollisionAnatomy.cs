using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class CheckAnswersCollisionAnatomy : MonoBehaviour {

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
	

    void Update()
    {
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
        GameObject now = transform.gameObject;
        GameObject parent = transform.parent.parent.parent.gameObject;
        string ActiveTag = parent.tag;
        string[] taggg = ActiveTag.Split('_');
        int questNumber = int.Parse(ActiveTag.Split('_')[2]);

        string rightName;

        switch (questNumber)
        {

            case 1:
                rightName = "peito";
                break;
            case 2:
                rightName = "foot";
                break;
            case 3:
                rightName = "eye";
                break;
            case 4:
                rightName = "pescoco";
                break;
            case 5:
                rightName = "braco";
                break;
            default:
                rightName = "";
                break;
        }

        if(string.Compare(rightName, btn)==0){
            Debug.Log("resposta certa");
            //scoreName.setScorePlayer(10);


            am.PlaySound("right");

            Color newRColor = new Color(0, 1, 0);
            //Changes the button's Normal color to the new color.
            pressedButton.GetComponent<Renderer>().material.SetColor("righColor", newRColor);
      
            Invoke("GoToNext", 2);

        }else
        {
            Debug.Log("resposta erradah");
        

            scoreName.setScorePlayer(-5);

            am.PlaySound("wrong");

            Color newWColor = new Color(1, 0, 0);
            //Changes the button's Normal color to the new color.
            pressedButton.GetComponent<Renderer>().material.SetColor("wrongColor", newWColor);

            Invoke("GoToNext", 2);

        }

    }


    public void GoToNext(){

        //which question is active
        GameObject parent = transform.parent.parent.parent.gameObject;
        string ActiveTag = parent.tag;
        string[] taggg = ActiveTag.Split('_');
        int questNumber = int.Parse(ActiveTag.Split('_')[2]);


        if(questNumber == 5){

            Debug.Log("e a ultima");
            GameObject goOutQ = GameObject.FindWithTag("Q_" + ActiveTag[2] + "_" + questNumber);
            goOutQ.SetActive(false);
            parent.SetActive(false);
            
            GameObject board = GameObject.Find("BoardAna");
            Debug.Log(board);
            board.SetActive(false);


            GameObject endScreen = FindInActiveObjectByTag("End_cat_anatomy");
            Debug.Log(endScreen);

            endScreen.SetActive(true);



        }
        else
        {

            int nextQuestion = questNumber + 1;
            Debug.Log(nextQuestion);

            GameObject goA = FindInActiveObjectByTag(ActiveTag[0] + "_" + ActiveTag[2] + "_" + nextQuestion);
            Debug.Log(goA);
            goA.SetActive(true);

            GameObject goQ = FindInActiveObjectByTag("Q_" + ActiveTag[2] + "_" + nextQuestion);
            Debug.Log(goQ);
            goQ.SetActive(true);

            GameObject goOutQ = GameObject.FindWithTag("Q_" + ActiveTag[2] + "_" + questNumber);
            goOutQ.SetActive(false);
            parent.SetActive(false);


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
