using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class StartEntertButton : MonoBehaviour, IVirtualButtonEventHandler {

    private GameObject entertBtnObject;
    public GameObject Entertainment;
    public GameObject AnatomyImageTarget;
    public GameObject EntertainmentImageTarget;
    public GameObject CategorySelectionText;
    public GameObject EntPlaneFinder;
    public GameObject AnaPlaneFinder;

    void Start () {
        entertBtnObject = GameObject.Find("StartEntertainmentButton");
        entertBtnObject.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

    }

    public void OnButtonPressed(VirtualButtonBehaviour vb) {  //esta funcao tem que estar aqui anyway, mesmo que nao faca nada.
        Debug.Log("button pressed");
        Debug.Log("estamos no entertainment");

    }

    public void OnButtonReleased(VirtualButtonBehaviour vb) { //same com esta

        EntPlaneFinder.SetActive(true);
        AnaPlaneFinder.SetActive(false);
        CategorySelectionText.SetActive(false);      //retira o texto para escolher categoria
        Entertainment.SetActive(true);               //activa o game object para o board da categoria
        AnatomyImageTarget.GetComponent<ImageTargetBehaviour>().enabled = false;           //faz disable a deteccao de image targets
        AnatomyImageTarget.SetActive(false);                                               //e aos game objects relativos aos image targets
        EntertainmentImageTarget.GetComponent<ImageTargetBehaviour>().enabled = false;     //para nao reconhecer nada durante o jogo
        EntertainmentImageTarget.SetActive(false);                                         //depois reactivaremos mais tarde no fim para recomecar

        EntPlaneFinder.SetActive(true);
        Debug.Log("button released");
        Debug.Log("estamos no entertainment");

        Debug.Log(EntPlaneFinder);
        Debug.Log(Entertainment);

    }


    // Update is called once per frame
    void Update () {
    }


}
