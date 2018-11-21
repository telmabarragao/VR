using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animController : MonoBehaviour {


    public Animator anim;
    AudioManager am;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        am = FindObjectOfType<AudioManager>();


    }

    // Update is called once per frame
    void Update () {
        if(am.isPlaying()){
            anim.Play("idle");
            anim.speed = 0.7f;
        }
	}
}
