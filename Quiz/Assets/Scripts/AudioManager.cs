using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {


    public Music[] musics;

    public static AudioManager instance;


    void Awake()
    {

        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }


        DontDestroyOnLoad(gameObject);

        foreach(Music m in musics){

            m.source =  gameObject.AddComponent<AudioSource>();
            m.source.clip = m.clip;

            m.source.volume = m.volume;
            m.source.pitch = m.pitch;
        }
    }


    //Used to play single sound clips.
    public void Play(string namee)
    {
        foreach(Music s in musics){
            if(String.Equals(s.name, namee)){
                s.source.Play();
            }
        }
        //Sound musicc = Array.Find(musics, m => m.name == namee);
        //Debug.Log(musicc.source);
        //musicc.source.Play();
    }


    public void PlayInd(int index)
    {
        for (int i = 0; i < musics.Length; i++){
            if (i==index)
            {
                musics[i].source.Play();
            }
        }
   
    }


    //Used to play single sound clips.
    public void Stop(string namee)
    {
        foreach (Music s in musics)
        {
            if (String.Equals(s.name, namee))
            {
                s.source.Stop();
            }
        }
        //Sound musicc = Array.Find(musics, m => m.name == namee);
        //Debug.Log(musicc.source);
        //musicc.source.Play();
    }

    //Used to play single sound clips.
    public bool isPlaying()
    {
        foreach (Music m in musics)
        {
            if(m.source.isPlaying){

                return true;
            }
        }
        return false;
    }

    public string GetNameMusicPlaying(){

        foreach (Music m in musics)
        {
            if (m.source.isPlaying)
            {
                return m.name;
            }
        }
        return "";

    }


    public int GetIndMusicPlaying()
    {
        for (int i = 0; i < musics.Length; i++){
        
            if (musics[i].source.isPlaying)
            {
                return i;
            }
        }
        return -1;

    }


}


