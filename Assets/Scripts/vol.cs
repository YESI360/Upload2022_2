﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vol : MonoBehaviour
{
    public Instrucciones instrucciones;
    public AudioSource Voces;
    public float SpeedUp;
    public float SpeedDown;
    //public float maxVolume = 0.5f;
    bool maximo;


    void Start()
    {
        //GetComponent<AudioSource>().volume = 0;
    }
    void Update()
    {

        Voces.volume += Time.deltaTime * SpeedUp;

        if (instrucciones.currentVolumen == -10)//(Voces.volume >= maxVolume)
        {
        maximo = true;
        }

       if (maximo == true)
       Voces.volume -= Time.deltaTime * SpeedDown;

    }



}
