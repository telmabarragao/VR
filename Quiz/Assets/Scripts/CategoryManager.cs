using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryManager : MonoBehaviour {

    string category;

    GameObject objectToShowEntert;

    GameObject objectToShowAnatom;

    GameObject objectToShowGeo;

    GameObject planeFinderEntert;

    GameObject pressedButton;

    GameObject imageTargetEntert;


    string nameClickedButton;

    private void Start()
    {
        objectToShowEntert = FindInActiveObjectByTag("entertainment_ground");
        planeFinderEntert = FindInActiveObjectByTag("planeFinder_entert");
        imageTargetEntert = GameObject.Find("EntertainmentImageTarget");

    }

    public void OnClicked(GameObject button)
    {
        pressedButton = button.gameObject;
        nameClickedButton = pressedButton.name;

        setCategory(nameClickedButton);
    }

    public void setCategory(string which){

        if(which.Equals("StartEntertainment")){
            category = "entertainment";

            if (category.Equals("entertainment"))
            {
                planeFinderEntert.SetActive(true);
                Debug.Log(objectToShowEntert.name);

                objectToShowEntert.SetActive(true);

                Debug.Log(planeFinderEntert.name);

              

                Debug.Log(imageTargetEntert.name);

                if (objectToShowEntert.activeSelf)
                {

                    Debug.Log("TOU ATIVO");
                    imageTargetEntert.SetActive(false);
                }
                else
                {
                    Debug.Log("TOU INATIVO!!!");
                }
            }
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
