﻿using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Music
{

    public string name;

    public AudioClip clip;

    [Range(0.0f, 1.0f)]
    public float volume;
    [Range(0.1f, 3.0f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
}
