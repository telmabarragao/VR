using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class startAnatomButton : MonoBehaviour, IVirtualButtonEventHandler {


    public GameObject anatomyBtnObject;
    //public Animator btnAnim;

	void Start () {
        anatomyBtnObject = GameObject.Find("StartQuizButton");
        anatomyBtnObject.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        //btnAnim.GetComponent<Animator>();
		
	}
	
    public void OnButtonPressed(VirtualButtonBehaviour vb) {
        //setCategory(nameClickedButton);
        Debug.Log("button pressed");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb) {
        Debug.Log("button released");
    }

    // Update is called once per frame
    void Update () {
		
	}


}
