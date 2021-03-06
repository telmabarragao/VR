﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class StartAnatomButton : MonoBehaviour, IVirtualButtonEventHandler {

    private GameObject anatomyBtnObject;
    public GameObject Anatomy;
    public GameObject EntertainmentImageTarget;
    public GameObject AnatomyImageTarget;
    public GameObject EntPlaneFinder;
    public GameObject AnaPlaneFinder;
    public GameObject CategorySelectionText;


    void Start () {
        anatomyBtnObject = GameObject.Find("StartAnatomyButton");
        anatomyBtnObject.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

	}
	
    public void OnButtonPressed(VirtualButtonBehaviour vb) {  //esta funcao tem que estar aqui anyway, mesmo que nao faca nada.
        Debug.Log("button pressed");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb) {  //same com esta
        EntPlaneFinder.SetActive(false);
        AnaPlaneFinder.SetActive(true);
        CategorySelectionText.SetActive(false);         //retira o texto para escolher categoria
        Anatomy.SetActive(true);                        //activa o game object para o board da categoria

        AnatomyImageTarget.GetComponent<ImageTargetBehaviour>().enabled = false;           //faz disable a deteccao de image targets
        AnatomyImageTarget.SetActive(false);                                               //e aos game objects relativos aos image targets
        EntertainmentImageTarget.GetComponent<ImageTargetBehaviour>().enabled = false;     //para nao reconhecer nada durante o jogo
        EntertainmentImageTarget.SetActive(false);                                         //depois reactivaremos mais tarde no fim para recomecar

        Debug.Log("button released");

    }

    // Update is called once per frame
    void Update () {
		
	}


}
