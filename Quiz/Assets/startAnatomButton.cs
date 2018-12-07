using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class startAnatomButton : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject anatomyBtnObject;
    public GameObject Anatomy;
    //public GameObject EntertainmentImageTarget;

	void Start () {
        anatomyBtnObject = GameObject.Find("StartQuizButton");
        anatomyBtnObject.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
		
	}
	
    public void OnButtonPressed(VirtualButtonBehaviour vb) {
        Debug.Log("button pressed");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb) {
        Anatomy.SetActive(true);
        //EntertainmentImageTarget.SetActive(false);
        //enquanto esta estiver activa, fazer disable ao image target
        Debug.Log("button released");
    }

    // Update is called once per frame
    void Update () {
		
	}


}
