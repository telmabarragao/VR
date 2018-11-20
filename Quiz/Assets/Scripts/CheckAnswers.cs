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

    // Use this for initialization
    void Start () {

        am = FindObjectOfType<AudioManager>();

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

            //Changes the button's Normal color to the new color.
            ColorBlock cb = GetComponent<UnityEngine.UI.Button>().colors;
            cb.normalColor = Color.green;
            GetComponent<UnityEngine.UI.Button>().colors = cb;

            //which question is active
            GameObject parent = transform.parent.gameObject;
            string ActiveTag = parent.tag;
            string[] taggg = ActiveTag.Split('_');
            int questNumber = int.Parse(ActiveTag.Split('_')[2]);

            int nextQuestion = questNumber + 1;


            GameObject goA = FindInActiveObjectByTag(ActiveTag[0] + "_"+ ActiveTag[2] +"_"+nextQuestion);
            Debug.Log(goA);
            goA.SetActive(true);
            GameObject goQ = FindInActiveObjectByTag("Q_" + ActiveTag[2] + "_" + nextQuestion);
            Debug.Log(goQ);

            goQ.SetActive(true);

            //GameObject goOutQ = GameObject.FindWithTag("Q_" + ActiveTag[2] + "_" + questNumber);
            //goOutQ.SetActive(false);
            parent.SetActive(false);

            int nextSong = am.GetIndMusicPlaying()+1;
            am.Stop(audioNameNow);
            Debug.Log(nextSong);
            am.PlayInd(nextSong);

        }
        else
        {
            Debug.Log("resposta erradah");
            //mudar cor
            //por disable


            //Changes the button's Normal color to the new color.
            ColorBlock cb = GetComponent<UnityEngine.UI.Button>().colors;
            cb.normalColor = Color.red;
            GetComponent<UnityEngine.UI.Button>().colors = cb;

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
