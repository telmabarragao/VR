using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class button : MonoBehaviour, IVirtualButtonEventHandler {


    private GameObject vButton;
	// Use this for initialization
	void Start () {

        vButton = GameObject.Find("EntButton");
        vButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        Debug.Log("OLA");

	}

    public void OnButtonPressed (VirtualButtonBehaviour vb){

        Debug.Log("pressed");

    }

    public void OnButtonReleased(VirtualButtonBehaviour vb){

    }

}
